﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'LineItemList.vb.
'
'     Template: EditableRootList.DataAccess.ParameterizedSQL.cst
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

Namespace PetShop.Tests.ParameterizedSQL
    Public Partial Class LineItemList
    
        <RunLocal()> _
        Protected Overrides Sub DataPortal_Create()
        End Sub
    
        Private Shadows Sub DataPortal_Fetch(ByVal criteria As LineItemCriteria)
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            RaiseListChangedEvents = False
    
            ' Fetch Child objects.
            Dim commandText As String = String.Format("SELECT [OrderId], [LineNum], [ItemId], [Quantity], [UnitPrice] FROM [dbo].[LineItem] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Do
                                Me.Add(New PetShop.Tests.ParameterizedSQL.LineItem(reader))
                            Loop While reader.Read()
                        End If
                    End Using
                End Using
            End Using
    
            RaiseListChangedEvents = True
    
            OnFetched()
        End Sub

        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Update()
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
    
            RaiseListChangedEvents = False
    
            For index As Integer = 0 To DeletedList.Count - 1
            DeletedList(index) = DeletedList(index).Save()
        Next
    
        DeletedList.Clear()
    
        For index As Integer = 0 To Items.Count - 1
            Items(index) = Items(index).Save()
        Next
    
    
            RaiseListChangedEvents = True
    
            OnUpdated()
        End Sub
    End Class
End Namespace
