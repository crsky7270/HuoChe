using ZhangTuo.IoC;

namespace WiFi.Configuration.BootStarp
{
    /// <summary>
    /// 数据访问层的IOC注册
    /// </summary>
    public static class DataAccessRegister
    {
        /// <summary>
        /// DataAccess的IOC注册方法
        /// </summary>
        /// <param name="locator">注册的对象</param>
        /// <returns>DataAccess注册后的对象</returns>
        public static IRegistration UseDataAccessLayer(this IRegistration locator)
        {

            return locator;
        }
    }
}
