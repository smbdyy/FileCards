using System.Windows.Forms;
using Application.Dto;

namespace Client.Forms;

public partial class FileCardForm : Form
{
    private readonly FileCardDto _fileCard;
    
    public FileCardForm(FileCardDto fileCard)
    {
        _fileCard = fileCard;
        InitializeComponent();
    }
}