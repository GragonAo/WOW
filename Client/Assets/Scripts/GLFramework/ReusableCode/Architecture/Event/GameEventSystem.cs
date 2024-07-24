using System;
using System.Collections.Generic;

/// <summary>
/// 描述：GameEventSystem 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public class GameEventSystem : IEventSystem
    {
        private Dictionary<Type, IEventRegistror> m_EventRegisterDict = new Dictionary<Type, IEventRegistror>();
        public void Register<T>(Action<object> onEvent)
        {
            var type = typeof(T);
            if (m_EventRegisterDict.TryGetValue(type, out IEventRegistror eventRegistror))
            {
                (eventRegistror as EventRegistraion).OnEvent += onEvent;
            }
            else
            {
                eventRegistror = new EventRegistraion() { OnEvent = onEvent };
                m_EventRegisterDict.Add(type, eventRegistror);
            }
        }

        public void Send<T>(object obj)
        {
            var type = typeof(T);
            if (m_EventRegisterDict.TryGetValue(type, out IEventRegistror eventRegistror))
            {
                (eventRegistror as EventRegistraion).OnEvent.Invoke(obj);
            }
        }

        public void UnRegister<T>(Action<object> onEvent)
        {
            var type = typeof(T);
            if (m_EventRegisterDict.TryGetValue(type, out IEventRegistror eventRegistror))
            {
                (eventRegistror as EventRegistraion).OnEvent -= onEvent;
            }
        }
    }
}