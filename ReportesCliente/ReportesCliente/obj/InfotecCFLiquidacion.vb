Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports Intelexion.Nomina
Imports Nomina
Imports System.IO

Public Class InfotecCFLiquidacion

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
                 sConnection, "sp_Reporte_CartaFiniquitoLQ @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
                 "@IdTipoNominaAsig = " + Me.Parameters("IdTipoNominaAsig").Value + "," & _
                 "@IdTipoNominaProc = " + Me.Parameters("IdTipoNominaProc").Value + "," & _
                 "@Anio = " + Me.Parameters("Anio").Value + "," & _
                 "@Periodo = " + Me.Parameters("Periodo").Value + "," & _
                 "@IdEmpleado = " + "'" + Me.Parameters("IdEmpleado").Value + "'" + "," & _
                 "@UID = " + Me.Parameters("UID").Value + "," & _
                 "@LID = " + Me.Parameters("LID").Value + "," & _
                 "@idAccion = " + Me.Parameters("idAccion").Value + "", 90)


        'parametros que se envian al subreporte abajo mencionados
        Dim ParamIdRazonSocial As New Parameter
        ParamIdRazonSocial.Key = "IdRazonSocial"

        Dim ParamIdTipoNominaAsig As New Parameter
        ParamIdTipoNominaAsig.Key = "IdTipoNominaAsig"
        ParamIdTipoNominaAsig.Type = Parameter.DataType.String

        Dim ParamIdTipoNominaProc As New Parameter
        ParamIdTipoNominaProc.Key = "IdTipoNominaProc"
        ParamIdTipoNominaProc.Type = Parameter.DataType.String

        Dim ParamAnio As New Parameter
        ParamAnio.Key = "Anio"

        Dim ParamPeriodo As New Parameter
        ParamPeriodo.Key = "Periodo"

        Dim ParamIdEmpleado As New Parameter
        ParamIdEmpleado.Key = "IdEmpleado"
        ParamIdEmpleado.Type = Parameter.DataType.String

        Dim ParamUID As New Parameter
        ParamUID.Key = "UID"
        ParamUID.Type = Parameter.DataType.String

        Dim ParamLID As New Parameter
        ParamLID.Key = "LID"
        ParamLID.Type = Parameter.DataType.String

        Dim ParamidAccion As New Parameter
        ParamidAccion.Key = "idAccion"

        Dim SubReportePercepcionesL As New PercepcionesLiquidacion
        SubReportePercepcionesL.Parameters.Clear()

        'aqui se agregan
        SubReportePercepcionesL.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepcionesL.Parameters.Add(ParamIdTipoNominaAsig)
        SubReportePercepcionesL.Parameters.Add(ParamIdTipoNominaProc)
        SubReportePercepcionesL.Parameters.Add(ParamAnio)
        SubReportePercepcionesL.Parameters.Add(ParamPeriodo)
        SubReportePercepcionesL.Parameters.Add(ParamIdEmpleado)
        SubReportePercepcionesL.Parameters.Add(ParamUID)
        SubReportePercepcionesL.Parameters.Add(ParamLID)
        SubReportePercepcionesL.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepcionesL.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepcionesL.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        SubReportePercepcionesL.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        SubReportePercepcionesL.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepcionesL.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        SubReportePercepcionesL.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        SubReportePercepcionesL.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepcionesL.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepcionesL.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport1.Report = SubReportePercepcionesL

        Dim SubReporteDeduccionesL As New DeduccionesLiquidacion
        SubReporteDeduccionesL.Parameters.Clear()

        'aqui se agregan
        SubReporteDeduccionesL.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeduccionesL.Parameters.Add(ParamIdTipoNominaAsig)
        SubReporteDeduccionesL.Parameters.Add(ParamIdTipoNominaProc)
        SubReporteDeduccionesL.Parameters.Add(ParamAnio)
        SubReporteDeduccionesL.Parameters.Add(ParamPeriodo)
        SubReporteDeduccionesL.Parameters.Add(ParamIdEmpleado)
        SubReporteDeduccionesL.Parameters.Add(ParamUID)
        SubReporteDeduccionesL.Parameters.Add(ParamLID)
        SubReporteDeduccionesL.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeduccionesL.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeduccionesL.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        SubReporteDeduccionesL.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        SubReporteDeduccionesL.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeduccionesL.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        SubReporteDeduccionesL.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        SubReporteDeduccionesL.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteDeduccionesL.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeduccionesL.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReporteDeduccionesL

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


End Class
