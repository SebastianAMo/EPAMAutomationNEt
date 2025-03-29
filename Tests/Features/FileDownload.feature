Feature: File download functionality
  As a user
  I want to download files from the EPAM website
  So that I can access relevant documents

  Scenario: Validate file download function works as expected
    Given I am on the EPAM homepage
    When I select the About nav menu option
    And I scroll down to the EPAM at a Glance section
    And I click on the Download button
    Then I should wait until the file "EPAM_Corporate_Overview_Q4FY-2024.pdf" is downloaded