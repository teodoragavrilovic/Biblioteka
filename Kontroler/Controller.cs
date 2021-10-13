using Domain;
using Domen;
using Storage;
using Storage.Implementation.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.AutorSO;
using SystemOperations.ClanarinaSO;
using SystemOperations.ClanSO;
using SystemOperations.NaslovSO;
using SystemOperations.UserSO;
using SystemOperations.IzdavacSO;
using SystemOperations.KnjigaSO;

namespace ControllerBL
{
    public class Controller
    {
        private IGenericRepository repository;

        public User User { get; set; }

        #region singleton
        private static Controller instance;

        private static object _lock = new object();
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Controller();
                        }
                    }
                }
                return instance;
            }
        }

        private Controller()
        {
            repository = new GenericRepository();
        }
        #endregion


        public User Login(User user)
        {
            LoginSO so = new LoginSO();
            so.ExecuteTemplate(user);
            return so.Result;
        }

        public void DodajNovogClana(Clan clan)
        {
            DodajNovogClanaSO so = new DodajNovogClanaSO();
            so.ExecuteTemplate(clan);

        }


        public object ProveriClanarinu(Clanarina c)
        {
            VratiClanaSaClanarinomSO so = new VratiClanaSaClanarinomSO();
            so.ExecuteTemplate(c);
            return so.Result;
        }

        public void ProduziClanarinu(Clanarina cl)
        {
            ProduziClanarinuSO so = new ProduziClanarinuSO();
            so.ExecuteTemplate(cl);
        }

        public object PopuniZanrove()
        {
            PopuniZanroveSO so = new PopuniZanroveSO();
            so.ExecuteTemplate(new Zanr());
            return so.Result;
        }

        public object PopuniAutore()
        {
            VratiAutoreSO so = new VratiAutoreSO();
            so.ExecuteTemplate(new Autor());
            return so.Result;
        }

        public void DodajNaslov(Naslov n)
        {
            DodajNaslovSO so = new DodajNaslovSO();
            so.ExecuteTemplate(n);

        }

        public object PopuniIzdavace()
        {
            VratiIzdavaceSO so = new VratiIzdavaceSO();
            so.ExecuteTemplate(new Izdavac());
            return so.Result;
        }

        public object VratiNaslovePoKriterijumu(Naslov n)
        {
            VratiNaslovePoKriterijumuSO so = new VratiNaslovePoKriterijumuSO();
            so.ExecuteTemplate(n);
            return so.Result;
        }

        public void ZapamtiKnjigu(Knjiga k)
        {
            ZapamtiKnjiguSO so = new ZapamtiKnjiguSO();
            so.ExecuteTemplate(k);

        }

        public object VratiKnjigePoKriterijumu(Knjiga k)
        {
            VratiKnjigePoKriterijumuSO so = new VratiKnjigePoKriterijumuSO();
            so.ExecuteTemplate(k);
            return so.Result;
        }

        public void ObrisiKnjigu(Knjiga k)
        {
            ObrisiKnjiguSO so = new ObrisiKnjiguSO();
            so.ExecuteTemplate(k);
        }

        public void ZaduziKnjige(Zaduzenje z)
        {
            ZaduziKnjigeSO so = new ZaduziKnjigeSO();
            so.ExecuteTemplate(z);
        }

        public object VratiKnjigu(Knjiga k)
        {
            UcitajKnjiguSO so = new UcitajKnjiguSO();
            so.ExecuteTemplate(k);
            return so.Result;
        }

        public void RazduziKnjige(Zaduzenje z)
        {
            RazduziKnjigeSO so = new RazduziKnjigeSO();
            so.ExecuteTemplate(z);
        }

        public object VratiID()
        {
            VratiClanaSO so = new VratiClanaSO();
            so.ExecuteTemplate(new Clan());
            return so.Result;
        }

        public void PostaviZaduzenje(Knjiga k)
        {
            IzmeniKnjiguSO so = new IzmeniKnjiguSO();
            so.ExecuteTemplate(k);
        }

        public object VratiIDKnjige()
        {
            VratiKnjiguSO so = new VratiKnjiguSO();
            so.ExecuteTemplate(new Knjiga());
            return so.Result;
        }

        public object ProveriJMBG(Clan c)
        {
            VratiClanaPoKriterijumuSO so = new VratiClanaPoKriterijumuSO();
            so.ExecuteTemplate(c);
            return so.Result;
        }

        public object ProveriKasnjenje(Zaduzenje z)
        {
            ProveriKasnjenjeSO so = new ProveriKasnjenjeSO();
            so.ExecuteTemplate(z);
            return so.Result;
        }

        public void IzmeniClana(Clan c)
        {
            IzmeniClanaSO so = new IzmeniClanaSO();
            so.ExecuteTemplate(c);
           
        }
    }
}
