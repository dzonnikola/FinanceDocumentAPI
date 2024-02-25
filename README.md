# Financial Transaction API

This is a .NET Core 6 Web API project that implements endpoint functionality as per the provided specifications.

## Table of Contents

- [Project Structure](#project-structure)
- [Example Request and Response](#example-request-and-response)

## Project Structure

Explain the overall structure of your project. For example:
- Controllers: Contains API endpoint implementations.
- Services: Implements business logic and interacts with the database.
- Models: Defines data models for requests, responses, and entities.

## Example Request and Response

Request : 

{
  "productCode": "string",
  "tenantId": "guid",
  "documentId": "guid"
}

Response :

{
  "data": "serialized and anonymized JSON",
  "company": {
    "registrationNumber": "string",
    "companyType": "string"
  }
}