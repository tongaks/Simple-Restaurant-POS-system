Namespace Restaurant_POS_system.My
    ' Lightweight shim for My.Settings.ConnectionString to satisfy designer/IntelliSense
    Friend NotInheritable Class Settings
        Private Shared ReadOnly _instance As New Settings()

        Public Shared ReadOnly Property [Default] As Settings
            Get
                Return _instance
            End Get
        End Property

        ' Default connection string - change as needed
        Public Property ConnectionString As String = "server=localhost;userid=root;password=;database=restaurant;SslMode=none;"
    End Class
End Namespace