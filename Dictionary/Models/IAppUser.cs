using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Models
{
   public  interface IAppUser
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
