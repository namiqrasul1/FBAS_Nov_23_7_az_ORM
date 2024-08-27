using Lesson3DapperPractice.Data;

using var db = new Database("Data Source=STHQ0118-01;Initial Catalog=Library;User ID=admin;Password=admin");

//var stud = db.Login(5);

//Console.WriteLine(stud?.Id);

//var books = db.GetAllBooks();

//foreach (var book in books)
//{
//    Console.WriteLine(book.Name + ": " + book.Id);
//}

db.TakeBook(21, 5);