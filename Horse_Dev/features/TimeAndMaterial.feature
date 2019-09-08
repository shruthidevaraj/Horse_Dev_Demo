Feature: TimeAndMaterialFeature
TimeAndMaterialFeature tests
	  

@mytag
	Scenario: Login as an admin and should be able to create a time and material
	Given I have Logged into the portal
	And I have to navigate to Time and material page
	Then I should be able to create time and material sucessfully

	Scenario: Login as an admin and validate if the created Time/Material item is present or not
	Given I have Logged into the portal
	And I have to navigate to Time and material page 
	Then search for particular Time/Material Item and verify if Time/Material is present

	Scenario: Login as an admin and edit the Time/Material item 
	Given I have Logged into the portal
	And I have to navigate to Time and material page
	And I have to search for Item which needs to be edited 
	Then  Edit and save it and verify if the Time/material item is edited

	Scenario: Login as an admin and delete the Time/Material item 
	Given I have Logged into the portal
	And I have to navigate to Time and material page
	And I have to search for Item which needs to be deleted and delete it
	Then verify if Time/Material is deleted
