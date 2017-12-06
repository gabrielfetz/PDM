using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BluetoothFinal
{
    public partial class MainPage : ContentPage
    {
        IBluetoothLE ble;
        IAdapter adapter;

        public MainPage()
        {
            InitializeComponent();

            ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
        }

        private void StatusButton_Clicked(object sender, EventArgs e)
        {
            // Verifica o estado do adaptador bluetooth (teste).
            var estado = ble.State;

            if (estado == BluetoothState.Off)
            {
                SituacaoLabel.Text = "Desligado";
                StatusBoxView.BackgroundColor = Color.Red;
            }
            else if (estado == BluetoothState.On)
            {
                SituacaoLabel.Text = "Ligado";
                StatusBoxView.BackgroundColor = Color.Green;
            }
        }

        ObservableCollection<string> deviceList;
        IDevice device;

        private async void ScanButton_Clicked(object sender, EventArgs e)
        {
            // Retorna todos os dispositivos pareados anteriormente no celular
            Array dispositivosPareadosArray = DependencyService.Get<IBluetooth>().scanPareados();
            DispositivosListView.ItemsSource = dispositivosPareadosArray;
        }

        private void DispositivosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Seleciona um dispositivo pareado para iniciar a comunicação bluetooth e abre a pagina de informacoes
            DependencyService.Get<IBluetooth>().conectar(e.SelectedItem.ToString());
            Navigation.PushAsync(new DashBoard());
        }
    }
}
