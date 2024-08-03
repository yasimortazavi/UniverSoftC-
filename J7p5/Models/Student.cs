using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J7p5.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            { 
                return FirstName + " " + LastName;
            }
        }
        public int ID { get; set; }

        public bool Gender { get; set; }
        public string GenderName 
        {
            get
            {
                if (Gender)
                    return "زن";
                return "مرد";
            }
        }
        public bool IsMarried { get; set; }

        public string MarridName
        {
            get
            {
                if (IsMarried)
                    return "متاهل";
                return "مجرد";
            }
        }

        public Proof proof { get; set; }
        public string ProofName
        {
            get 
            {
                if (proof == null)
                    return "بدون مقطع";
                return proof.ProofName;
            }
        }
    }
}
