using System.Data.SqlClient;
using System.Net;
using Dapper;
using Lesson1Dapper.Models;
using Lesson1Dapper.Models.DTOs;

//var conStr = "Data Source=STHQ0118-01;Initial Catalog=Library;Integrated Security=true"; // for windows auth


var conStr = "Data Source=STHQ0118-01;Initial Catalog=Library;User ID=admin;Password=admin"; // for sql auth

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

var sql = "SELECT * FROM Books WHERE Pages < @p";

var books = sqlConnection.Query(sql, param: new { p = 100 }).ToList();

books.ForEach(b => Console.WriteLine(b));

//new Book { Name = " asd" };

#endregion

#region Spesific Columns

var query = "SELECT [Name], Pages, Quantity FROM Books";

var result = sqlConnection.Query<BookDto>(query);

#endregion

Console.WriteLine();
Console.WriteLine();