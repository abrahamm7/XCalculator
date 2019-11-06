using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace XCalculator
{
    public class Historial
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public DateTime Fecha { get; set; }
        public double total { get; set; }

        
    }
}
