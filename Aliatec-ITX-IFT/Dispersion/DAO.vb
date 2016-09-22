Imports Intelexion.Framework.Model
Imports System.Data
Imports Intelexion.Nomina
Imports System.Web
Imports System.Collections
Imports System.Collections.Specialized
Imports Intelexion.Framework.Controller
Imports Intelexion.Framework.View
Imports System.IO
Imports System.Data.SqlClient

Public Class DAO
    Inherits Intelexion.Framework.Model.DAO

    Private Const LayoutDispersionBANCOMER_NETCASH108 As String = "sp_Reporte_LayoutDisPersionBANCOMER '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMER_Liberados As String = "sp_Reporte_LayoutDisPersionBANCOMER_Liberados '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMER_108Tradicional As String = "sp_Reporte_LayoutDispersionBANCOMER_108Tradicional '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMER_108TradicionalInter As String = "sp_Reporte_LayoutDispersionBANCOMER_108TradicionalInter '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMERAltas As String = "sp_Reporte_LayoutDispersionBANCOMERAltas '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMERAltasInter As String = "sp_Reporte_LayoutDispersionBANCOMERAltasInter '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMER_Liberados_SPEI As String = "sp_Reporte_LayoutDisPersionBANCOMER_Liberados_SPEI '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMER_SPEI As String = "sp_Reporte_LayoutDisPersionBANCOMER_SPEI '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const ValesDespensaInfotec As String = "sp_Reporte_LayoutValesDespensaInfotec '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutProvisionesporQuincenaInfotec As String = "sp_Reporte_ProvisionesXQuincena '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const ReporteSIIWEB As String = "sp_Reporte_SIIWEB_INS '@IdRazonSocial','@IdTipoNominaAsig','@Anio','@Mes','@UID','@LID','@idAccion'"
    Private Const ReporteSIIWEBEventual As String = "sp_Reporte_SIIWEB_EVE '@IdRazonSocial','@IdTipoNominaAsig','@Anio','@Mes','@UID','@LID','@idAccion'"
    Private Const ReporteCentroCostos As String = "sp_CentroCostoscategoria '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const spPolizaContable As String = "spq_PolizaContableSuntory '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const spReportePropinas As String = "sp_Reporte_Propinas '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    'Private Const LayoutDispersionHSBC As String = "sp_Reporte_LayoutDispersionHSBC_ALI '@IdRazonSocial','@IdEmpleado','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const ReporteCentroCostosporProyectos As String = "sp_CentroCostosCategoria2 '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"

    Private Const LayoutDispersionBANCOMER_108Tradicional_Liberados As String = "sp_Reporte_LayoutDispersionBANCOMER_108Tradicional_Liberados '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const LayoutDispersionBANCOMER_108TradicionalInter_Liberados As String = "sp_Reporte_LayoutDispersionBANCOMER_108TradicionalInter_Liberados '@IdRazonSocial','@IdTipoNominaAsig','@IdTipoNominaProc','@Anio','@Periodo','@UID','@LID','@idAccion'"
    Private Const ReporteAuditoria As String = "sp_Reporte_Auditoria '@IdRazonSocial','@IdTipoNominaAsig','@Anio','@Mes','@UID','@LID','@idAccion'"

    Public Sub New(ByVal DataConnection As SQLDataConnection)
        MyBase.New(DataConnection)
    End Sub
    Public Function Layout(ByVal ReportesProceso As EntitiesITX.ReportesProceso, ByVal opL As String) As DataSet
        Dim ds As New DataSet
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            Select Case opL

                Case "ValesDespensaInfotec"
                    comandstr = ValesDespensaInfotec
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds

                Case "LayoutProvisionesporQuincenaInfotec"
                    comandstr = LayoutProvisionesporQuincenaInfotec
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds

                Case "ReporteCentroCostos"
                    comandstr = ReporteCentroCostos
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds

                Case "ReporteSIIWEB"
                    comandstr = ReporteSIIWEB
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds

                Case "ReporteSIIWEBEventual"
                    comandstr = ReporteSIIWEBEventual
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds
                    'Case "spPolizaContable"
                    '    comandstr = spPolizaContable
                    '    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    '    Return ds

                Case "ReporteCentroCostosporProyectos"
                    comandstr = ReporteCentroCostosporProyectos
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds

                Case "ReporteAuditoria"
                    comandstr = ReporteAuditoria
                    resultado = Me.ExecuteQuery(comandstr, ds, ReportesProceso)
                    Return ds

            End Select
        Catch e As Exception


        End Try
        Return ds
    End Function

    Public Function LayoutTxt(ByVal ReportesProceso As EntitiesITX.ReportesProceso, ByVal opL As String, ByVal context As System.Web.HttpContext) As String
        Dim ds As New DataSet
        Dim sFile As String
        Dim sPathApp As String = Intelexion.Framework.ApplicationConfiguration.ConfigurationSettings.GetConfigurationSettings("ApplicationPath")
        Dim sPathArchivosTemp As String = Intelexion.Framework.ApplicationConfiguration.ConfigurationSettings.GetConfigurationSettings("ArchivosTemporales")
        'Dim ruta As String
        Try
            Select Case opL

                
                Case "LayoutDispersionBANCOMER_NETCASH108"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMER_NETCASH108" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMER(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile

                Case "LayoutDispersionBANCOMER_Liberados"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\DispersionBancomerLiberados" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMER_Liberados(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile

                Case "LayoutDispersionBANCOMER_108Tradicional"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMER_108Tradicional" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERTradicional(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile

                Case "LayoutDispersionBANCOMER_108TradicionalInter"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMER_108TradicionalInter" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERTradicionalInter(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile

                Case "LayoutDispersionBANCOMERAltas"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMERAltas" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERAltas(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile


                Case "LayoutDispersionBANCOMERAltasInter"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMERAltasInter" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERAltasInter(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile


                Case "LayoutDispersionBANCOMER_Liberados_SPEI"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMERLiberaSPEI" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERSPEI_Libera(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile



                Case "LayoutDispersionBANCOMER_SPEI"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMERSPEI" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERSPEI(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile


                Case "LayoutDispersionBANCOMER_108Tradicional_Liberados"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMER_108Tradicional_Lib" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERTradicional_Liberados(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile

                Case "LayoutDispersionBANCOMER_108TradicionalInter_Liberados"
                    Dim results As ResultCollection
                    Dim objLayoutDispersion As Entities.LayoutDispersion
                    Dim dTotalImporte As Decimal
                    Dim sCadena As String
                    Dim i As Integer
                    results = New ResultCollection
                    ReportesProceso.tipoArchivo = 0
                    objLayoutDispersion = New Entities.LayoutDispersion
                    objLayoutDispersion.IdRazonSocial = context.Session("IdRazonSocial")
                    objLayoutDispersion.UID = context.Session("UID")
                    objLayoutDispersion.LID = context.Session("LID")
                    objLayoutDispersion.idAccion = context.Items.Item("idAccion")
                    Dim UserId As String
                    UserId = ReportesProceso.UID.ToString
                    UserId = UserId.Replace("/", "")
                    UserId = UserId.Replace("\", "")
                    UserId = UserId.Replace("%", "")
                    UserId = UserId.Replace("_", "")
                    UserId = UserId.Replace("-", "")
                    sFile = "\LayoutDispersionBANCOMER_108TradicionalInter_Lib" + ReportesProceso.IdRazonSocial.ToString + UserId + Date.Now.Second.ToString + ".txt"

                    results.getEntitiesFromDataReader(objLayoutDispersion, Me.ReporteDispersionBANCOMERTradicionalInter_Liberados(ReportesProceso))
                    dTotalImporte = 0
                    If results.Count > 0 Then
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        For i = 0 To results.Count - 1
                            sCadena = results(i).centroCosto
                            sw.WriteLine(sCadena)
                        Next i

                        sw.Close()
                    Else
                        Dim sb As New FileStream(context.Server.MapPath(sPathApp + sPathArchivosTemp) + sFile, FileMode.Create)
                        Dim sw As New StreamWriter(sb)

                        sCadena = "No se genero información con los datos recibidos."
                        sw.WriteLine(sCadena)
                        sw.Close()

                    End If

                    Return sPathApp + sPathArchivosTemp + sFile
            End Select
        Catch e As Exception
        End Try
        Return ""
    End Function

    Public Function ReporteDispersionBANCOMER(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_NETCASH108
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMER_Liberados(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_Liberados
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERTradicional(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_108Tradicional
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERTradicionalInter(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_108TradicionalInter
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERAltas(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMERAltas
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERAltasInter(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMERAltasInter
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERSPEI(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_SPEI
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERSPEI_Libera(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_Liberados_SPEI
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERTradicional_Liberados(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_108Tradicional_Liberados
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function

    Public Function ReporteDispersionBANCOMERTradicionalInter_Liberados(ByVal ReportesProceso As EntitiesITX.ReportesProceso) As SqlDataReader
        Dim data As SqlDataReader = Nothing
        Dim resultado As Boolean
        Dim comandstr As String
        Try
            comandstr = LayoutDispersionBANCOMER_108TradicionalInter_Liberados
            resultado = Me.ExecuteQuery(comandstr, data, ReportesProceso)
            Return data
        Catch e As Exception
        End Try
        Return data
    End Function


End Class
