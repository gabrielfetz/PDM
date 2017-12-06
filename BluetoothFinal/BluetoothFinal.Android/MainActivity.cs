using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RoundedBoxView.Forms.Plugin.Droid;
using Android.Bluetooth;
using Android.Content;
using System.Linq;

namespace BluetoothFinal.Droid
{
    [Activity(Label = "BluetoothFinal", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //BluetoothConnection myConnection = new BluetoothCKConnection();
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            RoundedBoxViewRenderer.Init();
            LoadApplication(new App());

        //    BluetoothSocket _socket = null;

        //    myConnection = new BluetoothConnection();
        //    myConnection.getAdapter();
        //    myConnection.thisAdapter.StartDiscovery();

        //    try
        //    {
        //        myConnection.getDevice();
        //        myConnection.thisDevice.SetPairingConfirmation(false);
        //        //   myConnection.thisDevice.Dispose();
        //        myConnection.thisDevice.SetPairingConfirmation(true);
        //        myConnection.thisDevice.CreateBond();
        //    }
        //    catch (Exception deviceEX)
        //    {
        //    }

        //    myConnection.thisAdapter.CancelDiscovery();

        //}
        //public class BluetoothConnection
        //{

        //    public void getAdapter() { this.thisAdapter = BluetoothAdapter.DefaultAdapter; }
        //    public void getDevice() { this.thisDevice = (from bd in this.thisAdapter.BondedDevices where bd.Name == "Loivi Fetz" select bd).FirstOrDefault(); }

        //    public BluetoothAdapter thisAdapter { get; set; }
        //    public BluetoothDevice thisDevice { get; set; }

        //    public BluetoothSocket thisSocket { get; set; }



     }
    }
}

