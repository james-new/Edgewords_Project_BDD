Feature: Purchasing items in the store

Background: 
		Given a user has logged on to the website
		And I have an item in my basket

Scenario: A user wants to use the 15% off coupon 
	When I apply the coupon 'edgewords'
	Then I get 15% off the item price


Scenario: A user purchases an item
	When I order the item
	Then the order number will be the same in my account as it is at the checkout 


