Feature: RegisterNewStandardUser

Alice is a new user that wants to register on the application.

Scenario: [Alice registers on the registration page]
	Given [Alice is on the registration page]
	When [Alice fills in her email address]
	And [Alice fills in her password]
	And [Alice presses the register button]
	Then [Alice is registered]
	Then [Alice is redirected to the home page]
