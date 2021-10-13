using Common;
using Domain;
using Domen.Communication;
using View.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Forme.Exceptions;
using System.Windows.Forms;

namespace View.Communication
{
    public class Communication
    {
        private static Communication instance;

        internal Clanarina ProveriClanarine(Clanarina cl)
        {
            Request r = new Request()
            {
                Operation = Operation.ProveriClanarinu,
                RequestObject = cl
            };

            client.SendRequest(r);
            return (Clanarina)client.GetResponseResult();
        }

        internal List<Autor> PopuniAutore()
        {
            Request r = new Request()
            {
                Operation = Operation.PopuniAutore,

            };

            client.SendRequest(r);
            return (List<Autor>)client.GetResponseResult();
        }

        private Socket socket;
        private CommunicationClient client;
        public static Communication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Communication();
                }
                return instance;
            }
        }

        internal List<Naslov> VratiNaslovePoKriterijumu(Naslov n)
        {
            Request r = new Request()
            {
                Operation = Operation.VratiNaslovePoKriterijumu,
                RequestObject = n
            };

            client.SendRequest(r);
            return (List<Naslov>)client.GetResponseResult();
        }

        internal bool ProveriJMBG(Clan c)
        {
            Request r = new Request()
            {
                Operation = Operation.ProveriJMBG,
                RequestObject = c
            };

            client.SendRequest(r);
            return (bool)client.GetResponseResult();
        }

        internal int VratiID()
        {
            Request r = new Request()
            {
                Operation = Operation.VratiID,
                
            };

            client.SendRequest(r);
            return (int)client.GetResponseResult();
        }

        internal void ZapamtiKnjigu(Knjiga k)
        {
            Request r = new Request()
            {
                Operation = Operation.ZapamtiKnjigu,
                RequestObject = k
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal Knjiga VratiKnjigu(Knjiga k)
        {
            Request r = new Request()
            {
                Operation = Operation.VratiKnjigu,
                RequestObject = k
            };

            client.SendRequest(r);
            return (Knjiga)client.GetResponseResult();
        }

        internal void RazduziKnjige(Zaduzenje z)
        {
            Request r = new Request()
            {
                Operation = Operation.RazduziKnjige,
                RequestObject = z
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void IzmeniClana(Clan c)
        {
            Request r = new Request()
            {
                Operation = Operation.IzmeniClana,
                RequestObject = c
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal List<Knjiga> VratiKnjigePoKriterijumu(Knjiga k)
        {
            Request r = new Request()
            {
                Operation = Operation.VratiKnjigePoKriterijumu,
                RequestObject = k
            };

            client.SendRequest(r);
            return (List<Knjiga>)client.GetResponseResult();
        }

        internal void ObrisiKnjigu(Knjiga k)
        {
            Request r = new Request()
            {
                Operation = Operation.ObrisiKnjigu,
                RequestObject = k
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void DodajNaslov(Naslov n)
        {
            Request r = new Request()
            {
                Operation = Operation.DodajNaslov,
                RequestObject = n
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void ProduziClanarinu(Clanarina cl)
        {
            Request r = new Request()
            {
                Operation = Operation.ProduziClanarinu,
                RequestObject = cl
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal bool ProveriKasnjenje(Zaduzenje z)
        {
            Request r = new Request()
            {
                Operation = Operation.ProveriKasnjenje,
                RequestObject = z
            };

            client.SendRequest(r);
            return (bool)client.GetResponseResult();
        }

        internal void ZaduziKnjige(Zaduzenje z)
        {
            Request r = new Request()
            {
                Operation = Operation.ZaduziKnjige,
                RequestObject = z
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void DodajNovogClana(Clan c)
        {
            Request r = new Request()
            {
                Operation = Operation.DodajNovogClana,
                RequestObject = c
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        private Communication()
        {

        }

        internal Clan ProveraClanarine(string brojCK)
        {
            Request r = new Request()
            {
                Operation = Operation.ProveriClanarinu,
                RequestObject = brojCK
            };

           client.SendRequest(r);
           return (Clan)client.GetResponseResult();
        }

        public void Connect()
        {
            if (socket != null && socket.Connected)
            {
                return;
            }
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            client = new CommunicationClient(socket);

        }

        internal void Disconnect()
        {
            socket.Close();
            socket = null;
        }

       
        internal User Login(string username, string password)
        {
            Request request = new Request()
            {
                Operation = Operation.Login,
                RequestObject = new User { Username = username, Password = password }
            };
            client.SendRequest(request);
            return (User)client.GetResponseResult();
        }

        internal List<Zanr> PopuniZanrove()
        {
            Request r = new Request()
            {
                Operation = Operation.PopuniZanrove,
                
            };

            client.SendRequest(r);
            return (List<Zanr>)client.GetResponseResult();
        }

        internal List<Izdavac> PopuniIzdavace()
        {
            Request r = new Request()
            {
                Operation = Operation.PopuniIzdavace,

            };

            client.SendRequest(r);
            return (List<Izdavac>)client.GetResponseResult();
        }

        internal void PostaviZaduzenje(Knjiga k)
        {
            Request r = new Request()
            {
                Operation = Operation.PostaviZaduzenje,
                RequestObject = k
            };

            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal int VratiIDKnjige()
        {
            Request r = new Request()
            {
                Operation = Operation.VratiIDKnjige,

            };

            client.SendRequest(r);
            return (int)client.GetResponseResult();
        }
    }
}
