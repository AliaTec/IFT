Imports System.Data

Public Class Items
    Inherits DataTable

    Public Sub New()
        Me.Columns.Add("Label")
        Me.Columns.Add("Accion")
        Me.Columns.Add("Case")

        Dim newRow As DataRow

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100014
        ''accion
        'newRow.Item("Accion") = 100014
        ''case del aspx
        'newRow.Item("Case") = 100014
        'Me.Rows.Add(newRow)

        newRow = Me.NewRow()
        newRow.Item("Label") = 100016
        'accion
        newRow.Item("Accion") = 100016
        'case del aspx
        newRow.Item("Case") = 100016
        Me.Rows.Add(newRow)

        newRow = Me.NewRow()
        newRow.Item("Label") = 100017
        'accion
        newRow.Item("Accion") = 100017
        'case del aspx
        newRow.Item("Case") = 100017
        Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100019
        ''accion
        'newRow.Item("Accion") = 100019
        ''case del aspx
        'newRow.Item("Case") = 100019
        'Me.Rows.Add(newRow)

        newRow = Me.NewRow()
        newRow.Item("Label") = 100020
        'accion
        newRow.Item("Accion") = 100020
        'case del aspx
        newRow.Item("Case") = 100020
        Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100021
        ''accion
        'newRow.Item("Accion") = 100021
        ''case del aspx
        'newRow.Item("Case") = 100021
        'Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100022
        ''accion
        'newRow.Item("Accion") = 100022
        ''case del aspx
        'newRow.Item("Case") = 100022
        'Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100023
        ''accion
        'newRow.Item("Accion") = 100023
        ''case del aspx
        'newRow.Item("Case") = 100023
        'Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100024
        ''accion
        'newRow.Item("Accion") = 100024
        ''case del aspx
        'newRow.Item("Case") = 100024
        'Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100025
        ''accion
        'newRow.Item("Accion") = 100025
        ''case del aspx
        'newRow.Item("Case") = 100025
        'Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100026
        ''accion
        'newRow.Item("Accion") = 100026
        ''case del aspx
        'newRow.Item("Case") = 100026
        'Me.Rows.Add(newRow)

        newRow = Me.NewRow()
        newRow.Item("Label") = 100027
        'accion
        newRow.Item("Accion") = 100027
        'case del aspx
        newRow.Item("Case") = 100027
        Me.Rows.Add(newRow)

        newRow = Me.NewRow()
        newRow.Item("Label") = 100028
        'accion
        newRow.Item("Accion") = 100028
        'case del aspx
        newRow.Item("Case") = 100028
        Me.Rows.Add(newRow)

        newRow = Me.NewRow()
        newRow.Item("Label") = 100029
        'accion
        newRow.Item("Accion") = 100029
        'case del aspx
        newRow.Item("Case") = 100029
        Me.Rows.Add(newRow)

        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100031
        ''accion
        'newRow.Item("Accion") = 100031
        ''case del aspx
        'newRow.Item("Case") = 100031
        'Me.Rows.Add(newRow)

        ''''''''NUEVOS LAYOUTS''''''

        'Layout_Altas_Interbancario
        newRow = Me.NewRow()
        newRow.Item("Label") = 100118
        'accion
        newRow.Item("Accion") = 100118
        'case del aspx
        newRow.Item("Case") = 100118
        Me.Rows.Add(newRow)

        'Layout_Altas_Bancomer
        newRow = Me.NewRow()
        newRow.Item("Label") = 100119
        'accion
        newRow.Item("Accion") = 100119
        'case del aspx
        newRow.Item("Case") = 100119
        Me.Rows.Add(newRow)

        'Layout_Nómina_Interbancario
        newRow = Me.NewRow()
        newRow.Item("Label") = 100120
        'accion
        newRow.Item("Accion") = 100120
        'case del aspx
        newRow.Item("Case") = 100120
        Me.Rows.Add(newRow)

        'Layout_Nómina_Bancomer
        newRow = Me.NewRow()
        newRow.Item("Label") = 100121
        'accion
        newRow.Item("Accion") = 100121
        'case del aspx
        newRow.Item("Case") = 100121
        Me.Rows.Add(newRow)

        'Layout_Nómina_Interbancario_Liberados
        newRow = Me.NewRow()
        newRow.Item("Label") = 100122
        'accion
        newRow.Item("Accion") = 100122
        'case del aspx
        newRow.Item("Case") = 100122
        Me.Rows.Add(newRow)

        'Layout_Nómina_Bancomer_Liberados
        newRow = Me.NewRow()
        newRow.Item("Label") = 100123
        'accion
        newRow.Item("Accion") = 100123
        'case del aspx
        newRow.Item("Case") = 100123
        Me.Rows.Add(newRow)

        'Layout_SPEI_Interbancario
        newRow = Me.NewRow()
        newRow.Item("Label") = 100124
        'accion
        newRow.Item("Accion") = 100124
        'case del aspx
        newRow.Item("Case") = 100124
        Me.Rows.Add(newRow)

        'Layout_SPEI_Bancomer
        newRow = Me.NewRow()
        newRow.Item("Label") = 100125
        'accion
        newRow.Item("Accion") = 100125
        'case del aspx
        newRow.Item("Case") = 100125
        Me.Rows.Add(newRow)

        ''Layout_SPEI_Interbancario_Liberados
        'newRow = Me.NewRow()
        'newRow.Item("Label") = 100126
        ''accion
        'newRow.Item("Accion") = 100126
        ''case del aspx
        'newRow.Item("Case") = 100126
        'Me.Rows.Add(newRow)

        'Layout_SPEI_Bancomer_Liberados
        newRow = Me.NewRow()
        newRow.Item("Label") = 100127
        'accion
        newRow.Item("Accion") = 100127
        'case del aspx
        newRow.Item("Case") = 100127
        Me.Rows.Add(newRow)

        'Layout_SPEI_Interbancario_Liberados
        newRow = Me.NewRow()
        newRow.Item("Label") = 100128
        'accion
        newRow.Item("Accion") = 100128
        'case del aspx
        newRow.Item("Case") = 100128
        Me.Rows.Add(newRow)

    End Sub
End Class