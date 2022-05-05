Feature: Purchasing items in the store

A short summary of the feature

@tag1
Scenario: A user wants to use the 15% off coupon 
	Given I have an item in my basket
	When I apply the coupon 'edgewords'
	Then I get 15% off the item price


Scenario: A user purchases an item
	Given I have an item in my basket 
	When I order the item
	Then the order number will be the same in my account as it is at the checkout 


