Feature: Login
	Valid Login test 

@login@automate
Background, Scenario Outline: On passing the valid user name and password Should be login successfully
	Given Launch the chrome browser and navigate to the portal 
	When I have entered a valid <Username> and <Password> 
	And click on login button
	Then Login successfully and should be  on the Home page
	Examples: 
	| Username | Password |
	| hari     | 123123   |

	#Research about background and scenario outline - specflow

@logn@automate
Scenario Outline:On passing the user name and  password login should fail
	Given Launch the chrome browser and navigate to the portal 
	When User enter a invalid  <Username> and  <Password> 
	And click on login button
	Then Login should fail and stay on login page
	Examples: 
	| Username | Password |
	| hari     | 1435123  |