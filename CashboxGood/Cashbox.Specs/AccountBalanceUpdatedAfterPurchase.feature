#// TODO 6: Write test to check that account balance is correctly updated after purchase. Fix code if test fails.
Feature: AccountBalanceUpdatedAfterPurchase
	
Scenario: Check that account balance is correctly updated after purchase
	Given I have an account with 3 on balance
	And I am going to by product which price is 1
	And I buy product
	When I check account balance
	Then the result should be 2