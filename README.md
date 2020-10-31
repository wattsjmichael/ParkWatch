<br>
<p>
  <u><big>|| <b>ParkWatch API</b> ||</big></u>
</p>
<p>
    <!-- Project Avatar/Logo -->
    <br>
    <a>
        <img src="https://mystickermania.com/cdn/stickers/travel/previews-256x256.png">
    </a>
    <p>
      ___________________________
    </p>
    <!-- GitHub Link -->
    <p>
        <a href="https://github.com/wattsjmichael">
            <strong>Michael Watts</strong>
        </a> 
    </p>
    <p>
  <small>Created October 30th, 2020.</small>
</p>
---

### <u>Table of Contents</u>

- <a href="#🌐-about-the-project">About the Project</a>
  - <a href="#📖-description">Description</a>
  - <a href="#🦠-known-bugs">Known Bugs</a>
  - <a href="#🛠-built-with">Built With</a>
- <a href="#🏁-getting-started">Getting Started</a>
  - <a href="#📋-prerequisites">Prerequisites</a>
  - <a href="#⚙️-setup-and-use">Setup and Use</a>
- <a href="#🛰️-api-documentation">API Documentation</a>
  - <a href="#✉️-contact-and-support">Contact</a>
  - <a href="#⚖️-license">License</a>
  - <a href="#🌟-acknowledgements">Acknowledgements</a>

---
## 🌐 About the Project

### 📖 Description

An API that functions as an archive for trips to State and National Parks. It utilizes RESTful principles and pagination.

### 🦠 Known Bugs

- There are no known bugs at this time. If you find one send me an email. <a href=mailto:wattsjmichael@gmail.com>Michael Watts </a>

### 🛠 Built With

- [Visual Studio Code](https://code.visualstudio.com/)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
- [MySQL](https://dev.mysql.com/)
- [Entity Framework Core 2.2.6](https://docs.microsoft.com/en-us/ef/core/)
- [Postman](postman.com)

---

# 🏁 Getting Started

### 📋 Prerequisites

#### Install .NET Core

- On macOS Mojave or later
  - [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download the .NET Core SDK from Microsoft Corp for macOS.
- On Windows 10 x64 or later
  - [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp for Windows.

#### Install dotnet script

Enter the command `dotnet tool install -g dotnet-script` in Terminal for macOS or PowerShell for Windows.

#### Install MySQL Workbench

[Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/).

#### Install Postman

(Optional, but you really should!) [Download and install Postman](https://www.postman.com/downloads/).

### Code Editor

To view or edit the code, you will need an code editor or text editor. The popular open-source choices for an code editor are Atom and VisualStudio Code.

1. Code Editor Download:
   - Option 1: [Atom](https://nodejs.org/en/)
   - Option 2: [VisualStudio Code](https://www.npmjs.com/)
2. Click the download most applicable to your OS and system.
3. Wait for download to complete, then install -- Windows will run the setup exe and macOS will drag and drop into applications.
4. Optionally, create a [GitHub Account](https://github.com)

### ⚙️ Setup and Use

#### Cloning

1. Navigate to the [ParkWatchApi Here](https://github.com/wattsjmichael/ParkWatch).
2. Click 'Clone or download' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
3. Open up your system Terminal or GitBash, navigate to your desktop with the command: `cd Desktop`, or whichever location suits you best.
4. Clone the repository to your desktop: `$ git clone https://github.com/wattsjmichael/ParkWatch.git`
5. Run the command `cd ParkWatchAPI` to enter into the project directory.
6. View or Edit:
   - Code Editor - Run the command `atom .` or `code .` to open the project in Atom or VisualStudio Code respectively for review and editing.
   - Text Editor - Open by double clicking on any of the files to open in a text editor.

   #### Download

1. Navigate to the [ParkWatchAPI Here](https://github.com/wattsjmichael/ParkWatch).
2. Click 'Clone or download' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
3. Click 'Download ZIP' and unextract.
4. Open by double clicking on any of the files to open in a text editor.

#### AppSettings

1. Create a new file in the TravelAPI directory named `appsettings.json`
2. Add in the following code snippet to the new appsettings.json file:

```
{
  "Logging": {
      "LogLevel": {
      "Default": "Warning"
      }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=parkwatchapi;uid=root;pwd=YourPassword;"
  }
}
```

3. Change the server, port, and user id as necessary. Replace 'YourPassword' with relevant MySQL password (set at installation of MySQL).

#### Database

1. Navigate to ParkWatchApi directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/ParkWatch.Solutions/ParkWatchApi`).
2. Run the command `dotnet ef database update` to generate the database through Entity Framework Core.
3. (Optional) To update the database with any changes to the code, run the command `dotnet ef migrations add <MigrationsName>` which will use Entity Framework Core's code-first principle to generate a database update. After, run the previous command `dotnet ef database update` to update the database.

#### Launch the API

1. Navigate to ParkWatchApi directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/ParkWatch.Solution/ParkWatchApi`).
2. Run the command `dotnet run` to have access to the API in Postman or browser.

## 🛰️ API Documentation

Explore the API endpoints in Postman or a browser.

### Note on Pagination

The ParkWatchAPI returns a default of 3 results per page at a time, up to a maximum of 100.

To modify this, use the query parameters `pageLimit` and `pageNumber` to alter the response results displayed. The `pageLimit` parameter will specify how many results will be displayed, and the `pageNumber` parameter will specify which element in the response the limit should start counting.

#### Example Query

```
http://localhost:5000/api/natlParks/?pageLimit=3&pageNumber=1
```
#### Sample JSON Response
{
    "pageNumber": 1,
    "pageSize": 3,
    "firstPage": "http://localhost:5000/api/natlParks/?pageNumber=1&pageSize=3",
    "lastPage": "http://localhost:5000/api/natlParks/?pageNumber=2&pageSize=3",
    "totalPages": 2,
    "totalRecords": 5,
    "nextPage": "http://localhost:5000/api/natlParks/?pageNumber=2&pageSize=3",
    "previousPage": null,
    "data": [
        {
            "natlParkId": 1,
            "natlParkName": "Yellowstone",
            "natlParkCity": "Yellowstone City",
            "natlParkState": "Wyoming",
            "natlParkCampingSpots": 200,
            "isOpenNatl": true
        },
        {
            "natlParkId": 2,
            "natlParkName": "Glacier",
            "natlParkCity": "Glacier City",
            "natlParkState": "Montana",
            "natlParkCampingSpots": 1200,
            "isOpenNatl": true
        },
        {
            "natlParkId": 3,
            "natlParkName": "Appalachia National Park",
            "natlParkCity": "Montiplier",
            "natlParkState": "Vermont",
            "natlParkCampingSpots": 25,
            "isOpenNatl": false
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}

To use default, _don't include_ `pageLimit` and `pageNumber` or set them equal to zero.

..........................................................................................

### Endpoints

Base URL: `http://localhost:5000/api/natlparks`
Base URL: `http://localhost:5000/api/stateparks`

### ParkWatch

Database of State and National Parks, with the number of camping spots and whether they are open or not.

#### HTTP Request

```
GET /api/natlparks
POST /api/natlparks
GET /api/natlparks/{id}
PUT /api/natlparks/{id}
DELETE /api/natlparks/{id}
```
#### Path Parameters

|       Parameter       |  Type  | Default | Required | Description                                        |
| :--------------------:| :----: | :-----: | :------: |:--------------------------------------------------:|
| natlParkName          |  string|  none   |  false   | Return matches by National Park name.              |
|   natlParkCity        | string |  none   |  false   | Return matches by city name.                       |
|  natlParkState        | string |  none   |  false   | Return matches by state name.                      |
|  natlParkCampingSpots |  int   |  none   |  false   | Return matches by camping spots value.             |
|  isOpenNatl           |  bool  |  none   |  false   | Return matches by whether a camping venue is open. |

#### Example Query

```
http://localhost:5000/api/natlparks/?natlParkCity=Glacier City
```
#### Sample JSON Response
```
{
    "pageNumber": 1,
    "pageSize": 3,
    "firstPage": "http://localhost:5000/api/natlparks/?pageNumber=1&pageSize=3",
    "lastPage": "http://localhost:5000/api/natlparks/?pageNumber=2&pageSize=3",
    "totalPages": 2,
    "totalRecords": 5,
    "nextPage": "http://localhost:5000/api/natlparks/?pageNumber=2&pageSize=3",
    "previousPage": null,
    "data": [
        {
            "natlParkId": 2,
            "natlParkName": "Glacier",
            "natlParkCity": "Glacier City",
            "natlParkState": "Montana",
            "natlParkCampingSpots": 1200,
            "isOpenNatl": true
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}
```
#### HTTP Request
```
GET /api/stateparks
POST /api/stateparks
GET /api/stateparks/{id}
PUT /api/stateparks/{id}
DELETE /api/stateparks/{id}
```
#### Path Parameters

|       Parameter        |  Type  | Default | Required | Description                                        |
| :---------------------:| :----: | :-----: | :------: | -------------------------------------------------- |
| stateParkName          |  string|  none   |  false   | Return matches by StatePark name.              |
|   stateParkCity        | string |  none   |  false   | Return matches by city name.                       |
|  stateParkkState       | string |  none   |  false   | Return matches by state name.                      |
|  stateParkCampingSpots |  int   |  none   |  false   | Return matches by camping spots value.             |
|  isOpenNatl            |  bool  |  none   |  false   | Return matches by whether a camping venue is open. |


#### Example Query
```
http://localhost:5000/api/stateparks/?isOpenState=true&stateParkCity=Bellingham
```

#### Sample JSON Response

```
{
    "pageNumber": 1,
    "pageSize": 3,
    "firstPage": "http://localhost:5000/api/stateparks/?pageNumber=1&pageSize=3",
    "lastPage": "http://localhost:5000/api/stateparks/?pageNumber=2&pageSize=3",
    "totalPages": 2,
    "totalRecords": 5,
    "nextPage": "http://localhost:5000/api/stateparks/?pageNumber=2&pageSize=3",
    "previousPage": null,
    "data": [
        {
            "stateParkId": 1,
            "stateParkName": "Bellingham State Park",
            "stateParkCity": "Bellingham",
            "stateParkState": "Washington",
            "stateParkCampingSpots": 15,
            "isOpenState": true
        },
        {
            "stateParkId": 5,
            "stateParkName": "Bellingham State Park",
            "stateParkCity": "Bellingham",
            "stateParkState": "Washington",
            "stateParkCampingSpots": 15,
            "isOpenState": true
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}
```
### ✉️ Contact and Support

If you have any feedback or concerns, please contact me
| Portfolio                              |                      GitHub                       |                           Email                           |
| ---------------------------------------| :-----------------------------------------------: | :--------------------------------------------------------:|
| [Michael Watts](www.wattsjmichael.com) | [Michael Watts](https://github.com/wattsjmichael) | [wattsjmichael@gmail.com](mailto:wattsjmichael@gmail.com) |

---

### ⚖️ License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2020 Michael Watts. All Rights Reserved.

```
MIT License

Copyright (c) 2020 Michael Watts.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

---
### Guidance Used

[Guidance on Paging in ASP.NET Core Web API](https://www.codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/)

All the Googles and Stack Overflows, who knew bools could be nullable! 

---
<center><a href="#">Return to Top</a></center>