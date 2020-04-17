using System;
using System.Collections.Generic;

namespace Dictionary.Models
{
    public partial class AppUser:IAppUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



        public AppUserDto ToDto()
        {
            AppUserDto user = new AppUserDto
            {
                Password = this.Password,
                UserName = this.UserName
            };

            return user;
        }

        //public bool Equals(IAppUser user)
        //{
        //    return (this.UserName == user.UserName && this.Password == user.Password);
        //}
    }
}
