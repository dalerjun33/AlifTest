using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlifJobTest
{
    public class Functions
    {
        private static List<MyClass> DB=new List<MyClass>();
        public static int Id=1;
        public void AddToDB(MyClass NewData)
        {
            NewData.Id = Id;
            Id++;
            DB.Add(NewData);
        }
        public void ChangeDB(MyClass NewData, int QuoteId)
        {
            foreach (MyClass data in DB)
            {
                if (data.Id == QuoteId)
                {
                    data.Author = NewData.Author;
                    data.Category = NewData.Category;
                    data.Quote = NewData.Quote;
                }
            }
        }
        public List<MyClass> ReturnDB()
        {
            return DB;
        }
        public MyClass ReturnRandom()
        {
            MyClass TMP = new MyClass();
            Random rnd = new Random();
            int Random = rnd.Next(1,Id);
            //TMP= DB.Where(s =>DB.FirstOrDefault(x=>x.Id==Random)!=null);
            foreach (MyClass data in DB)
            {
                if (data.Id == Random)
                {
                    TMP = data;
                }
            }
            return TMP;
        }
        public void DeleteById(int QuoteId)
        {
            List<MyClass> TMPDB = new List<MyClass>();
            foreach (MyClass data in DB)
            {
                if (data.Id != QuoteId)
                {
                    TMPDB.Add(data);
                }
            }
            DB = TMPDB;
        }
        public List<MyClass> GetAllQuotesByCategory(string CategoryName)
        {
            List<MyClass> TMPDB = new List<MyClass>();
            foreach (MyClass data in DB)
            {
                if (data.Category == CategoryName)
                {
                    TMPDB.Add(data);
                }
            }
            return TMPDB;
        }
        public void Collector()
        {
            Console.WriteLine("Collector is runed");
            foreach (MyClass Quote in DB)
            {
                if((DateTime.Now - Quote.CreatedDate).TotalMinutes >= 20)
                {
                    DB.Remove(Quote);
                    Console.WriteLine("Removed");
                }
            }
            Thread.Sleep(50000);
            Collector();
        }
    }
}
