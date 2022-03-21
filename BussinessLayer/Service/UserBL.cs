using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserEntity Registration(UserRegistration User)
        {
            try
            {
                return userRL.Registration(User);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string login(UserLogin userLogin)
        {
            try
            {
                return userRL.login(userLogin);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public string ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool ResetPassWord(string email, string password, string confirmpassword)
        {
            try
            {
                return userRL.ResetPassWord(email, password, confirmpassword);
            }
            catch(Exception)
            {
                throw;
            }
        }

        


    }
}

