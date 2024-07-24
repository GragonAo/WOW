/// <summary>
/// 描述：CanGetLayersExternsion 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public static class CanGetLayersExternsion
    {
        public static T GetSystem<T>(this ICanGetSystem self, T instance) where T : class, ISystem
        {
            return StartArchitecture.Instance.GetArchitecture().GetSystem<T>();
        }
        public static T GetModel<T>(this ICanGetModel self, T instance) where T : class, IModel
        {
            return StartArchitecture.Instance.GetArchitecture().GetModel<T>();
        }
        public static T GetUtility<T>(this ICanGetUtility self, T instance) where T : class, IUtility
        {
            return StartArchitecture.Instance.GetArchitecture().GetUtility<T>();
        }
    }
}