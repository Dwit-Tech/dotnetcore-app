using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Data.Entities
{
    public class RefreshActivationCode
    {
        public string activationCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
    }
}
