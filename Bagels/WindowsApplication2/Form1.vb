'Eric Skipper
'Chapter 5, Bagel making

Option Strict On
Option Explicit On

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set date
        Dim thisDay As Date
        thisDay = Today
        tslDate.Text = thisDay.ToString("d")

        'set initial four values
        cmbBagels.Items.Add("Blueberry")
        cmbBagels.Items.Add("Whole Wheat")
        cmbBagels.Items.Add("Poppyseed")
        cmbBagels.Items.Add("Everything")

        'sort the list and keep it sorted
        cmbBagels.Sorted = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'input
        Dim newBagel As String
        newBagel = cmbBagels.Text.ToString

        'processing
        Dim isBagelAlreadyHere As Boolean
        isBagelAlreadyHere = False

        If newBagel <> "" Then
            For counter = 0 To cmbBagels.Items.Count - 1
                cmbBagels.SelectedIndex = counter
                If cmbBagels.SelectedItem.ToString.ToLower = newBagel.ToLower Then
                    isBagelAlreadyHere = True
                End If
            Next
            'output
            If isBagelAlreadyHere Then
                MessageBox.Show("This bagel type already exists, try a new type of bagel.", "Not valid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbBagels.Text = ""
                cmbBagels.Focus()
            Else
                cmbBagels.Items.Add(newBagel)
                lblBagelCount.Text = ""
                cmbBagels.Text = ""
            End If
        Else
            MessageBox.Show("No Bagel inputed, we need a new bagel...", "Not valid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbBagels.Focus()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'input
        Dim messageResponse As DialogResult
        messageResponse = MessageBox.Show("Are you sure you want to clear the list?", "Desicions....", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'processing
        If messageResponse = DialogResult.Yes Then
            'output
            cmbBagels.Items.Clear()
            cmbBagels.Text = ""
            lblBagelCount.Text = ""
            cmbBagels.Focus()
        End If
    End Sub

    Private Sub btnCount_Click(sender As Object, e As EventArgs) Handles btnCount.Click
        lblBagelCount.Text = cmbBagels.Items.Count.ToString
        cmbBagels.Focus()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If cmbBagels.Items.Count = 0 Then
            MessageBox.Show("No begals to delete, maybe add some...?", "Deletion Requirements", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbBagels.Focus()
        Else
            If cmbBagels.SelectedIndex = -1 Then
                MessageBox.Show("Please select a bagel to delete from the list.", "Deletion Requirments", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbBagels.Focus()
            Else
                cmbBagels.Items.RemoveAt(cmbBagels.SelectedIndex)
                cmbBagels.Focus()
                lblBagelCount.Text = ""
            End If
        End If
    End Sub
End Class
