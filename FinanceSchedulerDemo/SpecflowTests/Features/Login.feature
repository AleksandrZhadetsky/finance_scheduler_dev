Feature: Login
	Login to FIN App

@NeedsSelenium
Scenario: Sign In in the FIN App and see to user account page
	Given I launch the app
	And I click the Sign In button
	And I enter the following credentials
	| Username | Password |
	| administrator | administrator |
	And I click submit button button
	Then I should see the user account page