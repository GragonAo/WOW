
using GLFramework;

/// <summary>
/// 描述：IUISystem 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public interface IUISystem : ISystem
{
    public void OpenPanel<T>(params object[] objs) where T : BasePanel;
    public void ClosePanel<T>(bool destroy = false) where T : BasePanel;
}
