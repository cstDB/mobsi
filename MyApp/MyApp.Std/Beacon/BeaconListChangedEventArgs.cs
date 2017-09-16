using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Beacon
{
  public class BeaconListChangedEventArgs : EventArgs
  {
    public System.Collections.Generic.List<SharedBeacon> Data { get; protected set; }
    public BeaconListChangedEventArgs(System.Collections.Generic.List<SharedBeacon> data)
    {
      Data = data;
    }
  }
}
