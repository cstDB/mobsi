using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Beacon
{
  public interface IBeaconHandler
  {
    event EventHandler<BeaconListChangedEventArgs> BeaconListChanged;

    void StartMonitoring();
    void StartRanging();
  }
}
