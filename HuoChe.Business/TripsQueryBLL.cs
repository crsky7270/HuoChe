using HuoChe.DataAccess;
using HuoChe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuoChe.Business
{
    public class TripsQueryBLL
    {
        /// <summary>
        /// 根据车次查询
        /// </summary>
        /// <param name="trainNumber">车次号</param>
        /// <returns></returns>
        public StationInfo SearchTrips(string trainNumber)
        {
            return new LoadFileDAL().GetStationInfoList().FirstOrDefault(o => o.TrainNumber.ToLower().Equals(trainNumber.ToLower()));
        }

        /// <summary>
        /// 从缓存中获取温馨提示文字
        /// </summary>
        /// <returns></returns>
        public string GetReminderTxt()
        {
            return new LoadFileDAL().GetReminderTxt();
        }

        /// <summary>
        /// 获取西站车次信息
        /// </summary>
        /// <param name="trainNumber"></param>
        /// <returns></returns>
        public WestStationInfo SearchWestStationTrips(string trainNumber)
        {
            return
                new LoadFileDAL().GetWestStationInfoList()
                    .FirstOrDefault(o => o.TrainNumber.ToLower().Equals(trainNumber.ToLower()));
        }

        /// <summary>
        /// 获取西站温馨提示
        /// </summary>
        /// <returns></returns>
        public string GetWestReminderTxt()
        {
            return new LoadFileDAL().GetWestReminderTxt();
        }

    }
}
