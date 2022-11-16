using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Models
{
    public class MeasurementUnits
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public MeasurementUnits(string Name)
        {
            this.Name = Name;
        }


    }
}
