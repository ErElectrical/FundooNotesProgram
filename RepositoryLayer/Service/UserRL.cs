using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.IO;
using System.Security.Cryptography;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly FundooContext fundooContext;

        private readonly IConfiguration _Toolsettings;

        public UserRL(FundooContext fundooContext, IConfiguration _Toolsettings)
        {
            this.fundooContext = fundooContext;
            this._Toolsettings = _Toolsettings;

        }

        public UserEntity Registration(UserRegistration User)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = User.FirstName;
                userEntity.LastName = User.LastName;
                userEntity.Email = User.Email;
                userEntity.Password = Encrypt(User.Password);
                fundooContext.User.Add(userEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                    return userEntity;
                else
                    return null;

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
                //Returns the first element of a collection, or the first element that satisfies a condition. Returns a default value if index is out of range.

                var Decryptpassword = this.fundooContext.User.Where(x => x.Email == userLogin.Email).Select(x => x.Password).ToString();
                var Encryptpassword = Decrypt(Decryptpassword);
                var user = fundooContext.User.Where(x => x.Email == userLogin.Email).FirstOrDefault();
                if( user != null && Encryptpassword == userLogin.Password)
                {
                    var result = GenerateSecurityToken(user.Email, user.Id);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GenerateSecurityToken(string Email, long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Toolsettings["Jwt:secretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Email,Email),
                new Claim("Id",Id.ToString())
            };
            var token = new JwtSecurityToken(_Toolsettings["Jwt:Issuer"],
              _Toolsettings["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public string ForgetPassword(string email)
        {
            try
            {
                var result = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
                if(result != null)
                {
                    var token = GenerateSecurityToken(result.Email, result.Id);
                    new MsMq().Sender(token);
                    return token;
                }
                return null;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool ResetPassWord(string email,string password,string confirmpassword)
        {
            try
            {
                if(password.Equals(confirmpassword))
                {
                    var user = fundooContext.User.Where(opt => opt.Email == email).FirstOrDefault();
                    user.Password = Encrypt(confirmpassword);
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public UserEntity GetUserByEmail(string EmailId)
        {
            return this.fundooContext.User.SingleOrDefault(e => e.Email.Equals(EmailId));
        }

        public static string Encrypt(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public static string Decrypt(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }


    }
}