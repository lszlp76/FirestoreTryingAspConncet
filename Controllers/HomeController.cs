using FirestoreTryingAspConncet.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirestoreTryingAspConncet.Controllers
{
    public class HomeController : Controller
    {
        FirestoreDb db = FirestoreDb.Create("firestoretryingaspnetconnect");



        public async Task<IActionResult> Index()
        {
            CollectionReference collection = db.Collection("employee");
            QuerySnapshot employeeSnapshot = await collection.GetSnapshotAsync();

            var liste = new List<Employee>();
            foreach ( var empl in employeeSnapshot)
            {
                liste.Add(new Employee
                {
                    Name = empl.GetValue<string>("name"),
                    Surname = empl.GetValue<string>("surname"),
                    Age = empl.GetValue<int>("age")
                }) ;
            }
                return View(liste);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
