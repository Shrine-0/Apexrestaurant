using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Apexrestaurant.Mvc.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

public class CustomerController : Controller
{
    private string baseUri;

    public CustomerController(IConfiguration iConfig)
    {
        // Get baseUri of Web API from appsettings.json > ApiBaseUrl
        baseUri = iConfig.GetValue<string>("ApiBaseUrl");
    }



    // GET: Customer
    public ActionResult Index()
    {
        IEnumerable<CustomerViewModel> customers = null;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Add("accept", "application/json");
            var responseTask = client.GetAsync("api/customer");
            responseTask.Wait();
            //responseTask.EnsureSuccessStatusCode();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var apiResponse = result.Content.ReadAsStringAsync();
                apiResponse.Wait();
                customers = JsonConvert.DeserializeObject<IList<CustomerViewModel>>(apiResponse.Result);
            }
            else //web api sent error response
            {
                customers = Enumerable.Empty<CustomerViewModel>();
                ModelState.AddModelError(
                    string.Empty,"Server error. Please contact administrator."
                );
            }
        }
        return View(customers);
    }

   

    [HttpPost]
    public ActionResult Create(CustomerViewModel customer)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseUri);
            //HTTP POST
            var postTask = client.PostAsJsonAsync<CustomerViewModel>("customer", customer);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        }
        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
        return View(customer);
    }

    // public ActionResult Delete(int id)
    // {
    //     using (var client = new HttpClient())
    //     {
    //         client.BaseAddress = new Uri("http://localhost:9001/api/");
    //         //HTTP DELETE
    //         var deleteTask = client.DeleteAsync("customer/" + id.ToString());
    //         deleteTask.Wait();
    //         var result = deleteTask.Result;
    //         if (result.IsSuccessStatusCode)
    //         {
    //             return RedirectToAction("Index");
    //         }
    //     }
    //     return RedirectToAction("Index");
    // }
}
