using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rest;
using static Newtonsoft.Json.JsonConvert;

namespace MyApp.Rest
{

    public class DataObject
    {
        public string Name { get; set; }
    }

    public class RestClient
    {
        public RestClient()
        {
        }

        private const string legDataAdress = "http://decs.imice.de:8081/legdata/";
        private const string trainDataAddress = "http://decs.imice.de:8081/traindata/";
        private const string zipDataAddress = "http://decs.imice.de:8081/zipdata/";

       
        public async Task<LegData> getLegData()
        {
            HttpClient httpClient = new HttpClient();

            LegData dataset = null;

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(legDataAdress);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                dataset = LegData.FromJson(responseBody);
                Debug.WriteLine("Leg Data: " + dataset.Data.TrainState.TrainStateCouplingActive);
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.Message);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Request canceled.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
               
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }

            return dataset;
        }

        public async Task<TrainData> getTrainData()
        {
            HttpClient httpClient = new HttpClient();

            TrainData dataset = null;

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(trainDataAddress);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                dataset = TrainData.FromJson(responseBody);
                Debug.WriteLine("Train Data: " + dataset.Triebzugnummer);
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.Message);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Request canceled.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {

                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }

            return dataset;
        }

        public async Task<ZipData> getZipData()
        {
            HttpClient httpClient = new HttpClient();

            ZipData dataset = null;

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(zipDataAddress);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                dataset = ZipData.FromJson(responseBody);
                Debug.WriteLine("Zip Data: " + dataset.ChassisId);
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.Message);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Request canceled.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {

                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }

            return dataset;
        }

       
    }
}
