namespace Lesson1Dapper.Models.DTOs;

internal record AuthorBookDto
{
    public string FirstName { get; }
    public string LastName { get; }
    public string BookName { get; }
}
