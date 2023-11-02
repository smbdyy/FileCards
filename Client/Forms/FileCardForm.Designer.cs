using System.ComponentModel;

namespace Client.Forms;

partial class FileCardForm
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
    
    private Label _descriptionLabel;
    private Button _saveChangesButton;
    private TextBox _descriptionTextBox;
    private Label _lastEditTimeLabel;
    private Label _extensionLabel;
    private TextBox _filenameTextBox;
    private Button _deleteCardButton;

    private void InitializeComponent()
    {
        _filenameTextBox = new TextBox();
        _extensionLabel = new Label();
        _descriptionTextBox = new TextBox();
        _lastEditTimeLabel = new Label();
        _saveChangesButton = new Button();
        _descriptionLabel = new Label();
        _deleteCardButton = new Button();
        SuspendLayout();
        // 
        // _filenameTextBox
        // 
        _filenameTextBox.Location = new System.Drawing.Point(15, 29);
        _filenameTextBox.Name = "_filenameTextBox";
        _filenameTextBox.Size = new System.Drawing.Size(217, 22);
        _filenameTextBox.TabIndex = 0;
        // 
        // _extensionLabel
        // 
        _extensionLabel.Location = new System.Drawing.Point(238, 29);
        _extensionLabel.Name = "_extensionLabel";
        _extensionLabel.Size = new System.Drawing.Size(45, 22);
        _extensionLabel.TabIndex = 1;
        _extensionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _descriptionTextBox
        // 
        _descriptionTextBox.Location = new System.Drawing.Point(15, 93);
        _descriptionTextBox.Multiline = true;
        _descriptionTextBox.Name = "_descriptionTextBox";
        _descriptionTextBox.Size = new System.Drawing.Size(267, 275);
        _descriptionTextBox.TabIndex = 2;
        // 
        // _lastEditTimeLabel
        // 
        _lastEditTimeLabel.Location = new System.Drawing.Point(15, 384);
        _lastEditTimeLabel.Name = "_lastEditTimeLabel";
        _lastEditTimeLabel.Size = new System.Drawing.Size(266, 45);
        _lastEditTimeLabel.TabIndex = 3;
        _lastEditTimeLabel.Text = "Время последнего изменения:";
        // 
        // _saveChangesButton
        // 
        _saveChangesButton.Location = new System.Drawing.Point(15, 432);
        _saveChangesButton.Name = "_saveChangesButton";
        _saveChangesButton.Size = new System.Drawing.Size(193, 28);
        _saveChangesButton.TabIndex = 4;
        _saveChangesButton.Text = "Сохранить";
        _saveChangesButton.UseVisualStyleBackColor = true;
        // 
        // _descriptionLabel
        // 
        _descriptionLabel.Location = new System.Drawing.Point(15, 68);
        _descriptionLabel.Name = "_descriptionLabel";
        _descriptionLabel.Size = new System.Drawing.Size(214, 22);
        _descriptionLabel.TabIndex = 5;
        _descriptionLabel.Text = "Описание:";
        // 
        // _deleteCardButton
        // 
        _deleteCardButton.Location = new System.Drawing.Point(15, 466);
        _deleteCardButton.Name = "_deleteCardButton";
        _deleteCardButton.Size = new System.Drawing.Size(193, 28);
        _deleteCardButton.TabIndex = 6;
        _deleteCardButton.Text = "Удалить карточку";
        _deleteCardButton.UseVisualStyleBackColor = true;
        // 
        // FileCardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(307, 516);
        Controls.Add(_descriptionLabel);
        Controls.Add(_saveChangesButton);
        Controls.Add(_lastEditTimeLabel);
        Controls.Add(_descriptionTextBox);
        Controls.Add(_extensionLabel);
        Controls.Add(_filenameTextBox);
        Controls.Add(_deleteCardButton);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FileCardForm";
        Text = "FileCardForm";
        ResumeLayout(false);
        PerformLayout();
    }
}