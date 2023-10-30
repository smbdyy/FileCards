namespace Client.Forms;

public partial class ErrorMessage : Form
{
    public ErrorMessage(string message)
    {
        InitializeComponent();
        _message.Text = message;
    }

    public static void ShowWithMessage(string message)
    {
        var form = new ErrorMessage(message);
        form.ShowDialog();
    }
}