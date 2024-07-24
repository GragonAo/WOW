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
        Debug.Log(gameObject.name + " OnInit()");
        gameObject.SetActive(false);
    }

    public virtual void OnDestroy()
    {
        Debug.Log(gameObject.name + " OnDestroy()");
        Destroy(gameObject);
    }

    public virtual void OnEnter()
    {
        Debug.Log(gameObject.name + " OnEnter()");
        gameObject.SetActive(true);
    }

    public virtual void OnExit()
    {
        Debug.Log(gameObject.name + " OnExit()");
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
}
