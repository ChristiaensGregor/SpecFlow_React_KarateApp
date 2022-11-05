Feature: NavigationUnknownUser

Bob a new user visits the site and navigates between the different navigation menu items.
Bob is not logged in and should be blocked from viewing Lessons and Users.
Bob should receive a clear indicator that he should first log-in before acessing those pages.

@navigation_not_loged_in
Scenario: [Bob can navigate to the home page]
	When [Bob clicks on the app name in the navigation bar]
	Then [Bob is navigated to the home page]

@navigation_not_loged_in
Scenario: [Bob can navigate to the login page]
	Given [Bob is on the home page]
	When [Bob clicks on the Login setting]
	Then [Bob is navigated to the login page]

@navigation_not_loged_in
Scenario: [Bob can't navigate to the lessons page]
	Given [Bob is on the home page]
	When [Bob clicks on the Lessons button in the navigation bar]
	Then [Bob is not navigated to the Lessons page]
	Then [Bob is automatically navigated to the login page]

@navigation_not_loged_in
Scenario: [Bob can't navigate to the Users page]
	Given [Bob is on the home page]
	When [Bob clicks on the Users button in the navigation bar]
	Then [Bob is not navigated to the Users page]
	Then [Bob is automatically navigated to the login page]