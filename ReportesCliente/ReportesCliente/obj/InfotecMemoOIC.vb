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

        'Dim SubReportePercepciones1 As New SubMemoOIC1
        'SubReportePercepciones1.Parameters.Clear()

        ' ''aqui se agregan
        'SubReportePercepciones1.Parameters.Add(ParamIdRazonSocial)
        'SubReportePercepciones1.Parameters.Add(ParamAnio)
        'SubReportePercepciones1.Parameters.Add(ParamMes)
        'SubReportePercepciones1.Parameters.Add(ParamUID)
        'SubReportePercepciones1.Parameters.Add(ParamLID)
        'SubReportePercepciones1.Parameters.Add(ParamidAccion)


        ''aqui se les asigna el valor
        'SubReportePercepciones1.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        'SubReportePercepciones1.Parameters("Anio").Value = Me.Parameters("Anio").Value
        'SubReportePercepciones1.Parameters("Mes").Value = Me.Parameters("Mes").Value
        'SubReportePercepciones1.Parameters("UID").Value = Me.Parameters("UID").Value
        'SubReportePercepciones1.Parameters("LID").Value = Me.Parameters("LID").Value
        'SubReportePercepciones1.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        'Me.SubReport1.Report = SubReportePercepciones1


    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
