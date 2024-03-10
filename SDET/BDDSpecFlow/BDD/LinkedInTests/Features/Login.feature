Feature: Login

User logs in with valid credentials (username,password)
Home page will load after successful login

Background: 
	Given user will be on the login page

@positive
Scenario: Login with valid credentials
	Given user will enter '<UserName>'
	And User will enter '<Password>'
	When User will click On Login button
	Then User will redirected to home page
Examples: 
     | UserName         | Password |
     | gokul@gmail.com  | gokulraj |
     | vishnu@gmail.com | vishnu   |