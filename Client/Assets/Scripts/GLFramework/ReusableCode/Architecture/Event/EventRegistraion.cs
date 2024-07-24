using System;

/// <summary>
/// 描述：EventRegistraion 脚本 事件
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public class EventRegistraion : IEventRegistror
    {
        public Action<object> OnEvent = obj => { };
    }
}