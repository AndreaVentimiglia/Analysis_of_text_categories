package main

import (
	"ServerGo/services"
	"context"
	"fmt"
	"log"
	"net/http"
	"time"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

/*********** MAIN ***********/
func main() {
	fmt.Println("Welcome")

	//Connection to DB
	// Local
	client, err := mongo.NewClient(options.Client().ApplyURI("mongodb://localhost:27017"))
	// Server
	//client, err := mongo.NewClient(options.Client().ApplyURI("mongodb+srv://gaianataljcontino97:KpdSgrK1HExL7DUO@cluster0.ok6j81v.mongodb.net/"))

	if err != nil {
		log.Fatal(err)
	}

	// Create a context with a 10 second timeout
	ctx, _ := context.WithTimeout(context.Background(), 10*time.Second)
	// Make the client connection passing the context
	err = client.Connect(ctx)
	if err != nil {
		log.Fatal(err)
	}

	database := client.Database("TextAnalysis")

	/* Handle Functuons */
	http.HandleFunc("/receive-category", func(w http.ResponseWriter, r *http.Request) {

		services.ReceiveCategory(w, r, database)
	})

	http.HandleFunc("/receive-text", func(w http.ResponseWriter, r *http.Request) {

		services.ReceiveText(w, r, database)
	})

	http.HandleFunc("/text-list", func(w http.ResponseWriter, r *http.Request) {

		services.ReceiveTextList(w, r, database)
	})

	http.HandleFunc("/rate-list", func(w http.ResponseWriter, r *http.Request) {

		services.RateListCalculation(w, r, database)
	})

	http.HandleFunc("/text-comparison", func(w http.ResponseWriter, r *http.Request) {
		services.TextComparison(w, r, database)
	})

	log.Fatal(http.ListenAndServe(":5000", nil))

	// DB closing
	defer client.Disconnect(ctx)
	if err != nil {
		log.Fatal(err)
	}
}
