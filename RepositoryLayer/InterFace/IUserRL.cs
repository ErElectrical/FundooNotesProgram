// <copyright file="IUserRL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;
    using RepositoryLayer.Entity;

    /// <summary>
    /// IUserRL an Interface satisfied by UserRL class.
    /// </summary>
    public interface IUserRL
    {
        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="User">The user.</param>
        /// <returns>
        /// If Registed successfull than return userEntity
        /// else return null.
        /// </returns>
        public UserEntity Registration(UserRegistration User);

        /// <summary>
        /// login the specified user login.
        /// </summary>
        /// <param name="userLogin">The user login.</param>
        /// <returns>
        /// a Token if SuccessFull
        /// else return null.
        /// </returns>
        public string login(UserLogin userLogin);

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// Token if successfull
        /// else null.
        /// </returns>
        public string ForgetPassword(string email);

        /// <summary>
        /// Resets the pass word.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmpassword">The confirmpassword.</param>
        /// <returns>
        /// True if Reset Password successfull
        /// return false.
        /// </returns>
        public bool ResetPassWord(string email, string password, string confirmpassword);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="EmailId">The email identifier.</param>
        /// <returns>
        /// UserEntity.
        /// </returns>
        public UserEntity GetUserByEmail(string EmailId);
    }
}
