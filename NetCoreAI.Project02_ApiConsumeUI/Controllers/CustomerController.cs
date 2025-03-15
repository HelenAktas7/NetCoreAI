using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project02_ApiConsumeUI.Dtos;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NetCoreAI.Project02_ApiConsumeUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CustomerList() //api metotları async olarak calısır
        {
            var client = _httpClientFactory.CreateClient(); //istemci olusturduk
            var responseMessage = await client.GetAsync(" https://localhost:7010/api/Customers"); //İstekte bulunacagımız adres
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync(); //responseMessage içindeki degeri okur ve jsonData içine atar
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
                return View(values); //Json formatında gelen verileri deserialize ettil.Adresten gelen veriler ile ResultCustomerDto degerlerin birbiri ile eşleşmeli
            } 
            return View();
        }
    }
}
