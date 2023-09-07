Feature: PagedList

Background: 
	Given The following array is provide for pagination
		| Data |
		| 1    |
		| 2    |
		| 3    |
		| 4    |
		| 5    |
		| 6    |
		| 7    |
		| 8    |

Scenario Outline: Pagination list give consistant data
	When Pagination list is created with <pageNumber> and <pageSize>
	Then Pagination list must have pageSize = <lPageSize>
	* Page number = <lPageNumber>
	* Current page size = <CurrentPageSize>
	* Current start index = <CurrentStartIndex>
	* Current end index = <CurrentEndIndex>
	* Total page = <lTotalPages>
	* Has previous is <hasPrevious>
	* Has next is <hasNext>

	Examples: 
	| pageNumber | pageSize | totalCount | lPageSize | lPageNumber | CurrentPageSize | CurrentStartIndex | CurrentEndIndex | lTotalPages | hasPrevious | hasNext |
	| 2          | 2        | 8          | 2         | 2           | 2               | 3                 | 4               | 4           | 1           | 1       |
	| 1          | 8        | 8          | 8         | 1           | 8               | 1                 | 8               | 1           | 0           | 0       |
	| 2          | 6        | 8          | 6         | 2           | 2               | 7                 | 8               | 2           | 1           | 0       |
	