Feature: KarateLessons

The user can access the list of lessonst.
This list can contain both passed and future.
From the list the user should be able to derrive the date, location and type of each lesson.

Background: 
Given Bob is logged in


@tag1
Scenario: Bob can view the title of the first lesson
	When Bob clicks on the Lessons tab
	Then The application navigates to the lesson list
	And The first lesson is Expired
