/// <summary>
/// 描述：StartArchitecture 脚本 启动框架的启动器(框架启动入口)
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>

namespace GLFramework
{
    public class StartArchitecture : Singleton<StartArchitecture>, ISingleton
    {
        private IArchitecture m_GameArchitecture;
        private StartArchitecture() { Init(); }
        public void Init()
        {
            
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            m_GameArchitecture = architecture;
        }
        public IArchitecture GetArchitecture()
        {
            return m_GameArchitecture;
        }
        public void InitAllModulesInArchitecture(){
            m_GameArchitecture.InitAllModules();
        }
    }
}

