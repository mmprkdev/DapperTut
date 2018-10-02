using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    // Person Model
    public class Person
    {
        // NOTE: Make sure the property names line up with the column
        // names in the the Person table so that Dapper is able to hook
        // everything up properly. 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstAndLastName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }

        public string FullData
        {
            get
            {
                return $"{ FirstName } { LastName } { EmailAddress } { PhoneNumber }";
            }
        }
    }
}
