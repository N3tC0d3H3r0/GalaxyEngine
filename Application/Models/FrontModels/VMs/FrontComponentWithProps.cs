using Application.Queries.FrontPropValue.GetFrontPropValueByComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.VMs
{
    public class FrontComponentTypeWithProps
    {
        public string ComponentType { get; set; }
        public List<GetFrontPropValueListDto> Props { get; set; }
    }
}
