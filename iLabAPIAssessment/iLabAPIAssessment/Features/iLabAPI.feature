Feature: iLabAPI
	ilAB Assessment

@iLabTag
Scenario: Get Avalable pet  list and confirm if the list has required name and category id
	Given I set the required endpoint
	When I submit a GET request to list all available pets
	And I confirm the list has the name '<name>' with category id '<categoryId>'  
	
Examples:	
	| name   | categoryId |
	| string | 0          |
	| string | 12         |


Scenario: Add new pet with auto generated name and status available and retrieve pet using the category id
	Given I set the required endpoint
	When I set up the body and submit POST request with name, category Id '<categoryId>' and status '<status>'
	And I confirm the json has the name with category id '<categoryId>' 
	Then I should see new pet on the list
	When I submit GET request in get pets by category id
	Then I should see pet is returned from request with name
	
Examples:	
	| categoryId | status    |
	| 62         | available |



	


