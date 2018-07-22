using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Samples.Models
{
    public class Person
    {
        private const string GenderFemale = "F";
        private const string GenderMale = "M";

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GenderToString { get; private set; }

        public Gender? Gender
        {
            get
            {
                switch(this.GenderToString)
                {
                    case GenderFemale: return Models.Gender.Female;
                    case GenderMale: return Models.Gender.Male;
                    default: return null;
                }
            }
            set
            {
                switch(value)
                {
                    case Models.Gender.Female:
                        this.GenderToString = GenderFemale;
                        break;

                    case Models.Gender.Male:
                        this.GenderToString = GenderMale;
                        break;

                    default:
                        this.GenderToString = null;
                        break;
                }
            }
        }
    }
}
