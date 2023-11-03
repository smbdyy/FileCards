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

        foreach (var card in fileCards)
        {
            _filesDataGrid.Rows.Add(card.Name);
        }
    }

    private async void AddFileButtonClicked(object sender, EventArgs e)
    {
        using var dialog = CreateFilePickingDialog();
        if (dialog.ShowDialog() != DialogResult.OK) return;

        try
        {
            await _mediator.Send(new AddNewFile.Request(dialog.FileName, string.Empty));
            var filename = Path.GetFileName(dialog.FileName);
            _filesDataGrid.Rows.Add(filename);
        }
        catch (Exception ex)
        {
            ErrorMessage.ShowWithMessage(ex.Message);
        }
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

    private async void FilesDataGridCellClicked(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == _openButtonColumn.Index && e.RowIndex >= 0)
        {
            var cell = _filesDataGrid.Rows[e.RowIndex].Cells["Filename"];
            var filename = cell.Value.ToString() ?? string.Empty;
            var response = await _mediator.Send(new GetFileByName.Request(filename));

            var fileCardForm = new FileCardForm(response.File, _mediator);
            fileCardForm.ShowDialog();
            cell.Value = fileCardForm.CurrentName;
        }
    }
}