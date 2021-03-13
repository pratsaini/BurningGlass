Feature: Chat with customer care
	A user tries to chat with customer care from landing page

@smoke
Scenario: A site visitor in the landing page and opens the chat box
	Given User navigates to "home" page
	When User clicks on Chat button
	Then the chat box should open
	And User can <action> the chat box

	Examples: 
	| action  |
	| write in|
	| minimze |
