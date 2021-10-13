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
    public class Clanarina : IEntity
    {
        public int BrojPlacanja { get; set; }
        public Clan Clan { get; set; }
        public DateTime DatumDo { get; set; }
        [Browsable(false)]
        public string TableName => "Clanarina";
        [Browsable(false)]
        public string InsertValues => $"{Clan.BrojClanskeKarte},'{DatumDo}'";
        [Browsable(false)]
        public string IdName => "BrojPlacanja";
        [Browsable(false)]
        public string JoinCondition => "ON (C.BrojClanskeKarte = CL.ClanID)";
        [Browsable(false)]
        public string JoinTable => $"JOIN Clan C";
        [Browsable(false)]
        public string TableAlias => "CL";
        [Browsable(false)]
        public object SelectValues =>"*";
        [Browsable(false)]
        public string WhereCondition => $"ClanID = {Clan.BrojClanskeKarte}";
        [Browsable(false)]
        public string GetUpdateValues => $"DatumDo='{DatumDo}'";
        [Browsable(false)]
        public string GCondition;
        [Browsable(false)]
        public string GeneralCondition => $"{GCondition}";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Clanarina
                {
                    BrojPlacanja = (int)reader[0],
                    DatumDo = (DateTime)reader[2],
                    Clan = new Clan
                    {
                        BrojClanskeKarte= (int)reader[1],
                        Ime = (string)reader[4],
                        Prezime = (string)reader[5],
                        Telefon = (string)reader[7],
                        Adresa = (string)reader[8],
                        Jmbg = (string)reader[6]
                    }
                });
            }
            return result;
        }
       
    }
}
