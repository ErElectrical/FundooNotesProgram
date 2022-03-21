using CommonLayer.Model;

using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity Registration(UserRegistration User);
        public string login(UserLogin userLogin);

        public string ForgetPassword(string email);

        public bool ResetPassWord(string email, string password, string confirmpassword);

        public UserEntity GetUserByEmail(string EmailId);




    }
}

