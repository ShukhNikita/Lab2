using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Models
{
    public class ProductSalesPlans
    {

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProductionTypeId { get; set; }
        public float PlannedImplementationVolume { get; set; }
        public float ActualImplementationVolume { get; set; }
        public int QuarterInfo { get; set; }
        public int YearInfo { get; set; }
    }
}
