using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XCalculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int contador = 1;
        string operador;
        double numero1, numero2;
        public MainPage()
        {
            InitializeComponent();

        }

        private void History_Clicked(object sender, EventArgs e)
        {

        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {

        }
        void Operacion(object sender, EventArgs e)
        {

        }
        void SelNumero(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string pressed = btn.Text;

            if (this.resultado.Text == "0" || contador  < 0)
            {
                this.resultado.Text = "";

                if (contador < 0)
                {
                    contador *= -1;
                }
            }         
            this.resultado.Text += pressed;
            double numero;
            if (double.TryParse(this.resultado.Text, out numero))
            {
                
                if (contador == 1)
                {
                    numero1 = numero;
                }
                else
                {
                    numero2 = numero;
                }
            }
        }
    }
}
