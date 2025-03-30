Feature: Services Section
  As a user
  I want to be able to review for services
  So that I can learn more about the services offered by EPAM

  Scenario: Validate Navigation to Services Section
    Given I am on the EPAM homepage
    When I hover over the "Services" menu
    And I select the "<Service>" option
	Then I should see the page with the title the "<Service>" 
    And the Our Related Expertise section should be displayed on the page

    Examples:
        | Service |
        | Generative AI |
        | Responsible AI |