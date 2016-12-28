Imports DataDynamics.ActiveReports
Imports Nomina
Imports System.IO
Imports System.Web
Imports System
Imports Intelexion.Framework.Model
Imports Intelexion.Nomina
Imports Intelexion.Framework.View
Imports Intelexion.Framework

Public Class InfotecMemoOICDetalle
    Inherits DataDynamics.ActiveReports.ActiveReport3

    Public Sub New()

        'This call is required by the ActiveReports Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub


    Private Sub Percepciones_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

        Me.ShowParameterUI = False
        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")
        Dim sConnection As String = Intelexion.Framework.Model.SQLConnectionProvider.getConnection("default").getConnection.ConnectionString
        'Dim sConnection As String = "Data Source=DCW319V1\MSSQLSERVER8; Initial Catalog=V5McGrawHillNominaTest; User Id=ITXTV5; Password=ITXTV5; Connection Lifetime=60; Max Pool Size=50; Min Pool Size=3"

        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
        sConnection, "sp_Reporte_MemoOIC @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
        "@Anio = " + Me.Parameters("Anio").Value + "," & _
        "@Mes = " + Me.Parameters("Mes").Value + "," & _
        "@IdElementoUsuario = " + "'" + Me.Parameters("IdElementoUsuario").Value + "'" + "," & _
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

        Dim ParamIdElementoUsuario As New Parameter
        ParamIdElementoUsuario.Key = "IdElementoUsuario"
        ParamIdElementoUsuario.Type = Parameter.DataType.String

        Dim ParamUID As New Parameter
        ParamUID.Key = "UID"
        ParamUID.Type = Parameter.DataType.String

        Dim ParamLID As New Parameter
        ParamLID.Key = "LID"
        ParamLID.Type = Parameter.DataType.String

        Dim ParamidAccion As New Parameter
        ParamidAccion.Key = "idAccion"

        'Dim SubReportePercepciones As New SubResumenOIC
        Dim SubReportePercepciones As New InfotecMemoOICDetalleSubReporte1
        SubReportePercepciones.Parameters.Clear()

        'aqui se agregan
        SubReportePercepciones.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones.Parameters.Add(ParamAnio)
        SubReportePercepciones.Parameters.Add(ParamMes)
        SubReportePercepciones.Parameters.Add(ParamIdElementoUsuario)
        SubReportePercepciones.Parameters.Add(ParamUID)
        SubReportePercepciones.Parameters.Add(ParamLID)
        SubReportePercepciones.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepciones.Parameters("IdElementoUsuario").Value = Me.Parameters("IdElementoUsuario").Value
        SubReportePercepciones.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        SubReportePercepciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones.Parameters("UID").Value = Me.Parameters("UID").Value
        Me.SubReport1.Report = SubReportePercepciones

        'Dim SubReportePercepciones As New SubResumenOIC
        Dim SubReporteDeducciones As New InfotecMemoOICDetalleSubReporte2
        SubReporteDeducciones.Parameters.Clear()

        'aqui se agregan
        SubReporteDeducciones.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeducciones.Parameters.Add(ParamAnio)
        SubReporteDeducciones.Parameters.Add(ParamMes)
        SubReporteDeducciones.Parameters.Add(ParamIdElementoUsuario)
        SubReporteDeducciones.Parameters.Add(ParamUID)
        SubReporteDeducciones.Parameters.Add(ParamLID)
        SubReporteDeducciones.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeducciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeducciones.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteDeducciones.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeducciones.Parameters("IdElementoUsuario").Value = Me.Parameters("IdElementoUsuario").Value
        SubReporteDeducciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        SubReporteDeducciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeducciones.Parameters("UID").Value = Me.Parameters("UID").Value
        Me.SubReport2.Report = SubReporteDeducciones

    End Sub


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

    End Sub
End Class
