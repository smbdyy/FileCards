namespace FileCards.Domain;

public class DocxFileCard : FileCard
{
    public DocxFileCard(string path) : base(path) { }

    public override string Extension => "docx";
}