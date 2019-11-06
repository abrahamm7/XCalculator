
using SimpleInjector;
using SQLite;
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
        public SQLiteConnection conn;
        Historial historial = new Historial();
        public MainPage()
        {
            InitializeComponent();
            Borrar(this, null);
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Historial>();
        }
        void Operacion(object sender, EventArgs e)
        {
            contador = -2;
            Button btn = (Button)sender;
            string pressed = btn.Text;
            operador = pressed;
            historial.Operador = operador;
        } //Seleccion de operacion
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
                    historial.FirstNumber = numero1;

                }
                else
                {
                    numero2 = numero;
                    historial.SecondNumber = numero2;
                }
            }
        } //Seleccion de Numero
        void Borrar(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            resultado.Text = "0";
            contador = 1;
        } 
        async private void BtnHistory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new History());
        }
        void Igual(object sender, EventArgs e)
        {
            if (contador == 2)
            {
                var result = Operaciones.Calcular(numero1, numero2, operador);
                this.resultado.Text = result.ToString();
                numero1 = result;
                contador = -1;              
                historial.total = result;
                historial.Fecha = DateTime.Now;

                int x = 0;
                try
                {
                    x = conn.Insert(historial);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        } //Resultado

    }
}
