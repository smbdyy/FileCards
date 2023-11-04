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

    private async void DeleteCardButtonClicked(object sender, EventArgs e)
    {
        
    }

    private async void SaveChangesButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if (_filenameTextBox.Text != Path.GetFileNameWithoutExtension(_fileCard.Name))
            {
                await RenameFileAsync(_filenameTextBox.Text);
            }

            if (_descriptionTextBox.Text != _fileCard.Description)
            {
                await ChangeDescriptionAsync(_descriptionTextBox.Text);
            }
            
            Close();
        }
        catch (Exception ex)
        {
            ErrorMessage.ShowWithMessage(ex.Message);
        }
    }

    private async Task RenameFileAsync(string newName)
    {
        await _mediator.Send(new RenameFile.Request(_fileCard.Name, newName));
        CurrentName = newName + Path.GetExtension(_fileCard.Name);
    }

    private async Task ChangeDescriptionAsync(string newDescription)
    {
        await _mediator.Send(new ChangeFileDescription.Request(CurrentName, newDescription));
    }
}