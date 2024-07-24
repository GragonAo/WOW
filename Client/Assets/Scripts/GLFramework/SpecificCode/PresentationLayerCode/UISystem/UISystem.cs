using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 描述：UISystem 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class UISystem : IUISystem
{
    private Dictionary<string, IBasePanel> m_PanelDict = new Dictionary<string, IBasePanel>();
    private Stack<IBasePanel> m_PanelStack = new Stack<IBasePanel>();
    private Dictionary<UILayerType, Transform> m_LayerTransforms = new Dictionary<UILayerType, Transform>();
    private Transform m_CanvasTrans;

    public void Init()
    {
        Debug.Log("UI系统已实例化");
        InitCanvas();
        OpenPanel<LoginPanel>();
    }

    public void OpenPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (!m_PanelDict.TryGetValue(panelName, out IBasePanel panel))
        {
            UIPanelInfo panelInfo = GetUIPanelInfo(panelName);
            if (panelInfo == null)
            {
                Debug.LogError($"UIPanelInfo for {panelName} 加载失败");
                return;
            }
            GameObject panelPrefab = GameResSystem.GetRes<GameObject>(panelInfo.UIPath + "/" + panelInfo.UIName);
            if (panelPrefab != null)
            {
                GameObject panelInstance = GameObject.Instantiate(panelPrefab);
                panelInstance.name = panelInfo.UIName;
                panelInstance.transform.SetParent(GetParentTransform((UILayerType)panelInfo.UILayer), false);

                T panelComponent = panelInstance.AddComponent<T>();
                panelComponent.LayerType = (UILayerType)panelInfo.UILayer;
                m_PanelDict.Add(panelName, panelComponent);
                panelComponent.OnInit();
                panel = panelComponent;
            }
            else
            {
                Debug.LogError($"panelPrefab 实例化失败 for {panelInfo.UIName} at {panelInfo.UIPath}/{panelInfo.UIName}");
                return;
            }
        }
        else
        {
            Debug.Log($"Panel {panelName} 已经存在于字典中");
        }

        if (((BasePanel)panel).LayerType == UILayerType.Interaction)
        {
            if (m_PanelStack.Count > 0)
                m_PanelStack.Peek().OnPause();
            m_PanelStack.Push(panel);
        }
        panel.OnEnter();
    }


    public void ClosePanel<T>() where T : BasePanel
    {
        Debug.Log("关闭UI :" + typeof(T).ToString());
        if (m_PanelStack.Count > 0)
        {
            m_PanelStack.Pop().OnExit();
            if (m_PanelStack.Count > 0)
            {
                m_PanelStack.Peek().OnResume();
            }
        }
    }
    private UIPanelInfo GetUIPanelInfo(string panelName)
    {
        UIPanelInfo panelInfo = null;
        string jsonFilePath = Path.Combine(Application.dataPath, "UIConfig", panelName + ".json");
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            panelInfo = JsonUtility.FromJson<UIPanelInfo>(json);
        }
        return panelInfo;
    }
    private void InitCanvas()
    {
        // 创建Canvas
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();
        m_CanvasTrans = canvasGO.transform;

        // 创建Event System
        GameObject eventSystemGO = new GameObject("Event System");
        eventSystemGO.AddComponent<UnityEngine.EventSystems.EventSystem>();
        eventSystemGO.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();

        // 创建面板层级
        m_LayerTransforms[UILayerType.Main] = CreatePanel("MainPanel", UILayerType.Main);
        m_LayerTransforms[UILayerType.Normal] = CreatePanel("NormalPanel", UILayerType.Normal);
        m_LayerTransforms[UILayerType.Interaction] = CreatePanel("InteractionPanel", UILayerType.Interaction);
        m_LayerTransforms[UILayerType.Tip] = CreatePanel("TipPanel", UILayerType.Tip);
    }

    private Transform CreatePanel(string panelName, UILayerType layer)
    {
        GameObject panelGO = new GameObject(panelName);
        RectTransform rectTransform = panelGO.AddComponent<RectTransform>();
        rectTransform.SetParent(m_CanvasTrans);
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.sizeDelta = Vector2.zero;
        rectTransform.anchoredPosition = Vector2.zero;

        switch (layer)
        {
            case UILayerType.Main:
                panelGO.transform.SetSiblingIndex(0);  // MainPanel 层级最低
                break;
            case UILayerType.Normal:
                panelGO.transform.SetSiblingIndex(1);  // NormalPanel 层级中间
                break;
            case UILayerType.Interaction:
                panelGO.transform.SetSiblingIndex(2);  // InteractionPanel 层级中间
                break;
            case UILayerType.Tip:
                panelGO.transform.SetSiblingIndex(3);  // TipPanel 层级最高
                break;
        }
        return panelGO.transform;
    }
    private Transform GetParentTransform(UILayerType layer)
    {
        if (m_LayerTransforms.TryGetValue(layer, out Transform parentTransform))
        {
            return parentTransform;
        }
        return m_CanvasTrans;
    }
}
[System.Serializable]
public class UIPanelInfo
{
    public string UIName;
    public string UIPath;
    public int UILayer;
}
