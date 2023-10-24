namespace FileCards.Domain;

public class TxtFileCard : FileCard
{
    public TxtFileCard(string path) : base(path) { }

    public override string Extension => "txt";
}