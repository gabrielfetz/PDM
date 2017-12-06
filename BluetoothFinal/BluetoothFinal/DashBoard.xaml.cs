using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : ContentPage
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void AtualizarButton_Clicked(object sender, EventArgs e)
        {
            // Seta o text dos labels conforme a leitura aferida dos sensores
            TemperaturaLabel.Text = DependencyService.Get<IBluetooth>().atualizarDado(116);
            LuminosidadeLabel.Text = DependencyService.Get<IBluetooth>().atualizarDado(108);
        }

        private void DesconectarButton_Clicked(object sender, EventArgs e)
        {
            // Desconecta do modulo
            DependencyService.Get<IBluetooth>().desconectar();
        }
    }
}