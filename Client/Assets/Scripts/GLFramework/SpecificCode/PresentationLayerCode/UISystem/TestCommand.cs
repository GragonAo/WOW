
using GLFramework;
using UnityEngine;

/// <summary>
/// 描述：TestCommand 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public struct TestCommand : ICommand

{

    public void Execute(object dataObj)
    {
        Debug.Log((string)dataObj);
    }
}
