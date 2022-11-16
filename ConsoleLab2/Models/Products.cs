using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Models
{
    public class Products
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public string Characteristic { get; set; }

        public int MeasurementUnitId { get; set; }

        public string Photo { get; set; }
    }
}
