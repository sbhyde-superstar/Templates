﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v3.8.4.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.vb.
'
'     Template: DynamicRoot.DataAccess.StoredProcedures.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data

Namespace PetShop.Tests.Collections.DynamicRoot
    Public Partial Class Category
        <RunLocal()> _
        Protected Overrides Sub DataPortal_Create()
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            ValidationRules.CheckRules()
    
            OnCreated()
        End Sub
        Private Shadows Sub DataPortal_Fetch(ByVal criteria As CategoryCriteria )
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Category_Select]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    command.Parameters.AddWithValue("@p_NameHasValue", criteria.NameHasValue)
					command.Parameters.AddWithValue("@p_DescnHasValue", criteria.DescriptionHasValue)
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'Category' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            OnFetched()
    
            MarkOld()
        End Sub
        
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Insert()
            Dim cancel As Boolean = False
            OnInserting(cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Category_Insert]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@p_CategoryId", Me.CategoryId)
				command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(Me.Name))
				command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(Me.Description))
    
                    command.ExecuteNonQuery()
    
                    Using (BypassPropertyChecks)
                    End Using
                End Using
                
                LoadProperty(_originalCategoryIdProperty, Me.CategoryId)
            End Using
    
            OnInserted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Update()
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
    
            If Not OriginalCategoryId = CategoryId Then
                ' Insert new child.
                Dim item As New Category()
                item.CategoryId = CategoryId
			item.Name = Name
			item.Description = Description
                item = item.Save()
    
                ' Mark child lists as dirty. This code may need to be updated to one-to-one relationships.
    
                ' Create a new connection.
                Using connection As New SqlConnection(ADOHelper.ConnectionString)
                    connection.Open()
                    FieldManager.UpdateChildren(Me, connection)
                End Using
    
                ' Delete the old.
                Dim criteria As New CategoryCriteria()
                criteria.CategoryId = OriginalCategoryId
                DataPortal_Delete(criteria)
    
                ' Mark the original as the new one.
                OriginalCategoryId = CategoryId
                OnUpdated()
    
                Return
            End If
    
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Category_Update]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@p_OriginalCategoryId", Me.OriginalCategoryId)
				command.Parameters.AddWithValue("@p_CategoryId", Me.CategoryId)
				command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(Me.Name))
				command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(Me.Description))
    
                    'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    Dim result As Integer = command.ExecuteNonQuery()
                    If (result = 0) Then
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
    
                LoadProperty(_originalCategoryIdProperty, Me.CategoryId)
                End Using
            End Using
    
            OnUpdated()
        End Sub
    
        Protected Overrides Sub DataPortal_DeleteSelf()
            Dim cancel As Boolean = False
            OnSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New CategoryCriteria (CategoryId))
        
            OnSelfDeleted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Shadows Sub DataPortal_Delete(ByVal criteria As CategoryCriteria )
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Category_Delete]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
    
                    'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    Dim result As Integer = command.ExecuteNonQuery()
                    If (result = 0) Then
                        Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
                End Using
            End Using
    
            OnDeleted()
        End Sub
    
        Private Sub Map(ByVal reader As SafeDataReader)
            Dim cancel As Boolean = False
            OnMapping(reader, cancel)
            If (cancel) Then
                Return
            End If
    
            Using(BypassPropertyChecks)
                LoadProperty(_categoryIdProperty, reader.Item("CategoryId"))
                LoadProperty(_originalCategoryIdProperty, reader.Item("CategoryId"))
                LoadProperty(_nameProperty, reader.Item("Name"))
                LoadProperty(_descriptionProperty, reader.Item("Descn"))
            End Using
    
            OnMapped()
    
            MarkOld()
        End Sub
    End Class
End Namespace
