using System;
using System.Net.Mime;
using System.Collections;
using Newtonsoft.Json;

namespace Webhook.SugarJson {

    public class SugarLeads {
        
        public string id {get; set;}
        public string name {get; set;}
        public string created_by {get; set;}
        public string created_by_name {get; set;}
        public string assigned_user_id {get; set;}
        public string assigned_user_name {get; set;}
       /* public IList<string> assigned_user_link {get; set;}
        public IList<string> team_name {get; set;}
        public IList<string> email {get; set;}*/
    }
    
}