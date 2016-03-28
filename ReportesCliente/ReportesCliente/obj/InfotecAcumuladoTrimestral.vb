Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports Intelexion.Nomina
Imports Nomina
Imports System.IO

Public Class InfotecAcumuladoTrimestral

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

    Public Sub AcumuladoTrimestral_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.ShowParameterUI = False
        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")

        Dim Path As String = Intelexion.Framework.ApplicationConfiguration.ConfigurationSettings.GetConfigurationSettings("ApplicationPath")
        Dim picRazonSocial As String = "/logos/Logoempresa" + Me.Parameters("IdRazonSocial").Value + ".jpg"
        Dim archivo As New FileInfo(System.Web.HttpContext.Current.Server.MapPath(Path) + picRazonSocial)

        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
                 sConnection, "sp_Reporte_Trimestral @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
                 "@IdTipoNomina = " + Me.Parameters("IdTipoNomina").Value + "," & _
                 "@Anio = " + Me.Parameters("Anio").Value + "," & _
                 "@Bimestre = " + Me.Parameters("Bimestre").Value + "," & _
                 "@UID = " + Me.Parameters("UID").Value + "," & _
                 "@LID = " + Me.Parameters("LID").Value + "," & _
                 "@idAccion = " + Me.Parameters("idAccion").Value + "", 90)


        'parametros que se envian al subreporte abajo mencionados
        Dim ParamIdRazonSocial As New Parameter
        ParamIdRazonSocial.Key = "IdRazonSocial"

        Dim ParamIdTipoNomina As New Parameter
        ParamIdTipoNomina.Key = "IdTipoNomina"
        ParamIdTipoNomina.Type = Parameter.DataType.String

        Dim ParamAnio As New Parameter
        ParamAnio.Key = "Anio"

        Dim ParamBimestre As New Parameter
        ParamBimestre.Key = "Bimestre"

        Dim ParamUID As New Parameter
        ParamUID.Key = "UID"
        ParamUID.Type = Parameter.DataType.String

        Dim ParamLID As New Parameter
        ParamLID.Key = "LID"
        ParamLID.Type = Parameter.DataType.String

        Dim ParamidAccion As New Parameter
        ParamidAccion.Key = "idAccion"

        Dim SubReporteAc As New Trimestral
        SubReporteAc.Parameters.Clear()

        'aqui se agregan
        SubReporteAc.Parameters.Add(ParamIdRazonSocial)
        SubReporteAc.Parameters.Add(ParamIdTipoNomina)
        SubReporteAc.Parameters.Add(ParamAnio)
        SubReporteAc.Parameters.Add(ParamBimestre)
        SubReporteAc.Parameters.Add(ParamUID)
        SubReporteAc.Parameters.Add(ParamLID)
        SubReporteAc.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteAc.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteAc.Parameters("IdTipoNomina").Value = Me.Parameters("IdTipoNomina").Value
        SubReporteAc.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteAc.Parameters("Bimestre").Value = Me.Parameters("Bimestre").Value
        SubReporteAc.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteAc.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteAc.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport1.Report = SubReporteAc


        ''*************************************************************************
        ' ''******* SUBREPORTE DEDUCCIONES **************/
        ''                                  nombre del subreporte
        Dim SubReporteTrimestral As New TrimestralMes
        SubReporteTrimestral.Parameters.Clear()

        'aqui se agregan
        SubReporteTrimestral.Parameters.Add(ParamIdRazonSocial)
        SubReporteTrimestral.Parameters.Add(ParamIdTipoNomina)
        SubReporteTrimestral.Parameters.Add(ParamAnio)
        SubReporteTrimestral.Parameters.Add(ParamBimestre)
        SubReporteTrimestral.Parameters.Add(ParamUID)
        SubReporteTrimestral.Parameters.Add(ParamLID)
        SubReporteTrimestral.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteTrimestral.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteTrimestral.Parameters("IdTipoNomina").Value = Me.Parameters("IdTipoNomina").Value
        SubReporteTrimestral.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteTrimestral.Parameters("Bimestre").Value = Me.Parameters("Bimestre").Value
        SubReporteTrimestral.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteTrimestral.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteTrimestral.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReporteTrimestral


        ''*************************************************************************
        Dim SubReporteDeduccionesTotal As New TrimestralMesTotal
        SubReporteDeduccionesTotal.Parameters.Clear()

        'aqui se agregan
        SubReporteDeduccionesTotal.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeduccionesTotal.Parameters.Add(ParamIdTipoNomina)
        SubReporteDeduccionesTotal.Parameters.Add(ParamAnio)
        SubReporteDeduccionesTotal.Parameters.Add(ParamBimestre)
        SubReporteDeduccionesTotal.Parameters.Add(ParamUID)
        SubReporteDeduccionesTotal.Parameters.Add(ParamLID)
        SubReporteDeduccionesTotal.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeduccionesTotal.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeduccionesTotal.Parameters("IdTipoNomina").Value = Me.Parameters("IdTipoNomina").Value
        SubReporteDeduccionesTotal.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeduccionesTotal.Parameters("Bimestre").Value = Me.Parameters("Bimestre").Value
        SubReporteDeduccionesTotal.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteDeduccionesTotal.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeduccionesTotal.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport3.Report = SubReporteDeduccionesTotal


    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


End Class
