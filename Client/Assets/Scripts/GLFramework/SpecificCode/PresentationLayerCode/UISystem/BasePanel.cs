using GLFramework;
using UnityEngine;

/// <summary>
/// 描述：BasePanel 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
/// 
public enum UILayerType
{
    Main,
    Normal,
    Interaction,
    Tip,
}
public abstract class BasePanel : MonoBehaviour, IBasePanel
{
    protected IUISystem m_UISystem;
    protected UILayerType m_LayerType = UILayerType.Normal;
    public UILayerType LayerType { get => m_LayerType; set=>m_LayerType = value;}
    public virtual void OnInit()
    {
        m_UISystem = this.GetSystem<IUISystem>();
        gameObject.SetActive(false);
    }

    public virtual void OnDestroy()
    {
        Destroy(gameObject);
    }

    public virtual void OnEnter(params object[] objs)
    {
        gameObject.SetActive(true);
    }

    public virtual void OnExit()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnPause()
    {
        Debug.Log(gameObject.name + " OnPause()");
    }

    public virtual void OnResume()
    {
        Debug.Log(gameObject.name + " OnResume()");
    }
    protected void OpenPanel<T>(params object[] objs)where T:BasePanel{
        m_UISystem.OpenPanel<T>(objs);
    }
    protected void ClosePanel<T>(bool destroy= false)where T:BasePanel{
        m_UISystem.ClosePanel<T>(destroy);
    }
}
