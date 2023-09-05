Feature: Exceptions handler

Scenario: Registered NotFound exception return not found response
	Given NotFound Exception is register in builder exception mapper with status code 404
	And NotFound Exception title is "Not found"
	When  NotFound Exception is throw with message "One item not found" in the ExceptionHandlerMiddleware
	Then  Response title is "Not found", Detail is "One item not found" Status code is 404
	And Response detail length is 0

Scenario: Registered Invalid data exception return invalid data exception
	Given Invalid data exception in builder exception mapper with status code 400
	And Invalid data exception title is "Bad request"
	And Field "Username" has error "Username must have 3 difits"
	When  Invalid data exception is throw with message "Invalid data" in the ExceptionHandlerMiddleware
	Then  Response title is "Bad request", Detail is "Invalid data" Status code is 400
	And Response detail length is 1
	And First Detail is "Username" and "Username must have 3 difits"

