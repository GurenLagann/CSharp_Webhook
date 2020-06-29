using System;
using Newtonsoft.Json;

namespace Webhook.Json {

    public class Token {

        public string token_type { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string download_token { get; set;}
        public string expires_in { get; set; }
        public string refresh_expires_in { get; set; }
        public string scope { get; set; }
    }
}
