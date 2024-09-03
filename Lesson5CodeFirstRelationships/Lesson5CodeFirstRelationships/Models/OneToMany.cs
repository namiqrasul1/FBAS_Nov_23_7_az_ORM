using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson5CodeFirstRelationships.Models;

#region Default Convention

//public class Product
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public int CategoryId { get; set; }
//    public Category Category { get; set; }
//}

//public class Category
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Product> Products { get; set; }
//}

#endregion

#region Data Annotation

//public class Product
//{
//    [Key] // Primary Key
//    public int Id { get; set; }

//    public string Name { get; set; }

//    [ForeignKey(nameof(Models.Category))]
//    public int CategoryId { get; set; }

//    public Category Category { get; set; }
//}

//public class Category
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Product> Products { get; set; }
//}


#endregion

#region Fluent Api


public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}


#endregion

