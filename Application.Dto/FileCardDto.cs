namespace Application.Dto;

public record FileCardDto(string Name, string Description)
{
    public DateTime LastEditTime { get; set; }
}