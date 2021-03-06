﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
    /// <summary>
    /// Defines information for creating a charge
    /// </summary>
    public class ChargeCreateInfo : RequestObject
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        private int amount;

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        /// <value>Charge amount</value>
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private string currency;

        /// <summary>
        /// Gets or sets the currency
        /// </summary>
        /// <value>Charge currency</value>
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        private string description;

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        /// <value>Charge description</value>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string returnUri;

        /// <summary>
        /// Gets or sets the return URI when charging is completed
        /// </summary>
        /// <value>Return URI</value>
        public string ReturnUri
        {
            get { return returnUri; }
            set { returnUri = value; }
        }

        private string reference;

        /// <summary>
        /// Gets or sets the charge reference number
        /// </summary>
        /// <value>The charge reference number</value>
        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        private string cardId;

        /// <summary>
        /// Gets or sets the card Id or card token
        /// </summary>
        /// <value>Card Id or Card Token</value>
        public string CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        private string customerId;

        /// <summary>
        /// Gets or sets the customer Id
        /// </summary>
        /// <value>The customer Id</value>
        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private bool capture;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Omise.ChargeCreateInfo"/> will be automaticaly captured
        /// </summary>
        /// <value><c>true</c> if capture; otherwise, <c>false</c></value>
        public bool Capture
        {
            get { return capture; }
            set { capture = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeCreateInfo"/> class.
        /// </summary>
        public ChargeCreateInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeCreateInfo"/> class with a specific customer's card.
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="currency">Currency</param>
        /// <param name="description">Description</param>
        /// <param name="returnUri">Return URI</param>
        /// <param name="reference">Reference</param>
        /// <param name="cardId">Card Id or Card Token</param>
        /// <param name="customerId">Customer Id</param>
        public ChargeCreateInfo(int amount, string currency, string description, string returnUri, string reference, string cardId, string customerId)
        {
            this.amount = amount;
            this.currency = currency;
            this.description = description;
            this.returnUri = returnUri;
            this.reference = reference;
            this.cardId = cardId;
            this.customerId = customerId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeCreateInfo"/> class with default customer's card.
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="currency">Currency</param>
        /// <param name="description">Description</param>
        /// <param name="returnUri">Return URI</param>
        /// <param name="reference">Reference</param>
        /// <param name="customerId">Customer Id</param>
        public ChargeCreateInfo(int amount, string currency, string description, string returnUri, string reference, string customerId)
        {
            this.amount = amount;
            this.currency = currency;
            this.description = description;
            this.returnUri = returnUri;
            this.reference = reference;
            this.customerId = customerId;
        }

        /// <summary>
        /// Get the string representing the querystring parameters
        /// </summary>
        /// <returns>The request parameters</returns>
        public override string ToRequestParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("amount", this.amount.ToString());
            dict.Add("currency", this.currency);
            dict.Add("description", this.description);
            dict.Add("return_uri", this.returnUri);
            dict.Add("capture", this.capture.ToString());
            if (this.customerId != null)
            {
                dict.Add("customer", this.customerId);
            }

            if (this.cardId != null)
            {
                dict.Add("card", this.cardId);
            }

            string result = "";

            foreach (string key in dict.Keys)
            {
                result += key.ToLower() + "=" + dict[key] + "&";
            }

            return result.TrimEnd(new[] { '&' });
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Omise.ChargeCreateInfo"/> is valid.
        /// </summary>
        /// <value><c>true</c> if valid; otherwise, <c>false</c></value>
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
        /// <value>The errors dictionary object</value>
        public override Dictionary<string, string> Errors
        {
            get
            {
                return errors;
            }
        }

        private void validate()
        {
            errors.Clear();
            if (this.amount <= 0)
            {
                errors.Add("Amount", "must be greater than 0");
            }

            if (string.IsNullOrEmpty(this.currency))
            {
                errors.Add("Currency", "cannot be blank");
            }

            if (string.IsNullOrEmpty(this.returnUri))
            {
                errors.Add("ReturnUri", "cannot be blank");
            }

            if (string.IsNullOrEmpty(this.cardId))
            {
                if (string.IsNullOrEmpty(this.customerId))
                {
                    errors.Add("CardId", "cannot be blank. You can use card id or card token. Using card Id you must also pass the customer Id. You could only pass CustomerId to use the customer's default card.");
                }
            }
        }
    }
}

