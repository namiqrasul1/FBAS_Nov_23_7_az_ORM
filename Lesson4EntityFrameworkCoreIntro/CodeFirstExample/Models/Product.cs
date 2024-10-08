﻿namespace CodeFirstExample.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public List<Tag> Tags { get; set; }

    public bool IsExpensive() => 100 < Price; 

}
