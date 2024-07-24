using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 描述：IOCContainer 脚本 IOC容器，保存所有层级以及各个模块的实例
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public class IOCContainer
    {
        private Dictionary<Type, object> m_InstanceDict = new Dictionary<Type, object>();
        public void Register<T>(T instance)
        {
            var key = typeof(T);
            if (m_InstanceDict.ContainsKey(key))
            {
                m_InstanceDict[key] = instance;
            }
            else
            {
                m_InstanceDict.Add(key, instance);
            }
        }

        public T Get<T>() where T : class
        {
            var key = typeof(T);
            if (m_InstanceDict.TryGetValue(key, out object obj))
            {
                return obj as T;
            }
            else
            {
                Debug.Log("想要获取的对象为空");
            }
            return null;
        }
        public void InitAllModules()
        {
            foreach(var item in m_InstanceDict.Values){
                ((INeedInit)item).Init();
            }
        }
    }
}