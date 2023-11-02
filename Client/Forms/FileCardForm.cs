using Application.Dto;

namespace Client.Forms;

public partial class FileCardForm : Form
{
    private readonly FileCardDto _fileCard;
    
    public FileCardForm(FileCardDto fileCard)
    {
        _fileCard = fileCard;
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
}