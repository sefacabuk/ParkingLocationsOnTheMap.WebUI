using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingLocationsOnTheMap.WebUI.BusinessLogicLayer;
using ParkingLocationsOnTheMap.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLocationsOnTheMap.WebUI.Controllers
{
    public class NewIsparkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MapList()
        {
            string link = ApiCall.ApiLink + "api/NewIsparkData/";

           List<NewIsparkDto> sonucList = new List<NewIsparkDto>();
            //object sonucList = new object();

            try
            {
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                string json = "";
                //json = Newtonsoft.Json.JsonConvert.SerializeObject(Request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.GetAsync(link);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                sonucList = (JsonConvert.DeserializeObject<List<NewIsparkDto>>(responJsonText));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var sonuc = Json(sonucList);
            return sonuc;
        }


        [HttpPost]
        public IActionResult SaveLocation(NewIsparkDto newIspark)
        {

            string link = ApiCall.ApiLink + "api/NewIsparkData";


            try
            {
                var httpClient = new HttpClient();
               
                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(newIspark);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.PostAsync(link, httpContent);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<NewIsparkDto>(responJsonText));


                return Json(new { success = true, responseText = "Kayıt Başarılı" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Hata" });
            }

        }


        [HttpPut]
        public IActionResult UpdateLocation(NewIsparkDto newIspark)
        {

            string link = ApiCall.ApiLink + "api/NewIsparkData/";

            try
            {
                var httpClient = new HttpClient();

                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(newIspark);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.PutAsync(link, httpContent);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<NewIsparkDto>(responJsonText));


                return Json(new { success = true, responseText = "Guncelle Basarili" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Guncelle Hata" });
            }


        }


    }
}
