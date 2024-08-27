using System.Data;
using System.Data.SqlClient;
using System.Net;
using Dapper;
using Lesson1Dapper.Models;
using Lesson1Dapper.Models.DTOs;
using Microsoft.Extensions.Configuration;

//var conStr = "Data Source=STHQ0118-01;Initial Catalog=Library;Integrated Security=true"; // for windows auth


//var conStr = "Data Source=STHQ0118-01;Initial Catalog=Library;User ID=admin;Password=admin"; // for sql auth

var builder = new ConfigurationBuilder();
builder.AddJsonFile(@"C:\Users\namiqrasullu\Desktop\FBAS_Nov_23_7_az_ORM\Lesson1Dapper\Lesson1Dapper\appsettings.json");

var config = builder.Build();

var conStr = config.GetConnectionString("Default");

using var sqlConnection = new SqlConnection(conStr);

//var query = "SELECT * FROM Authors";

//var result = sqlConnection.Query(query).ToList();

//foreach (var item in result)
//{
//    Console.WriteLine(item.FirstName);
//}


#region Querying Scalar Values

////var query = "SELECT COUNT(*) FROM BOOKS WHERE Pages > 200";
//var query = "SELECT SUM(Pages) FROM BOOKS WHERE Pages > 200";

//var result = sqlConnection.ExecuteScalar<int>(query);

//Console.WriteLine(result);

#endregion

#region Querying Single Row

// QuerySingle => tekdirsa qaytarir, choxdursa exception, yoxdusa exception
// QuerySingle<T> => tekdirsa qaytarir, choxdursa exception, yoxdusa exception
// QuerySingleOrDefault => tekdirsa qaytarir, choxdursa exception, yoxdusa dafault value
// QuerySingleOrDefault<T> => tekdirsa qaytarir, choxdursa exception, yoxdusa dafault value

//var query = "select [Name] AS Name1 from Books where Id = 5";

////var book = sqlConnection.QuerySingle(query);
////var book = sqlConnection.QuerySingleOrDefault(query);
//var book = sqlConnection.QuerySingleOrDefault<Book>(query);

//Console.WriteLine(book);



// QueryFirst => varsa 1cini qaytarir, yoxdursa exception
// QueryFirst<T> => varsa 1cini qaytarir, yoxdursa exception
// QueryFirstOrDefault => varsa 1cini qaytarir, yoxdursa default value
// QueryFirstOrDefault<T> => varsa 1cini qaytarir, yoxdursa default value

//var query = "select * from books where [Name] like 'S%'";

////var book = sqlConnection.QueryFirst(query);
//var book = sqlConnection.QueryFirst<Book>(query);

//Console.WriteLine(book.Name);




//var input = Console.ReadLine(); // 5 or 1 = 1
//var query = $"select * from Books where Id = {input}"; // olmaz
//var query = $"select * from Books where Id = @bookId"; // olar

//var param = new DynamicParameters();
//param.Add("@bookId", 5, System.Data.DbType.Int32);

////var book = sqlConnection.QueryFirstOrDefault<Book>(query, param: new { bookId = 5 });
//var book = sqlConnection.QueryFirstOrDefault<Book>(query, param: param);

//Console.WriteLine(book?.Name);



#endregion

#region Querying Multiple Rows

//var query = "select * from Books";

//var books = sqlConnection.Query<Book>(query);

//foreach (var book in books)
//{
//    Console.WriteLine(book.Name);
//}

//var sql = "SELECT * FROM Books WHERE Pages < @p";

//var books = sqlConnection.Query(sql, param: new { p = 100 }).ToList();

//books.ForEach(b => Console.WriteLine(b));

//new Book { Name = " asd" };

#endregion

#region Spesific Columns

//var query = "SELECT [Name], Pages, Quantity FROM Books";

//var result = sqlConnection.Query<BookDto>(query);

#endregion

#region CreateUpdateDelete

//var cmd = "insert into Authors(Id, FirstName, LastName) Values(@Id, @FirstName, @LastName)";

//var realAuthor = new Author { Id = 22, FirstName = "Murad", LastName = "Babayev" };
//sqlConnection.Execute(cmd, param: author);
//var anonymousAuthor = new { Id = 23, FirstName = "Murad", LastName = "Ahmedov" };
//sqlConnection.Execute(cmd, anonymousAuthor);

//var authors = new List<Author>
//{
//    new() { Id = 22, FirstName = "Murad", LastName = "Ahmedov" },
//    new() { Id = 23, FirstName = "Murad", LastName = "Babayev" },
//};

//var result = sqlConnection.Execute(cmd, authors);

//var cmd = "DELETE FROM Authors Where Id = @id";

//sqlConnection.Execute(cmd, param: new { id = 23 });


//var cmd = "Update Authors Set LastName = @lastName Where Id = @id";

//sqlConnection.Execute(cmd, param: new { id = 21, lastName = "Nesbo" });

#endregion

#region RelationShips

//var sqlQuery = "Select * From Authors A Join Books B On A.Id = B.Id_Author";

//var books = sqlConnection.Query<Author, Book, Book>(sqlQuery,
//    map: (author, book) =>
//    {
//        book.Author = author;
//        return book;
//    },
//    splitOn: "Id").ToList();

//foreach (var book in books)
//    Console.WriteLine($"{book.Name} - {book.Author.FirstName}");



//var sqlQuery = "Select * From Authors A Join Books B On A.Id = B.Id_Author";

//var authorDict = new Dictionary<int, Author>();

//var authors = sqlConnection.Query<Author, Book, Author>(sqlQuery,
//    map: (author, book) =>
//    {
//        if(!authorDict.TryGetValue(author.Id, out var currentAuthor))
//        {
//            currentAuthor = author;
//            authorDict.Add(author.Id, currentAuthor);
//        }
//        book.Author = currentAuthor;
//        currentAuthor.Books.Add(book);
//        return currentAuthor;
//    },
//    splitOn: "Id").ToList();



#endregion

#region Procedure

//var procName = "sp_get_author_books";

//var result = sqlConnection.Query(procName, commandType: CommandType.StoredProcedure);

//var procName = "sp_get_author_books_by_id";

//var result = sqlConnection.Query<AuthorBookDto>(procName, param: new { authorId = 5 }, commandType: CommandType.StoredProcedure);

//var procName = "sp_get_author_books_with_count";

//var parameters = new DynamicParameters();
//parameters.Add("authorId", 5, DbType.Int32, ParameterDirection.Input);
//parameters.Add("count", null, DbType.Int32, ParameterDirection.Output);

//var result = sqlConnection.Query(procName, parameters, commandType: CommandType.StoredProcedure);

//var count = parameters.Get<int>("count");
//Console.WriteLine(count);



#endregion

#region Querying Mutiple Results

var query = "Select * from books where Id_Author = @AuthorId;" +
            "Select * from Authors where Id = @AuthorId;";

using(var mult = sqlConnection.QueryMultiple(query, param: new { AuthorId = 5 }))
{
    var books = mult.Read<Book>().ToList();
    var author = mult.ReadFirst<Author>();
}



#endregion

Console.WriteLine();
Console.WriteLine();