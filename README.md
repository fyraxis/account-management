### The purpose 
- To provide the account management api implementation according to the specs which define the operations that it is to support.
Starting point - a boilerplate project with a '/ping' endpoint to check the api is up and running and some integrated tests for the final functionality.

### How to run the application
- It can be used as any other normal C# API by using a client capable of making http calls. Otherwise during implementation the tool Postman was used to issue calls and test the functionality.

### Design considerations
- The backbone of the aplication is the database which contains one main table and 3 views that are used for storing, processing, aggregating the data for the purpose of making as few sql queries to the db as possible. 
- Table 
     - Transactions, Columns: Transaction_Id, Account_Id, Amount - is used to store all the transactions.
- Views
     - Balance, Columns: Account_id, Amount - This view is used to calculate the balance for each account based on the transactions entered.
     - MaxTransactionVolume, Columns: MaxVolume - Helper view used to determine, given the transactions available, the max volume for any account present.
     - MaxTrVolumeAccounts, Coumns: Account_Id, Volume - Given all the transactions in the system and data provided by the helper view from above it retrieves all the accounts which have the same max transaction volume.

- API Implementation
     - There are two controllers one for Transactions which focuses mainly on the transaction oriented operations and one for Accounts (which should focus on higher level operations related to the account, one such operation being the balance calculation).
     - The controllers are each backed by a specific repository (Transaction/Account Repository) that are represented in the controllers by their specific interfaces used to issue the calls to the underlying implementation for the operations.
     - The data access and management is handled through the SQLiteDataAccess class which provides simple bare bones implementation for methods for each specific API action. For ease of handling of the queries Dapper was also used. The calls to insert new transaction are encapsulated in db transactions in order to make sure the operations are consistent.
     - The ConnectionStrings singleton is used to map the connection string supplied in the configuration json file.
     - Only two simple models are used: - one to model the Transaction object used mainly for the validation of the data coming from the api calls through data annotations; - one to model the result of the max transaction volumes action in order to aggregate the results for all accounts under the same volume value
