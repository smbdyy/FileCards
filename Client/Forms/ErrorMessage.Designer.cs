using System.ComponentModel;

namespace Client.Forms;

partial class ErrorMessage
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

    private void InitializeComponent()
    {
        _message = new Label();
        SuspendLayout();
        //
        // _message
        //
        _message.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
        _message.Location = new Point(48, 54);
        _message.Name = "_message";
        _message.Size = new Size(283, 139);
        _message.TabIndex = 0;
        _message.Text = "sdfsadf";
        _message.TextAlign = ContentAlignment.MiddleCenter;
        //
        // Form
        //
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(385, 246);
        Controls.Add(_message);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Ошибка";
        Text = "Ошибка";
        TopMost = true;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        ResumeLayout(false);
    }

    private Label _message;
}