using GLFramework;
/// <summary>
/// 描述：WowArchitecture 脚本 Wow游戏架构
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class WowArchitecture : Architecture<WowArchitecture>
{
    protected override void Init()
    {
        this.RegisterSystem<IUISystem>(new UISystem());
    }
}
