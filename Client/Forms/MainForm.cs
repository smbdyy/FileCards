using System.Windows.Forms;
using Application.Contracts;
using MediatR;

namespace Client.Forms;

public partial class MainForm : Form
{
    private readonly IMediator _mediator;
    
    public MainForm(IMediator mediator)
    {
        _mediator = mediator;
        InitializeComponent();
    }

    private async void FormLoaded(object sender, EventArgs e)
    {
        var response = await _mediator.Send(new GetAllFiles.Request());
        var fileCards = response.Files;
    }

    private async void AddFileButtonClicked(object sender, EventArgs e)
    {
        using var dialog = CreateFilePickingDialog();
        if (dialog.ShowDialog() != DialogResult.OK) return;

        var filepath = dialog.FileName;
        
    }

    private static OpenFileDialog CreateFilePickingDialog()
    {
        var dialog = new OpenFileDialog();
        dialog.AddExtension = true;
        dialog.CheckFileExists = true;
        dialog.CheckPathExists = true;
        dialog.Multiselect = true;
        dialog.SelectReadOnly = true;
        dialog.Filter = "PDF Files (*.pdf)|*.pdf|Word Files (*.docx)|*.docx|Text Files (*.txt)|*.txt";

        return dialog;
    }
}