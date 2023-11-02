using System.ComponentModel;

namespace Client.Forms;

partial class MainForm
{
    private IContainer components = null;

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
    private DataGridViewButtonColumn _openButtonColumn;
    
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
        _filesDataGrid.RowTemplate.Height = 30;
        _filesDataGrid.Size = new System.Drawing.Size(360, 367);
        _filesDataGrid.TabIndex = 1;
        _filesDataGrid.AutoGenerateColumns = false;
        _filesDataGrid.RowHeadersVisible = false;
        _filesDataGrid.CellContentClick += FilesDataGridCellClicked;

        var filenameColumn = new DataGridViewTextBoxColumn();
        filenameColumn.HeaderText = "Имя файла";
        filenameColumn.Name = "Filename";
        filenameColumn.Resizable = DataGridViewTriState.False;
        filenameColumn.Width = 217;
        _filesDataGrid.Columns.Add(filenameColumn);

        _openButtonColumn = new DataGridViewButtonColumn();
        _openButtonColumn.HeaderText = string.Empty;
        _openButtonColumn.Text = "Открыть карточку";
        _openButtonColumn.UseColumnTextForButtonValue = true;
        _openButtonColumn.Resizable = DataGridViewTriState.False;
        _openButtonColumn.Width = 140;
        _filesDataGrid.Columns.Add(_openButtonColumn);
        // 
        // Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(390, 476);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MinimizeBox = false;
        MaximizeBox = false;
        Name = "MainForm";
        Text = "FileCards";
        Load += FormLoaded;
        
        Controls.Add(_filesDataGrid);
        Controls.Add(_addFileButton);

        ((System.ComponentModel.ISupportInitialize)(_filesDataGrid)).EndInit();
        ResumeLayout(false);
    }
}