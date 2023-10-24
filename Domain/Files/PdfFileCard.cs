namespace FileCards.Domain;

public class PdfFileCard : FileCard
{
    public PdfFileCard(string path) : base(path) { }

    public override string Extension => "pdf";
}