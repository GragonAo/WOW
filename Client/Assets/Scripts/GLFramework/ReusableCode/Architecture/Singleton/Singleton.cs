using System;
using System.Reflection;
/// <summary>
/// 描述：Singleton 脚本 单例模版
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public class Singleton<T> where T : class, ISingleton
    {
        private static T mInstance;
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null) throw new Exception("No non-public constructor found" + typeof(T));
                    mInstance = ctor.Invoke(null) as T;
                }
                return mInstance;
            }
        }
    }
}

