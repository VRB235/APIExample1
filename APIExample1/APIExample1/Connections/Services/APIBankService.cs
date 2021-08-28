using APIBank.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIExample1.Connections.Services
{
    public static class APIBankService
    {
        public static async Task<List<Account>> GetAccounts(IConfiguration configuration, string documentId)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync($"{configuration["URL_API_BANK"]}/api/v1/Persons/{documentId}/Accounts");

                List<Account> accounts = new();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync();

                    accounts = JsonConvert.DeserializeObject<List<Account>>(result.Result);

                    return accounts;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<List<Person>> GetPersons(IConfiguration configuration)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync($"{configuration["URL_API_BANK"]}/api/v1/Persons");

                List<Person> persons = new();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync();

                    persons = JsonConvert.DeserializeObject<List<Person>>(result.Result);

                    return persons;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
