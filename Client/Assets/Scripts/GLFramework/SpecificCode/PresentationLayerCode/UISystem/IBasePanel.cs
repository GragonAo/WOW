using GLFramework;
/// <summary>
/// 描述：IBasePanel 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public interface IBasePanel : IController
{
    public void OnInit();
    public void OnEnter();
    public void OnPause();
    public void OnResume();
    public void OnExit();
    public void OnDestroy();
}
