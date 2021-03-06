using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Net;

using static System.Console;

using Webhook.Json;
using Webhook.SugarJson;

namespace Webhook {

    public class Requisicao {

        private const string instanceUri = "link Api";
        
        public Token Autentica() {
            // Endpoint de autenticação
            var url = instanceUri + "oauth2/token";

            // Configurando os parametros necessarios para a autenticação
            Dictionary<string, string> auth = new Dictionary<string, string>();
            auth.Add("grant_type", "");
            auth.Add("client_id", "");
            auth.Add("username", "username");
            auth.Add("password", "Password");
            auth.Add("platform", "");

            // Transformando os parametros em JSON
            var jsonParams = JsonConvert.SerializeObject(auth, Formatting.Indented);
            var httpContent = new StringContent(jsonParams, Encoding.UTF8, "application/json");


            // CONFIG DO REQUEST
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Executando POST e pegando resposta
                    HttpResponseMessage response = cliente.PostAsync(url, httpContent).Result;
                    var responseAux = response.Content.ReadAsStringAsync();
                    var jsonResult = responseAux.Result;
                    Token token = JsonConvert.DeserializeObject<Token>(jsonResult);
                    return token;
                    
                }
                catch (HttpRequestException e)
                {
                    WriteLine("\nException Caught!");
                    WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
        }

       public SugarLeads Leads (string PLeads, string token){
            var url = instanceUri + PLeads;

            using (HttpClient cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Add("oauth-token", token);

                SugarLeads leads = new SugarLeads();

                try {
                    Task<HttpResponseMessage> response =  cliente.GetAsync(url);
                    var responseAux = response.Result.Content.ReadAsStringAsync();
                    var jsonResult = responseAux.Result;
                    //List<string> leads = JsonConvert.DeserializeObject<List<string>>(jsonResult);
                    //WriteLine(jsonResult);
                    foreach (var records in jsonResult)
                    {
                        
                        leads = JsonConvert.DeserializeObject<SugarLeads>(jsonResult);
                        WriteLine(leads.id);
                        WriteLine(leads.name); 
                    }
            
                    
                    return leads;
                }
                
                catch (HttpRequestException e) {
                    WriteLine("\nException Caught!");
                    WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            } 
        }
    }
}
