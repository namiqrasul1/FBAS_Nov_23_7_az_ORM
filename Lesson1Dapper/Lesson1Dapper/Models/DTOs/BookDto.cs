﻿namespace Lesson1Dapper.Models.DTOs;

internal record BookDto
{
    public string Name { get; }
    public int Pages { get; }
    public int Quantity { get; }
}
