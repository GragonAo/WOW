using GLFramework;
using UnityEngine;

/// <summary>
/// 描述：GameStarter 脚本 游戏入口实例
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class GameStarter : MonoBehaviour,IController
{
    private StartArchitecture m_StartArchitecture;

    public void Init()
    {
        
    }

    void Start()
    {
        m_StartArchitecture = StartArchitecture.Instance;
        m_StartArchitecture.SetArchitecture(new WowArchitecture());
        m_StartArchitecture.InitAllModulesInArchitecture();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)){
            this.SendEvent<TestEvent>();
        }else if(Input.GetKeyDown(KeyCode.D)){
            this.SendCommand<TestCommand>("这是一条命令");
        } 
    }
}
