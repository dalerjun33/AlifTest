using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AlifJobTest
{
  
    public class AddController : ApiController
    {
        public Result Get(string AuthorName, string AuthorSurname, string DateOfbirth,string Quote,string Category)
        {
            MyClass Quotes = new MyClass();
            Author author = new Author();
            author.Name = AuthorName;
            author.Surname = AuthorSurname;
            author.DateOfbirth = DateOfbirth;
            Quotes.CreatedDate = DateTime.Now;
            Quotes.Author = author;
            Quotes.Quote = Quote;
            Quotes.Category = Category;
            Functions functions = new Functions();
            functions.AddToDB(Quotes);
            Result result = new Result();
            result.Comment = "Успешно";
            result.Status = 1;
            return result;
        }
       
    }
    public class ChangeController : ApiController
    {
        public Result Get(string AuthorName, string AuthorSurname, string DateOfbirth, string Quote, string Category,int Id)
        {
            MyClass Quotes = new MyClass();
            Author author = new Author();
            author.Name = AuthorName;
            author.Surname = AuthorSurname;
            author.DateOfbirth = DateOfbirth;
            Quotes.Author = author;
            Quotes.Quote = Quote;
            Quotes.Category = Category;
            Functions functions = new Functions();
            functions.ChangeDB(Quotes,Id);
            Result result = new Result();
            result.Comment = "Успешно";
            result.Status = 1;
            return result;
        }

    }
    public class ReturnAllQuotesController : ApiController
    {
        public List<MyClass> Get()
        {
            Functions functions = new Functions();
            return functions.ReturnDB();
        }
    }
    public class DeleteQuoteByIdController : ApiController
    {
        public Result Get(int Id)
        {
            Result result = new Result();
            Functions functions = new Functions();
            functions.DeleteById(Id);
            result.Comment = "Успешно удалино";
            result.Status = 1;
            return result;
        }
    }
    public class GetAllQuotesByCategoryController : ApiController
    {
        public List<MyClass> Get( string Category)
        {
            Functions functions = new Functions();
            return functions.GetAllQuotesByCategory(Category);
        }

    }
    public class ReturnRandomQuotesController : ApiController
    {
        public MyClass Get()
        {
            Functions functions = new Functions();
            return functions.ReturnRandom();
        }
    }
}
