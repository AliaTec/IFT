Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports Intelexion.Nomina
Imports Nomina
Imports System.IO

Public Class InfotecMemoOIC

    Inherits DataDynamics.ActiveReports.ActiveReport3

    Dim RPT As New ActiveReport3

    Dim sConnection As String = Intelexion.Framework.Model.SQLConnectionProvider.getConnection("default").getConnection.ConnectionString

    Public Sub New()

        'This call is required by the ActiveReports Designer.
        InitializeComponent()


    End Sub

    Public Sub New(ByVal reporte As Entities.ReportesProceso)

        'This call is required by the ActiveReports Designer.
        InitializeComponent()

    End Sub

    Public Sub InfotecMemoOIC_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.ShowParameterUI = False
        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")

        Dim Path As String = Intelexion.Framework.ApplicationConfiguration.ConfigurationSettings.GetConfigurationSettings("ApplicationPath")
        Dim picRazonSocial As String = "/logos/Logoempresa" + Me.Parameters("IdRazonSocial").Value + ".jpg"
        Dim archivo As New FileInfo(System.Web.HttpContext.Current.Server.MapPath(Path) + picRazonSocial)

        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
                 sConnection, "sp_Reporte_OIC_Memo_Totales @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
                 "@Anio = " + Me.Parameters("Anio").Value + "," & _
                 "@Mes = " + Me.Parameters("Mes").Value + "," & _
                 "@UID = " + Me.Parameters("UID").Value + "," & _
                 "@LID = " + Me.Parameters("LID").Value + "," & _
                 "@idAccion = " + Me.Parameters("idAccion").Value + "", 90)


        'parametros que se envian al subreporte abajo mencionados
        Dim ParamIdRazonSocial As New Parameter
        ParamIdRazonSocial.Key = "IdRazonSocial"

        Dim ParamAnio As New Parameter
        ParamAnio.Key = "Anio"

        Dim ParamMes As New Parameter
        ParamMes.Key = "Mes"

        Dim ParamUID As New Parameter
        ParamUID.Key = "UID"
        ParamUID.Type = Parameter.DataType.String

        Dim ParamLID As New Parameter
        ParamLID.Key = "LID"
        ParamLID.Type = Parameter.DataType.String

        Dim ParamidAccion As New Parameter
        ParamidAccion.Key = "idAccion"

        Dim SubReportePercepciones1 As New SubMemoOIC1
        SubReportePercepciones1.Parameters.Clear()

        ''aqui se agregan
        SubReportePercepciones1.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones1.Parameters.Add(ParamAnio)
        SubReportePercepciones1.Parameters.Add(ParamMes)
        SubReportePercepciones1.Parameters.Add(ParamUID)
        SubReportePercepciones1.Parameters.Add(ParamLID)
        SubReportePercepciones1.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepciones1.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones1.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones1.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones1.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones1.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones1.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport1.Report = SubReportePercepciones1

        '--------------------------------------------------------

        Dim SubReportePercepciones2 As New SubMemoOIC2
        SubReportePercepciones2.Parameters.Clear()

        ''aqui se agregan
        SubReportePercepciones2.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones2.Parameters.Add(ParamAnio)
        SubReportePercepciones2.Parameters.Add(ParamMes)
        SubReportePercepciones2.Parameters.Add(ParamUID)
        SubReportePercepciones2.Parameters.Add(ParamLID)
        SubReportePercepciones2.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepciones2.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones2.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones2.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones2.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones2.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones2.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReportePercepciones2

        '--------------------------------------------------------

        Dim SubReportePercepciones3 As New SubMemoOIC3
        SubReportePercepciones3.Parameters.Clear()

        ''aqui se agregan
        SubReportePercepciones3.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones3.Parameters.Add(ParamAnio)
        SubReportePercepciones3.Parameters.Add(ParamMes)
        SubReportePercepciones3.Parameters.Add(ParamUID)
        SubReportePercepciones3.Parameters.Add(ParamLID)
        SubReportePercepciones3.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepciones3.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones3.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones3.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones3.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones3.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones3.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport3.Report = SubReportePercepciones3

        '--------------------------------------------------------

        Dim SubReportePercepciones4 As New SubMemoOIC4
        SubReportePercepciones4.Parameters.Clear()

        ''aqui se agregan
        SubReportePercepciones4.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones4.Parameters.Add(ParamAnio)
        SubReportePercepciones4.Parameters.Add(ParamMes)
        SubReportePercepciones4.Parameters.Add(ParamUID)
        SubReportePercepciones4.Parameters.Add(ParamLID)
        SubReportePercepciones4.Parameters.Add(ParamidAccion)

        'aqui se les asigna el valor
        SubReportePercepciones4.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones4.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones4.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones4.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones4.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones4.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport4.Report = SubReportePercepciones4

        '--------------------------------------------------------

        Dim SubReportePercepciones5 As New SubMemoOIC5
        SubReportePercepciones5.Parameters.Clear()

        ''aqui se agregan
        SubReportePercepciones5.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones5.Parameters.Add(ParamAnio)
        SubReportePercepciones5.Parameters.Add(ParamMes)
        SubReportePercepciones5.Parameters.Add(ParamUID)
        SubReportePercepciones5.Parameters.Add(ParamLID)
        SubReportePercepciones5.Parameters.Add(ParamidAccion)

        'aqui se les asigna el valor
        SubReportePercepciones5.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones5.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones5.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones5.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones5.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones5.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport5.Report = SubReportePercepciones5

        '--------------------------------------------------------

        Dim SubReportePercepciones6 As New SubMemoOIC6
        SubReportePercepciones6.Parameters.Clear()

        ''aqui se agregan
        SubReportePercepciones6.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones6.Parameters.Add(ParamAnio)
        SubReportePercepciones6.Parameters.Add(ParamMes)
        SubReportePercepciones6.Parameters.Add(ParamUID)
        SubReportePercepciones6.Parameters.Add(ParamLID)
        SubReportePercepciones6.Parameters.Add(ParamidAccion)

        'aqui se les asigna el valor
        SubReportePercepciones6.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones6.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones6.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones6.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones6.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones6.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport6.Report = SubReportePercepciones6


    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub
End Class
