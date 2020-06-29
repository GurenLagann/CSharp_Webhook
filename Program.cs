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
            string PLeads;

            WriteLine("1: buscar leads por time: \n2: Buscar leads por assessor atribuido:");
            int i = Convert.ToInt32(ReadLine());

            if (i < 2){
                WriteLine("Nome do time: ");
                string time = ReadLine();
                PLeads = "Leads?filter[0][team_name]=" + time;
            }

            else if (i > 1) {
                WriteLine("Nome do Assessor: ");
                string ass = ReadLine();
                PLeads = "filter[0][assigned_user_link]="+ ass;
            }

            else {
                WriteLine("Opção Errada!");
                return;                
            }

            SugarLeads leads = r1.Leads(PLeads, token.access_token);
        }
    }
}
