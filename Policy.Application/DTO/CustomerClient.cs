using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Application.DTO
{
    public class CustomerClient
    {
        HttpClient client;
        public CustomerClient(HttpClient client)
        {
            this.client = client;
        }
        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            return await client.GetFromJsonAsync<CustomerDTO>($"api/Customer/{id}");
        }

    }
}
