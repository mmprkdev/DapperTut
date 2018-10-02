using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace FormUI
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DapperTut")))
            {
                // Not safe method (open for dependancy injection)
                //var output = connection.Query<Person>($"select * from DapperTut.dbo.People where LastName = '{ lastName }'").ToList();
                // Safe Method:
                var output = connection.Query<Person>("DapperTut.dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
                return output;
            }
        }

        public void InsertPerson(string firstName, string lastName, string email, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DapperTut")))
            {
                var person = new Person { FirstName = firstName, LastName = lastName, EmailAddress = email, PhoneNumber = phoneNumber };
                var people = new List<Person>();
                people.Add(person);

                connection.Execute("DapperTut.dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
            }
        }
    }
}
