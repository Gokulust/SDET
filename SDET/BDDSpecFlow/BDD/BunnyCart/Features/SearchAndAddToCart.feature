Feature: SearchAndAddToCart

A short summary of the feature

@E2E-Search_And_Add_To_Cart
Scenario Outline: 1 Search for products
	Given User will be on the home page
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
	Then The heading should have '<searchtext>'
	* Title should have '<searchtext>'
	When User selects a '<productno>'
	Then Product page is loaded
	When User clicks on the addtocart button
	Then Modal with viwecart appers
Examples: 
	| searchtext | productno |
	| water      | 2         |
	| java       | 5         |



