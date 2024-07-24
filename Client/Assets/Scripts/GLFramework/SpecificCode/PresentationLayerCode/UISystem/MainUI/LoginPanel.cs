using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 描述：LoginPanel 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class LoginPanel : BasePanel
{
    public override void OnEnter()
    {
        base.OnEnter();
        m_UISystem.OpenPanel<ChoicePanel>();
    }
}
