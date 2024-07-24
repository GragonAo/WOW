using System;


/// <summary>
/// 描述：IArchitecture 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
namespace GLFramework
{
    public interface IArchitecture
    {
        public void InitAllModules();
        public void RegisterEvent<U>(Action<object> onEvent) where U:new();
        public void UnRegisterEvent<U>(Action<object> onEvent) where U:new();
        public void SendEvent<U>(object dataObj) where U:new();
        public void SendCommand<U>(object dataObj) where U:ICommand,new();
        public void RegisterSystem<U>(U instance) where U:ISystem;
        public void RegisetrModel<U>(U instance)where U:IModel;
        public void RegisterUtility<U>(U instance)where U:IUtility;
        public U GetSystem<U>()where U:class,ISystem;
        public U GetModel<U>()where U:class,IModel;
        public U GetUtility<U>()where U:class,IUtility;
    }
}

