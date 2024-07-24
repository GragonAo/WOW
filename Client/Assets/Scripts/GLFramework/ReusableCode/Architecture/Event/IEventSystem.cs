using System;


/// <summary>
/// 描述：IEventSystem 脚本 事件系统接口
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public interface IEventSystem
    {
        public void Register<T>(Action<object> onEvent);
        public void UnRegister<T>(Action<object> onEvent);
        public void Send<T>(object obj);
    }
}