using System;
using System.Threading.Tasks;
using MyApp.Rest;

namespace Rest
{

    public class TrainUtils
    {
        public async static Task<bool> Driving()
        {
            RestClient client = new RestClient();
            LegData res = await client.getLegData();
            long speed = res.Data.TrainLocation.TrainLocationOSpeed;
            return (speed != 0);
        }
    }
}