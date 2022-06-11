using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FrontPropValue
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Align { get; set; }
        public string Type { get; set; }
        public bool IsHidden { get; set; }
        public Guid ComponentId { get; set; }
        public FrontComponent Component { get; set; }
        public FrontComponentProp Prop { get; set; }
    }
}
