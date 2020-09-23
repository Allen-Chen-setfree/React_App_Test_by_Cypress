
# QA code task 

The application consists of two projects - UI (React SPA) and API (ASP.Net Core).

## What we have
A boilerplate code for both frontend and backend has been provided.

### UI:

The application has 4 pages and each page has instructions on what should be implemented:
- home page
- factorial - a user should be able to calculate *n!*
- fibonacci - a user should be able to calculate *Fib(n)*
- random square - a user should be able to calculate *rand(0, n)^2*

### API:

REST endpoints that are used in the UI have been implemented.


## What you need to do

### UI:
- Implement missing features
    > Please start the application (see instructions below) and explore it to understand what needs to be implemented.
- Implement the test suite to cover the UI. Preferred frameworks are `Jest` and `Cypress` but open to use any frameworks.

### API:

- Make sure the application logic is working correctly and feel free to refractor or change the code to make it work as desired.
- Implement the test suite to cover the API. Preferred framework is `NUnit`.

## This code task is to test a candidate's ability to (non exhaustive list):
- code
- write automated tests (unit, integration, end-to-end as required)
- use git
- decide on testing strategy
- pay attention to details
- own and improve the code as required


## Before start

- Install dotnet SDK: https://dotnet.microsoft.com/download
- Install Yarn package manager: https://classic.yarnpkg.com/en/docs/install

- NB: Current app has been tested with:
    - node: v10.16.0
    - yarn: 1.22.4
    - dotnet: 3.1.202
    - npm: 6.9.0

## Start

- `yarn start` - this will start ui (port 3000) and api  (port 3001)


## How to run test

- API test<br/>
  `dotnet test` - under directory .\api\tests

- UI test<br/>
  `yarn run cypress open` - under directory .\ui


