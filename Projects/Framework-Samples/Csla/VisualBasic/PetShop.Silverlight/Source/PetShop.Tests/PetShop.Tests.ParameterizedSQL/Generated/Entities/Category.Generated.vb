﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.vb.
'
'     Template path: EditableRoot.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Rules
Imports Csla.Data

Namespace PetShop.Tests.ParameterizedSQL
    <Serializable()> _
    Public Partial Class Category
        Inherits BusinessBase(Of Category)
    
#Region "Contructor(s)"
    
        Private Sub New()
            ' require use of factory method 
        End Sub
    
        Friend Sub New(ByVal categoryId As System.String)
            Using(BypassPropertyChecks)
                _categoryId = categoryId
            End Using
        End Sub
    
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
        End Sub

#End Region    
    
#Region "Business Rules"
    
        Protected Overrides Sub AddBusinessRules()
    
            If AddBusinessValidationRules() Then Exit Sub
    
            BusinessRules.AddRule(New Csla.Rules.CommonRules.Required(_categoryIdProperty))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_categoryIdProperty, 10))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_nameProperty, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_descriptionProperty, 255))
        End Sub
    
#End Region

#Region "Properties"
    
        Private Shared ReadOnly _categoryIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.CategoryId, String.Empty)
        Private _categoryId As System.String = _categoryIdProperty.DefaultValue
        
		<System.ComponentModel.DataObjectField(true, false)> _
        Public Property CategoryId() As System.String
            Get 
                Return GetProperty(_categoryIdProperty, _categoryId) 
            End Get
            Set (value As System.String)
                SetProperty(_categoryIdProperty, _categoryId, value)
            End Set
        End Property

        Private Shared ReadOnly _originalCategoryIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.OriginalCategoryId, String.Empty)
        Private _originalCategoryId As System.String = _originalCategoryIdProperty.DefaultValue
        ''' <summary>
        ''' Holds the original value for CategoryId. This is used for non identity primary keys.
        ''' </summary>
        Friend Property OriginalCategoryId() As System.String
            Get 
                Return GetProperty(_originalCategoryIdProperty, _originalCategoryId) 
            End Get
            Set (value As System.String)
                SetProperty(_originalCategoryIdProperty, _originalCategoryId, value)
            End Set
        End Property

        Private Shared ReadOnly _nameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.Name, String.Empty, vbNullString)
        Private _name As System.String = _nameProperty.DefaultValue
        
        Public Property Name() As System.String
            Get 
                Return GetProperty(_nameProperty, _name) 
            End Get
            Set (value As System.String)
                SetProperty(_nameProperty, _name, value)
            End Set
        End Property

        Private Shared ReadOnly _descriptionProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.Description, String.Empty, vbNullString)
        Private _description As System.String = _descriptionProperty.DefaultValue
        
        Public Property Description() As System.String
            Get 
                Return GetProperty(_descriptionProperty, _description) 
            End Get
            Set (value As System.String)
                SetProperty(_descriptionProperty, _description, value)
            End Set
        End Property

        'AssociatedOneToMany
        Private Shared ReadOnly _productsProperty As PropertyInfo(Of ProductList) = RegisterProperty(Of ProductList)(Function(p As Category) p.Products, Csla.RelationshipTypes.Child)
    Public ReadOnly Property Products() As ProductList
            Get
                If Not (FieldManager.FieldExists(_productsProperty)) Then
                    Dim criteria As New PetShop.Tests.ParameterizedSQL.ProductCriteria()
                    criteria.CategoryId = CategoryId
    
                    If (Me.IsNew OrElse Not PetShop.Tests.ParameterizedSQL.ProductList.Exists(criteria)) Then
                        LoadProperty(_productsProperty, PetShop.Tests.ParameterizedSQL.ProductList.NewList())
                    Else
                        LoadProperty(_productsProperty, PetShop.Tests.ParameterizedSQL.ProductList.GetByCategoryId(CategoryId))
                    End If
                End If
                
                Return GetProperty(_productsProperty) 
            End Get
        End Property

#End Region
    
#Region "Synchronous Factory Methods"
    
        Public Shared Function NewCategory() As Category
            Return DataPortal.Create(Of Category)()
        End Function
    
        Public Shared Function GetByCategoryId(ByVal categoryId As System.String) As Category
            Dim criteria As New CategoryCriteria()
            criteria.CategoryId = categoryId
            
            Return DataPortal.Fetch(Of Category)(criteria)
        End Function
    
        Public Shared Sub DeleteCategory(ByVal categoryId As System.String)
            DataPortal.Delete(Of Category)(New CategoryCriteria(categoryId))
        End Sub
    
#End Region
    
#Region "DataPortal partial methods"
    
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
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
        Partial Private Sub OnDeleting(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As CategoryCriteria ) As Boolean
            Return PetShop.Tests.ParameterizedSQL.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace
