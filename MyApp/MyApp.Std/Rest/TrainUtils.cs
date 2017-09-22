using System;
using System.Threading.Tasks;
using MyApp.Rest;

namespace Rest
{

    public class TrainUtils
    {
        public static Boolean Driving()
        {
            RestClient client = new RestClient();
            Task<LegData> data = client.getLegData();
            long speed = 0;
            //long speed = await data.Run Result.Data.TrainLocation.TrainLocationOSpeed;
            return (speed != 0);
        }
    }
}