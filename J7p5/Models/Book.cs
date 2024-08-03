using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J7p5.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string  BookName { get; set; }

        public List<Person> people { get; set; }
    }
}
