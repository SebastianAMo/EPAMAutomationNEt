Feature: Search for a position based on criteria
  As a user
  I want to be able to search for a job position based on criteria such as keywords and location
  So that I can apply to relevant positions that match my interests

  @smoke
  Scenario: Validate that the user can search for a position based on criteria
    Given I am on the EPAM homepage
    When I select the Career nav menu option
    And I check Remote in the Job Type field
    And I enter "<ProgrammingLanguage>" in the Keywords field
    And I select "<Location>" in the Location field
    And I click on the Find button
    And I click the latest job posting in the list
    Then I should see the programming language "<ProgrammingLanguage>" mentioned on the job application page

    Examples:
      | ProgrammingLanguage | Location   |
      | Java               | All Locations |
      | Python             | All Locations |
      | C#                 | All Locations |