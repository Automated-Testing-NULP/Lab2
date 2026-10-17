Feature: Customer Withdrawal

  Scenario: Successful withdrawal
    Given I navigate to the Banking application
    And I login as customer "Harry Potter"
    And I deposit 100 to my account
    When I withdraw 50 from my account
    Then I should see a "Transaction successful" message