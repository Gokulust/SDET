Feature: GoogleSearch

To Pefrom search operation on google home page
@tag1
Scenario: to perfome search with google search button
	Given Google home page should be loaded
	When Type "hp laptop" in the search text input
	And  Click on the google search button 
	Then The results should be displayed on the next page with title "hp laptop - Google Search"

Scenario: TO perform search with IMFL button
	Given Google home page should be loaded
	When Type "hp laptop" in the search text input
	And  Click on the IMFL button
	Then The results should be redirected to a new page with title "hp laptop"

