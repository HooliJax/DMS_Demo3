﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using testDMS.Models;
using System.Web.Mvc.Ajax;
using System.Web.Helpers;

namespace testDMS.Controllers
{
    public class ChartController : Controller
    {
        DonorManagementDatabaseEntities db = new DonorManagementDatabaseEntities();

        public ActionResult Index()
        {
            Report model = new Report();
            return View(model);
        }

        [HttpPost]
        public string GetChartParams(Report reportModel)
        {

            string chosenCriteria = reportModel.Criteria;
            string chosenType = reportModel.Type;
            string chosenParams = reportModel.Params;
            char chosenEquivalance = reportModel.Equivalance;

            //StringBuilder reportString = new StringBuilder();
            //reportString.Append("Criteria: " + chosenCriteria + "<br/>");
            //reportString.Append("Equivalance: " + chosenEquivalance + "<br/>");
            //reportString.Append("Params: " + chosenParams + "<br/>");
            //reportString.Append("Type: " + chosenType + "<br/>");

            var donors = db.DONORs.Where(n => n.FNAME == chosenParams).Select(n => n.LNAME);

            //MakeChart();

            return donors.FirstOrDefault();
        }

        public ActionResult MakeChart()
        {
            //var myChart = new Chart(width: 600, height: 400)
            //    .AddTitle("Chart Title")
            //    .AddSeries(
            //        name: "Employee",
            //        xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
            //        yValues: new[] { "2", "6", "4", "5", "3" })
            //        .Write();

            //myChart.Save("~/Content/")
 
            return PartialView();
        }

    }
}