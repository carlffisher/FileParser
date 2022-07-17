An unfinished program that parse a CSV file, performs LINQ queries on the result and passes the subsequnt result as an ArrayList for output to screen.

System IO services reads each line of the CSV file into class CSVValues which splits each CSV line into its constituent fields.
Each field is assigned to an element containing individually defined strings.

These values are then sent along with a query id to class CollectionOfQueries which performs a LINQ query on the values and returns the result as an ArrayList.
This is output to screen.



