# Analysis of text categories
## Description
The application allows users to analyze texts to understand the most frequent words and genres they belong to. Thanks to the developed interface, users can also examine different texts and obtain comparison statistics. The application architecture includes:
- Two graphical interfaces developed in C# with Windows Forms, to interact with the application in an intuitive way.
- A Pythoncon Flask Back-End, which exposes REST APIs to receive texts and perform textual analysis operations.
- A Go module that manages the connection to the MongoDB Atlas database, to save and retrieve the analyzed texts. It also allows additional data operations.

The integration of these different components allows us to provide a complete application, which from the user interface to data persistence exploits the potential of different languages. The user can interact easily via the graphical client and obtain advanced text mining results through Python and Go.

The possible operations that can be carried out are:
- Addition of a new text category
- Adding new text
- Analysis of a text with detection of the most common words and the percentage of genres they belong to
- Cross analysis between two texts
- List of texts and total percentage of the most used genres by an author
- WordCloud image creations

## Link testi:
https://imsdb.com/search.php

## Installations
1) Python dependencies
Go into the "ServerPython" folder and open the terminal and run the command:
pip install -r requirements.txt

2) C# packages:
- Administrator:
  - Newtonsoft.Json.13.0.3
  - System.Buffers.4.5.1
  - System.Memory.4.5.5
  - System.Numerics.Vectors.4.5.0
  - System.Runtime.CompilerServices.Unsafe.6.0.0
- User
  - Newtonsoft.Json.13.0.3

## START
1) Connect mongoDB server

2) Start the GO server
   - Go into the "ServerGo" folder and open the terminal and run the command:
   - go run main.go

3) Start the Python server
   - Go into the "ServerPython" folder and open the terminal and run the command:
   - py main.py
     
4) Start the C# client
