namespace Client.Forms;

public partial class ErrorMessage : Form
{
    public ErrorMessage(string message)
    {
        InitializeComponent();
        _message.Text = message;
    }
}