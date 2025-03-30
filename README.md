# Task Selenium WebDriver with SpecFlow

## Test Cases
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


## Commands

The following commands are used to run the project

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
  dotnet test --filter TestCategory=important
  ```

### Author

[Sebastian Agudelo Morales](https://www.linkedin.com/in/sebastianamo) 