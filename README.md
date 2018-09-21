# Word Counter

#### by _Chan Lee_ , 09/21/2018

## Description

This program manages the hair salon system. Admin can add a list of the stylists, and for each stylist, add clients who see that stylist . Admin can modify both stylists/clients values as well as delete the data.


## Behavior-driven Development

| Specs    |  Input | Output | Rationale   
| ------------- |:-------------: |:-------------: |:-------------:|
|  Program displays a list of all stylists.  | View stylists | List of all stylists |
|  When user selects a stylist, program displays its clients.  | Stylist clicked | Stylist's list of clients |
| The website allows user to add new stylist | Add Stylist | List of all stylists |
| The website allows user to add new clients under approached stylist | Add Client | Clients of Selected stylist |
| The website allows user to modify stylist information. | Edit Stylist | Edited description of Stylist |
| The website allows user to modify client information. | Edit Client | Edited description of Client |
| The website allows user to delete stylist information. | Delete Stylist | List of all stylists |
| The website allows user to delete client information. | Delete Client | List of all clients |


## Setup/Installation Requirements

1. Clone this repository
```
    $ git clone https://github.com/goenchan/HairSalon
```
2. Navigate into the directory
```
    $ cd WordCount.Solution/WordCounter/
```
3. Import given sql file.
```
    CREATE DATABASE chan_lee;

    USE chan_lee;

    CREATE TABLE stylists (stylist_id serial PRIMARY KEY, name VARCHAR(255), income INT(32));

    CREATE TABLE clients (client_id serial PRIMARY KEY, name VARCHAR(255), appointment VARCHAR(255) stylist_id INT(32));
```
4. Run local hosting through dotnet run
```
    $ dotnet run
```
5. Connect to http://localhost:5000 in web browser.


## Known Bugs

*None.*
*Module other than WordCounter is not added yet.*


## Support and contact details

_ChanEthanLee@gmail.com_

## Technologies Used

* Visual Studio
* C#/.Net Core 1.1
* AspNetCore MVC 1.1.3
* MAMP
* CSS
* HTML

#### Licensed under MIT

### _Chan Lee_ Copyright (c) 2018
