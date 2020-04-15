using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WVC.Models;

namespace WVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;
            HttpResponseMessage respone = GlobalVariables.WebAplClient.GetAsync("Employee").Result;
            empList = respone.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int id=0)
        {
            if(id==0)
             return View(new mvcEmployeeModel());
            else
            {
                HttpResponseMessage respon = GlobalVariables.WebAplClient.GetAsync("Employee/"+id.ToString()).Result;
                return View(respon.Content.ReadAsAsync<mvcEmployeeModel>().Result); ;
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeId == 0)
            {
                HttpResponseMessage respon = GlobalVariables.WebAplClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Berhasil Tersimpan";
            }
            else
            {
                HttpResponseMessage respon = GlobalVariables.WebAplClient.PutAsJsonAsync("Employee/"+emp.EmployeeId, emp).Result;
                TempData["SuccessMessage"] = "Data Berhasil Diperbaruhi";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage respon = GlobalVariables.WebAplClient.DeleteAsync("Employee/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Berhasil Terhapus";
            return RedirectToAction("Index");
        }
    }
}