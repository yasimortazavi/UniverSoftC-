﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J7p5.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName  { get; set; }
        public string  LastName { get; set; }
        public  string  FullName
        {
         
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Book FavBook  { get; set; }
    }
}
