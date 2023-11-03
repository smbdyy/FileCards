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
        CurrentName = _fileCard.Name;
        InitializeComponent();
        FillValues();
    }
    
    public string CurrentName { get; private set; }

    private void FillValues()
    {
        _filenameTextBox.Text = Path.GetFileNameWithoutExtension(_fileCard.Name);
        _extensionLabel.Text = Path.GetExtension(_fileCard.Name);
        _descriptionTextBox.Text = _fileCard.Description;
        _lastEditTimeLabel.Text = $"Время последнего изменения:\n{_fileCard.LastEditTime}";
    }

    private async void SaveChangesButtonClicked(object sender, EventArgs e)
    {
        var errorOccured = false;
        
        if (_filenameTextBox.Text != Path.GetFileNameWithoutExtension(_fileCard.Name))
        {
            errorOccured = await RenameFileAsync(_filenameTextBox.Text);
        }

        if (_descriptionTextBox.Text != _fileCard.Description)
        {
            errorOccured = await ChangeDescriptionAsync(_descriptionTextBox.Text);
        }

        if (!errorOccured)
        {
            Close();
        }
    }

    private async Task<bool> RenameFileAsync(string newName)
    {
        try
        {
            await _mediator.Send(new RenameFile.Request(_fileCard.Name, newName));
            CurrentName = newName + Path.GetExtension(_fileCard.Name);
            return false;
        }
        catch (Exception ex)
        {
            ErrorMessage.ShowWithMessage(ex.Message);
            return true;
        }
    }

    private async Task<bool> ChangeDescriptionAsync(string newDescription)
    {
        try
        {
            await _mediator.Send(new ChangeFileDescription.Request(CurrentName, newDescription));
            return false;
        }
        catch (Exception ex)
        {
            ErrorMessage.ShowWithMessage(ex.Message);
            return true;
        }
    }
}