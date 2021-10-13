using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class User : IEntity
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Username { get; set; }
        [Browsable(false)]
        public string Password { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        [Browsable(false)]
        public string TableName => "Bibliotekar";
        [Browsable(false)]
        public string InsertValues => "";
        [Browsable(false)]
        public string IdName => "BibliotekarID";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string JoinTable => "";
        [Browsable(false)]
        public string TableAlias => "";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string WhereCondition => "";
        [Browsable(false)]
        public string GetUpdateValues => "";
        [Browsable(false)]
        public string GeneralCondition => "";

        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new User
                {
                    Id = (int)reader[0],
                    Username = (string)reader[3],
                    Password = (string)reader[4],
                    Name = (string)reader[1],
                    LastName = (string)reader[2],
                    //LogedIn = (bool)reader[5]
                });
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}
