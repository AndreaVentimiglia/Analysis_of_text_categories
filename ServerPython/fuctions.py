import requests
from wordcloud import WordCloud, STOPWORDS,  ImageColorGenerator
import json
import numpy as np
from matplotlib import pyplot as plt
from PIL import Image
import os
import base64
from io import BytesIO
import sys

# ALtri file
from config import Config
import constants as constant

cfg = Config()

#**********************Functions**********************
# ---- Stop words function 
def stopWordsFunction():
	"""Returns a set of uninteresting words to be removed from the textual analysis."""
	stopwords = set(STOPWORDS)
	
	return stopwords.union(constant.uniinteresting_words)

# ---- Punctuations function
def punctuationsFunction():
	""" Returns a punctuation string to remove from text analysis. """
	punctuations = constant.punctuations
	return punctuations

# ---- Frequency words
def frequencyWords(wordlist, punctuations, uninteresting_words):
	""" Parses a list of words and returns a dictionary with the frequency of each word.
		Parameters:
		- wordlist: list of words to analyze
		- punctuations: punctuation string to remove
		- uninteresting_words: uninteresting words to remove
		
		Come back:
		- word_dictionary: dictionary {word: frequency}"""
	
	# Algorithm for counting word frequency
	word_dictionary = {}
	for word in wordlist:
		new_string=""
		for character in word:
			#if character is not in punctuations and a numbers:
			if character.isalpha() and character not in punctuations:
				new_string = new_string+character.lower() 
		if new_string not in uninteresting_words and len(new_string)>0:
			if new_string in word_dictionary:
				word_dictionary[new_string] += 1
			else:
				word_dictionary[new_string] = 1
	return word_dictionary


# ---- Word cloud img
def wordCloudImg(wordDictionary, wcMaskType):
	""" Generates and returns a Word Cloud image from a word/frequency dictionary.
		Parameters:
		- wordDictionary: dictionary {word: frequency}
		- wcMaskType: type of mask to use
		
		Come back:
		- plt: Matplotlib object containing the Word Cloud image"""
	
	# Create the worldcloud
	if(wcMaskType =="default"):
		wc = WordCloud(background_color="black", contour_width=3, contour_color='white')
	else:
		maskPath = "mask/" + wcMaskType + "_mask.png"
		print(maskPath)	
		# Let's create the mask
		mask = np.array(Image.open(maskPath))
		wc = WordCloud(background_color="black", mask=mask, contour_width=3, contour_color='white')

	wc.generate_from_frequencies(wordDictionary)

	# Create the image
	plt.figure(frameon=False) 				 # Create the figure for the image
	plt.imshow(wc, interpolation="bilinear") # Show the wc image
	plt.axis("off") 		
	
	return plt

def typeGraph(typeGraph2, color, title, labels ,values):
	"""Create a bar or pie chart given labels and values.
		Parameters:
		- typeGraph2: graph type, "Histogram" or "pie"
		- color: color of the histogram bars
		- title: title of the graph
		- labels: labels for x-axes or slices
		- values: percentage values
		
		Come back:
		- plt: matplotlib object containing the plot"""
	_, ax = plt.subplots()

	match typeGraph2:
		case "Histogram":
			ax.bar(labels, values, color = color, ec="black")
			ax.set_ylabel("Rate %")
			ax.set_title(title)
			
			plt.xticks(rotation=30, ha='right')
			plt.tight_layout()

		case "pie":
			#ax.pie(values, labels=labels)
			ax.pie(values, labels=labels, autopct='%1.1f%%')
			ax.set_title(title)
	return plt

# ---- Frequency graphs img
def frequencyGraphsImg(wordDictionary, typeGraph1, typeGraph2, color):
	""" Generate a bar or pie chart from a dictionary of words/frequencies.
		Parameters:
		- wordDictionary: dictionary {word: frequency}
		- typeGraph1: first graph type (words or category rate)
		- typeGraph2: second graph type (histogram or pie)
		- color: color of histogram bars
		
		Come back:
		plt: Matplotlib object of the created plot"""
	
	match typeGraph1:
		case "FrequencyWords":
			# Sort word dictionaries and retrieve top 10 words
			top_10 = sortAndFilterWords(wordDictionary)
			
			labels = list(top_10.keys())
			values = list(top_10.values())
			title = "Frequency words"

		case "RateCategory":
			# Send via HTTP to Go server
			# #print(urlReceiveText)
			headers = {'Content-Type': 'application/json'}
			response = requests.post(cfg.get_url_rate_list(), json=wordDictionary, headers=headers)
			
			rateCategories = json.loads(response.text) # Deserialize the JSON into a Python dictionary

			labels = list(rateCategories.keys())
			values = list(rateCategories.values())
			title = "category texts"
	
	# Generate the graph
	plt = typeGraph(typeGraph2, color, title, labels ,values)
	
	return plt

# ---- Dictionary update
def dictionaryUpdate(datas):
	""" Update a word/frequency dictionary by merging data from multiple dictionaries.
		Parameters:
		- datas: list of dictionaries {word:frequency}
		
		Come back:
		- wordDictionary: aggregate dictionary """
	tmp ={}
	wordDictionary ={}
	for data in datas:
		tmp = json.loads(data)
		for word, count in tmp.items():
			if word in wordDictionary:
				wordDictionary[word] += count
			else:
				wordDictionary[word] = count
	return wordDictionary

# ---- Sort and filter words
def sortAndFilterWords(dictionary):
	""" Filter a word/frequency dictionary, sorting it by frequency and taking the top 10 words.
		Parameters:
		- dictionary: dictionary {word: frequency}
		
		Come back:
		- dict: filtered dictionary
   """
	sorted_words = sorted(dictionary.items(), key=lambda x: x[1], reverse=True)
	return dict(sorted_words[:10])

# ---- Uniform dictionary keys
def uniformDictionaryKeys(dict1, dict2):
	""" Makes the keys of two dictionaries uniform by adding missing keys with a value of 0.
		Useful for comparing dictionaries with different key sets.
		Parameters:
		- dict1: first dictionary
		- dict2: second dictionary
		
		Come back:
		- dict1, dict2: dictionaries with same keys"""
	# Used to have dictionaries with the same label number.
	# For example if dictionary 2 does not have "horror" but the first one does then it will put "horror" but with value 0
	keys = set(dict1.keys()) | set(dict2.keys())
	dict1 = dict((k, dict1.get(k, 0)) for k in keys)
	dict2 = dict((k, dict2.get(k, 0)) for k in keys)

	return dict1, dict2

# ---- Prepare data
def prepareData(dictionary1, dictionary2, char_type):
	""" Prepare data to create comparison graphs between two dictionaries.
		Parameters:
		- dictionary1: first data dictionary
		- dictionary2: second data dictionary
		- char_type: chart type, "word" or "rate"

		Returns:
		- labels: labels x
		- values1: y values for dictionary1
		- values2: y values for dictionary2"""
	if char_type =="word":
		# Sort word dictionaries and retrieve top 10 words
		dictionary1 = sortAndFilterWords(dictionary1)
		dictionary2 = sortAndFilterWords(dictionary2)

	elif  char_type =="rate %":
		# Uniform dictionary keys
		dictionary1, dictionary2 = uniformDictionaryKeys(dictionary1, dictionary2)

	# Extract labels and values
	labels = list(dictionary1.keys())
	values1 = list(dictionary1.values())
	values2 = list(dictionary2.values())
	return labels, values1, values2

# ---- Plot double rate chart
def plotDoubleRateChart(labels, values1, values2, title1, title2):
	""" Create a bar chart to compare two sets of categorical percentage values.
		Parameters:
		- labels: category names
		- values1: category 1 percentages
		- values2: category 2 percentages
		- title1: series 1 title
		- title2: series 2 title
		
		Come back:
		- plt: Matplotlib graphics object"""
	# Label positions
	x = np.arange(len(labels)) 
			
	_, ax = plt.subplots()

	# We put the first parameter to center the label between the two coffins
	ax.bar(x-0.2, values1, width=0.4, color='blue', label = title1, ec="black")
	ax.bar(x+0.2, values2, width=0.4, color='darkorange', label = title2, ec="black")

	# per centrare la lables
	ax.set_xticks(x)
	ax.set_xticklabels(labels)
	plt.xticks(fontsize=8) 

	plt.legend()
	plt.xlabel("Category")
	plt.ylabel("Rate (%)")
	plt.title("Category rate")
	return plt

# ---- Plot double word chart
def plotDoubleWordChart(labels, values1, values2, title1, title2):
	""" Create a bar graph to compare the frequency of words in two sets of text.
		Parameters:
		- labels: words
		- values1: text frequencies 1
		- values2: text 2 frequencies
		- title1: text title 1
		- title2: text title 2
		
		Come back:
		- plt: Matplotlib graphics object
		"""
	# Label positions
	x = np.arange(len(labels)) 
	_, ax = plt.subplots()

	# We put the first parameter to center the label between the two coffins
	ax.bar(x-0.2, values1, width=0.4, color='blue', label = title1, ec="black")
	ax.bar(x+0.2, values2, width=0.4, color='darkorange', label = title2, ec="black")

	# To center the labels
	ax.set_xticks(x)
	ax.set_xticklabels(labels)
	plt.xticks(fontsize=8) 

	plt.legend(loc='best')
	plt.xlabel("Word")
	plt.ylabel("Word frequenct")
	plt.title("Common words")
	
	
	return plt

# ---- Buffer image
def bufferImage(plt):
	""" Converts a Matplotlib plot to a Base64 encoded PNG image.
		Parameters:
		- plt: Matplotlib graphics object
		
		Come back:
		- img_bytes: Base64 encoded PNG image"""
	# Save the graph in in-memory PNG format
	buffer = BytesIO()
	plt.savefig(buffer, format='png')

	# Encode the png image to base64
	img_bytes = base64.b64encode(buffer.getvalue()).decode('utf-8')
	return img_bytes

# ---- Comparison graphs img
def comparisonGraphsImg(dictionary1, dictionary2, title1, title2, char_type):
	""" Generate a comparison graph between two dictionaries of words/frequencies or percentages.
		Parameters:
		- dictionary1: first dictionary
		- dictionary2: second dictionary
		- title1: dictionary title 1
		- title2: dictionary title 2
		- char_type: 'word' or 'rate'
		
		Come back:
		- img_bytes: graphic image in Base64"""
	# Check that char_type is valid
	if char_type not in["word", "rate"]:
		raise ValueError("invalid char_type")
	
	# Prepare the data
	labels, values1, values2 = prepareData(dictionary1, dictionary2, char_type)
	match char_type:
		case "rate": 	
			plt = plotDoubleRateChart(labels, values1, values2, title1, title2)
			
		case "word":
			plt = plotDoubleWordChart(labels, values1, values2, title1, title2)

	return plt 