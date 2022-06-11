using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FrontComponent
    {
        public FrontComponent()
        {
            PropValues = new List<FrontPropValue>();
        }
        public Guid Id { get; set; }
        public Guid BaseComponentId { get; set; }
        public FrontBaseComponent BaseComponent { get; set; }
        public Guid PageId { get; set; }
        public FrontPage Page { get; set; }
        public int DisplayIndex { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsHidden { get; set; }

        public List<FrontPropValue> PropValues { get; set; }

    }
}
