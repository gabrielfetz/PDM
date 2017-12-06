using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothFinal
{
    public interface IBluetooth
    {
        // A interface funciona como meio de campo entre o PCL e as classes nativas do Android, neste caso o bluetooth.
        Array scanPareados();
        void conectar(string dispositivo);
        string atualizarDado(byte codigoAscii);
        void desconectar();
    }
}
