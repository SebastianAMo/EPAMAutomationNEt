# Task Selenium WebDriver with SpecFlow

This project uses a base Page Object Model Task [Link to the repository](https://autocode.git.epam.com/sebastian.agudelo2/task-selenium-webdriver)
.The previous test cases have been converted to SpecFlow scenarios, and a new test case has been added to validate the navigation to the Services section.
Also, additional of the LivingDoc report generation has been added to the project. To run the project and generate report, follow the [Commands](#commands) below. 


## Test Cases UI
- Test case #1. Validate that the user can search for a position based on criteria.
    - Navigate to https://www.epam.com/
    - Find a link “Carriers” and click on it
    - Write the name of any programming language in the field “Keywords” (should be taken from test parameter)
    - Select “All Locations” in the “Location” field (should be taken from the test parameter)
    - Select the option “Remote”
    - Click on the button “Find”
    - Find the latest element in the list of results
    - Click on the button “View and apply”
    - Validate that the programming language mentioned in the step above is on a page


- Test case #2. Validate global search works as expected.
    - Navigate to https://www.epam.com/
    - Find a magnifier icon and click on it
    - Find a search string and put there “BLOCKCHAIN”/”Cloud”/”Automation” (use as a parameter for a test)
    - Click “Find” button
    - Validate that all links in a list contain the word “BLOCKCHAIN”/”Cloud”/”Automation” in the text. LINQ should be used. 


- Test case #3. Validate file download function works as expected:
    - Create a Chrome instance.
    - Navigate to https://www.epam.com/.
    - Select “About” from the top menu.
    - Scroll down to the “EPAM at a Glance” section.
    - Click on the “Download” button.
    - Wait till the file is downloaded.
    - Validate that file “EPAM_Systems_Company_Overview.pdf” downloaded (use the name of the file as a parameter)
    - Close the browser.


- Test case #4. Validate title of the article matches with title in the carousel:
    - Create a Chrome instance.
    - Navigate to https://www.epam.com/.
    - Select “Insights” from the top menu.
    - Swipe a carousel twice.
    - Note the name of the article.
    - Click on the “Read More” button.
    - Validate that the name of the article matches with the noted above. 
    - Close the browser.

- Test case #5. Validate Navigation to Services Section
    - Navigate to https://www.epam.com/
    - Locate and click on the "Services" link in the main navigation menu.
    - From the dropdown, select a specific service category: “Generative AI” or “Responsible AI” (parameterize the category selection).
    - Validate that the page contains the correct title.
    - Validate that the section ‘Our Related Expertise’ is displayed on the page

## Test Cases API

- **Tasks #1.** Validate that the list of users can be received successfully
	- Create and send request to https://jsonplaceholder.typicode.com/users using GET method
	- Validate that user recives a list of users with the following information: "id",  "name", "username", "email", "address”,     "phone",   "website",  "company";
	- Validate that user receives 200 OK response code. There are no error messages;


- **Tasks #2.** Validate response header for a list of users 
	- Create and send request to https://jsonplaceholder.typicode.com/users using GET method.
	- Validate content-type header exists in the obtained response.
	- The value of the content-type header is application/json; charset=utf-8.
	- Validate that user receives 200 OK response code. There are no error messages.

- **Tasks #3.** Validate response header for a list of users 
	- Create and send request to https://jsonplaceholder.typicode.com/users using GET method. 
	- Validate that the content of the response body is the array of 10 users.
	- Validate that each user should be with different ID.
	- Validate that each user should be with non-empty Name and Username.
	- Validate that each user contains the Company with non-empty Name Validate that user receives 200 OK response code. There are no error messages.

- **Tasks #4.** Validate that user can be created
	- Create and send request to https://jsonplaceholder.typicode.com/users using POST method with Name and Username fields 
	- Validate that response is not empty and contains the ID value
	- Validate that user receives 201 Created response code. There are no error messages

- **Tasks #5.** Validate that user is notified if resource doesn’t exist
	- Create and send a request to https://jsonplaceholder.typicode.com/invalidendpoint using GET method.
	- Validate that user receives 404 Not Found response code. There are no error messages.  



## Commands

The following commands are used to run the project, and generate the LivingDoc report
Commands should be run in the Tests project directory

- Install LivingDoc CLI
  ```bash
  dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
  ```

- Clean the project
  ```bash
  dotnet clean
  ```

- Clean and restore the project
  ```bash
  dotnet restore
  ```

- Build the project
  ```bash
  dotnet build
  ```

- Run the tests and generate a test report
  ```bash
  dotnet test --logger "trx;LogFileName=TestExecution.trx" --results-directory ./bin/Debug/net8.0
  ```

- Generate LivingDoc report
  ```bash
  livingdoc test-assembly ./bin/Debug/net8.0/Tests.dll -t ./bin/Debug/net8.0/TestExecution.json --output ./bin/Debug/net8.0/LivingDocReport.html
  ```


- Open the LivingDoc report
  ```bash
  start ./bin/Debug/net8.0/LivingDocReport.html
  ```

- Run the tests with a filter
  ```bash
  dotnet test --filter "FullyQualifiedName~ValidateGlobalSearchWorksAsExpected"
  ```

- Run the tests with a tag
  ```bash
  dotnet test --filter TestCategory=smoke
  ```


- Run all tests with API category
    ```bash
    dotnet test --filter "Category=API"
    ```

### Author

[Sebastian Agudelo Morales](https://www.linkedin.com/in/sebastianamo) 