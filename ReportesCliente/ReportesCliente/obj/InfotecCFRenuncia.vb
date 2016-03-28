Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports Intelexion.Nomina
Imports Nomina
Imports System.IO

Public Class InfotecCFRenuncia

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
                 sConnection, "sp_Reporte_CartaFiniquitoR @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
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

        Dim SubReportePercepcionesR As New PercepcionesRenuncia
        SubReportePercepcionesR.Parameters.Clear()

        'aqui se agregan
        SubReportePercepcionesR.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepcionesR.Parameters.Add(ParamIdTipoNominaAsig)
        SubReportePercepcionesR.Parameters.Add(ParamIdTipoNominaProc)
        SubReportePercepcionesR.Parameters.Add(ParamAnio)
        SubReportePercepcionesR.Parameters.Add(ParamPeriodo)
        SubReportePercepcionesR.Parameters.Add(ParamIdEmpleado)
        SubReportePercepcionesR.Parameters.Add(ParamUID)
        SubReportePercepcionesR.Parameters.Add(ParamLID)
        SubReportePercepcionesR.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepcionesR.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepcionesR.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        SubReportePercepcionesR.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        SubReportePercepcionesR.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepcionesR.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        SubReportePercepcionesR.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        SubReportePercepcionesR.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepcionesR.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepcionesR.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport1.Report = SubReportePercepcionesR

        Dim SubReporteDeduccionesR As New DeduccionesRenuncia
        SubReporteDeduccionesR.Parameters.Clear()

        'aqui se agregan
        SubReporteDeduccionesR.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeduccionesR.Parameters.Add(ParamIdTipoNominaAsig)
        SubReporteDeduccionesR.Parameters.Add(ParamIdTipoNominaProc)
        SubReporteDeduccionesR.Parameters.Add(ParamAnio)
        SubReporteDeduccionesR.Parameters.Add(ParamPeriodo)
        SubReporteDeduccionesR.Parameters.Add(ParamIdEmpleado)
        SubReporteDeduccionesR.Parameters.Add(ParamUID)
        SubReporteDeduccionesR.Parameters.Add(ParamLID)
        SubReporteDeduccionesR.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeduccionesR.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeduccionesR.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        SubReporteDeduccionesR.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        SubReporteDeduccionesR.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeduccionesR.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        SubReporteDeduccionesR.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        SubReporteDeduccionesR.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteDeduccionesR.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeduccionesR.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReporteDeduccionesR

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


End Class
