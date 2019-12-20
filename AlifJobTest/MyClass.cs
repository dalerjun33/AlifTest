using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifJobTest
{
    public class MyClass
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Quote { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Author
    {
        public  string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfbirth { get; set; }
    }
    public class Result
    {
        public int Status { get; set; }
        public string Comment { get; set; }
    }
    
}
