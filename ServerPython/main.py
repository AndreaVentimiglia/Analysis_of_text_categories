from flask import Flask, jsonify, request, Response
import requests
from wordcloud import WordCloud, STOPWORDS
import json
import numpy as np
from matplotlib import pyplot as plt
from PIL import Image
import os
import base64
from io import BytesIO


# ALtri file
from fuctions import *
from config import Config

app = Flask(__name__)
cfg = Config()

#**********************Rest Functions**********************
# ---- Frequency category
@app.route('/frequency-category', methods=['POST'])
def frequencyCategory():
	data = request.get_json()   # message received from the request
	text = data['textFile']          
	category = data['category'].lower() 
	
	print("start")

	# list of stopwords
	punctuations = punctuationsFunction()
	uninteresting_words = stopWordsFunction()

	# Dictionaries to create our word list
	word_dictionary = {}
	infoText = {}
	
	# let's create a list with all the words present in the text provided
	word_list = text.split()
	word_dictionary = frequencyWords(word_list, punctuations, uninteresting_words)
	
	infoText["category"] = category
	infoText["words"] = word_dictionary
	print(infoText)
	
	# Send via HTTP to Go server
	headers = {'Content-Type': 'application/json'}
	response = requests.post(cfg.get_url_receive_category(), json=infoText, headers=headers)
	
	return jsonify({'Message': response.text})
	
# ---- Insert new text
@app.route('/insert-new-text', methods=['POST'])
def insertNewText():
	data = request.get_json()  			 # message received from the request
	title = data['title'].lower()        
	author = data['author'].lower() 
	edition = data['edition'].lower()        
	ISBN = data['isbn']
	text = data['textFile'] 

	# list of stopwords
	punctuations = punctuationsFunction()
	uninteresting_words = stopWordsFunction()

	# Dictionaries to create our word list
	word_dictionary = {}
	infoText = {}
	
	# let's create a list with all the words present in the text provided
	word_list = text.split()
	
	print("start")
	word_dictionary = frequencyWords(word_list, punctuations, uninteresting_words)
	
	infoText["title"] = title
	infoText["author"] = author
	infoText["edition"] = edition
	infoText["isbn"] = ISBN
	infoText["words"] = word_dictionary
	print(infoText)
	
	# Send via HTTP to Go server
	headers = {'Content-Type': 'application/json'}
	response = requests.post(cfg.get_url_receive_text(), json=infoText, headers=headers)

	#print(response.text) 
	jsonData=response.json()
	jsonString=""

	# Prepare the return message
	for key in jsonData:
		jsonString=jsonString + "- " + key + ": " + str(jsonData[key])+ "%\n"
	
	jsonString="Category:\n" + jsonString
	#print(jsonString)

	wordsString = json.dumps(word_dictionary)
	return jsonify({'Message': jsonString, 'Words':wordsString})


# ---- Retrieve text list
@app.route('/retrieve-text-list', methods=['GET'])
def textList():
	headers = {'Content-Type': 'application/json'}
	response = requests.get(cfg.get_url_text_list(),  headers=headers)
	print(response.json())
	return jsonify(response.json())

# ---- Word cloud
@app.route('/word-cloud', methods=['POST'])
def wordCloud():
	data = request.get_json() 
	wcMaskType = data['wcType']        
	wordDictionary = json.loads(data['words'])
	
	# Generate the word cloud object
	plt = wordCloudImg(wordDictionary, wcMaskType)

	# Convert the image to base64
	b64_img = bufferImage(plt)
	
	#return response 
	return jsonify({'Message': b64_img})

# ---- Frequency Graphs
@app.route('/frequency-graphs', methods=['POST'])
def frequencyGraphs():
	data = request.get_json()  			     
	wordDictionary = json.loads(data['words'])
	typeGraph1 = data['typeGraph1']
	typeGraph2 = data['typeGraph2']
	color = data['color']  
	
	# Creation of frequency graphs
	plt = frequencyGraphsImg(wordDictionary, typeGraph1, typeGraph2, color)
	
	# Convert the image to base64
	b64_img = bufferImage(plt)

	return jsonify({'Message': b64_img})

# ---- Text search
@app.route('/text-search', methods=['POST'])
def textSearch():
	datas = request.get_json()  
	wordDictionary ={}

	wordDictionary = dictionaryUpdate(datas)

	# Send via HTTP to Go server
	headers = {'Content-Type': 'application/json'}
	response = requests.post(cfg.get_url_rate_list(), json=wordDictionary, headers=headers)
	rateCategories = json.loads(response.text) # Deserialize the JSON into a Python dictionary

	print(rateCategories)

	# Extract labels and values
	labels = list(rateCategories.keys())
	values = list(rateCategories.values())
	title = "category texts"
	typeGraph2 = "Histogram" 
	color ="darkorange"

	# Creation of the percentage graph
	plt = typeGraph(typeGraph2, color, title, labels ,values)
	
	# Convert the image to base64
	b64_img = bufferImage(plt)
	
	#return response 
	return jsonify({'Message': b64_img})

@app.route('/text-comparison', methods=['POST'])
def textComparison():
	data = request.get_json() 
	wordDictionary1 = json.loads(data['words1'])
	wordDictionary2 = json.loads(data['words2'])
	title1 = data['title1']
	title2 = data['title2']
	wordDictionary3 ={}
	category_rate1 = {}
	category_rate2 = {}
	word_dictionaryComparison = {}
	
	wordDictionary3 = {
		"wordDictionary1": wordDictionary1,
		"wordDictionary2": wordDictionary2
	}

	print("")
	print(wordDictionary3)
	
	# Send via HTTP to Go server
	headers = {'Content-Type': 'application/json'}
	response = requests.post(cfg.get_url_text_comparison(), json=wordDictionary3, headers=headers)

	# Upload received JSON
	data = json.loads(response.text)
	
	# let's fill the dictionaries
	category_rate1 = dict(data["categoryRate1"]) 
	category_rate2 = dict(data["categoryRate2"])
	word_dictionaryComparison = dict(data["WordDictionaryComparison"])

	# Let's create the percentage graph
	plt1 = comparisonGraphsImg(category_rate1, category_rate2, title1,title2, "rate")

	# Convert the image to base64
	b64img1 = bufferImage(plt1)
	
	# Before creating the word graph check whether the word_dictionaryComparison is empty or not
	if not word_dictionaryComparison["WordDictionary1"]:
		b64img2 = ""
		print("empty map")
	else:
		# Let's create the word comparison graph
		plt2 = comparisonGraphsImg(word_dictionaryComparison["WordDictionary1"], word_dictionaryComparison["WordDictionary2"], title1, title2, "word")
		
		# Convert the image to base64
		b64img2 = bufferImage(plt2)

	#return response 
	return jsonify({'Img1': b64img1, 'Img2':b64img2})

if __name__ == '__main__':
	app.run(host=cfg.get_host(), port=cfg.get_port_8080())