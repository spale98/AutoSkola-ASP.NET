using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pokusaj3.Controllers
{
    public class HomeController : Controller
    {

        public class TempResponse
        {
            public string BusIdentifier { get; set; }
            public DateTime[] Dates { get; set; }
            public Measurement[] Measurements { get; set; }
        }

        public class Measurement
        {
            public string Unit { get; set; }
            public float[] Values { get; set; }
        }


        public async Task<ActionResult> Index()
        {
            LoginResult loginResult = await Login();

            SensorsData data = await GetSensorsData(loginResult.Token);

            return View(data);
        }

        public async Task<ActionResult> Chart()
        {
            LoginResult loginResult = await Login();

            SensorsData data = await GetSensorsData(loginResult.Token);

            return View(data);
        }

        public async Task<LoginResult> Login()
        {
            try
            {
                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new UserLogin { Username = "demostudent", Password = "demostudent" }));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync("http://azure.dunavnet.eu/agronetAPIv2/api/account/login", content);

                var value = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<LoginResult>(value);
            }
            catch (Exception ex)
            {
                throw;
               
            }
        }

        public async Task<SensorsData> GetSensorsData(string token)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetStringAsync("http://azure.dunavnet.eu/agronetAPIv2/api/agronetmobileextension/getmeasurementbydevice?busIdentifier=24e1641094192546");

                
                var result= JsonConvert.DeserializeObject<SensorsData>(response);
                //TODO: iterirati kroz result, i popunjavati npovi model ChartData

                return result;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        [HttpGet]
        public ActionResult FormaUpis()
        {
            return View();
        }
        [HttpPost]
        public ViewResult FormaUpis(Models.OdgovorStranica odgovor)
        {

            return View("Odgovor", odgovor);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}