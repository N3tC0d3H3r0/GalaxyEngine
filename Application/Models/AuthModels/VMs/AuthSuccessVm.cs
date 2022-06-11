using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AuthModels.VMs
{
    public class AuthSuccessVm
    {
        public string refresh_token { get; set; }
        public string access_token { get; set; }
    }
}
