package services

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"math"
	"net/http"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

// Structures and maps
type WordDictionary map[string]int
type CategoryDictionary struct {
	Category string         `json:"category"`
	Words    WordDictionary `json:"words"`
}

type CategoryDict struct {
	Category string         `bson:"category"`
	Words    WordDictionary `bson:"words"`
}

type TextDictionary struct {
	Title   string         `json:"title"`
	Author  string         `json:"author"`
	Edition string         `json:"edition"`
	Isbn    string         `json:"isbn"`
	Words   WordDictionary `json:"words"`
}

type TextDictionaryList struct {
	Title   string `json:"title"`
	Author  string `json:"author"`
	Edition string `json:"edition"`
	Isbn    string `json:"isbn"`
	Words   string `json:"words"`
}

type ComparisonDictionary struct {
	Words1 WordDictionary `json:"wordDictionary1"`
	Words2 WordDictionary `json:"wordDictionary2"`
}

/*********** Function ***********/
/* ------ Dictionaries Comparison ------ */
/* Compare two dictionaries of words and count the total occurrences of each word in the two dictionaries.
Parameters:
- result: result dictionary
- categoryDict: comparison dictionary

Come back:
- result: dictionary with aggregate counts */
func dictionariesComparison(result WordDictionary, categoryDict WordDictionary) WordDictionary {
	//Create a map to keep track of the words already encountered
	seen := make(map[string]bool)

	for word, count := range categoryDict {
		// the "_" is to ignore the value
		if _, ok := seen[word]; !ok {
			// If this is the first time I've encountered the word, I add it to seen
			seen[word] = true

			if _, ok := result[word]; ok {
				// If the word is already in the tmpWordDictionary, I update the count
				result[word] += count
			} else {
				// Otherwise I enter the new word with its count
				result[word] = count
			}
		}
	}
	return result
}

/* ------ Categories Rate ------ */
/* Calculates the percentages of each text category based on a word dictionary and category dictionaries stored in the database.

Parameters:
- newTest: new dictionary of words to classify
- database: connection to the database

Come back:
- cRate: map with percentages by category */
func categoriesRate(newTest WordDictionary, database *mongo.Database) map[string]float64 {
	cRate := make(map[string]float64)
	totalRate := 0.0

	// Let's get the collection from the DB
	categoryCollection := database.Collection("Categorys")

	// We find the information we need excluding the id
	findOptions := options.Find()
	findOptions.SetProjection(bson.D{{"_id", 0}})
	cur, err := categoryCollection.Find(context.TODO(), bson.D{}, findOptions)
	if err != nil {
		panic(err)
	}

	//Retrieving search results
	var results []CategoryDict
	if err = cur.All(context.TODO(), &results); err != nil {
		panic(err)
	}

	// Loop over each category dictionary
	for _, category := range results {
		// Loop over the words of the new text
		for textWord, _ := range newTest {
			// Check if the word is present in the current category
			if _, found := category.Words[textWord]; found {
				cRate[category.Category] += 1
				totalRate++
			}
		}
	}

	// Calculate the rate as a percentage and round it off
	for key, val := range cRate {
		cRate[key] = math.Round((val / totalRate) * 100)
	}
	return cRate
}

/* ------ Comparison Dictionary X2 ------ */
/*Compares two dictionaries of words and returns two new dictionaries containing only the words in common and their occurrences.

Parameters:
- text1: first word dictionary
- text2: second dictionary of words

Come back:
- wordComparison: map with the two comparison dictionaries*/
func comparisonDictionaryX2(text1 WordDictionary, text2 WordDictionary) map[string]WordDictionary {
	// Create a map to keep track of the words already encountered
	wordDictionary1 := make(map[string]int)
	wordDictionary2 := make(map[string]int)

	//Comparison of words from the two dictionaries
	for word1, count1 := range text1 {
		if count2, ok := text2[word1]; ok {
			wordDictionary1[word1] = count1
			wordDictionary2[word1] = count2
		}
	}

	wordComparison := map[string]WordDictionary{
		"WordDictionary1": wordDictionary1,
		"WordDictionary2": wordDictionary2,
	}

	return wordComparison
}

/*********** Rest Function ***********/
/* ------ Receive Category ------ */
/* It receives a new text category via HTTP API, saves it in the database and aggregates the related word dictionary.

Parameters:
-w: Response writer
-r: Request
- database: database connection */
func ReceiveCategory(w http.ResponseWriter, r *http.Request, database *mongo.Database) {
	var categoryDict CategoryDictionary

	// closing the body of request
	defer r.Body.Close()

	// Decoding of the message received via rest
	err := json.NewDecoder(r.Body).Decode(&categoryDict)
	if err != nil {
		http.Error(w, "Error decoding JSON", http.StatusBadRequest)
		return
	}

	collection := database.Collection("Categorys")

	// Search for a category within the "Category" table
	filter := bson.D{{"category", categoryDict.Category}}
	count, err := collection.CountDocuments(context.TODO(), filter) // If there is a genre in the table, increment the counter

	if err != nil {
		http.Error(w, "Error checking category", http.StatusInternalServerError)
		return
	}

	//Category already exists
	if count > 0 {
		fmt.Println("Category already exists")
		var result CategoryDict

		// search for a single item
		err := collection.FindOne(context.TODO(), filter).Decode(&result)
		if err != nil {
			log.Fatal(err)
		}

		// Update the table of the category found
		tmpWordDictionary := dictionariesComparison(result.Words, categoryDict.Words)
		filterUpdate := bson.M{"category": categoryDict.Category}
		update := bson.M{"$set": bson.M{"words": tmpWordDictionary}}

		_, err = collection.UpdateOne(context.Background(), filterUpdate, update)
		if err != nil {
			log.Fatal(err)
		}

		// Sending the response message
		w.WriteHeader(http.StatusOK)
		w.Write([]byte("Update Category"))
		return
	}

	// Insertion of a new category
	doc := bson.D{
		{"category", categoryDict.Category},
		{"words", categoryDict.Words},
	}

	insertResult, err := collection.InsertOne(context.TODO(), doc)
	if err != nil {
		http.Error(w, "Error inserting document", http.StatusInternalServerError)
		return
	}

	// Sending the response message
	fmt.Printf("Inserted ID: %v\n", insertResult.InsertedID)
	w.WriteHeader(http.StatusOK)
	w.Write([]byte("New category entered correctly"))
}

/* ------ Receive Text ------ */
/* Receives a new text via HTTP API, calculates the categorization percentages and saves it in the database if not present.

Parameters:
-w: Response writer
-r: Request
- database: database connection */
func ReceiveText(w http.ResponseWriter, r *http.Request, database *mongo.Database) {
	var newTest TextDictionary

	// closing the body of request
	defer r.Body.Close()

	// Decoding of the message received via rest
	err := json.NewDecoder(r.Body).Decode(&newTest)
	if err != nil {
		http.Error(w, "Error decoding JSON", http.StatusBadRequest)
		return
	}

	collection := database.Collection("Texts")
	filter := bson.D{{"Title", newTest.Title}, {"Edition", newTest.Edition}}
	count, err := collection.CountDocuments(context.TODO(), filter) // If there is a text in the table, increment the counter
	if err != nil {
		http.Error(w, "Error checking category", http.StatusInternalServerError)
		return
	}

	//Calculation of percentages of a text
	categoryRate := categoriesRate(newTest.Words, database)
	fmt.Println(categoryRate)

	// Map to Json conversion
	wordDictionaryJSON, err := json.Marshal(newTest.Words)
	if err != nil {
		http.Error(w, "Error converting word dictionary to JSON", http.StatusInternalServerError)
		return
	}

	// Json to string conversion
	wordDictionaryString := string(wordDictionaryJSON)

	//If the text does not exist
	if count == 0 {
		// Insertion of a new text
		doc := bson.D{
			{"Title", newTest.Title},
			{"Author", newTest.Author},
			{"Edition", newTest.Edition},
			{"Isbn", newTest.Isbn},
			{"Words", wordDictionaryString},
		}

		insertResult, err := collection.InsertOne(context.TODO(), doc)
		if err != nil {
			http.Error(w, "Error inserting document", http.StatusInternalServerError)
			return
		}

		// Sending the response message
		fmt.Printf("Inserted ID: %v\n", insertResult.InsertedID)
	}

	//Map to json conversion
	categoryRateJSON, err := json.Marshal(categoryRate)
	if err != nil {
		http.Error(w, "Error converting word dictionary to JSON", http.StatusInternalServerError)
		return
	}
	w.WriteHeader(http.StatusOK)
	w.Header().Set("Content-Type", "application/json")
	w.Write(categoryRateJSON)
}

/* ------ Receive Text List ------ */
/*Returns the list of all texts stored in the database.

Parameters:
-w: Response writer
-r: Request
- database: database connection */
func ReceiveTextList(w http.ResponseWriter, r *http.Request, database *mongo.Database) {
	// closing the body of request
	defer r.Body.Close()

	//Recovery of all texts
	textCollection := database.Collection("Texts")
	findOptions := options.Find()
	findOptions.SetProjection(bson.D{{"_id", 0}})
	cur, err := textCollection.Find(context.TODO(), bson.D{}, findOptions)
	if err != nil {
		panic(err)
	}

	var results []TextDictionaryList
	if err = cur.All(context.TODO(), &results); err != nil {
		panic(err)
	}

	//Map to json conversion
	jsonResponse, _ := json.Marshal(results)

	w.WriteHeader(http.StatusOK)
	w.Header().Set("Content-Type", "application/json")
	w.Write(jsonResponse)
}

/* ------ Rate List Calculation ------ */
/* Calculate categorization rates for a word dictionary received via API.

Parameters:
- w: Response writer
- r: Request
- database: database connection */
func RateListCalculation(w http.ResponseWriter, r *http.Request, database *mongo.Database) {
	var wordDictionary WordDictionary

	// closing the body of request
	defer r.Body.Close()

	// Decoding of the message received via rest
	err := json.NewDecoder(r.Body).Decode(&wordDictionary)
	if err != nil {
		http.Error(w, "Error decoding JSON", http.StatusBadRequest)
		return
	}

	//Calculate category percentages
	categoryRate := categoriesRate(wordDictionary, database)
	fmt.Println(categoryRate)

	//Map to json conversion
	categoryRateJSON, err := json.Marshal(categoryRate)
	if err != nil {
		http.Error(w, "Error converting word dictionary to JSON", http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusOK)
	w.Header().Set("Content-Type", "application/json")
	w.Write(categoryRateJSON)
}

/* ------ Text Comparison ------ */
/*Compare two texts received via API:
- Calculate categorization percentages
- Extracts words in common

Parameters:
- w: Response writer
- r: Request
- database: database connection */
func TextComparison(w http.ResponseWriter, r *http.Request, database *mongo.Database) {
	var comparisonDictionary ComparisonDictionary

	// closing the body of request
	defer r.Body.Close()

	// Decoding of the message received via rest
	err := json.NewDecoder(r.Body).Decode(&comparisonDictionary)
	if err != nil {
		http.Error(w, "Error decoding JSON", http.StatusBadRequest)
		return
	}

	//Calculate the category percentages of the two texts and common words
	categoryRate1 := categoriesRate(comparisonDictionary.Words1, database)
	categoryRate2 := categoriesRate(comparisonDictionary.Words2, database)
	WordDictionaryComparison := comparisonDictionaryX2(comparisonDictionary.Words1, comparisonDictionary.Words2)

	comparisonInfo := map[string]interface{}{
		"categoryRate1":            categoryRate1,
		"categoryRate2":            categoryRate2,
		"WordDictionaryComparison": WordDictionaryComparison,
	}

	fmt.Println(comparisonInfo)

	//Map to json conversion
	comparisonInfoJson, err := json.Marshal(comparisonInfo)
	if err != nil {
		http.Error(w, "Error converting word dictionary to JSON", http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusOK)
	w.Header().Set("Content-Type", "application/json")
	w.Write(comparisonInfoJson)
}
