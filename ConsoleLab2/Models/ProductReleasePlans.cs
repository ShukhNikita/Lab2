using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Models
{
    public class ProductReleasePlans
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public int ProductionTypesId { get; set; }
        public ProductReleasePlans(int ProductionTypesId, int CompanyId)
        {
            this.ProductionTypesId = ProductionTypesId;
            this.CompanyId = CompanyId;
        }
        public float PlannedOutputVolume { get; set; }

        public float ActualOutputVolume { get; set; }

        public int QuarterInfo { get; set; }

        public int YearInfo { get; set; }
    }
}
