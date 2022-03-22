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

                var Decryptpassword = fundooContext.User.Where(x => x.Email == userLogin.Email).Select(x => x.Password).ToString();
                var Encryptpassword = Decrypt(Decryptpassword);
                var user = fundooContext.User.Where(x => x.Email == userLogin.Email && Encryptpassword == userLogin.Password).FirstOrDefault();
                if( user != null)
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

        private  string Encrypt(string password)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }

        private  string Decrypt(string password)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return password;
        }

    }
}