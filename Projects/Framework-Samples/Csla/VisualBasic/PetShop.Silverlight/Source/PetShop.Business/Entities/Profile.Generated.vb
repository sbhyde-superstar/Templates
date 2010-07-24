﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Profile.vb.
'
'     Template: SwitchableObject.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Rules
#If SILVERLIGHT Then
Imports Csla.Serialization
#Else
Imports Csla.Data
Imports System.Data.SqlClient
#End If

Namespace PetShop.Business
    <Serializable()> _
    Public Partial Class Profile 
        Inherits BusinessBase(Of Profile)
    
#Region "Contructor(s)"
    
#If Not SILVERLIGHT Then
        Private Sub New()
            ' require use of factory method 
        End Sub
#Else
        public Sub New()
            ' require use of factory method 
        End Sub
#End If
    
        Friend Sub New(ByVal uniqueID As System.Int32)
            Using(BypassPropertyChecks)
            LoadProperty(_uniqueIDProperty, uniqueID)
            End Using
        End Sub
    
#If Not SILVERLIGHT Then
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
            MarkAsChild()   
        End Sub
#End If

#End Region    
    
#Region "Business Rules"
    
        Protected Overrides Sub AddBusinessRules()
    
            If AddBusinessValidationRules() Then Exit Sub
    
            BusinessRules.AddRule(New Csla.Rules.CommonRules.Required(_usernameProperty))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_usernameProperty, 256))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.Required(_applicationNameProperty))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_applicationNameProperty, 256))
        End Sub
    
#End Region

#Region "Properties"
    
        Private Shared ReadOnly _uniqueIDProperty As PropertyInfo(Of System.Int32) = RegisterProperty(Of System.Int32)(Function(p As Profile) p.UniqueID, String.Empty)
#If Not SILVERLIGHT Then
        
		<System.ComponentModel.DataObjectField(true, true)> _
        Public Property UniqueID() As System.Int32
#Else
        Public Property UniqueID() As System.Int32
#End If
            Get 
                Return GetProperty(_uniqueIDProperty)
            End Get
            Friend Set (ByVal value As System.Int32)
                SetProperty(_uniqueIDProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _usernameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Profile) p.Username, String.Empty)
#If Not SILVERLIGHT Then
        
        Public Property Username() As System.String
#Else
        Public Property Username() As System.String
#End If
            Get 
                Return GetProperty(_usernameProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_usernameProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _applicationNameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Profile) p.ApplicationName, String.Empty)
#If Not SILVERLIGHT Then
        
        Public Property ApplicationName() As System.String
#Else
        Public Property ApplicationName() As System.String
#End If
            Get 
                Return GetProperty(_applicationNameProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_applicationNameProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _isAnonymousProperty As PropertyInfo(Of System.Nullable(Of System.Boolean)) = RegisterProperty(Of System.Nullable(Of System.Boolean))(Function(p As Profile) p.IsAnonymous, String.Empty)
#If Not SILVERLIGHT Then
        
        Public Property IsAnonymous() As System.Nullable(Of System.Boolean)
#Else
        Public Property IsAnonymous() As System.Nullable(Of System.Boolean)
#End If
            Get 
                Return GetProperty(_isAnonymousProperty)
            End Get
            Set (ByVal value As System.Nullable(Of System.Boolean))
                SetProperty(_isAnonymousProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _lastActivityDateProperty As PropertyInfo(Of System.Nullable(Of System.DateTime)) = RegisterProperty(Of System.Nullable(Of System.DateTime))(Function(p As Profile) p.LastActivityDate, String.Empty)
#If Not SILVERLIGHT Then
        
        Public Property LastActivityDate() As System.Nullable(Of System.DateTime)
#Else
        Public Property LastActivityDate() As System.Nullable(Of System.DateTime)
#End If
            Get 
                Return GetProperty(_lastActivityDateProperty)
            End Get
            Set (ByVal value As System.Nullable(Of System.DateTime))
                SetProperty(_lastActivityDateProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _lastUpdatedDateProperty As PropertyInfo(Of System.Nullable(Of System.DateTime)) = RegisterProperty(Of System.Nullable(Of System.DateTime))(Function(p As Profile) p.LastUpdatedDate, String.Empty)
#If Not SILVERLIGHT Then
        
        Public Property LastUpdatedDate() As System.Nullable(Of System.DateTime)
#Else
        Public Property LastUpdatedDate() As System.Nullable(Of System.DateTime)
#End If
            Get 
                Return GetProperty(_lastUpdatedDateProperty)
            End Get
            Set (ByVal value As System.Nullable(Of System.DateTime))
                SetProperty(_lastUpdatedDateProperty, value)
            End Set
        End Property

        'AssociatedOneToMany
        Private Shared ReadOnly _accountsProperty As PropertyInfo(Of AccountList) = RegisterProperty(Of AccountList)(Function(p As Profile) p.Accounts, Csla.RelationshipTypes.Child)
    Public ReadOnly Property Accounts() As AccountList
            Get
                If Not (FieldManager.FieldExists(_accountsProperty)) Then
#If SILVERLIGHT Then
                    MarkBusy()
                    
                    Dim criteria As New PetShop.Business.AccountCriteria()
                    criteria.UniqueID = UniqueID

                    If (Me.IsNew OrElse Not PetShop.Business.AccountList.Exists(criteria)) Then
                        PetShop.Business.AccountList.NewListAsync(Sub(o, e)
                                If Not (e.Error Is Nothing) Then
                                    Throw e.Error
                                End If

                                Me.LoadProperty(_accountsProperty, e.Object)

                                MarkIdle()
                                OnPropertyChanged(_accountsProperty)
                            End Sub)
                    Else
                        PetShop.Business.AccountList.GetByUniqueIDAsync(UniqueID, Sub(o, e)
                                If Not (e.Error Is Nothing) Then
                                    Throw e.Error
                                End If

                                Me.LoadProperty(_accountsProperty, e.Object)

                                MarkIdle()
                                OnPropertyChanged(_accountsProperty)
                            End Sub)
                    End If
#Else
                    Dim criteria As New PetShop.Business.AccountCriteria()
                    criteria.UniqueID = UniqueID
    
                    If (Me.IsNew OrElse Not PetShop.Business.AccountList.Exists(criteria)) Then
                        LoadProperty(_accountsProperty, PetShop.Business.AccountList.NewList())
                    Else
                        LoadProperty(_accountsProperty, PetShop.Business.AccountList.GetByUniqueID(UniqueID))
                    End If
#End If
                End If
                
                Return GetProperty(_accountsProperty) 
            End Get
        End Property

        'AssociatedOneToMany
        Private Shared ReadOnly _cartsProperty As PropertyInfo(Of CartList) = RegisterProperty(Of CartList)(Function(p As Profile) p.Carts, Csla.RelationshipTypes.Child)
    Public ReadOnly Property Carts() As CartList
            Get
                If Not (FieldManager.FieldExists(_cartsProperty)) Then
#If SILVERLIGHT Then
                    MarkBusy()
                    
                    Dim criteria As New PetShop.Business.CartCriteria()
                    criteria.UniqueID = UniqueID

                    If (Me.IsNew OrElse Not PetShop.Business.CartList.Exists(criteria)) Then
                        PetShop.Business.CartList.NewListAsync(Sub(o, e)
                                If Not (e.Error Is Nothing) Then
                                    Throw e.Error
                                End If

                                Me.LoadProperty(_cartsProperty, e.Object)

                                MarkIdle()
                                OnPropertyChanged(_cartsProperty)
                            End Sub)
                    Else
                        PetShop.Business.CartList.GetByUniqueIDAsync(UniqueID, Sub(o, e)
                                If Not (e.Error Is Nothing) Then
                                    Throw e.Error
                                End If

                                Me.LoadProperty(_cartsProperty, e.Object)

                                MarkIdle()
                                OnPropertyChanged(_cartsProperty)
                            End Sub)
                    End If
#Else
                    Dim criteria As New PetShop.Business.CartCriteria()
                    criteria.UniqueID = UniqueID
    
                    If (Me.IsNew OrElse Not PetShop.Business.CartList.Exists(criteria)) Then
                        LoadProperty(_cartsProperty, PetShop.Business.CartList.NewList())
                    Else
                        LoadProperty(_cartsProperty, PetShop.Business.CartList.GetByUniqueID(UniqueID))
                    End If
#End If
                End If
                
                Return GetProperty(_cartsProperty) 
            End Get
        End Property

#End Region
    
#If Not SILVERLIGHT Then
#Region "Synchronous Root Factory Methods"
    
        Public Shared Function NewProfile() As Profile 
            Return DataPortal.Create(Of Profile)()
        End Function
    
        Public Shared Function GetByUniqueID(ByVal uniqueID As System.Int32) As Profile
            Dim criteria As New ProfileCriteria()
            criteria.UniqueID = uniqueID
    
            Return DataPortal.Fetch(Of Profile)(criteria)
        End Function
    
        Public Shared Function GetByUsernameApplicationName(ByVal username As System.String, ByVal applicationName As System.String) As Profile
            Dim criteria As New ProfileCriteria()
            criteria.Username = username
			criteria.ApplicationName = applicationName
    
            Return DataPortal.Fetch(Of Profile)(criteria)
        End Function
    
        Public Shared Sub DeleteProfile(ByVal uniqueID As System.Int32)
            DataPortal.Delete(Of Profile)(New ProfileCriteria (uniqueID))
        End Sub
    
#End Region
#End If        
    
#Region "Asynchronous Root Factory Methods"
            
        Public Shared Sub NewProfileAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.CreateCompleted, handler
            dp.BeginCreate()
        End Sub
    
        Public Shared Sub GetByUniqueIDAsync(ByVal uniqueID As System.Int32, ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.FetchCompleted, handler
        
            Dim criteria As New ProfileCriteria()
            criteria.UniqueID = uniqueID
    
            dp.BeginFetch(criteria)
        End Sub
    
        Public Shared Sub GetByUsernameApplicationNameAsync(ByVal username As System.String, ByVal applicationName As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.FetchCompleted, handler
        
            Dim criteria As New ProfileCriteria()
            criteria.Username = username
            criteria.ApplicationName = applicationName
    
            dp.BeginFetch(criteria)
        End Sub
    
        Public Shared Sub DeleteProfileAsync(ByVal uniqueID As System.Int32, ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.DeleteCompleted, handler
            dp.BeginDelete(New ProfileCriteria (uniqueID))
        End Sub
    
            
#End Region
    
#If Not SILVERLIGHT Then
#Region "Synchronous Child Factory Methods"
    
        Friend Shared Function NewProfileChild() As Profile
            Return DataPortal.CreateChild(Of Profile)()
        End Function
    
        Friend Shared Function GetByUniqueIDChild(ByVal uniqueID As System.Int32) As Profile
            Dim criteria As New ProfileCriteria()
            criteria.UniqueID = uniqueID
    
            Return DataPortal.FetchChild(Of Profile)(criteria)
        End Function
    
        Friend Shared Function GetByUsernameApplicationNameChild(ByVal username As System.String, ByVal applicationName As System.String) As Profile
            Dim criteria As New ProfileCriteria()
            criteria.Username = username
            criteria.ApplicationName = applicationName
    
            Return DataPortal.FetchChild(Of Profile)(criteria)
        End Function
    
#End Region
#End If        
    
#Region "Asynchronous Child Factory Methods"
    
        Friend Shared Sub NewProfileChildAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.CreateCompleted, handler
            dp.BeginCreate()
        End Sub

        Friend Shared Sub GetByUniqueIDChildAsync(ByVal uniqueID As System.Int32, ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.FetchCompleted, handler
        
            Dim criteria As New ProfileCriteria()
            criteria.UniqueID = uniqueID

            ' Mark as child?
            dp.BeginFetch(criteria)
        End Sub

        Friend Shared Sub GetByUsernameApplicationNameChildAsync(ByVal username As System.String, ByVal applicationName As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Profile)))
            Dim dp As New DataPortal(Of Profile)()
            AddHandler dp.FetchCompleted, handler
        
            Dim criteria As New ProfileCriteria()
            criteria.Username = username
            criteria.ApplicationName = applicationName

            ' Mark as child?
            dp.BeginFetch(criteria)
        End Sub

#End Region

#Region "DataPortal partial methods"
    
#If Not SILVERLIGHT Then
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As ProfileCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnFetched()
        End Sub
        Partial Private Sub OnMapping(ByVal reader As SafeDataReader, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnMapped()
        End Sub
        Partial Private Sub OnInserting(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnInserted()
        End Sub
        Partial Private Sub OnUpdating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnUpdated()
        End Sub
        Partial Private Sub OnSelfDeleting(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnSelfDeleted()
        End Sub
        Partial Private Sub OnDeleting(ByVal criteria As ProfileCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
#End If
    
#End Region
    
#Region "ChildPortal partial methods"

#If Not SILVERLIGHT Then
        Partial Private Sub OnChildCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildCreated()
        End Sub
        Partial Private Sub OnChildFetching(ByVal criteria As ProfileCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildFetched()
        End Sub
        Partial Private Sub OnChildInserting(ByVal connection As SqlConnection, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildInserted()
        End Sub
        Partial Private Sub OnChildUpdating(ByVal connection As SqlConnection, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildUpdated()
        End Sub
        Partial Private Sub OnChildSelfDeleting(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildSelfDeleted()
        End Sub
#End If 
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As ProfileCriteria ) As Boolean
            Return PetShop.Business.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace