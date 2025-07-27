# Academic Research Web Scraper

## Overview

This project is a full-stack academic research tool designed to collect, store, and present publication data using **web scraping**, **MongoDB**, and a dynamic web interface built with **ASP.NET Web Forms** and **MVC**. It allows users to search for academic publications using keywords, and displays structured results including metadata such as titles, authors, abstracts, and publication details.

---

## Features

- Web scraping of academic publication data based on user input
- Extracted fields include:
  - Title, Authors, Publication Type, Date, Publisher
  - Abstract, References, Citation Count, DOI, URL
- Downloads available PDF files (if accessible)
- Stores results in a MongoDB database
- Web interface for:
  - Searching by keyword
  - Viewing publication details
  - Sorting and filtering results dynamically

---

## Technologies Used

- **C#** – Backend logic  
- **ASP.NET Web Forms** – Main frontend structure  
- **ASP.NET MVC** – Routing and controller-based logic  
- **HtmlAgilityPack** – HTML scraping and parsing  
- **MongoDB.Driver** – NoSQL data storage  
- **Bootstrap** – Responsive UI layout  
- **JavaScript** – Client-side interactivity

---

## System Requirements

- Visual Studio 2022 or later  
- .NET Framework (compatible with Web Forms / MVC)  
- Local MongoDB server  

---

## How It Works

1. User enters a search term via the interface  
2. The system sends a request to an academic search engine (e.g., Google Scholar)  
3. `HtmlAgilityPack` parses the response HTML and extracts publication data  
4. Data is stored into MongoDB with a predefined schema  
5. The UI displays the results dynamically, allowing sorting and filtering  
6. PDF files are downloaded and stored if available

---

## Example Workflow

- User searches for "machine learning"  
- System scrapes top academic results and stores them  
- Each publication is displayed with metadata and link  
- Clicking a publication opens detailed information  
- Results can be sorted by date or citation count

---

## Limitations

- Web scraping depends on the target site's HTML structure  
- Google Scholar may block frequent requests  

---

## License

This project is licensed under the **MIT License**. You are free to use, modify, and distribute it with proper attribution.
