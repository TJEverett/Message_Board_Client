# Message Board Client

#### _Track Messages, 08/11/2021_

#### By _**Tristen Everett**_

## Description

This project was an attempt at practicing the skills I am learning to program in C# to interact with my created API. In this project I built an ASP.NET MVC webapp that allows users to view messages retrieved from the API, either all or by group. From the home screen the user can go to login, go to view existing groups, or go to view existing messages. From the login route you will be prompted for credentials that will be sent to the API for verification. If that fails then you will be re-asked to authenticate, if it succeeds then the webpage will store a cookie for 2 hours with your authentication token for the API. From the groups route you will see a listing of all the existing groups and verified users will be able to create new groups. From the messages route you will see a listing of all messages in the database and what group they belong to, you will also have the option to sort the list to show only messages from a specific group. Unverified users will be able to go to a details page and see details about specific messages from the message list. Verified users will also have the ability to create new messages and send them to an existing group or to delete messages that they posted previously.

### Cookies for storing Json Web Tokens (Further Exploration)

* When Cookies are Made
  1. User logs in through Login portal
  2. Client sends information to API to generate Authentication Token
  3. Client receives Token
  4. Old cookie is removed and a new cookie is created with the Authentication Token stored within that will last for 2 hours
* How Cookie is used
  1. When user tries to Create/Delete content in the API the website will check if they have an unexpired cookie
  2. If they have no cookie they are sent to the Login page to acquire a new Authentication Token
  3. If they have a cookie the website will retrieve their Authentication Token and send it with request to the API to prove they are a valid user

## Setup/Installation Requirements

1. Clone this Repo
2. Run `dotnet restore` from within /MessageClient file location
3. Change the `apiRoute` variable in the /MessageClient/Model/ApiHelper.cs file to match the path to where your api is hosted, by default the api is hosted on http://localhost:5000/api
4. Run `dotnet build` from within /MessageClient file location
5. Run `dotnet run` from within /MessageClient file location
6. Using your preferred web browser navigate to http://localhost:5004

## Technologies Used

* C#
* ASP.NET Core
* Entity Framework Core
* Razor Pages

### License

This software is licensed under the MIT license

Copyright (c) 2021 **_Tristen Everett_**