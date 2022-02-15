using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using Dapper;
using backend.Domain;

namespace backend.DataAccess
{
    public static class SQLiteDataAccess
    {
        private static SQLiteConnection CreateDbConnection()
        {
            return new SQLiteConnection(GetConnectionString());
        }
        private static string GetConnectionString(string connStringName = "Default") {
            return ConnectionStrings.Instance.Default;
        }

        public static void SaveTransaction(string transactionId, Transaction newTransaction)
        {
            using (SQLiteConnection conn = CreateDbConnection())
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        DynamicParameters insParams = new DynamicParameters();
                        insParams.Add("Transaction_Id", transactionId);
                        insParams.Add("Account_Id", newTransaction.Account_Id);
                        insParams.Add("Amount", newTransaction.Amount);

                        conn.Execute("delete from Transactions where transaction_id = @Transaction_Id", insParams);

                        conn.Execute("insert into Transactions(transaction_id, account_id, amount) values (@Transaction_Id, @Account_Id, @Amount)", insParams);

                        transaction.Commit();
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static bool TryGetTransaction(string transactionId, out Transaction transaction)
        {
            using SQLiteConnection conn = CreateDbConnection();
            try
            {
                DynamicParameters queryParams = new DynamicParameters();
                queryParams.Add("transactionId", transactionId);
                IEnumerable <Transaction> results = conn.Query<Transaction>("select * from Transactions where transaction_id = @transactionId", queryParams);
                transaction = results.FirstOrDefault();
                return (transaction != null);
            }
            catch (SQLiteException ex)
            {
                transaction = null;
                return false;
            }
        }

        public static MaxTransactionVolume GetMaxTransactionVolume()
        {
            using SQLiteConnection conn = CreateDbConnection();
            try
            {
                var results = conn.Query("select * from MaxTrVolumeAccounts", new DynamicParameters());
                if (results.Count() == 0)
                    return null;
                int maxVolume = Convert.ToInt32((results.First() as IDictionary<string, object>)["volume"]);
                List<string> accounts = results.Select(row => (row as IDictionary<string, object>)["account_id"] as string).ToList<string>();
                return new MaxTransactionVolume(maxVolume, accounts);
            }
            catch (SQLiteException ex)
            {
                return new MaxTransactionVolume();
            }
        }

        public static bool TryGetAccountBalance(string accountId, out int balance)
        {
            using SQLiteConnection conn = CreateDbConnection();
            try
            {
                DynamicParameters queryParams = new DynamicParameters();
                queryParams.Add("accountId", accountId);
                IEnumerable<int> result = conn.Query<int>("select amount from Balance where account_id = @accountId", queryParams);
                if (result.Count() == 0)
                {
                    balance = 0;
                    return false;
                }
                balance = result.First();
                return true;
            }
            catch (SQLiteException ex)
            {
                balance = 0;
                return false;
            }
        }
    }
}
