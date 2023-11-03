using Application.Contracts;
using Application.Dto;
using MediatR;

namespace Client.Forms;

public partial class FileCardForm : Form
{
    private readonly FileCardDto _fileCard;
    private readonly IMediator _mediator;
    
    public FileCardForm(FileCardDto fileCard, IMediator mediator)
    {
        _fileCard = fileCard;
        _mediator = mediator;
        InitializeComponent();
        FillValues();
    }

    private void FillValues()
    {
        _filenameTextBox.Text = Path.GetFileNameWithoutExtension(_fileCard.Name);
        _extensionLabel.Text = Path.GetExtension(_fileCard.Name);
        _descriptionLabel.Text = _fileCard.Description;
        _lastEditTimeLabel.Text = $"Время последнего изменения:\n{_fileCard.LastEditTime}";
    }

    private async void SaveChangesButtonClicked(object sender, EventArgs e)
    {
        if (_filenameTextBox.Text != _fileCard.Name)
        {
            await RenameFileAsync(_filenameTextBox.Text);
        }
    }

    private async Task RenameFileAsync(string newName)
    {
        try
        {
            await _mediator.Send(new RenameFile.Request(_fileCard.Name, newName));
        }
        catch (Exception ex)
        {
            ErrorMessage.ShowWithMessage(ex.Message);
        }
    }
}