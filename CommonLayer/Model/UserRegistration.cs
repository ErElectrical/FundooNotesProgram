// <copyright file="UserRegistration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CommonLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Poco class to Feed UserEntity class.
    /// </summary>
    public class UserRegistration
    {
        /// <summary>
        /// Gets or Sets value contains FirstName Of user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets value contains LastName Of user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets value contains Email Of user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets value contains Password Of user.
        /// </summary>
        public string Password { get; set; }
    }
}
