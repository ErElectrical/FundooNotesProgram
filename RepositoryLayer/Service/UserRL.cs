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

                var result = this.fundooContext.User.FirstOrDefault(x => x.Email == userLogin.Email);
                var Encryptpassword = Decrypt(result.Password);
                
                if(result != null && Encryptpassword == userLogin.Password)
                {
                    var token = GenerateSecurityToken(result.Email, result.Id);
                    return token;
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
            //Provide Secret key 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Toolsettings["Jwt:secretKey"]));
            //provide credentials 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //declare who claims for it 
            var claims = new[] {
                new Claim(ClaimTypes.Email,Email),
                new Claim("Id",Id.ToString())
            };
            //genrate token by giving important information
            var token = new JwtSecurityToken(_Toolsettings["Jwt:Issuer"],
              _Toolsettings["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        /// <summary>
        /// 1. check weather the provided email is available in table or not
        /// 2. genrate security token 
        /// 3. send it to msmq section that will mail the user on its mail Id
        /// 4. return the token
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Base64 is a group of similar binary-to-text encoding schemes 
        /// representing binary data in an ASCII string format by translating it into a radix-64 representation.
        /// rdix 64 is a binary to text representation that allow conversion of binary data into their ascii values
        /// Each Base64 digit represents exactly 6-bits of data that means 4 6-bit Base64 digits can represent 3 bytes.


        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {
            //take an empty string
            string strmsg = string.Empty;
            //initialise a array of length password length
            byte[] encode = new byte[password.Length];
            //encode the password into bytes and initialise it to byte array
            encode = Encoding.UTF8.GetBytes(password);
            //initialise the string by converting it into base64 string
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public static string Decrypt(string encryptpwd)
        {
            // take an empty string that will contains password 
            string decryptpwd = string.Empty;
            //create an object of encoding class
            UTF8Encoding encodepwd = new UTF8Encoding();
            //create a local varible of Decoder class and apply get decode method onit.
            Decoder Decode = encodepwd.GetDecoder();
            //take the encrypted password into byte array
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            // count charcter of byte array
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            //create a char array of length byte array
            char[] decoded_char = new char[charCount];
            //get all charcter of it
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            //put the decode charcter into string 
            decryptpwd = new String(decoded_char);

            return decryptpwd;
        }


    }
}