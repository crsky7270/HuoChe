﻿using System;
using System.IO;
using Microsoft.Practices.ServiceLocation;
using ZhangTuo.Caching;
using ZhangTuo.Caching.NetCache;
using ZhangTuo.IoC;
using log4net.Config;

namespace WiFi.Configuration.BootStarp
{
    /// <summary>
    /// IOC注册的业务逻辑
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// 注册调用的主入口
        /// </summary>
        /// <param name="moreMap">其他注册，在正常的注册完成后，会执行该方法，做其他的注册</param>
        public static void Bootstrap(Action<IRegistration> moreMap = null)
        {
            var locator = new StructureMapServiceLocator();
            locator.UseAsDefault();
            locator.Map(() => ServiceLocator.Current);
            locator.Logger.Log("Configuring Registries");

            locator.Map<IRegistration>(() => locator);
            locator.Map<ICacheProvider, CacheManager>().Singleton();
            locator.UseBusinessLayer().UseDataAccessLayer();
            if (moreMap != null)
                moreMap(locator);
            locator.Logger.Log("Loading container...");
            locator.Load();
            locator.Logger.Log("Done");
        }

        /// <summary>
        /// 日志的注册方法
        /// </summary>
        /// <param name="logConfig">日志的配置文件信息</param>
        public static void UseLog4Net(FileInfo logConfig)
        {
            XmlConfigurator.ConfigureAndWatch(logConfig);
        }
    }
}
