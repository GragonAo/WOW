/// <summary>
/// 描述：CanSendCommandExternsion 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public static class CanSendCommandExternsion
    {
        public static void SendCommand<T>(this ICanSendCommand self, object dataObj = null) where T : ICommand, new()
        {
            StartArchitecture.Instance.GetArchitecture().SendCommand<T>(dataObj);
        }
    }
}