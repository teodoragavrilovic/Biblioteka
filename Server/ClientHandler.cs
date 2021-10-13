using Common;
using ControllerBL;
using Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Socket client;
        private readonly BindingList<User> users;

        private User loggedInUser;
      
        public ClientHandler(Socket client, System.ComponentModel.BindingList<User> users)
        {
            this.client = client;
            this.users = users;
        }

        public void StartHandler()
        {
            try
            {
                NetworkStream stream = new NetworkStream(client);
                BinaryFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    Request request = (Request)formatter.Deserialize(stream);
                    Response response;
                    try
                    {
                        response = ProcessRequest(request);
                    }
                    catch (Exception ex)
                    {
                        response = new Response();
                        response.IsSuccessful = false;
                        response.Error = ex.Message;
                    }
                    formatter.Serialize(stream, response);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Doslo je do prekida veze");
                //obratiti paznju na EventHandler FrmMain FormClosed (ako zatvorimo glavnu formu, i prakticno se izlogujemo, prekidamo vezu sa serverom
                //drugi nacin bi bio da posaljemo zahtev sa operacijom logout, tako da klijent ostane povezan
              users.Remove(loggedInUser);

            }
            catch (SerializationException)
            {
                Console.WriteLine("Doslo je do prekida veze");
                //obratiti paznju na EventHandler FrmMain FormClosed (ako zatvorimo glavnu formu, i prakticno se izlogujemo, prekidamo vezu sa serverom
                //drugi nacin bi bio da posaljemo zahtev sa operacijom logout, tako da klijent ostane povezan
                users.Remove(loggedInUser);

            }
        }

        private Response ProcessRequest(Request request)
        {
            Response response = new Response();
            response.IsSuccessful = true;
            switch (request.Operation)
            {
                case Operation.Login:
                    response.Result = Controller.Instance.Login((User)request.RequestObject);
                    loggedInUser = (User)response.Result;
                    users.Add(loggedInUser);
                    break;
                case Operation.DodajNovogClana:
                    Controller.Instance.DodajNovogClana((Clan)request.RequestObject);
                    break;
                case Operation.ProveriClanarinu:
                    response.Result = Controller.Instance.ProveriClanarinu((Clanarina)request.RequestObject);
                    break;
                case Operation.ProduziClanarinu:
                    Controller.Instance.ProduziClanarinu((Clanarina)request.RequestObject);
                    break;
                case Operation.PopuniZanrove:
                    response.Result = Controller.Instance.PopuniZanrove();
                    break;
                case Operation.PopuniAutore:
                    response.Result = Controller.Instance.PopuniAutore();
                    break;
                case Operation.PopuniIzdavace:
                    response.Result = Controller.Instance.PopuniIzdavace();
                    break;
                case Operation.DodajNaslov:
                    Controller.Instance.DodajNaslov((Naslov)request.RequestObject);
                    break;
                case Operation.VratiNaslovePoKriterijumu:
                    response.Result = Controller.Instance.VratiNaslovePoKriterijumu((Naslov)request.RequestObject);
                    break;
                case Operation.ZapamtiKnjigu:
                    Controller.Instance.ZapamtiKnjigu((Knjiga)request.RequestObject);
                    break;
                case Operation.VratiKnjigePoKriterijumu:
                    response.Result = Controller.Instance.VratiKnjigePoKriterijumu((Knjiga)request.RequestObject);
                    break;
                case Operation.ObrisiKnjigu:
                    Controller.Instance.ObrisiKnjigu((Knjiga)request.RequestObject);
                    break;
                case Operation.ZaduziKnjige:
                    Controller.Instance.ZaduziKnjige((Zaduzenje)request.RequestObject);
                    break;
                case Operation.VratiKnjigu:
                    response.Result = Controller.Instance.VratiKnjigu((Knjiga)request.RequestObject);
                    break;
                case Operation.RazduziKnjige:
                    Controller.Instance.RazduziKnjige((Zaduzenje)request.RequestObject);
                    break;
                case Operation.VratiID:
                    response.Result = Controller.Instance.VratiID();
                    break;
                case Operation.VratiIDKnjige:
                    response.Result = Controller.Instance.VratiIDKnjige();
                    break;
                case Operation.PostaviZaduzenje:
                    Controller.Instance.PostaviZaduzenje((Knjiga)request.RequestObject);
                    break;
                case Operation.ProveriJMBG:
                    response.Result = Controller.Instance.ProveriJMBG((Clan)request.RequestObject);
                    break;
                case Operation.ProveriKasnjenje:
                    response.Result = Controller.Instance.ProveriKasnjenje((Zaduzenje)request.RequestObject);
                    break;
                case Operation.IzmeniClana:
                    Controller.Instance.IzmeniClana((Clan)request.RequestObject);
                    break;
            }
            return response;
        }

        internal void Stop()
        {
            client.Close();
        }
    }
}
