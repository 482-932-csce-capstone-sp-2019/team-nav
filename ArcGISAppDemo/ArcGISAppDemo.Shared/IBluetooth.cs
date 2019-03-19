using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcGISAppDemo
{
    public interface IBluetooth
    {
         void ConnectDevice();
         void SendMsg();
         void RecMsg();
    }
}
