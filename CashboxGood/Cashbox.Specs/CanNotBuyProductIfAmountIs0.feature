#// TODO 7: Write test to check that account can't buy product if it's amount is 0. Purchase should throw an exception. Fix code if test fails.
Feature: CanNotBuyProductIfAmountIs0
Scenario: Check that account can't buy product if it's amount is 0. Purchase should throw an exception
	Given I have an account
	And I am going to by product out of stock
	When I use service
	Then purchase should throw an exception