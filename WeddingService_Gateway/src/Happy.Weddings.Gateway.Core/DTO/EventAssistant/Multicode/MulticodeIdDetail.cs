using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Multicode
{
    public class MulticodeIdDetail
    {
        public string Code { get; set; }
        public MulticodeIdDetail(string code)
        {
            Code = code;
        }
    }
}
