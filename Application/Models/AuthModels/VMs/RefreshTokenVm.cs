using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AuthModels.VMs
{
    public class RefreshTokenVm
    {
        public string Id { get; set; }
        public Guid Token { get; set; }
        public DateTime ToLife { get; set; }
    }
}
