using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Auth
{
   public class FirebaseAuthServiceResponse
    {
        public string IdToken { get; set; }
        public int UserId { get; set; }
    }
}
