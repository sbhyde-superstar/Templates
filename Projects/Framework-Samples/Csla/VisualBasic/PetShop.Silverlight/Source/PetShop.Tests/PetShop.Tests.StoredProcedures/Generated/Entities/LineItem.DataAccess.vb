﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'LineItem.vb.
'
'     Template: SwitchableObject.DataAccess.StoredProcedures.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq

Imports Csla
Imports Csla.Data

Namespace PetShop.Tests.StoredProcedures
    Public Partial Class LineItem
    
#Region "Root Data Access"
    
        <RunLocal()> _
        Protected Overrides Sub DataPortal_Create()
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            BusinessRules.CheckRules()
    
            OnCreated()
        End Sub
    
        Private Shadows Sub DataPortal_Fetch(ByVal criteria As LineItemCriteria )
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_LineItem_Select]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            OnFetched()
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
                Using command As New SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters.AddWithValue("@p_LineNum", Me.LineNum)
				command.Parameters.AddWithValue("@p_ItemId", Me.ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Me.Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", Me.UnitPrice)
    
                    command.ExecuteNonQuery()
    
                    Using (BypassPropertyChecks)
                    End Using
                End Using
                
                _originalOrderId = Me.OrderId
                _originalLineNum = Me.LineNum
    
                FieldManager.UpdateChildren(Me, connection)
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
    
            If Not OriginalOrderId = OrderId Or Not OriginalLineNum = LineNum Then
                ' Insert new child.
                Dim item As New LineItem()
                item.OrderId = OrderId
			item.LineNum = LineNum
			item.ItemId = ItemId
			item.Quantity = Quantity
			item.UnitPrice = UnitPrice
                item = item.Save()
    
                ' Mark child lists as dirty. This code may need to be updated to one-to-one relationships.
    
                ' Create a new connection.
                Using connection As New SqlConnection(ADOHelper.ConnectionString)
                    connection.Open()
                    FieldManager.UpdateChildren(Me, connection)
                End Using
    
                ' Delete the old.
                Dim criteria As New LineItemCriteria()
                criteria.OrderId = OriginalOrderId
			criteria.LineNum = OriginalLineNum
                DataPortal_Delete(criteria)
    
                ' Mark the original as the new one.
                OriginalOrderId = OrderId
                OriginalLineNum = LineNum
                OnUpdated()
    
                Return
            End If
    
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_LineItem_Update]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@p_OriginalOrderId", Me.OriginalOrderId)
				command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters.AddWithValue("@p_OriginalLineNum", Me.OriginalLineNum)
				command.Parameters.AddWithValue("@p_LineNum", Me.LineNum)
				command.Parameters.AddWithValue("@p_ItemId", Me.ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Me.Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", Me.UnitPrice)
    
                    'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    Dim result As Integer = command.ExecuteNonQuery()
                    If (result = 0) Then
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
    
                _originalOrderId = Me.OrderId
                _originalLineNum = Me.LineNum
                End Using
    
                FieldManager.UpdateChildren(Me, connection)
            End Using
    
            OnUpdated()
        End Sub
    
        Protected Overrides Sub DataPortal_DeleteSelf()
            Dim cancel As Boolean = False
            OnSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New LineItemCriteria (_orderId, _lineNum))
        
            OnSelfDeleted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Shadows Sub DataPortal_Delete(ByVal criteria As LineItemCriteria )
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_LineItem_Delete]", connection)
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
    
        '<Transactional(TransactionalTypes.TransactionScope)> _
        Protected Shadows Sub DataPortal_Delete(ByVal criteria As LineItemCriteria, ByVal connection As SqlConnection)
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using command As New SqlCommand("[dbo].[CSLA_LineItem_Delete]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
    
                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
            End Using
    
            OnDeleted()
        End Sub
    
#End Region
    
#Region "Child Data Access"
    
        <RunLocal()> _
        Protected Overrides Sub Child_Create()
            Dim cancel As Boolean = False
            OnChildCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            BusinessRules.CheckRules()
    
            OnChildCreated()
        End Sub
        
        Private Sub Child_Fetch(ByVal criteria As LineItemCriteria)
            Dim cancel As Boolean = False
            OnChildFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_LineItem_Select]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            OnChildFetched()
            MarkAsChild()
        End Sub
    
#Region "Child_Insert"
    
        Private Sub Child_Insert(ByVal connection as SqlConnection)
            Dim cancel As Boolean = False
            OnChildInserting(connection, cancel)
            If (cancel) Then
                Return
            End If
    
            If Not (connection.State = ConnectionState.Open) Then connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters.AddWithValue("@p_LineNum", Me.LineNum)
				command.Parameters.AddWithValue("@p_ItemId", Me.ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Me.Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", Me.UnitPrice)
    
                command.ExecuteNonQuery()
    
    
                ' Update the original non-identity primary key value.
                _originalOrderId = Me.OrderId
    
                ' Update the original non-identity primary key value.
                _originalLineNum = Me.LineNum
    
            End Using
    
            FieldManager.UpdateChildren(Me, connection)
    
            OnChildInserted()
        End Sub
    
        Private Sub Child_Insert(ByVal order As Order, ByVal connection As SqlConnection)
            Dim cancel As Boolean = False
            OnChildInserting(connection, cancel)
            If (cancel) Then
                Return
            End If
    
            If Not (connection.State = ConnectionState.Open) Then connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OrderId", If(Not(order Is Nothing), order.OrderId, Me.OrderId))
				command.Parameters.AddWithValue("@p_LineNum", Me.LineNum)
				command.Parameters.AddWithValue("@p_ItemId", Me.ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Me.Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", Me.UnitPrice)
    
                command.ExecuteNonQuery()
    
    
                ' Update the original non-identity primary key value.
                _originalOrderId = Me.OrderId
    
                ' Update the original non-identity primary key value.
                _originalLineNum = Me.LineNum
    
            End Using
    
            ' A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            ' TODO: Please override OnChildInserted() and insert this child manually.
            'FieldManager.UpdateChildren(Me, connection)
    
            OnChildInserted()
        End Sub
    
    
#End Region
    
#Region "Child_Update"
    
        Private Sub Child_Update(ByVal connection as SqlConnection)
            Dim cancel As Boolean = False
            OnChildUpdating(connection, cancel)
            If (cancel) Then
                Return
            End If
    
            If Not connection.State = ConnectionState.Open Then connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_LineItem_Update]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OriginalOrderId", Me.OriginalOrderId)
				command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters.AddWithValue("@p_OriginalLineNum", Me.OriginalLineNum)
				command.Parameters.AddWithValue("@p_LineNum", Me.LineNum)
				command.Parameters.AddWithValue("@p_ItemId", Me.ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Me.Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", Me.UnitPrice)
    
                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
    
                ' Update non-identity primary key value.
                _orderId = DirectCast(command.Parameters("@p_OrderId").Value, System.Int32)
                ' Update non-identity primary key value.
                _lineNum = DirectCast(command.Parameters("@p_LineNum").Value, System.Int32)
                ' Update non-identity primary key value.
                _originalOrderId = Me.OrderId
                ' Update non-identity primary key value.
                _originalLineNum = Me.LineNum
            End Using
            FieldManager.UpdateChildren(Me, connection)
    
            OnChildUpdated()
        End Sub
    
        Private Sub Child_Update(ByVal order As Order, ByVal connection As SqlConnection)
            Dim cancel As Boolean = False
            OnChildUpdating(connection, cancel)
            If (cancel) Then
                Return
            End If
    
            If Not connection.State = ConnectionState.Open Then connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_LineItem_Update]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OriginalOrderId", If(Not(order Is Nothing), order.OrderId, Me.OriginalOrderId))
				command.Parameters.AddWithValue("@p_OrderId", If(Not(order Is Nothing), order.OrderId, Me.OrderId))
				command.Parameters.AddWithValue("@p_OriginalLineNum", Me.OriginalLineNum)
				command.Parameters.AddWithValue("@p_LineNum", Me.LineNum)
				command.Parameters.AddWithValue("@p_ItemId", Me.ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Me.Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", Me.UnitPrice)
    
                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
    
                ' Update non-identity primary key value.
                _orderId = DirectCast(command.Parameters("@p_OrderId").Value, System.Int32)
                ' Update non-identity primary key value.
                _lineNum = DirectCast(command.Parameters("@p_LineNum").Value, System.Int32)
    
                'Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                If(Not IsNothing(order) AndAlso Not order.OrderId = Me.OrderId) Then
                        _orderId = order.OrderId
                End If
                ' Update non-identity primary key value.
                _originalOrderId = Me.OrderId
                ' Update non-identity primary key value.
                _originalLineNum = Me.LineNum
            End Using
            ' A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            ' TODO: Please override OnChildUpdated() and update this child manually.
            'FieldManager.UpdateChildren(Me, connection)
    
            OnChildUpdated()
        End Sub
    
    
#End Region
    
        Private Sub Child_DeleteSelf()
            Dim cancel As Boolean = False
            OnChildSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New LineItemCriteria (_orderId, _lineNum))
        
            OnChildSelfDeleted()
        End Sub
    
        Private Sub Child_DeleteSelf(ParamArray args As Object())
        Dim connection As SqlConnection = args.OfType(Of SqlConnection)().FirstOrDefault()
        If connection Is Nothing Then
            Throw New ArgumentNullException("args", "Must contain a SqlConnection parameter.")
        End If
        
            Dim cancel As Boolean = False
            OnChildSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New LineItemCriteria (_orderId, _lineNum), connection)
        
            OnChildSelfDeleted()
        End Sub
    
#End Region
    
        Private Sub Map(ByVal reader As SafeDataReader)
            Dim cancel As Boolean = False
            OnMapping(reader, cancel)
            If (cancel) Then
                Return
            End If
    
            Using(BypassPropertyChecks)
                _orderId = reader.GetInt32("OrderId")
                _originalOrderId = reader.GetInt32("OrderId")
                _lineNum = reader.GetInt32("LineNum")
                _originalLineNum = reader.GetInt32("LineNum")
                _itemId = reader.GetString("ItemId")
                _quantity = reader.GetInt32("Quantity")
                _unitPrice = reader.GetDecimal("UnitPrice")
            End Using
    
            OnMapped()
    
            MarkOld()
        End Sub
    End Class
End Namespace
