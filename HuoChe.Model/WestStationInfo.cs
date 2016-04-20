using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuoChe.Model
{
    /// <summary>
    /// 南昌西站数据实体类
    /// </summary>
    [Serializable]
    public class WestStationInfo
    {
        /// <summary>
        /// 车次
        /// </summary>
        public string TrainNumber { get; set; }

        /// <summary>
        /// 始发站
        /// </summary>
        public string FormStation { get; set; }

        /// <summary>
        /// 终点站
        /// </summary>
        public string EndStation { get; set; }

        /// <summary>
        /// 检票口
        /// </summary>
        public string CheckInEntryStr { get; set; }

        /// <summary>
        /// 检票口列表
        /// </summary>
        public List<string> CheckInEntryList
        {
            get
            {
                return !string.IsNullOrEmpty(CheckInEntryStr) ? CheckInEntryStr.Trim().Split('|').ToList() : new List<string>();
            }
        }

    }
}
