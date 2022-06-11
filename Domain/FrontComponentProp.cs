using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FrontComponentProp
    {
        public FrontComponentProp()
        {
            PropValues = new List<FrontPropValue>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool CanBeHidden { get; set; }
        public Guid BaseComponentId { get; set; }
        public FrontBaseComponent BaseComponent { get; set; }
        public List<FrontPropValue> PropValues { get; set; }

    }
}
