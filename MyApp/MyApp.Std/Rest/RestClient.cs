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

                string responseBody = await SendRequest(httpClient, legDataAdress);

                dataset = LegData.FromJson(responseBody);
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
                string responseBody = await SendRequest(httpClient, trainDataAddress);
                dataset = TrainData.FromJson(responseBody);
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
              
                string responseBody = await SendRequest(httpClient, zipDataAddress);
                dataset = ZipData.FromJson(responseBody);
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

        private async Task<string> SendRequest(HttpClient httpClient, string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }


}
