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


        public async static Task<string> TrainID()
        {
            RestClient client = new RestClient();
            TrainData res = await client.getTrainData();
            string trainid = res.Triebzugnummer.Tzn;
            return trainid;
        }

    }
}