using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ArcGISAppDemo;
using Xamarin.Forms;
using Android.Bluetooth;
using Java.Util;

[assembly: Dependency(typeof(TestBluetooth))]

namespace ArcGISAppDemo
{
    public class TestBluetooth : IBluetooth
    {
        BluetoothSocket _socket;
        public async void ConnectDevice()
        {   //grab instance of bluetooth adapted
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if(adapter == null)
            {
                throw new Exception("No bluetooth adapter found");
            }
            if (!adapter.IsEnabled)
            {
                throw new Exception("Bluetooth adapter is not enabled");
            }
            //look at already paird devices
            BluetoothDevice device = (from bd in adapter.BondedDevices
                                      where bd.Name == "Name of device"
                                      select bd).FirstOrDefault();
            if(device == null)
            {
                throw new Exception("Named device not found");
            }
            _socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-000666827E07"));
            await _socket.ConnectAsync();

        }

        public async void RecMsg()
        {
            var buffer = Encoding.ASCII.GetBytes("a");
            await _socket.InputStream.ReadAsync(buffer, 0, buffer.Length);
        }

        public async void SendMsg()
        {
            var buffer = Encoding.ASCII.GetBytes("a");
            await _socket.OutputStream.WriteAsync(buffer, 0, buffer.Length)
        }
    }
}