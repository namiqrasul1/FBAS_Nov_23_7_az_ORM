using Dapper;
using Lesson3DapperPractice.Models;
using System.Data.SqlClient;

namespace Lesson3DapperPractice.Data;

internal class Database : IDisposable
{
    private readonly SqlConnection _connection;
    public Database(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public Student? Login(int studentId)
    {
        var query = "Select * From Students Where Id = @studentId";
        //var student = Connection.QueryFirst<Student>(query, param: new { studentId = studentId});
        var student = _connection.QueryFirstOrDefault<Student>(query, param: new { studentId });

        return student;
    }

    public List<Book> GetAllBooks()
    {
        var query = "Select * From Books Where Quantity > 0";
        var books = _connection.Query<Book>(query).ToList();
        return books;
    }

    // takeBook(idStudent, idBook){axrinci id tap, yeni scard yarat insert ele}

    public int TakeBook(int idStudent, int idBook)
    {
        var query = "Select Max(Id) From S_Cards";
        var lastId = _connection.ExecuteScalar<int>(query);

        var cmd = "Insert Into S_Cards(Id, Id_Student, Id_Book, DateOut, Id_Lib) Values (@Id, @IdStudent, @IdBook, @DateOut, @IdLib)";

        var result = _connection.Execute(cmd, param: new { Id = lastId + 1, IdBook = idBook, IdStudent = idStudent, DateOut = DateTime.Now, IdLib = 1});


        return result;
    }
    
    // takenBooks(isStudent) => onun goturduyu kitablari

    // returnBook(isStudent, idBook) => update scard dateIn datetime.now

    public void Dispose()
    {
        _connection.Dispose();
        GC.SuppressFinalize(this);
    }

    ~Database()
    {
        Dispose();
    }
}
