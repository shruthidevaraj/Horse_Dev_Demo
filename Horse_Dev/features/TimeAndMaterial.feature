Feature: TimeAndMaterialFeature
	  

@mytag
Scenario: Login as an admin and should be able to create a time and material
	Given I have Lgged in to the portal
	And I have to navigate to Time and material page
	Then I should be able to create time and material sucessfully
