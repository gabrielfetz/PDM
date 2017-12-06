using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;
using Java.Util;

[assembly: Xamarin.Forms.Dependency(typeof(BluetoothFinal.Droid.BluetoothAndroid))]
namespace BluetoothFinal.Droid
{
    public class BluetoothAndroid : IBluetooth
    {
        public BluetoothAndroid() { }
        BluetoothAdapter bta = BluetoothAdapter.DefaultAdapter;
        BluetoothSocket btSocket;

        public Array scanPareados()
        {
            // Recebe os dispositivos pareados anteriormente no dispositivos e os aloca num array que será o ItemSource de uma ListView
            List<string> lista = new List<string>();
            foreach (BluetoothDevice pareado in bta.BondedDevices)
            {
                lista.Add(pareado.Name.ToString());
            }
            return lista.ToArray();
        }

        public void conectar(string dispositivo)
        {
            // Conecta com o dispositivo selecionado na ListView
            var dispositivoObj = bta.BondedDevices.First(x => x.Name == dispositivo);
            BluetoothDevice device = bta.GetRemoteDevice(dispositivoObj.Address);
            // Esta UUID é default do módulo bluetooth HC-05 conectado ao Arduino. Caso a conexão fosse para outro dispositivo, o código teria de ser adaptado para capturar a UUID do dispositivo em questão.
            btSocket = device.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));

            // Conecta no dispositivo
            btSocket.Connect();
        }

        public string atualizarDado(byte codigoAscii)
        {
            // Envia o comando para o Arduino em um byte (116, letra `t`, para aferir a temperatura e 108, letra `l`, para aferir a luminosidade)
            byte[] byteRetorno = new byte[19];

            btSocket.OutputStream.WriteByte(codigoAscii);
            btSocket.InputStream.Read(byteRetorno, 0, 19);
            btSocket.OutputStream.Close();
            btSocket.InputStream.Close();

            return Encoding.GetEncoding(1252).GetString(byteRetorno);
        }

        public void desconectar()
        {
            // Desconecta do modulo
            btSocket.Close();
        }
    }
}
