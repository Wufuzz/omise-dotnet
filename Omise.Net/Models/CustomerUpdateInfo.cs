﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Omise
{
    public class CustomerUpdateInfo : RequestObject
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();
        private string email;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>Customer's email</value>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string description;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>Description of the customer</value>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string cardToken;

        /// <summary>
        /// Gets or sets the card token.
        /// </summary>
        /// <value>The card token</value>
        public string CardToken
        {
            get { return cardToken; }
            set { cardToken = value; }
        }

        private CardCreateInfo cardCreateInfo;

        public CardCreateInfo CardCreateInfo
        {
            get { return cardCreateInfo; }
            set { cardCreateInfo = value; }
        }

        private string defaultCardId;

        public string DefaultCardId
        {
            get { return defaultCardId; }
            set { defaultCardId = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        public CustomerUpdateInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        public CustomerUpdateInfo(string email, string description)
        {
            this.email = email;
            this.description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        /// <param name="cardToken">Credit card id or card token to attach to customer</param>
        public CustomerUpdateInfo(string email, string description, string cardToken)
        {
            this.email = email;
            this.description = description;
            this.cardToken = cardToken;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Omise.CustomerCreateInfo"/> class.
        /// </summary>
        /// <param name="email">Customer's email</param>
        /// <param name="description">Description of the customer</param>
        /// <param name="cardCreateInfo">Credit card information to attach to customer</param>
        public CustomerUpdateInfo(string email, string description, CardCreateInfo cardCreateInfo)
        {
            this.email = email;
            this.description = description;
            this.cardCreateInfo = cardCreateInfo;
        }

        private void validate()
        {
            errors.Clear();
            if (!string.IsNullOrEmpty(this.cardToken) && cardCreateInfo != null)
            {
                errors.Add("card", "Specifying both card token and card dictionary is not allowed");
            }

            if (this.cardCreateInfo != null && string.IsNullOrEmpty(this.cardToken))
            {
                if (!this.cardCreateInfo.Valid)
                {
                    errors.Add("card", "Card information is invalid");
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Omise.CustomerUpdateInfo"/> is valid.
        /// </summary>
        /// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
        public override bool Valid
        {
            get
            {
                validate();
                return errors.Count == 0;
            }
        }

        /// <summary>
        /// Gets the errors dictionary.
        /// </summary>
        /// <value>The errors dictionary object.</value>
        public override Dictionary<string, string> Errors
        {
            get
            {
                return errors;
            }
        }

        /// <summary>
        /// Get the string representing the querystring parameters
        /// </summary>
        /// <returns>The request parameters</returns>
        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("email", this.email);
            dict.Add("description", this.description);
            
            if (!string.IsNullOrEmpty(this.cardToken))
            {
                dict.Add("card", this.cardToken);
            }

            if (!string.IsNullOrEmpty(this.defaultCardId))
            {
                dict.Add("defaultCardId", this.defaultCardId);
            }

            string result = "";

            foreach (string key in dict.Keys)
            {
                result += key.ToLower() + "=" + dict[key] + "&";
            }

            return result.TrimEnd(new[] { '&' });
        }
    }
}
