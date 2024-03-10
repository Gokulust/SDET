Feature: Search

A short summary of the feature

@Product-Search
Scenario: Search For Products
	Given User Will be on the Homepage
	When User will type the '<Searchtext>' in the searchbox
	And User clicks on search button
	Then Search results are loaded in the same page with '<Searchtext>'
Examples: 
	| Searchtext | 
	| water      | 
	| java       |
	| hairgrass  |
