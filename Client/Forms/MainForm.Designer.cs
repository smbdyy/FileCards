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
    
    private VScrollBar _filesGridScrollBar;
    private DataGridView _filesDataGrid;
    private Button _addFileButton;
    
    private void InitializeComponent()
    {
        _addFileButton = new Button();
        _filesDataGrid = new DataGridView();
        _filesGridScrollBar = new VScrollBar();
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
        _filesDataGrid.Size = new System.Drawing.Size(336, 367);
        _filesDataGrid.TabIndex = 1;
        // 
        // _filesGridScrollBar
        // 
        _filesGridScrollBar.Location = new System.Drawing.Point(352, 82);
        _filesGridScrollBar.Name = "_filesGridScrollBar";
        _filesGridScrollBar.Size = new System.Drawing.Size(23, 367);
        _filesGridScrollBar.TabIndex = 2;
        // 
        // Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(392, 476);
        Controls.Add(_filesGridScrollBar);
        Controls.Add(_filesDataGrid);
        Controls.Add(_addFileButton);
        Name = "MainForm";
        Text = "FileCards";
        Load += FormLoaded;

        ((System.ComponentModel.ISupportInitialize)(_filesDataGrid)).EndInit();
        ResumeLayout(false);
    }
}