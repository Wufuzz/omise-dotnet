﻿using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class Card : ResponseObject
	{
		[JsonProperty("livemode")]
		public bool LiveMode{ get; set; }
		[JsonProperty("country")]
		public string Country{get;set;}
		[JsonProperty("city")]
		public string City{get;set;}
		[JsonProperty("postal_code")]
		public string PostalCode{get;set;}
		[JsonProperty("financing")]
		public string Financing{ get; set; }
		[JsonProperty("last_digits")]
		public string LastDigits{ get; set; }
		[JsonProperty("brand")]
		public Brand Brand{ get; set; }
		[JsonProperty("expiration_month")]
		public string ExpirationMonth{ get; set; }
		[JsonProperty("expiration_year")]
		public string ExpirationYear{ get; set; }
		[JsonProperty("fingerprint")]
		public string Fingerprint{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
	}
}
