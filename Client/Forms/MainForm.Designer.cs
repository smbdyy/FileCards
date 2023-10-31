using System.ComponentModel;

namespace Client.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }
    
    private DataGridView _filesDataGrid;
    private Button _addFileButton;
    
    private void InitializeComponent()
    {
        _addFileButton = new Button();
        _filesDataGrid = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)(_filesDataGrid)).BeginInit();
        SuspendLayout();
        // 
        // _addFileButton
        // 
        _addFileButton.Location = new System.Drawing.Point(13, 22);
        _addFileButton.Name = "_addFileButton";
        _addFileButton.Size = new System.Drawing.Size(233, 33);
        _addFileButton.TabIndex = 0;
        _addFileButton.Text = "Добавить файл";
        _addFileButton.UseVisualStyleBackColor = true;
        _addFileButton.Click += AddFileButtonClicked;
        // 
        // _filesDataGrid
        // 
        _filesDataGrid.AllowUserToAddRows = false;
        _filesDataGrid.AllowUserToDeleteRows = false;
        _filesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _filesDataGrid.Location = new System.Drawing.Point(13, 82);
        _filesDataGrid.Name = "_filesDataGrid";
        _filesDataGrid.ReadOnly = true;
        _filesDataGrid.RowTemplate.Height = 24;
        _filesDataGrid.Size = new System.Drawing.Size(340, 367);
        _filesDataGrid.TabIndex = 1;
        _filesDataGrid.AutoGenerateColumns = false;
        _filesDataGrid.RowHeadersVisible = false;

        var filenameColumn = new DataGridViewTextBoxColumn();
        filenameColumn.HeaderText = "Имя файла";
        filenameColumn.Resizable = DataGridViewTriState.False;
        filenameColumn.Width = 217;
        _filesDataGrid.Columns.Add(filenameColumn);

        var editButtonColumn = new DataGridViewButtonColumn();
        editButtonColumn.HeaderText = string.Empty;
        editButtonColumn.Text = "Редактировать";
        editButtonColumn.UseColumnTextForButtonValue = true;
        editButtonColumn.Resizable = DataGridViewTriState.False;
        editButtonColumn.Width = 120;
        _filesDataGrid.Columns.Add(editButtonColumn);
        // 
        // Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(370, 476);
        Controls.Add(_filesDataGrid);
        Controls.Add(_addFileButton);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "MainForm";
        Text = "FileCards";
        Load += FormLoaded;

        ((System.ComponentModel.ISupportInitialize)(_filesDataGrid)).EndInit();
        ResumeLayout(false);
    }
}