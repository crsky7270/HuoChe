using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HuoChe.Business;
using HuoChe.Model;

namespace HuoChe.Web.Controllers
{
    public class TipsQueryController : Controller
    {
        // GET: TipsQuery
        /// <summary>
        /// 南昌站
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 南昌西站
        /// </summary>
        /// <returns></returns>
        public ActionResult WestStation()
        {
            return View();
        }

        /// <summary>
        /// 引导页
        /// </summary>
        /// <returns></returns>
        public ActionResult Guide()
        {
            return View();
        }

        /// <summary>
        /// 南昌站车次查询
        /// </summary>
        /// <param name="tripNum"></param>
        /// <returns></returns>
        public JsonResult QueryTrips(string tripNum)
        {
            var bll = new TripsQueryBLL();
            var trip = bll.SearchTrips(tripNum.Trim()) ?? new StationInfo();
            return Json(trip, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取温馨提示信息
        /// </summary>
        /// <returns></returns>
        public string GetReminderTxt()
        {
            var bll = new TripsQueryBLL();
            return bll.GetReminderTxt();
        }

        /// <summary>
        /// 查询西站车次信息
        /// </summary>
        /// <param name="tripNum"></param>
        /// <returns></returns>
        public JsonResult QueryWestTrips(string tripNum)
        {
            var bll = new TripsQueryBLL();
            var trip = bll.SearchWestStationTrips(tripNum.Trim()) ?? new WestStationInfo();
            return Json(trip, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取西站温馨提示
        /// </summary>
        /// <returns></returns>
        public string GetWestReminderTxt()
        {
            var bll = new TripsQueryBLL();
            return bll.GetWestReminderTxt();
        }
    }
}