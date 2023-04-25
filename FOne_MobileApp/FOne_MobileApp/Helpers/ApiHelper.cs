using FOne_MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FOne_MobileApp.Helpers
{
    public class ApiHelper
    {
        const string BASE_URL = "https://ergast.com/api/f1";

        #region Circuit 

        // http://ergast.com/api/f1/current/next/circuits.json
        public static async Task<Response> GetNextCircuitAsync()
        {
            const string ENDPOINT = "current/next/circuits.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/circuits.json
        public static async Task<Response> GetCircuitsBySeasonYearAsync(string seasonYear)
        {
            const string ENDPOINT = "circuits.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/"+ seasonYear + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/circuits/albert_park.json
        public static async Task<Response> GetOneCircuitBySeasonYearAsync(string seasonYear, string id)
        {
            const string ENDPOINT = "circuits";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT + "/" + id + ".json");
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        #endregion

        #region Constructors

        // http://ergast.com/api/f1/2022/constructors.json
        public static async Task<Response> GetConstructorsBySeasonYearAsync(string seasonYear)
        {
            const string ENDPOINT = "constructors.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/constructors/alphatauri.json
        public static async Task<Response> GetOneConstructorBySeasonYearAsync(string seasonYear, string id)
        {
            const string ENDPOINT = "constructors";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT + "/" + id + ".json");
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        #endregion

        #region Drivers

        // http://ergast.com/api/f1/2022/drivers.json
        public static async Task<Response> GetDriversBySeasonYearAsync(string seasonYear)
        {
            const string ENDPOINT = "drivers.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/drivers/alonso/results
        public static async Task<Response> GetResultsBySeasonYearAndByOneDriverAsync(string seasonYear, string driverName)
        {
            const string ENDPOINT = "results.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + "drivers" + "/" + driverName + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/drivers/albon.json
        public static async Task<Response> GetOneDriverBySeasonYearAsync(string seasonYear, string id)
        {
            const string ENDPOINT = "drivers";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT + "/" + id + ".json");
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/driverStandings/1/drivers.json
        public static async Task<Response> GetDriverRankingBySeasonYearAsync(string seasonYear, int position)
        {
            const string ENDPOINT = "drivers.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/driverstandings/"  + position + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/constructors/mclaren/drivers.json
        public static async Task<Response> GetDriversBySeasonYearAndByConstructorAsync(string seasonYear, string constructorName)
        {
            const string ENDPOINT = "drivers.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/constructors/" + constructorName + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/constructors/mclaren/circuits/monza/drivers.json
        public static async Task<Response> GetDriversBySeasonYearByConstructorAndByCircuitAsync(string seasonYear, string constructorName, string circuitName)
        {
            const string ENDPOINT = "drivers.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/constructors/" + constructorName + "/circuits/" + circuitName + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }


        #endregion

        #region Race 

        // http://ergast.com/api/f1/2022/races.json
        public static async Task<Response> GetRacesBySeasonYearAsync(string seasonYear)
        {
            const string ENDPOINT = "races.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/1/races.json
        public static async Task<Response> GetOneRaceBySeasonYearAsync(string seasonYear, string round)
        {
            const string ENDPOINT = "races.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + round + "/" + ENDPOINT);
                var p = JsonConvert.DeserializeObject<Response>(jsonString);
                return p;
            }
        }

        // http://ergast.com/api/f1/current/next/races.json
        public static async Task<Response> GetNextRaceAsync()
        {
            const string ENDPOINT = "current/next/races.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + ENDPOINT);
                var p = JsonConvert.DeserializeObject<Response>(jsonString);
                return p;
            }
        }

        #endregion

        #region Result 

        // http://ergast.com/api/f1/2023/1/results.json
        public static async Task<Response> GetResultsBySeasonYearAndByRoundAsync(string seasonYear, string round)
        {
            const string ENDPOINT = "results.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + round + "/"+ ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2023/driverStandings.json
        public static async Task<Response> GetDriverStandingsBySeasonYearAsync(string seasonYear)
        {
            const string ENDPOINT = "driverStandings.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2023/constructorStandings.json
        public static async Task<Response> GetConstructorStandingsBySeasonYearAsync(string seasonYear)
        {
            const string ENDPOINT = "constructorStandings.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        // http://ergast.com/api/f1/2022/1/results.json
        public static async Task<Response> GetResultBySeasonYearAndByRaceAsync(string seasonYear, string round)
        {
            const string ENDPOINT = "results.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + round + "/" + ENDPOINT);
                var p = JsonConvert.DeserializeObject<Response>(jsonString);
                return p;
            }
        }

        // http://ergast.com/api/f1/current/last/results.json
        public static async Task<Response> GetResultOfMostRecentRaceAsync()
        {
            const string ENDPOINT = "current/last/results.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + ENDPOINT);
                var p = JsonConvert.DeserializeObject<Response>(jsonString);
                return p;
            }
        }

        // http://ergast.com/api/f1/2023/1/fastest/1/results.json
        public static async Task<Response> GetFatestDriverBySeasonYearByRaceAndByRankingAsync(string seasonYear, string round, string ranking)
        {
            const string ENDPOINT = "results.json";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + round + "/fastest/" + ranking + "/" + ENDPOINT);
                var p = JsonConvert.DeserializeObject<Response>(jsonString);
                return p;
            }
        }

        #endregion

        #region Lap 

        // http://ergast.com/api/f1/2023/1/drivers/alonso/laps.json?limit=80&offset=0
        public static async Task<Response> GetLapsBySeasonYearByRaceAndByDriverNameAsync(string seasonYear, string round, string driverName)
        {
            const string ENDPOINT = "laps.json?limit=80&offset=0";
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + "/" + seasonYear + "/" + round + "/drivers/" + driverName + "/" + ENDPOINT);
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                return response;
            }
        }

        #endregion
    }
}
