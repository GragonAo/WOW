using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 描述：GameResSystem 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public static class GameResSystem
{
    private static Dictionary<string,Object> m_ResDict = new Dictionary<string, Object>();

    public static T GetRes<T>(string resPath) where T:Object{
        if(m_ResDict.TryGetValue(resPath,out Object res)){
            return res as T;
        }else{
            res = Resources.Load(resPath);
            m_ResDict.Add(resPath,res);
            return res as T;
        }
    }
}
