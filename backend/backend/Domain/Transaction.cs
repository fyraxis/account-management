using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.Domain
{
    public class Transaction
    {
        [Required]
        [JsonPropertyName("account_id")]
        public string Account_Id { get; set; }
        
        [Required]
        [JsonPropertyName("amount")]
        public int? Amount { get; set; }
    }
}
