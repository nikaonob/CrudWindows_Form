using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CrudWindows_Form_ADO.Net
{
    public  class PeopleBD
    {
        private string connectionString = "" +
            "Data Source=localhost;Initial Catalog=CrudWindowsForm;" +
            "User=sa;Password=b4ut1n0b";

        public bool OK()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<People> Get()
        {
            List<People> people = new List<People>();
                string query = "select name,age,id from people";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(query,connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while(reader.Read())
                    {
                        People oPeople = new People();
                        oPeople.Name = reader.GetString(0);
                        oPeople.Age =reader.GetInt32(1);
                        oPeople.ID = reader.GetInt32(2);
                        people.Add(oPeople);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw new Exception("HAY UN ERROR" + ex.Message);
                }
                
            }
            return people;
        }
        
    }
    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
    }

}
