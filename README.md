# Hair Salon

#### by _Chan Lee_ , 09/28/2018

## Description

This program manages the hair salon system. Admin can add a list of the stylists, clients and specialties. For each stylist, add clients who see that stylist and possessing specialties. Admin can modify both stylists/clients/specialty values as well as delete the data.

![Screenshot](/HairSalon/wwwroot/img/thumbnail/screenshot.png)
![Screenshot](/HairSalon/wwwroot/img/thumbnail/screenshot2.png)

## Behavior-driven Development

| Specs    |  Input | Output |
| ------------- |:-------------: |:-------------: |
|  Program displays a list of all stylists.  | View stylists | List of all stylists |
|  Program displays a list of all clients.  | View clients | List of all clients |
|  Program displays a list of all specialties.  | View specialties | List of all specialties |
|  When user selects a stylist, program displays its clients.  | Stylist clicked | Stylist's list of clients |
| The website allows user to add new stylist | Add Stylist | List of all stylists |
| The website allows user to add new client | Add Client | List of all clients |
| The website allows user to add new specialty | Add Specialty | List of all specialties |
| The website allows user to add new clients under approached stylist | Add Client | Clients of Selected stylist |
| The website allows user to add new specialties under approached stylist | Add Specialty | Specialtys of Selected stylist |
| The website allows user to modify stylist information. | Edit Stylist | Edited description of Stylist |
| The website allows user to modify client information. | Edit Client | Edited description of Client |
| The website allows user to modify specialty information. | Edit Specialty | Edited description of Specialty |
| The website allows user to delete stylist information. | Delete Stylist | List of all stylists |
| The website allows user to delete client information. | Delete Client | List of all clients |
| The website allows user to delete specialty information. | Delete Specialty | List of all specialtys |


## Setup/Installation Requirements

1. Clone this repository
```
    $ git clone https://github.com/goenchan/HairSalon
```
2. Navigate into the directory
```
    $ cd HairSalon.Solution/HairSalon/
```
3. (option1) Go to MySQL from terminal and import given sql file.
```
    > mysql -u yourusername -p yourpassword yourdatabase < chan_lee.sql
```
   (option2) Create following database from MySQL command line
```
    CREATE DATABASE hair_salon;

    USE chan_lee;

    CREATE TABLE `stylists` (
      `id` int(32) NOT NULL,
      `name` varchar(255) NOT NULL
    );

    CREATE TABLE `clients` (
      `id` int(32) NOT NULL,
      `name` varchar(255) NOT NULL
    );

    CREATE TABLE `specialtys` (
      `id` int(11) NOT NULL,
      `name` varchar(255) NOT NULL
    );

    CREATE TABLE `specialtys_stylists` (
      `id` int(11) NOT NULL,
      `specialty_id` int(11) NOT NULL,
      `stylist_id` int(11) NOT NULL
    )

    CREATE TABLE `stylists_clients` (
      `id` int(11) NOT NULL,
      `stylist_id` int(11) NOT NULL,
      `client_id` int(11) NOT NULL
    );
```
4. Run the following command to restore HairSalon.csproj file in source directory.
```
    $ dotnet restore
```
5. Run local hosting through dotnet run
```
    $ dotnet run
```
6. Connect to http://localhost:5000 in web browser.


## Known Bugs

*None.*


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
