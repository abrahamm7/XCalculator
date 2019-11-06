using System;

namespace XCalculator
{
    public class Historial
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operador { get; set; }
        public DateTime Fecha { get; set; }
        public double total { get; set; }

        public string NewProperty
        {
            get
            {
                return string.Format("{0}  {1}  {2} = {3} ", FirstNumber, Operador, SecondNumber, total);
            }
        }


    }
}
