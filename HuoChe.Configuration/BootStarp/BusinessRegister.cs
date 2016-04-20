using ZhangTuo.IoC;

namespace WiFi.Configuration.BootStarp
{
    /// <summary>
    /// Business的IOC注册
    /// </summary>
    public static class BusinessRegister
    {
        /// <summary>
        /// Business的IOC注册方法
        /// </summary>
        /// <param name="locator">注册的对象</param>
        /// <returns>Business注册后的对象</returns>
        public static IRegistration UseBusinessLayer(this IRegistration locator)
        {
            return locator;
        }
    }
}
