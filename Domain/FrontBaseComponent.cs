using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FrontBaseComponent
    {
        public FrontBaseComponent()
        {
            Props = new List<FrontComponentProp>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool IsDeleted { get; set; }
        public List<FrontComponentProp> Props { get; set; }
    }
}
