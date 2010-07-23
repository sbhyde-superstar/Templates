//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1872, CSLA Framework: v3.8.4.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Account.cs'.
//
//     Template: ObjectFactory.DataAccess.ParameterizedSQL.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;
using Csla.Server;

using PetShop.Tests.ObjF.ParameterizedSQL;

#endregion

namespace PetShop.Tests.ObjF.ParameterizedSQL.DAL
{
    public partial class AccountFactory : ObjectFactory
    {
        #region Create

        /// <summary>
        /// Creates new Account with default values.
        /// </summary>
        /// <returns>new Account.</returns>
        [RunLocal]
        public Account Create()
        {
            var item = (Account)Activator.CreateInstance(typeof(Account), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            using (BypassPropertyChecks(item))
            {
                // Default values.
            }

            CheckRules(item);
            MarkNew(item);
            MarkAsChild(item);
            OnCreated();

            return item;
        }

        /// <summary>
        /// Creates new Account with default values.
        /// </summary>
        /// <returns>new Account.</returns>
        [RunLocal]
        private Account Create(AccountCriteria criteria)
        {
            var item = (Account)Activator.CreateInstance(typeof(Account), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            var resource = Fetch(criteria);
            using (BypassPropertyChecks(item))
            {
                item.Email = resource.Email;
                item.FirstName = resource.FirstName;
                item.LastName = resource.LastName;
                item.Address1 = resource.Address1;
                item.Address2 = resource.Address2;
                item.City = resource.City;
                item.State = resource.State;
                item.Zip = resource.Zip;
                item.Country = resource.Country;
                item.Phone = resource.Phone;
            }

            CheckRules(item);
            MarkNew(item);
            MarkAsChild(item);

            OnCreated();

            return item;
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Fetch Account.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public Account Fetch(AccountCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return null;

            Account item;
            string commandText = string.Format("SELECT [AccountId], [UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone] FROM [dbo].[Account] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if (reader.Read())
                            item = Map(reader);
                        else
                            throw new Exception(String.Format("The record was not found in 'Account' using the following criteria: {0}.", criteria));
                    }
                }
            }

            MarkAsChild(item);
            OnFetched();
            return item;
        }

        #endregion

        #region Insert

        private void DoInsert(ref Account item, bool stopProccessingChildren)
        {
            // Don't update if the item isn't dirty.
            if (!item.IsDirty) return;

            bool cancel = false;
            OnInserting(ref cancel);
            if (cancel) return;

            const string commandText = "INSERT INTO [dbo].[Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone]) VALUES (@p_UniqueID, @p_Email, @p_FirstName, @p_LastName, @p_Address1, @p_Address2, @p_City, @p_State, @p_Zip, @p_Country, @p_Phone); SELECT [AccountId] FROM [dbo].[Account] WHERE AccountId = SCOPE_IDENTITY()";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_UniqueID", item.UniqueID);
					command.Parameters.AddWithValue("@p_Email", item.Email);
					command.Parameters.AddWithValue("@p_FirstName", item.FirstName);
					command.Parameters.AddWithValue("@p_LastName", item.LastName);
					command.Parameters.AddWithValue("@p_Address1", item.Address1);
					command.Parameters.AddWithValue("@p_Address2", ADOHelper.NullCheck(item.Address2));
					command.Parameters.AddWithValue("@p_City", item.City);
					command.Parameters.AddWithValue("@p_State", item.State);
					command.Parameters.AddWithValue("@p_Zip", item.Zip);
					command.Parameters.AddWithValue("@p_Country", item.Country);
					command.Parameters.AddWithValue("@p_Phone", ADOHelper.NullCheck(item.Phone));

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                            item.AccountId = reader.GetInt32("AccountId");
                        }
                    }
                }
            }


            MarkOld(item);
            CheckRules(item);
            
            if(!stopProccessingChildren)
            {
            // Update Child Items.
                Update_Profile_ProfileMember_UniqueID(ref item);
            }

            OnInserted();
        }

        #endregion

        #region Update

        [Transactional(TransactionalTypes.TransactionScope)]
        public Account Update(Account item)
        {
            return Update(item, false);
        }

        public Account Update(Account item, bool stopProccessingChildren)
        {
            if(item.IsDeleted)
            {
                DoDelete(ref item);
                MarkNew(item);
            }
            else if(item.IsNew)
            {
                DoInsert(ref item, stopProccessingChildren);
            }
            else
            {
                DoUpdate(ref item, stopProccessingChildren);
            }

            return item;
        }

        private void DoUpdate(ref Account item, bool stopProccessingChildren)
        {
            bool cancel = false;
            OnUpdating(ref cancel);
            if (cancel) return;

            // Don't update if the item isn't dirty.
            if (item.IsDirty)
            {
                const string commandText = "UPDATE [dbo].[Account]  SET [UniqueID] = @p_UniqueID, [Email] = @p_Email, [FirstName] = @p_FirstName, [LastName] = @p_LastName, [Address1] = @p_Address1, [Address2] = @p_Address2, [City] = @p_City, [State] = @p_State, [Zip] = @p_Zip, [Country] = @p_Country, [Phone] = @p_Phone WHERE [AccountId] = @p_AccountId";
                using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@p_AccountId", item.AccountId);
					command.Parameters.AddWithValue("@p_UniqueID", item.UniqueID);
					command.Parameters.AddWithValue("@p_Email", item.Email);
					command.Parameters.AddWithValue("@p_FirstName", item.FirstName);
					command.Parameters.AddWithValue("@p_LastName", item.LastName);
					command.Parameters.AddWithValue("@p_Address1", item.Address1);
					command.Parameters.AddWithValue("@p_Address2", ADOHelper.NullCheck(item.Address2));
					command.Parameters.AddWithValue("@p_City", item.City);
					command.Parameters.AddWithValue("@p_State", item.State);
					command.Parameters.AddWithValue("@p_Zip", item.Zip);
					command.Parameters.AddWithValue("@p_Country", item.Country);
					command.Parameters.AddWithValue("@p_Phone", ADOHelper.NullCheck(item.Phone));

                        using(var reader = new SafeDataReader(command.ExecuteReader()))
                        {
                            //RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                            if(reader.RecordsAffected == 0)
                                throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
    
                            if(reader.Read())
                            {
                                item.AccountId = reader.GetInt32("AccountId");
                            }
                        }
                    }
                }
            }


            MarkOld(item);
            CheckRules(item);

            if(!stopProccessingChildren)
            {
                // Update Child Items.
                Update_Profile_ProfileMember_UniqueID(ref item);
            }

            OnUpdated();
        }
        #endregion

        #region Delete

        [Transactional(TransactionalTypes.TransactionScope)]
        public void Delete(AccountCriteria criteria)
        {
            // Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
            DoDelete(criteria);
        }

        protected void DoDelete(ref Account item)
        {
            // If we're not dirty then don't update the database.
            if (!item.IsDirty) return;

            // If we're new then don't call delete.
            if (item.IsNew) return;

            var criteria = new AccountCriteria{AccountId = item.AccountId};
            
            DoDelete(criteria);

            MarkNew(item);
        }

        /// <summary>
        /// This call to delete is for immediate deletion and doesn't keep track of any entity state.
        /// </summary>
        /// <param name="criteria">The Criteria.</param>
        private void DoDelete(AccountCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("DELETE FROM [dbo].[Account] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnDeleted();
        }

        #endregion

        #region Helper Methods

        public Account Map(SafeDataReader reader)
        {
            var item = (Account)Activator.CreateInstance(typeof(Account), true);
            using (BypassPropertyChecks(item))
            {
                item.AccountId = reader.GetInt32("AccountId");
                item.UniqueID = reader.GetInt32("UniqueID");
                item.Email = reader.GetString("Email");
                item.FirstName = reader.GetString("FirstName");
                item.LastName = reader.GetString("LastName");
                item.Address1 = reader.GetString("Address1");
                item.Address2 = reader.GetString("Address2");
                item.City = reader.GetString("City");
                item.State = reader.GetString("State");
                item.Zip = reader.GetString("Zip");
                item.Country = reader.GetString("Country");
                item.Phone = reader.GetString("Phone");
            }
            
            MarkOld(item);

            return item;
        }

        //AssociatedManyToOne
        private static void Update_Profile_ProfileMember_UniqueID(ref Account item)
        {
				item.ProfileMember.UniqueID = item.UniqueID;

            new ProfileFactory().Update(item.ProfileMember, true);
        }

        #endregion

        #region DataPortal partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(AccountCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnMapping(SafeDataReader reader, ref bool cancel);
        partial void OnMapped();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(AccountCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion
    }
}