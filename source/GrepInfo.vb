Public Class GrepInfo
    Private _keyword As String
    Private _extension As String
    Private _folder As String
    Private _searchAllSubDirectoriesChecked As Boolean
    Private _caseSensitivityChecked As Boolean
    Private _grep_CheckBox As Boolean

    Sub New(keyword As String, extension As String, folder As String)
        MyClass.Keyword = keyword
        MyClass.Extension = extension
        MyClass.Folder = folder
    End Sub

    Sub New(keyword As String, extension As String, folder As String, searchAllSubDirectoriesChecked As Boolean, caseSensitivityChecked As Boolean, grep_CheckBox As Boolean)
        MyClass.Keyword = keyword
        MyClass.Extension = extension
        MyClass.Folder = folder
        MyClass.SearchAllSubDirectoriesChecked = searchAllSubDirectoriesChecked
        MyClass.CaseSensitivityChecked = caseSensitivityChecked
        MyClass.Grep_CheckBox = grep_CheckBox
    End Sub


    Public Property Keyword() As String
        Get
            Return _keyword
        End Get
        Set(ByVal value As String)
            _keyword = value
        End Set
    End Property

    Public Property Extension() As String
        Get
            Return _extension
        End Get
        Set(ByVal value As String)
            _extension = value
        End Set
    End Property

    Public Property Folder() As String
        Get
            Return _folder
        End Get
        Set(ByVal value As String)
            _folder = value
        End Set
    End Property

    Public Property SearchAllSubDirectoriesChecked() As Boolean
        Get
            Return _searchAllSubDirectoriesChecked
        End Get
        Set(ByVal value As Boolean)
            _searchAllSubDirectoriesChecked = value
        End Set
    End Property

    Public Property CaseSensitivityChecked() As Boolean
        Get
            Return _caseSensitivityChecked
        End Get
        Set(ByVal value As Boolean)
            _caseSensitivityChecked = value
        End Set
    End Property

    Public Property Grep_CheckBox() As Boolean
        Get
            Return _grep_CheckBox
        End Get
        Set(ByVal value As Boolean)
            _grep_CheckBox = value
        End Set
    End Property
End Class
