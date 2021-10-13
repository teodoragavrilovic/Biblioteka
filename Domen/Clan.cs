using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Clan : IEntity
    {
        public int BrojClanskeKarte { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Jmbg { get; set; }
        [Browsable(false)]
        public string TableName => "Clan";
        [Browsable(false)]
        public string InsertValues => $"'{Ime}','{Prezime}','{Jmbg}','{Telefon}','{Adresa}'";
        [Browsable(false)]
        public string IdName => "BrojClanskeKarte";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string JoinTable => "";
        [Browsable(false)]
        public string TableAlias => "C";
        [Browsable(false)]
        public object SelectValues =>"*";
        [Browsable(false)]
        public string WhereCondition => $"BrojClanskeKarte = {BrojClanskeKarte}";
        [Browsable(false)]
        public string GetUpdateValues => $"Ime='{Ime}',Prezime='{Prezime}',Telefon='{Telefon}',Adresa='{Adresa}'";
        [Browsable(false)]
        public string GeneralCondition => $"JMBG = '{Jmbg}'";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
              
                result.Add(new Clan
                {
                   BrojClanskeKarte = (int)reader[0],
                   Ime = (string)reader[1],
                   Prezime= (string)reader[2],
                   Jmbg = (string)reader[3],
                   Telefon = (string)reader[4],
                   Adresa = (string)reader[5]

                });
               
            }
            return result;
        }
        public override string ToString()
        {
            return BrojClanskeKarte + " " + Ime + " " + Prezime;
        }
    }
}
