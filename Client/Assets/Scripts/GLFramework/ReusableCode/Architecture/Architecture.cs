using System;

/// <summary>
/// 描述：Architecture 脚本 架构抽象基类
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public abstract class Architecture<T> : IArchitecture where T : new()
    {
        private IOCContainer m_IOCContainer = new IOCContainer();
        private GameEventSystem m_GameEventSystem = new GameEventSystem();
        public Architecture() { Init(); }

        public void InitAllModules()
        {
            m_IOCContainer.InitAllModules();
        }

        public void RegisetrModel<U>(U instance) where U : IModel
        {
            m_IOCContainer.Register<U>(instance);
        }

        public void RegisterController<U>(U instance) where U : IController
        {
            m_IOCContainer.Register<U>(instance);
        }

        public void RegisterEvent<U>(Action<object> onEvent) where U : new()
        {
            m_GameEventSystem.Register<U>(onEvent);
        }

        public void RegisterSystem<U>(U instance) where U : ISystem
        {
            m_IOCContainer.Register<U>(instance);
        }

        public void RegisterUtility<U>(U instance) where U : IUtility
        {
            m_IOCContainer.Register<U>(instance);
        }

        public void SendCommand<U>(object dataObj) where U : ICommand, new()
        {
            var command = new U();
            command.Execute(dataObj);
        }

        public void SendEvent<U>(object dataObj) where U : new()
        {
            m_GameEventSystem.Send<U>(dataObj);
        }

        public void UnRegisterEvent<U>(Action<object> onEvent) where U : new()
        {
            m_GameEventSystem.UnRegister<U>(onEvent);
        }

        protected abstract void Init();

        U IArchitecture.GetController<U>()
        {
            return m_IOCContainer.Get<U>();
        }

        U IArchitecture.GetModel<U>()
        {
            return m_IOCContainer.Get<U>();
        }

        U IArchitecture.GetSystem<U>()
        {
            return m_IOCContainer.Get<U>();
        }

        U IArchitecture.GetUtility<U>()
        {
            return m_IOCContainer.Get<U>();
        }
    }
}

