using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuoChe.Model
{
    /// <summary>
    /// 车次信息
    /// </summary>
    [Serializable]
    public class StationInfo
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
        /// 车票上的达到时间
        /// </summary>
        public string TiketArrivalTime { get; set; }

        /// <summary>
        /// 预计达到时间
        /// </summary>
        public string PlanArrivalTime { get; set; }

        /// <summary>
        /// 实际达到时间
        /// </summary>
        public string RealArrivalTime { get; set; }

        /// <summary>
        /// 轨道
        /// </summary>
        public string Track { get; set; }

        /// <summary>
        /// 最终到站提示，如：晚点10分钟
        /// </summary>
        public string ArrivalTips { get; set; }

        /// <summary>
        /// 站台
        /// </summary>
        public string Platform { get; set; }
    }
}
