using System;


/// <summary>
/// 描述：EventExternsion 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public static class EventExternsion
    {
        public static void SendEvent<T>(this ICanSendEvent self, object dataObj = null) where T : new()
        {
            StartArchitecture.Instance.GetArchitecture().SendEvent<T>(dataObj);
        }
        public static void RegisterEvent<T>(this ICanRegisterAndUnRegisterEvent self, Action<object> onEvent) where T : new()
        {
            StartArchitecture.Instance.GetArchitecture().RegisterEvent<T>(onEvent);
        }
        public static void UnRegisterEvent<T>(this ICanRegisterAndUnRegisterEvent self, Action<object> onEvent) where T : new()
        {
            StartArchitecture.Instance.GetArchitecture().UnRegisterEvent<T>(onEvent);
        }
    }
}