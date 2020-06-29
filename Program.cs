using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;

using Webhook.Json;
using Webhook.SugarJson;

using static System.Console;

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

            WriteLine("1: buscar leads por Equipe: \n2: Buscar leads por Assessor atribuido:");
            int i = Convert.ToInt32(ReadLine());
            Clear();

            //troca de endpoint da api para pesquisa
            if (i < 2){
                WriteLine("Nome do Equipe: ");
                string time = ReadLine();
                //pesquisa a partir de uma equipe
                PLeads = "Leads?filter[0][team_name]=" + time;
                Clear();
            }

            else if (i > 1) {
                WriteLine("Nome do Assessor: ");
                string ass = ReadLine();
                //pesquisa por assessor atribuido
                PLeads = "filter[0][assigned_user_name]="+ ass;
                Clear();
            }

            else {
                WriteLine("Opção Errada!");
                return;                
            }
            
            SugarLeads leads = r1.Leads(PLeads, token.access_token);
            WriteLine(leads); 
            
            
        }
    }
}
