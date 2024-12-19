using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixApi.Models
{
    public class Pix
    {
        public string Gui { get; } = "br.gov.bcb.pix";
        public string Key { get; set; }
        public string Value { get; set; }
        public string Fss { get; set; }
        public string MerchantCategoryCode { get; set; } = "0000";
        public string CountryCode { get; set; } = "BR";
        public string MerchantName { get; set; }
        public string MerchantCity { get; set; }
        public Guid TxId { get; set; }
        
    }
}