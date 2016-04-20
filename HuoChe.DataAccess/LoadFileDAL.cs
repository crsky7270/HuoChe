using System.Diagnostics;
using HuoChe.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangTuo.Caching.NetCache;

namespace HuoChe.DataAccess
{
    public class LoadFileDAL
    {

        private const string NanChangStationFilePath = "D:\\jk\\tgwj.txt";
        private const string NanChangeStationTipFilePath = "D:\\jk\\wxts.txt";

        private const string NanChangWestStationFilePath = "D:\\jk\\xizhan_tgwj.xml";
        private const string NanChangWestStationTipFilePath = "D:\\jk\\xizhan_wxts.txt";



        private const string cacheStationInfoListKey = "StationInfoList";
        private const string cacheStationInfoUpdateTimeKey = "StationInfoUpdateTime";

        private const string cacheReminderTxtKey = "ReminderTxt";
        private const string cacheReminderUpdateTimeKey = "ReminderUpdateTime";


        private const string cacheStationWestInfoListKey = "StationWestInfoList";
        private const string cacheStationWestInfoUpdateTimeKey = "StationWestInfoUpdateTime";

        private const string cacheWestReminderTxtKey = "WestReminderTxt";
        private const string cacheWestReminderUpdateTimeKey = "WestReminderUpdateTime";

        #region "公共方法"

        /// <summary>
        /// 加载温馨提示文件信息,两个站公共方法
        /// </summary>
        /// <returns></returns>
        private static string LoadReminderTxtFromFile(string tipFilePath)
        {
            var lines = File.ReadAllLines(tipFilePath);
            if (lines.Length > 0)
            {
                return lines[0];
            }
            return string.Empty;
        }

        /// <summary>
        /// 从文件获取最后更新时间,两个站公用方法
        /// </summary>
        /// <returns></returns>
        private static string LoadFileUpdateTime(string filePath)
        {
            var updateTime = File.GetLastWriteTime(filePath);
            return updateTime.ToLongTimeString();
        }

        /// <summary>
        /// 从缓存中获取文件最后更新时间
        /// </summary>
        /// <returns></returns>
        private static string GetFileUpdateTime(string key, string filePath)
        {
            object tmp;
            if (!WebCache.GetCacheTryParse(key, out tmp))
            {
                tmp = LoadFileUpdateTime(filePath);
                WebCache.Add(key, tmp);
            }
            return tmp as string;
        }

        #endregion


        #region "南昌站操作方法"
        /// <summary>
        /// 将数据加载到缓存中
        /// </summary>
        /// <returns></returns>
        public List<StationInfo> GetStationInfoList()
        {
            //首页判断文件是否被改动过
            var newUpdateFileTime = LoadFileUpdateTime(NanChangStationFilePath);
            var oldUpdateFileTime = GetFileUpdateTime(cacheStationInfoUpdateTimeKey, NanChangStationFilePath);

            object tmp;
            if (!WebCache.GetCacheTryParse(cacheStationInfoListKey, out tmp) || newUpdateFileTime != oldUpdateFileTime)
            {
                tmp = LoadStationInfo();
                WebCache.Add(cacheStationInfoListKey, tmp);
            }
            return tmp as List<StationInfo>;
        }

        /// <summary>
        /// 将数据加载到缓存中
        /// </summary>
        /// <returns></returns>
        public string GetReminderTxt()
        {
            //首页判断文件是否被改动过
            var newUpdateFileTime = LoadFileUpdateTime(NanChangeStationTipFilePath);
            var oldUpdateFileTime = GetFileUpdateTime(cacheReminderUpdateTimeKey, NanChangeStationTipFilePath);

            object tmp;
            if (!WebCache.GetCacheTryParse(cacheReminderTxtKey, out tmp) || newUpdateFileTime != oldUpdateFileTime)
            {
                tmp = LoadReminderTxtFromFile(NanChangeStationTipFilePath);
                WebCache.Add(cacheReminderTxtKey, tmp);
            }
            return tmp.ToString();
        }

        /// <summary>
        /// 从文件中加载数据
        /// </summary>
        /// <returns></returns>
        private List<StationInfo> LoadStationInfo()
        {
            List<StationInfo> list = new List<StationInfo>();
            var lines = File.ReadAllLines(NanChangStationFilePath);
            foreach (var line in lines)
            {
                if (line == "")
                {
                    continue;
                }
                var arr = line.TrimStart('|').Split('|');
                if (arr.Length >= 8)
                {
                    list.Add(new StationInfo()
                    {
                        TrainNumber = arr[0],
                        FormStation = arr[1],
                        EndStation = arr[2],
                        TiketArrivalTime = Convert.ToDateTime(arr[3]).ToString("HH:mm"),
                        PlanArrivalTime = Convert.ToDateTime(arr[4]).ToString("HH:mm"),
                        RealArrivalTime = Convert.ToDateTime(arr[5]).ToString("HH:mm"),
                        Track = arr[6],
                        ArrivalTips = arr[7],
                        Platform = arr[8]
                    });
                }
            }
            return list;
        }

        #endregion

        #region "南昌西站操作方法"

        /// <summary>
        /// 获取西站数据
        /// </summary>
        /// <returns></returns>
        public List<WestStationInfo> GetWestStationInfoList()
        {
            //首页判断文件是否被改动过
            var newUpdateFileTime = LoadFileUpdateTime(NanChangWestStationFilePath);
            var oldUpdateFileTime = GetFileUpdateTime(cacheStationWestInfoUpdateTimeKey, NanChangWestStationFilePath);

            object tmp;
            if (!WebCache.GetCacheTryParse(cacheStationWestInfoListKey, out tmp) || newUpdateFileTime != oldUpdateFileTime)
            {
                tmp = LoadWestStationInfo();
                WebCache.Add(cacheStationInfoListKey, tmp);
            }
            return tmp as List<WestStationInfo>;
        }

        /// <summary>
        /// 获取西站温馨提示
        /// </summary>
        /// <returns></returns>
        public string GetWestReminderTxt()
        {
            //首页判断文件是否被改动过
            var newUpdateFileTime = LoadFileUpdateTime(NanChangWestStationTipFilePath);
            var oldUpdateFileTime = GetFileUpdateTime(cacheWestReminderUpdateTimeKey, NanChangWestStationTipFilePath);

            object tmp;
            if (!WebCache.GetCacheTryParse(cacheWestReminderTxtKey, out tmp) || newUpdateFileTime != oldUpdateFileTime)
            {
                tmp = LoadReminderTxtFromFile(NanChangWestStationTipFilePath);
                WebCache.Add(cacheWestReminderTxtKey, tmp);
            }
            return tmp.ToString();
        }

        /// <summary>
        /// 加载西站数据
        /// </summary>
        /// <returns></returns>
        private List<WestStationInfo> LoadWestStationInfo()
        {
            List<WestStationInfo> list = new List<WestStationInfo>();
            var lines = File.ReadAllLines(NanChangWestStationFilePath);
            foreach (var line in lines)
            {
                if (line == "")
                {
                    continue;
                }
                var arr = line.TrimStart('|').Split('|');
                if (arr.Length >= 4)
                {
                    list.Add(new WestStationInfo()
                    {
                        TrainNumber = (arr[0] + "").Trim(),
                        FormStation = (arr[1] + "").Trim(),
                        EndStation = (arr[2] + "").Trim(),
                        CheckInEntryStr = GetMultiCheckInStr(arr).Trim('|')
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetMultiCheckInStr(string[] lst)
        {
            var result = string.Empty;
            for (int i = 3; i < lst.Length; i++)
            {
                result += "|" + lst[i];
            }
            return result;
        }

        #endregion

    }
}
