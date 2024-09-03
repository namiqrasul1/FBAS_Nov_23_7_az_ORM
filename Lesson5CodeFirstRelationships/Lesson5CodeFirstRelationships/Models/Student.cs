using System.ComponentModel.DataAnnotations;

namespace Lesson5CodeFirstRelationships.Models;

#region Default Convention
//public class Student
//{
//    //public int Id { get; set; }
//    //public int ID { get; set; }
//    //public int StudentID { get; set; }
//    //public int StudentId { get; set; }

//    public int Id { get; set; }
//    public string Name { get; set; } = null!; // not null
//    public string Surname { get; set; } // not null
//    public double? Average { get; set; } // null
//}
#endregion

#region Data Annotation

//public class Student
//{
//    [Key]
//    public int Id { get; set; }
//    [MaxLength(25)]
//    public string Name { get; set; } = null!; // not null
//    public string Surname { get; set; } // not null
//    public double? Average { get; set; } // null
//}


#endregion

#region Fluent Api

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // not null
    public string Surname { get; set; } // not null
    public double? Average { get; set; } // null
}


#endregion

