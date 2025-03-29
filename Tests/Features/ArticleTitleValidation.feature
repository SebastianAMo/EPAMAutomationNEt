Feature: Validate title of the article in the carousel
  As a user
  I want to validate that the article title in the carousel matches the one I see when I click on it
  So that I can ensure the information is correct and consistent

  Scenario: Validate title of the article matches with title in the carousel
    Given I am on the EPAM homepage
    When I select the Insights menu option
    And I swipe the carousel 2 times and to the right
    And I click on the Read More button
    Then the title of the article should match the title I noted previously
