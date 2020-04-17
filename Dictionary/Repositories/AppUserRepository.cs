using Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Repositories
{
    public class AppUserRepository
    {

        private DictionaryContext _db;
        public AppUserRepository(DictionaryContext db)
        {
            _db = db;
        }

        public bool FindUser(IAppUser user)
        {
            // TODO: Is there better solution 
            try
            {
                bool x = _db.AppUser.Any(u => (u.UserName == user.UserName) && (u.Password == user.Password));
                return x;
            }
            catch
            {
                return false;
            }
            
           

            //return (x != null);
        }
    }
}
