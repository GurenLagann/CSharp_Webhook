using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;

using static System.Console;

using Webhook.Json;
using Webhook.SugarJson;


namespace Webhook
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Acessando o Sugar... ");
            Requisicao r1 = new Requisicao();

            Token token = r1.Autentica();
            //WriteLine(token.access_token);
            int PLeads;

            WriteLine("1: buscar leads por time: \n2: Buscar leads por assessor atribuido:");
            var i = Convert.ToInt32(ReadLine());

            if (i = 1){
                WriteLine("Nome do time: ");
                var time = ReadLine();
                PLeads = "Leads?filter[0][team_name]=" + time;
            }

            if (i = 2) {
                WriteLine("Nome do Assessor: ");
                var ass = ReadLine();
                PLeads = "filter[0][assigned_user_link]="+ ass;
            }

            SugarLeads leads = r1.Leads(PLeads, token.access_token);
        }
    }
}
