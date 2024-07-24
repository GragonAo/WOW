/// <summary>
/// 描述：IController 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{

    public interface IController:INeedInit,ICanGetSystem,ICanRegisterAndUnRegisterEvent,ICanSendEvent,ICanSendCommand
    {

    }
}