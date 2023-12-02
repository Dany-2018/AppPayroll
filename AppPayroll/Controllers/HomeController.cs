using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Text.Json;
using AppPayroll.Models;
using System.Reflection;
using System.Threading;

namespace AppPayroll.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            var response = await GetEmployeesFromApi();
            Thread.Sleep(5000);

            if (response.Data == null )
            {
                return View("Index");
            }
            else
            {
                return View(response?.Data);
            }
        }

        private async Task<ApiResponse> GetEmployeesFromApi()
        {
            var httpClient = new HttpClient();
            var obj = await httpClient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            return JsonConvert.DeserializeObject<ApiResponse>(obj);
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


        // Método para obtener los detalles del empleado por ID desde una API externa
        public async Task<ActionResult> MostrarEmpleadoPorId(int id)
        {
            try
            {
                if (id == 0 )
                {
                    return View("Index");
                }

                Thread.Sleep(10000);
                // URL de la API que proporciona detalles del empleado por ID
                string apiUrl = $"https://dummy.restapiexample.com/api/v1/employee/{id}";


                await Task.Delay(2000);
                var httpClient = new HttpClient();
                await Task.Delay(2000);
                var response = await httpClient.GetStringAsync(apiUrl);

            

                ApiResponseSearch resp = JsonConvert.DeserializeObject<ApiResponseSearch>(response);

                if (resp.Data == null || resp.Status != "success"  )
                {
                    // Manejo cuando el ID es incorrecto o el estado de la respuesta no es "success"
                    return View("Index");
                }
                else
                {
                    return View(resp?.Data);
                }
            }
            catch (HttpRequestException)
            {
                // Manejo de errores de solicitud HTTP
                return View("Index");
            }
            catch (Newtonsoft.Json.JsonException)
            {
                // Manejo de errores de deserialización JSON
                return View("Index");
            }
            catch (Exception)
            {
                // Otros errores
                return View("Index");
            }

        }

    }

}