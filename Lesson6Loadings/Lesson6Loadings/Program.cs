using Lesson6Loadings.Data;
using Lesson6Loadings.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using var context = new LibraryContext();

//var book = context.Books.SingleOrDefault(b => b.Name == "Ev tapshiriqlari");

// IQueryable 
// IEnumerable

// LINQ Methods
// LINQ Query

//var books = (from book in context.Books where book.YearPress > 2000 select book).ToList();

//var books = context.Books.Where(b => b.YearPress > 2000).ToList();

//foreach (var item in context.Books)
//{

//}

//var count = context.Books.Count(); // iqueryable
//var count1 = context.Books.ToList().Count(); 

//Console.WriteLine(count);
//Console.WriteLine(count1);

//var maxId = context.Books.Max(b => b.Id);
//var maxId1 = context.Books.ToList().Max(b => b.Id);

//var book = context.Books.SingleOrDefault(b => b.Name == "Ev tapshiriqlari");

// Loading
// Eager Loading
// Explicit Loading
// Auto Loading
// Lazy Loading


#region Eager Loading

//var book = context.Books.Include(b => b.Author).Include(b => b.Category).SingleOrDefault(b => b.Name == "Ev tapshiriqlari");

//var authors = context.Authors.Include(a => a.Books).ToList(); // author with books
//var authors1 = context.Authors.Include(a => a.Books).ThenInclude(b => b.Category).ToList(); // author with books and categories

// Include
// ThenInclude
#endregion

#region AutoLoading

// authors
// books

//var authors = context.Authors.ToList();
//Console.ReadKey();
//var books = context.Books.ToList();


#endregion

#region Explicit Loading

//var book = context.Books.FirstOrDefault(b => b.Id == 104);
//if(book is not null)
//{
//    context.Entry(book).Collection(b => b.SCards).Load();
//    context.Entry(book).Reference(b => b.Category).Load();
//}


#endregion

#region Lazy Loading

//var book = context.Books.FirstOrDefault(b => b.Id == 104);

//Console.WriteLine(book?.Name);
//Console.WriteLine(book?.Author?.LastName);

//var author = context.Authors.FirstOrDefault(a => a.Id == 1);

//foreach (var book in author!.Books)
//{
//    Console.WriteLine(book.Name);

//}


#endregion

//var author = context.Authors.FirstOrDefault(a => a.Id == 26);
//var a = new Author { Id = 1001, FirstName = "Kamil", LastName = "Fazil" };
//if (author is not null)
//{
//    ////var entityEntryForauthor = context.Entry(author);
//    //var entityEntryForA = context.Entry(a);
//    //context.Authors.Add(a);
//    ////Console.WriteLine(entityEntryForauthor.State);
//    //Console.WriteLine(entityEntryForA.State);

//    var entityEntryForauthor = context.Entry(author);
//    Console.WriteLine(entityEntryForauthor.State);
//    context.Remove(author);
//    Console.WriteLine(entityEntryForauthor.State);
//}

//context.SaveChanges();


//var book = context.Books.AsNoTracking().FirstOrDefault(b => b.Id == 104);
//var book = context.Books.FirstOrDefault(b => b.Id == 104);

//if (book is not null)
//{
//    book.YearPress = 1900;

//    context.Books.Update(book);

//    Console.WriteLine(context.Entry(book).State);

//    context.SaveChanges();
//}



//Func<int, bool>? func = num => { Console.WriteLine("salam"); return num == 2; };
//Expression<Func<int, bool>>? expression = num => num == 2;

// entities, context, dbsets

// in terminal
// dotnet ef migrations add migrationName
// dotnet ef migrations remove migrationName
// dotnet ef database update (migrationName optional)

// dotnet ef dbcontext scaffold "connectionString" provider --output-dir directoryName --context-dir directoryName -t TableName, -t TableName


// pm console (package manager colsole)
// add-migration migrationName
// remove-migration migrationName
// update-database (migrationName optional)
// scaffold-dbcontext  "connectionString" provider --output-dir directoryName --context-dir directoryName -t TableName, -t TableName


Console.WriteLine();
Console.WriteLine();