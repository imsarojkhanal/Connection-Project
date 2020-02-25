Option Explicit On
Option Strict On
Option Compare Text

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections

Public Class ActiveDataAccess
    Private conString As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal dbConnection As String)
        Me.conString = dbConnection
    End Sub

    Public Property ConnectionString() As String
        Get
            Return Me.conString
        End Get
        Set(ByVal Value As String)
            Me.conString = Value
        End Set
    End Property

    Public Function ExecuteNonQuery(ByVal cmdType As CommandType, ByVal cmdString As String) As Integer
        Return SqlHelper.ExecuteNonQuery(Me.conString, cmdType, cmdString)
    End Function

    Public Function ExecuteNonQuery(ByVal cmdType As CommandType, ByVal cmdString As String, ByVal sqlParameters() As SqlParameter) As Integer
        Return SqlHelper.ExecuteNonQuery(Me.conString, cmdType, cmdString, sqlParameters)
    End Function

    Public Function ExecuteNonQuery(ByVal transaction As SqlTransaction,
                                                 ByVal commandType As CommandType,
                                                 ByVal commandText As String,
                                                 ByVal ParamArray commandParameters() As SqlParameter) As Integer
        Return SqlHelper.ExecuteNonQuery(transaction, commandType, commandText, commandParameters)
    End Function

    Public Function ExecuteDataset(ByVal cmdType As CommandType, ByVal cmdString As String) As DataSet
        Return SqlHelper.ExecuteDataset(Me.conString, cmdType, cmdString)
    End Function

    Public Function ExecuteDataset(ByVal cmdType As CommandType, ByVal cmdString As String, ByVal sqlParameters() As SqlParameter) As DataSet
        Return SqlHelper.ExecuteDataset(Me.conString, cmdType, cmdString, sqlParameters)
    End Function

    Public Function ExecuteScalar(ByVal cmdType As CommandType, ByVal cmdString As String) As Object
        Return SqlHelper.ExecuteScalar(Me.conString, cmdType, cmdString)
    End Function

    Public Function ExecuteScalar(ByVal cmdType As CommandType, ByVal cmdString As String, ByVal sqlParameters() As SqlParameter) As Object
        Return SqlHelper.ExecuteScalar(Me.conString, cmdType, cmdString, sqlParameters)
    End Function

    Public Function ExecuteReader(ByVal cmdType As CommandType, ByVal cmdString As String) As SqlDataReader
        Return SqlHelper.ExecuteReader(Me.conString, cmdType, cmdString)
    End Function

    Public Function ExecuteReader(ByVal cmdType As CommandType, ByVal cmdString As String, ByVal sqlParameters() As SqlParameter) As SqlDataReader
        Return SqlHelper.ExecuteReader(Me.conString, cmdType, cmdString, sqlParameters)
    End Function

    Public Function ExecuteReader(ByVal transaction As SqlTransaction,
                                               ByVal commandType As CommandType,
                                               ByVal commandText As String,
                                               ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        Return ExecuteReader(transaction, commandType, commandText, commandParameters)
    End Function

End Class