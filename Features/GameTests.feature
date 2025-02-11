Feature: Game Functionality
    As a player
    I want to interact with the game
    So that I can play and enjoy it

Scenario: Open the game URL
    Given I open the game URL
    Then the game page should load successfully

Scenario: Start the game
    Given I open the game URL
    When I click the Play button
    Then the overlay should be hidden