using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class IsparkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MapList()
        {
            string link = ApiCall.ApiLink + "api/IsparkData/";

            List<IsparkDto> sonucList = new List<IsparkDto>();
            //object sonucList = new object();

            try
            {
                var httpClient = new HttpClient();
                string json = "";
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.GetAsync(link);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                sonucList = (JsonConvert.DeserializeObject<List<IsparkDto>>(responJsonText));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var sonuc = Json(sonucList);
            return sonuc;
        }

        [HttpPost]
        public IActionResult AddUpdate(IsparkDto isparkData)
        {

            string link = ApiCall.ApiLink + "api/IsparkData";

            try
            {
                var httpClient = new HttpClient();
                
                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(isparkData);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = httpClient.PostAsync(link, httpContent);
                postTask.Wait();
                var postResult = postTask.Result;
                var responJsonText = postResult.Content.ReadAsStringAsync().Result;

                var sonuc = (JsonConvert.DeserializeObject<IsparkDto>(responJsonText));

                return Json(new { success = true, responseText = "Güncelleme Başarılı" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Hata" });
            }

        }

    }
}
