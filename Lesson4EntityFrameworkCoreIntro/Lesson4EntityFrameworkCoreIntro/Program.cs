using Lesson4EntityFrameworkCoreIntro.Data;
using Lesson4EntityFrameworkCoreIntro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

using var context = new LibraryContext();

//var authors = context.Authors.Where(a => a.FirstName.Contains("a")).ToList();

//foreach (var author in authors)
//    Console.WriteLine(author.FirstName);


//var author = new Author
//{
//    Id = 25,
//    FirstName = "Aleq",
//    LastName = "Alexandrovich"
//};

//context.Authors.Add(author);
//context.SaveChanges();

//var author = context.Authors.FirstOrDefault(a => a.Id == 25);

//if(author is not null)
//{
//    author.LastName = "Vladimerovich";
//    context.Authors.Update(author);
//    context.SaveChanges();
//}


//var author = context.Authors.FirstOrDefault(a => a.Id == 25);
//if (author is not null)
//{
//    context.Authors.Remove(author);
//    context.SaveChanges();
//}

// IQueryable   => translate to Sql 
// IEnumerable  => ramda saxlamaq uchun

//var au = context.Authors.ToList();
//var authors = context.Authors.Where(a => a.FirstName.Contains("a")).ToList();
//var author = context.Authors.SingleOrDefault(a => a.Id == 24);

//var query = context.Authors.Where(a => a.FirstName.Contains("a"));

//foreach (var item in query)
//{
//    Console.WriteLine($"{item.FirstName} {item.LastName}");
//}


//Console.WriteLine();
//Console.WriteLine();


//var author = new Author
//{
//    Id = 25,
//    LastName = "Ehmedov",
//    FirstName = "Kamil"
//};

//var author1 = new Author
//{
//    Id = 26,
//    LastName = "Fazilli",
//    FirstName = "Nazim"
//};
//context.Authors.Add(author);
//context.Authors.Add(author1);

//context.Authors.AddRange(author, author1);

//var author = new Author
//{
//    Id = 25,
//    LastName = "Ehmedov",
//    FirstName = "Kamil"
//};

//var ee = context.Authors.Entry(author);
//Console.WriteLine(ee.State);
//context.Authors.Add(author);
//Console.WriteLine(ee.State);

//context.SaveChanges();


//var author = context.Authors.FirstOrDefault(a => a.Id == 26);
//if (author is not null)
//{
//    Console.WriteLine(context.Authors.Entry(author).State);
//    //context.Authors.Remove(author);
//    context.Authors.Update(author);
//    Console.WriteLine(context.Authors.Entry(author).State);
//    context.SaveChanges();
//    Console.WriteLine(context.Authors.Entry(author).State);
//}


//var author = context.Authors.AsNoTracking().FirstOrDefault(a => a.Id == 26);

//Console.WriteLine(context.Authors.Entry(author!));

//author!.FirstName = "Ferid"; // Tracking

//context.Authors.Update(author);

//Console.WriteLine(context.Authors.Entry(author).State);

//context.SaveChanges(); 

// Code First
// Database First