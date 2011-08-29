using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RemAuth.Web.Mvc.Models
{
   [Serializable]
   public class AuthenticatorDTO
   {
      public int AuthenticatorId { get; set; }
      public string Name { get; set; }
   }
}