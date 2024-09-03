using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson5CodeFirstRelationships.Models;

#region Default Convention

//public class User
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public PhoneNumber Number { get; set; }
//}

//public class PhoneNumber
//{
//    public int Id { get; set; }
//    public string Number { get; set; }
//    public int UserId { get; set; }
//    public User User { get; set; }
//}



#endregion

#region Data Annotation

//public class User
//{
//    [Key]
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public PhoneNumber Number { get; set; }
//}

//public class PhoneNumber
//{
//    [Key, ForeignKey(nameof(Models.User))]
//    public int Id { get; set; }
//    public string Number { get; set; }
//    public User User { get; set; }
//}

#endregion

#region Fluent Api

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public PhoneNumber Number { get; set; }
}

public class PhoneNumber
{
    public int Id { get; set; }
    public string Number { get; set; }
    public User User { get; set; }
}


#endregion
