using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Beacon
{
  public class SharedBeacon
  {
    public string BeaconId { get; set; }
    public string Distance { get; set; }
    public string MacAddress { get; set; }
    public string Major { get; set; }
    public string Minor { get; set; }


    public string DisplayString {
      get{
        return "Id = " + BeaconId + "; MacAdresse = " + MacAddress + "; Distance = " + Distance + "; Major = " + Major + "; Minor= " + Minor; 
      }
}

  }//end class
}//end namespace
