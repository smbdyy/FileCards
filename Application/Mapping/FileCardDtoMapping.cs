using Application.Dto;
using FileCards.Application.Storage;
using FileCards.Domain;

namespace FileCards.Application.Mapping;

public static class FileCardDtoMapping
{
    public static FileCardDto AsDto(this FileCard file)
        => new(file.Name, file.Description, file.GetLastEditTime());
}