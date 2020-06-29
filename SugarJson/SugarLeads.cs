using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Webhook.SugarJson {

    public class SugarLeads {
        
        public string id {get; set;}
        public string name {get; set;}
        public string created_by {get; set;}
        public string created_by_name {get; set;}
        public List<Atribuido> assigned_user_link {get; set;}
        public List<Equipe> team_name {get; set;}
        public List<Email> email {get; set;}
    }

    public class Email {
        public string email_address { get; set; }
        public bool primary_address { get; set; }
    }
    
    public class Atribuido {
        public string full_name { get; set; }
        public string id { get; set; }
    }

    public class Equipe {
        public string id { get; set; }
        public string name { get; set; }
        public bool primary { get; set; }
    }
    
}