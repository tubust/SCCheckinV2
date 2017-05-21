Imports System.Data.SqlClient
Imports System.Xml.Serialization


#Region "Enums"
Public Enum enClassList
    Unknown = 0
    Pink = 1
    Purple = 2
    Yellow = 4
    Red = 3
    Green = 5
    Blue = 6
    Teacher = 7
    FloorRentalOnly = 8
End Enum

Public Enum DanceType
    Swing = 1
End Enum

Public Enum PaidType
    Unknown = 0
    MonthlyDues = 1
    YearlyDues = 2
    CheckIn = 3
    Raffle = 4
    SpecialEvent = 5
    SingleLesson = 6
    Exempt = 7
    Child = 8
    FridayNight = 9
    SaturdayNight = 10
    Merchandise = 11
    MonthlyMaintenence = 12
    FloorRental = 13
    Donations = 14
    Blank = 15
    MondayNight = 16
End Enum
#End Region

Module modApplication

#Region "Main loader"
    ' This sub loads the initial screen and the main screen.
    Public Sub Main()
        Dim wLoad As splSplashScreen
        wLoad = New splSplashScreen
        wLoad.ShowDialog()
        wLoad.Dispose()
        wLoad = Nothing

        Dim xLoad As frmLoad
        xLoad = New frmLoad
        xLoad.ShowDialog()
        xLoad.Dispose()
        xLoad = Nothing

        Dim xFrm As frmMain
        xFrm = New frmMain
        xFrm.ShowDialog()
        xFrm.Dispose()
        xFrm = Nothing

    End Sub
#End Region

#Region "Global Variables"
    Public conMain As SqlConnection = New SqlConnection
    Public conPaid As SqlConnection = New SqlConnection
    Public Members As DataTable = New DataTable
    Public dsCheckIn As DataSet
    'Public XMLPath As String = application.CommonAppDataPath & "\SwingClubData\" & Now.ToString("yyyyMM") & ".xml"
    Public XMLPath As String = Application.CommonAppDataPath & "\SwingClubData\PaidItems.xml"

    Public PaidItems As DataTable
    Public _PaidItems As DataSet

    Public PaidMembers As Collections.Generic.List(Of MemberCheckInItem)
#End Region

#Region "Loading sub processes"

    Public Sub LoadMembers()
        Try
            'This Line of code uses a SQL command that joins the tblFees table and OKSwingMemberList table
            'Joining them on the common value called Type and FeeCode
            Dim oAdapt As SqlDataAdapter = New SqlDataAdapter("SELECT *, M.LastName + ' ' + M.FirstName + ' ' + M.MiddleName AS FullName FROM tblFees F INNER JOIN OKSwingMemberList M ON F.FeeCode = M.[Type] WHERE M.IsDeleted = 0 AND M.LastName > '' ORDER BY M.LastName, M.FirstName, M.MiddleName", conMain)
            'Checks if the connection is open or not and
            'opens it if it is not
            If Not conMain.State = ConnectionState.Open Then
                conMain.Open()
            End If
            Members = New DataTable
            oAdapt.Fill(Members)

        Catch ex As Exception
            MessageBox.Show("The SQL Server Express Service is not Running. Go To Control Panel -> Administrative Tools -> Services and Select Start on the SQL Server Express.", "Server Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception("The SQL Server Express Service is not Running. Go To Control Panel -> Administrative Tools -> Services and Select Start on the SQL Server Express.")
            Try
                If _PaidItems.Tables("PaidItems") Is Nothing Then
                    PaidItems = New DataTable("PaidItems")
                    PaidItems.Columns.Add("MemberID")
                    PaidItems.Columns.Add("FullName")
                    PaidItems.Columns.Add("FirstName")
                    PaidItems.Columns.Add("LastName")
                    PaidItems.Columns.Add("PaidType")
                    PaidItems.Columns.Add("PaidAmount")
                    PaidItems.Columns.Item("PaidAmount").DataType = System.Type.GetType("System.Decimal")
                    PaidItems.Columns.Add("PaidDate")
                    PaidItems.Columns.Add("PaidDesc")
                    _PaidItems.Tables.Add(PaidItems)
                Else
                    PaidItems = _PaidItems.Tables("PaidItems")
                End If
            Catch ex1 As Exception
            End Try

        End Try
    End Sub

    Public Sub UpdateAnniversaries()
        Dim strSQL As String = "UPDATE OKSwingMemberList SET Anniversary = CAST(CAST(YEAR(GETDATE()) + 1 AS VARCHAR) + '-' + CAST(MONTH(GETDATE()) AS VARCHAR) + '-1' AS DATETIME), Type = 'REGULAR', MemberStatus = 'Active' FROM OKSwingMemberList WHERE MemberID IN(SELECT MemberID FROM CheckIns WHERE PaidType = 2 AND DATEADD(DAY, 1, CreateDate) < GETDATE() AND DATEADD(MONTH, 1, CreateDate) >  GETDATE()) AND Anniversary < GETDATE()"
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Dim aComm As SqlCommand = New SqlCommand(strSQL, aConn)
        Try
            aConn.Open()
            aComm.ExecuteNonQuery()
            If Not aConn.State = ConnectionState.Closed Then
                aConn.Close()
            End If
            aConn = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadNewMembers()
        Try
            If Not conPaid.State = ConnectionState.Open Then
                conPaid.Open()
            End If
            Dim oAdapt As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM CheckIns WHERE PaidDate >= '" & Now.ToString("MM/01/yyyy") & "' ", conPaid) 'ORDER BY LastName, FirstName, MiddleName
            _PaidItems = New DataSet("SwingClub")
            oAdapt.Fill(_PaidItems)
            PaidItems = _PaidItems.Tables("Table")

            Dim aPaidView As DataView = New DataView(PaidItems)
            aPaidView.RowFilter = "MemberID = 0 AND PaidDate >= '" & Now.ToString("MM-01-yyyy") & "'"
            aPaidView.Sort = "LastName, FirstName"
            Dim strLastMember As String = ""
            For Each aRow As DataRowView In aPaidView
                If Not strLastMember = aRow.Item("LastName") & " " & aRow.Item("FirstName") Then
                    If CDate(aRow.Item("PaidDate").ToString).Year = Now.Year Then
                        If CDate(aRow.Item("PaidDate").ToString).Month = Now.Month Then
                            Dim aNewPerson As DataRow = Members.NewRow
                            strLastMember = aRow.Item("LastName") & " " & aRow.Item("FirstName")
                            aNewPerson.Item("MemberID") = 0
                            aNewPerson.Item("FullName") = strLastMember & " (New)"
                            aNewPerson.Item("FirstName") = aRow.Item("FirstName")
                            aNewPerson.Item("LastName") = aRow.Item("LastName")
                            Members.Rows.Add(aNewPerson)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Function LoadPaidMembers(ByRef XMLPath As String) As Boolean
        If System.IO.File.Exists(XMLPath) Then
            Dim fStream As IO.FileStream = New IO.FileStream(XMLPath, IO.FileMode.Open)
            Try
                Dim XmlS As XmlSerializer = New XmlSerializer(GetType(Collections.Generic.List(Of MemberCheckInItem)))
                PaidMembers = XmlS.Deserialize(fStream)
                Return True
            Catch ex As Exception
                Return False
            Finally
                fStream.Close()
            End Try
        Else
            Return False
        End If
    End Function

#End Region

End Module
'This Class loads information about a member of the club

Public Class MemberCheckInItem

#Region "Global Variables"
    Public MemberID As Integer
    Public FirstName As String
    Public MiddleName As String
    Public LastName As String

    Public Address As String
    Public City As String
    Public State As String
    Public Zip As String
    Public HomePhone As String
    Public WorkPhone As String
    Public Type As String

    Public EMailAddress As String

    Public Status As String
    Public MemberStatus As String

    Public Birthday As Date
    Public Anniversary As Date
    Public DateJoined As Date
    Public LastPaid As Date

    Public CheckedIn As Boolean
    Public LessonAmount As Integer
    Public PaidFor As PaidCollection

    Public ElementsAmount As Integer
    Public MonthlyAmount As Integer
    Public YearlyAmount As Integer

    Public InvalidAddress As Boolean

    Public ClassItem As enClassList

    Private bolHasPaid As Boolean

#End Region

#Region "Payment Check"

    Public Function HasPaid() As Boolean
        If PaidFor Is Nothing Then
            PaidFor = New PaidCollection
            LoadPaidItems(Now.ToString("yyyy-MM-01"))
        End If
        If bolHasPaid Then Return bolHasPaid
        For Each aPaid As PaidItem In PaidFor
            Select Case aPaid.PaidType
                Case PaidType.Exempt
                    bolHasPaid = True
                    Exit For
                Case PaidType.MonthlyDues
                    If aPaid.PaidType = PaidType.MonthlyDues Then
                        bolHasPaid = True
                        Exit For
                    End If
                Case PaidType.MonthlyMaintenence
                    MessageBox.Show(FirstName & " " & LastName & " has paid the Monthly Maintenence fee.  Classes have not been paid for.", "Monthly Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bolHasPaid = True
                    Exit For
            End Select
        Next
        Return bolHasPaid
    End Function


    Public ReadOnly Property BirthdayText() As String
        Get
            Dim strReturn As String = ""
            If IsDate(Birthday) Then
                If CDate(Birthday).Month = Now.Month Then
                    strReturn = "Happy Birthday " & FirstName & " " & CDate(Birthday).ToString(" (MMM dd)")
                End If
            End If
            Return strReturn
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim strReturn As String = FirstName & " " & LastName
        Dim dblTotal As Double = 0 'PaidFor.Total
        If dblTotal > 0 Then
            strReturn &= " (" & dblTotal & ")"
        End If
        Return strReturn
    End Function

#End Region

#Region "Database Loaders"

    Public Sub New()
        MemberID = 0
        FirstName = ""
        MiddleName = ""
        LastName = ""

        Address = ""
        City = ""
        State = ""
        Zip = ""
        HomePhone = ""
        WorkPhone = ""
        Type = "INTRO"

        EMailAddress = ""

        Status = ""
        MemberStatus = ""

        Birthday = Nothing
        Anniversary = Now.AddMonths(3)
        Anniversary = Anniversary.AddDays(-Anniversary.Day)

        DateJoined = Now
        LastPaid = Now

        InvalidAddress = False

        CheckedIn = False
        Try
            Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim strSQL As String = "Select FeeAmount from tblFees where FeeCode = 'REGULAR'"
            Dim comTemp As SqlCommand = New SqlCommand(strSQL, aConn)
            Dim anAdapt As SqlDataAdapter = New SqlDataAdapter(comTemp)
            Dim dtTemp As DataTable = New DataTable
            aConn.Open()
            anAdapt.Fill(dtTemp)
            For Each aRow As DataRow In dtTemp.Rows
                LessonAmount = aRow.Item("FeeAmount")
            Next
        Catch ex As Exception
            LessonAmount = My.Settings.MonthlyPrice
        End Try

        PaidFor = New PaidCollection

        YearlyAmount = 50
    End Sub
    Public Sub New(ByVal aRow As DataRow)
        'Loads Member number from the database
        MemberID = aRow.Item("MemberID")
        'Loads Member First Name from the database
        FirstName = aRow.Item("FirstName").ToString
        'Loads Member Middle Name from the database
        MiddleName = aRow.Item("MiddleName").ToString
        'Loads Member Last Name from the database
        LastName = aRow.Item("LastName").ToString
        'Loads Member Address from Database
        Address = aRow.Item("Address").ToString
        'Loads Member City from Database
        City = aRow.Item("City").ToString
        'Loads Member State from the database
        State = aRow.Item("State").ToString
        'Loads member zip code from the database
        Zip = aRow.Item("Zip").ToString
        'Loads Member HomePhone from Database
        HomePhone = aRow.Item("HomePhone").ToString
        'Loads Member WorkPhone from database
        WorkPhone = aRow.Item("WorkPhone").ToString
        'Loads Member E-Mail from Database
        EMailAddress = aRow.Item("EmailAddress").ToString
        'Loads member status from database
        Status = aRow.Item("Status").ToString
        'Loads member status from database can be ACTIVE or INACTIVE
        MemberStatus = aRow.Item("MemberStatus").ToString
        'Loads member type from database. Can be INTRO or REGULAR
        Type = aRow.Item("Type").ToString
        'Loads lesson amount from Database (on me it is 55 as I am listed as INTRO)
        LessonAmount = aRow.Item("FeeAmount").ToString
        InvalidAddress = aRow.Item("InvalidAddress")

        If Not aRow.Item("ClassID") Is DBNull.Value Then
            ClassItem = aRow.Item("ClassID")
        Else
            ClassItem = enClassList.Unknown
        End If

        If Not aRow.Item("DOB") Is DBNull.Value Then
            Birthday = aRow.Item("DOB")
        End If

        If Not aRow.Item("Anniversary") Is DBNull.Value Then
            Anniversary = aRow.Item("Anniversary")
        End If
        If Not aRow.Item("DateJoined") Is DBNull.Value Then
            DateJoined = aRow.Item("DateJoined")
        End If
        If Not aRow.Item("LastPaid") Is DBNull.Value Then
            LastPaid = aRow.Item("LastPaid")
        End If
    End Sub
    Public Function GetRow() As DataRow
        Dim aRow As DataRow = Members.NewRow
        Try
            aRow.Item("MemberID") = MemberID
            aRow.Item("FirstName") = FirstName
            If MemberID = 0 Then
                If Not FirstName.EndsWith(" (New") Then
                    aRow.Item("FirstName") &= " (NEW)"
                End If
            End If
            aRow.Item("MiddleName") = MiddleName
            aRow.Item("LastName") = LastName

            If MiddleName Is Nothing Then
                MiddleName = ""
            End If
            aRow.Item("FullName") = LastName.ToString & " " & aRow.Item("FirstName").ToString.Trim & " " & MiddleName.ToString

            aRow.Item("Address") = Address
            aRow.Item("City") = City
            aRow.Item("State") = State
            aRow.Item("Zip") = Zip
            aRow.Item("HomePhone") = HomePhone
            aRow.Item("WorkPhone") = WorkPhone
            aRow.Item("EmailAddress") = EMailAddress

            aRow.Item("Status") = Status
            aRow.Item("MemberStatus") = MemberStatus
            aRow.Item("Type") = Type
            aRow.Item("FeeAmount") = LessonAmount
            aRow.Item("InvalidAddress") = InvalidAddress
            aRow.Item("currentMonth") = Now.Month

            If Not aRow.Item("DOB") Is DBNull.Value Then
                aRow.Item("DOB") = Birthday
            End If
            If Anniversary.Year > 1900 Then
                aRow.Item("Anniversary") = Anniversary
            End If
            If DateJoined.Year > 1900 Then
                aRow.Item("DateJoined") = DateJoined
            End If
            If LastPaid.Year > 1900 Then
                aRow.Item("LastPaid") = LastPaid
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
        Return aRow
    End Function

    Public Function GetInfo() As Boolean

        Try
            Dim comTemp As SqlCommand = New SqlCommand
            Dim TempAdapt As SqlDataAdapter
            Dim dsTemp As DataSet = New DataSet
            Dim dtTemp As DataTable
            Dim aRow As DataRow

            dsTemp = New DataSet
            dtTemp = New DataTable
            comTemp.CommandText = "SELECT * FROM OKSwingMemberList WHERE MemberID = " & MemberID
            comTemp.CommandTimeout = 300

            comTemp.Connection = conMain
            comTemp.CommandType = CommandType.Text
            TempAdapt = New SqlDataAdapter(comTemp)
            TempAdapt.Fill(dsTemp, "Members")
            dtTemp = dsTemp.Tables("Members")

            If dtTemp.Rows.Count = 0 Then
                aRow = dtTemp.NewRow
                aRow.Item("LastPaid") = DateJoined
            Else
                aRow = dtTemp.Rows(0)
                FirstName = aRow.Item("FirstName").ToString
                MiddleName = aRow.Item("MiddleName")
                LastName = aRow.Item("LastName")
                Address = aRow.Item("Address")
                City = aRow.Item("City")
                State = aRow.Item("State")
                Zip = aRow.Item("Zip")
                HomePhone = aRow.Item("HomePhone")
                WorkPhone = aRow.Item("WorkPhone")
                EMailAddress = aRow.Item("EMailAddress")
                Status = aRow.Item("Status")
                Type = aRow.Item("Type")
                MemberStatus = aRow.Item("MemberStatus")
                InvalidAddress = aRow.Item("InvalidAddress")
                ClassItem = aRow.Item("ClassID")
                If IsDate(aRow.Item("DOB")) Then
                    Birthday = aRow.Item("DOB")
                End If
                If IsDate(aRow.Item("Anniversary")) Then
                    Anniversary = aRow.Item("Anniversary")
                End If
                If IsDate(aRow.Item("DateJoined")) Then
                    DateJoined = aRow.Item("DateJoined")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return True
    End Function

    Public Function LoadPaidItems() As Boolean
        Return LoadPaidItems("1960-01-01")
    End Function
    Public Function LoadPaidItems(ByVal Startdate As String) As Boolean

        Try
            Dim comTemp As SqlCommand = New SqlCommand
            Dim TempAdapt As SqlDataAdapter
            Dim dsTemp As DataSet = New DataSet
            Dim dtTemp As DataTable

            dsTemp = New DataSet
            dtTemp = New DataTable
            comTemp.CommandText = "SELECT * FROM CheckIns WHERE MemberID = " & MemberID & " AND PaidDate >= '" & Startdate & "' ORDER BY PaidDate DESC"
            comTemp.CommandTimeout = 300

            comTemp.Connection = conMain
            comTemp.CommandType = CommandType.Text
            TempAdapt = New SqlDataAdapter(comTemp)
            TempAdapt.Fill(dtTemp)

            If PaidFor Is Nothing Then
                PaidFor = New PaidCollection
            End If
            PaidFor.Clear()
            For Each aRow As DataRow In dtTemp.Rows
                Dim aPaidItem As PaidItem = New PaidItem
                aPaidItem.SetData(aRow)
                PaidFor.Add(aPaidItem)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return True
    End Function
#End Region

#Region "Save Function"
    Public Function Save() As Boolean

        Try
            Dim comTemp As SqlCommand = New SqlCommand
            Dim TempAdapt As SqlDataAdapter
            Dim dsTemp As DataSet = New DataSet
            Dim dtTemp As DataTable
            Dim aRow As DataRow

            dsTemp = New DataSet
            dtTemp = New DataTable
            comTemp.CommandText = "SELECT * FROM OKSwingMemberList WHERE MemberID = " & MemberID
            comTemp.CommandTimeout = 300

            comTemp.Connection = conMain
            comTemp.CommandType = CommandType.Text
            TempAdapt = New SqlDataAdapter(comTemp)
            TempAdapt.Fill(dsTemp, "Members")
            dtTemp = dsTemp.Tables("Members")

            dtTemp.BeginLoadData()
            If dtTemp.Rows.Count = 0 Then
                aRow = dtTemp.NewRow
            Else
                aRow = dtTemp.Rows(0)
            End If

            aRow.Item("FirstName") = FirstName
            aRow.Item("MiddleName") = MiddleName
            aRow.Item("LastName") = LastName
            aRow.Item("Address") = Address
            aRow.Item("City") = City
            aRow.Item("State") = State
            aRow.Item("Zip") = Zip
            aRow.Item("Charter") = False
            aRow.Item("HomePhone") = HomePhone
            aRow.Item("WorkPhone") = WorkPhone
            aRow.Item("EMailAddress") = EMailAddress
            aRow.Item("Status") = Status
            aRow.Item("Type") = Type
            aRow.Item("MemberStatus") = MemberStatus
            aRow.Item("InvalidAddress") = InvalidAddress
            aRow.Item("currentMonth") = Now.Month

            aRow.Item("ClassID") = ClassItem

            If Not Birthday.Date = Nothing Then
                aRow.Item("DOB") = Birthday
            End If
            If IsDate(Anniversary) Then
                aRow.Item("Anniversary") = Anniversary
            End If
            If IsDate(DateJoined) Then
                aRow.Item("DateJoined") = DateJoined
            End If

            dtTemp.EndLoadData()
            If MemberID = 0 Then
                dtTemp.Rows.Add(aRow)
            End If

            Dim cmdBuilder As SqlCommandBuilder = New SqlCommandBuilder(TempAdapt)
            TempAdapt.InsertCommand = cmdBuilder.GetInsertCommand
            TempAdapt.UpdateCommand = cmdBuilder.GetUpdateCommand

            TempAdapt.Update(dsTemp, "Members")

            If MemberID = 0 Then
                Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
                Dim aComm As SqlCommand = New SqlCommand("SELECT TOP 1 MemberID FROM OKSwingMemberList WHERE FirstName = '" & FirstName & "' AND LastName = '" & LastName & "' ORDER BY MemberID DESC", aConn)
                aConn.Open()
                MemberID = aComm.ExecuteScalar
                aConn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return True
    End Function
#End Region

End Class

Public Class BaseCollection
    Inherits System.Collections.CollectionBase

#Region "Initial Loader"
    Public Sub New()
    End Sub
#End Region

#Region "Data Manipulators"
    Public Sub Add(ByVal anObject As Object)
        List.Add(anObject)
    End Sub
    Public Function Remove(ByVal Index As Integer) As Boolean
        If Index <= List.Count Then
            List.RemoveAt(Index)
        End If
    End Function
    Public Function Remove(ByVal anObject As Object) As Boolean
        Dim x As Integer
        For x = 0 To List.Count - 1
            If anObject Is List.Item(x) Then
                List.RemoveAt(x)
                Exit For
            End If
        Next
    End Function
    Public Property Items(ByVal Index As Integer) As Object
        Get
            If Index <= List.Count Then
                Return List.Item(Index)
            End If
            Return Nothing
        End Get
        Set(ByVal Value As Object)
            List.Item(Index) = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return List.Count
    End Function
#End Region

End Class

Public Class MemberCheckInCollection
    Inherits BaseCollection

#Region "Initial Loader"
    Public Sub New()
    End Sub
#End Region

#Region "Data Manipulators"
    Public Shadows Sub Add(ByVal aMember As MemberCheckInItem)
        For x As Integer = 0 To MyBase.List.Count - 1
            If aMember.MemberID > 0 Then
                If aMember.MemberID = MyBase.List.Item(x).MemberID Then
                    MyBase.List.Item(x) = aMember
                    Return
                End If
            Else
                If aMember.FirstName = MyBase.List.Item(x).FirstName Then
                    If aMember.LastName = MyBase.List.Item(x).LastName Then
                        MyBase.List.Item(x) = aMember
                        Return
                    End If
                End If
            End If
        Next
        MyBase.List.Add(aMember)
    End Sub
    Public ReadOnly Property Members(ByVal aMemberID As Integer) As MemberCheckInItem
        Get
            For lx As Integer = 0 To MyBase.Count - 1
                If MyBase.List.Item(lx).MemberID = aMemberID Then
                    Return MyBase.List.Item(lx)
                End If
            Next
            Return Nothing
        End Get
    End Property

    Default Public Shadows Property Items(ByVal Index As Integer) As MemberCheckInItem
        Get
            If Index <= MyBase.List.Count Then
                Return MyBase.List.Item(Index)
            End If
            Return Nothing
        End Get
        Set(ByVal Value As MemberCheckInItem)
            MyBase.List.Item(Index) = Value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return MyBase.List.Count
    End Function
#End Region

End Class

Public Class PaidItem

#Region "Global Variables"
    Public CheckInID As Integer
    Public MemberID As Integer
    Public FullName As String = String.Empty
    Public FirstName As String = String.Empty
    Public LastName As String
    Public PaidType As Integer
    Public PaidAmount As Double
    Public PaidDate As Date
    Public PaidDesc As String
    Public DanceType As Integer
    Public CreateDate As Date
#End Region

#Region "initial loader"
    Public Sub New()
        CreateDate = Now
    End Sub
#End Region

#Region "Data Manipulator"
    Public Sub SetData(ByVal aRow As DataRow)
        CheckInID = aRow.Item("CheckInID")
        MemberID = aRow.Item("MemberID")
        FullName = aRow.Item("FullName")
        FirstName = aRow.Item("FirstName")
        LastName = aRow.Item("LastName")
        PaidType = aRow.Item("PaidType")
        PaidAmount = aRow.Item("PaidAmount")
        PaidDate = aRow.Item("PaidDate")
        PaidDesc = aRow.Item("PaidDesc")
        DanceType = aRow.Item("DanceType")
        CreateDate = aRow.Item("CreateDate")
    End Sub

    Public Sub Delete(ByVal admin As String)
        Dim aConn As SqlConnection = New SqlConnection(My.Settings.SCCheckInConnectionString)
        Try
            Dim strSQL As String = "INSERT INTO VoidedEntries(CheckInID,MemberID,FullName,FirstName,LastName,PaidType,PaidAmount,PaidDate,PaidDesc,DanceType,CreateDate,ReferredBy) SELECT CheckInID,MemberID,FullName,FirstName,LastName,PaidType,PaidAmount,PaidDate,PaidDesc,DanceType,CreateDate,ReferredBy FROM CheckIns WHERE CheckInID =" & CheckInID & ""
            Dim aComm As SqlCommand = New SqlCommand(strSQL, aConn)
            aConn.Open()
            aComm.ExecuteNonQuery()
            strSQL = "UPDATE VoidedEntries SET AuthorizedBy = '" & admin & "' WHERE CheckInID = " & CheckInID
            aComm.CommandText = strSQL
            aComm.ExecuteNonQuery()
            strSQL = "DELETE From CheckIns WHERE CheckInID = " & CheckInID
            aComm.CommandText = strSQL
            aComm.ExecuteNonQuery()
            aConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Public Overrides Function ToString() As String
        Dim strTemp As String = ""
        If CreateDate > New Date(1900, 1, 1) Then
            strTemp = CDate(CreateDate).ToString("MMM dd, yyyy") & " "
        Else
            strTemp = "Unknown Date "
        End If

        If PaidDesc.Length > 0 Then
            strTemp &= PaidDesc.Trim & " "
        End If
        If PaidAmount > 0 Then
            strTemp &= PaidAmount
        End If
        Return strTemp.Trim
    End Function
#End Region

End Class

Public Class PaidCollection
    Inherits BaseCollection

#Region "Functions of inherited class"
    Public Shadows Sub Add(ByVal aPaidItem As PaidItem)
        List.Add(aPaidItem)
    End Sub
    Default Public ReadOnly Property PaidItems(ByVal Index As Integer) As PaidItem
        Get
            'For lx As Integer = 0 To MyBase.Count - 1
            '    If list.Item(lx).MemberID = aMemberID Then
            '        Return list.Item(lx)
            '    End If
            'Next
            Return List.Item(Index)
        End Get
    End Property

    'Public Function Items(ByVal Index As Integer) As PaidItem
    '    Return list.Item(Index)
    'End Function
    Public Function Total() As Double
        Dim dblReturn As Double
        For x As Integer = 0 To List.Count - 1
            dblReturn += CType(List.Item(x), PaidItem).PaidAmount
        Next
        Return dblReturn
    End Function
#End Region

End Class