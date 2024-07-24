using System;
using GLFramework;
using UnityEngine;

/// <summary>
/// 描述：UISystem 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class UISystem : IUISystem
{
    public void Init()
    {
        Debug.Log("UI系统已实例化");
        this.RegisterEvent<TestEvent>(testEvent);
    }

    private void testEvent(object obj)
    {
        Debug.Log("事件被调用了");
    }
}
