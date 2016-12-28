Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports Intelexion.Nomina
Imports Nomina
Imports System.IO

Public Class InfotecResumenOIC

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

    Public Sub PensionAlimenticia_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.ShowParameterUI = False
        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")

        Dim Path As String = Intelexion.Framework.ApplicationConfiguration.ConfigurationSettings.GetConfigurationSettings("ApplicationPath")
        Dim picRazonSocial As String = "/logos/Logoempresa" + Me.Parameters("IdRazonSocial").Value + ".jpg"
        Dim archivo As New FileInfo(System.Web.HttpContext.Current.Server.MapPath(Path) + picRazonSocial)

        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
                 sConnection, "sp_Reporte_OIC_Totales @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
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

        Dim SubReportePercepciones As New SubResumenOIC
        SubReportePercepciones.Parameters.Clear()

        'aqui se agregan
        SubReportePercepciones.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones.Parameters.Add(ParamAnio)
        SubReportePercepciones.Parameters.Add(ParamMes)
        SubReportePercepciones.Parameters.Add(ParamUID)
        SubReportePercepciones.Parameters.Add(ParamLID)
        SubReportePercepciones.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        SubReportePercepciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones.Parameters("UID").Value = Me.Parameters("UID").Value
        Me.SubReport1.Report = SubReportePercepciones


        '*************************************************************************
        ''******* SUBREPORTE DEDUCCIONES **************/
        '                                  nombre del subreporte
        Dim SubReporteDeducciones As New SubResumenOIC2
        SubReporteDeducciones.Parameters.Clear()

        'aqui se agregan
        SubReporteDeducciones.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeducciones.Parameters.Add(ParamAnio)
        SubReporteDeducciones.Parameters.Add(ParamMes)
        SubReporteDeducciones.Parameters.Add(ParamUID)
        SubReporteDeducciones.Parameters.Add(ParamLID)
        SubReporteDeducciones.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeducciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeducciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeducciones.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteDeducciones.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteDeducciones.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeducciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReporteDeducciones


        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa As New SubResumenOIC3
        SubReporteEmpresa.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa.Parameters.Add(ParamAnio)
        SubReporteEmpresa.Parameters.Add(ParamMes)
        SubReporteEmpresa.Parameters.Add(ParamUID)
        SubReporteEmpresa.Parameters.Add(ParamLID)
        SubReporteEmpresa.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport3.Report = SubReporteEmpresa


        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa5 As New SubResumenOIC5
        SubReporteEmpresa5.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa5.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa5.Parameters.Add(ParamAnio)
        SubReporteEmpresa5.Parameters.Add(ParamMes)
        SubReporteEmpresa5.Parameters.Add(ParamUID)
        SubReporteEmpresa5.Parameters.Add(ParamLID)
        SubReporteEmpresa5.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa5.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa5.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa5.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa5.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa5.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa5.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport4.Report = SubReporteEmpresa5

        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa6 As New SubResumenOIC6
        SubReporteEmpresa6.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa6.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa6.Parameters.Add(ParamAnio)
        SubReporteEmpresa6.Parameters.Add(ParamMes)
        SubReporteEmpresa6.Parameters.Add(ParamUID)
        SubReporteEmpresa6.Parameters.Add(ParamLID)
        SubReporteEmpresa6.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa6.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa6.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa6.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa6.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa6.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa6.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport5.Report = SubReporteEmpresa6


        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa7 As New SubResumenOIC7
        SubReporteEmpresa7.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa7.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa7.Parameters.Add(ParamAnio)
        SubReporteEmpresa7.Parameters.Add(ParamMes)
        SubReporteEmpresa7.Parameters.Add(ParamUID)
        SubReporteEmpresa7.Parameters.Add(ParamLID)
        SubReporteEmpresa7.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa7.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa7.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa7.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa7.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa7.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa7.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport6.Report = SubReporteEmpresa7

        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa8 As New SubResumenOIC8
        SubReporteEmpresa8.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa8.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa8.Parameters.Add(ParamAnio)
        SubReporteEmpresa8.Parameters.Add(ParamMes)
        SubReporteEmpresa8.Parameters.Add(ParamUID)
        SubReporteEmpresa8.Parameters.Add(ParamLID)
        SubReporteEmpresa8.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa8.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa8.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa8.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa8.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa8.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa8.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport7.Report = SubReporteEmpresa8

        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa9 As New SubResumenOIC9
        SubReporteEmpresa9.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa9.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa9.Parameters.Add(ParamAnio)
        SubReporteEmpresa9.Parameters.Add(ParamMes)
        SubReporteEmpresa9.Parameters.Add(ParamUID)
        SubReporteEmpresa9.Parameters.Add(ParamLID)
        SubReporteEmpresa9.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa9.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa9.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa9.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa9.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa9.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa9.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport8.Report = SubReporteEmpresa9

        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa10 As New SubResumenOIC10
        SubReporteEmpresa10.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa10.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa10.Parameters.Add(ParamAnio)
        SubReporteEmpresa10.Parameters.Add(ParamMes)
        SubReporteEmpresa10.Parameters.Add(ParamUID)
        SubReporteEmpresa10.Parameters.Add(ParamLID)
        SubReporteEmpresa10.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa10.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa10.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa10.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa10.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa10.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa10.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport9.Report = SubReporteEmpresa10


        '*************************************************************************
        '******* SUBREPORTE DEDUCCIONES **************/
        'nombre del subreporte
        Dim SubReporteEmpresa11 As New SubResumenOIC11
        SubReporteEmpresa11.Parameters.Clear()

        'aqui se agregan
        SubReporteEmpresa11.Parameters.Add(ParamIdRazonSocial)
        SubReporteEmpresa11.Parameters.Add(ParamAnio)
        SubReporteEmpresa11.Parameters.Add(ParamMes)
        SubReporteEmpresa11.Parameters.Add(ParamUID)
        SubReporteEmpresa11.Parameters.Add(ParamLID)
        SubReporteEmpresa11.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteEmpresa11.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteEmpresa11.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteEmpresa11.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteEmpresa11.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteEmpresa11.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteEmpresa11.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport10.Report = SubReporteEmpresa11


    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


End Class
