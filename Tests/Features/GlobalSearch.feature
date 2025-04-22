Feature: Global search functionality
  As a user
  I want to use the global search to find relevant content
  So that I can find articles and resources related to specific topics

  @smoke
  Scenario: Validate global search works as expected
    Given I am on the EPAM homepage
    When I click on the magnifier icon
    And I enter "<SearchTerm>" in the search input field
    And I click the "Find" button
    Then I should see a list of search results
    And all the links in the search results should contain "<SearchTerm>" in the text

    Examples:
      | SearchTerm   |
      | BLOCKCHAIN   |
      | Cloud        |
      | Automation   |