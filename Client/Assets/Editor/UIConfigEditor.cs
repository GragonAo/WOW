using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class UIConfigEditor : EditorWindow
{
    private string uiName;
    private string uiPath;
    private UILayerType uiLayer;

    private List<UIPanelInfo> uiPanelInfos = new List<UIPanelInfo>();
    private int selectedPanelIndex = -1;

    [MenuItem("Tools/UI Config Editor")]
    public static void ShowWindow()
    {
        UIConfigEditor window = GetWindow<UIConfigEditor>("UI Config Editor");
        window.LoadUIPanelConfigs();
    }

    private void OnGUI()
    {
        GUILayout.Label("Configure UI Panel", EditorStyles.boldLabel);

        uiName = EditorGUILayout.TextField("UI Name", uiName);
        uiPath = EditorGUILayout.TextField("UI Path", uiPath);
        uiLayer = (UILayerType)EditorGUILayout.EnumPopup("UI Layer", uiLayer);

        if (GUILayout.Button("Add UI Panel"))
        {
            AddUIPanel();
        }

        GUILayout.Space(20);
        GUILayout.Label("UI Panel Configurations", EditorStyles.boldLabel);

        for (int i = 0; i < uiPanelInfos.Count; i++)
        {
            var panelInfo = uiPanelInfos[i];
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Select", GUILayout.Width(60)))
            {
                SelectUIPanel(i);
            }
            GUILayout.Label($"Name: {panelInfo.UIName}, Path: {panelInfo.UIPath}, Layer: {panelInfo.UILayer}");
            if (GUILayout.Button("Remove", GUILayout.Width(60)))
            {
                RemoveUIPanel(panelInfo);
                break;
            }
            GUILayout.EndHorizontal();
        }

        if (selectedPanelIndex >= 0 && selectedPanelIndex < uiPanelInfos.Count)
        {
            GUILayout.Space(20);
            GUILayout.Label("Edit Selected UI Panel", EditorStyles.boldLabel);

            var selectedPanel = uiPanelInfos[selectedPanelIndex];
            selectedPanel.UIName = EditorGUILayout.TextField("UI Name", selectedPanel.UIName);
            selectedPanel.UIPath = EditorGUILayout.TextField("UI Path", selectedPanel.UIPath);
            selectedPanel.UILayer = (UILayerType)EditorGUILayout.EnumPopup("UI Layer", selectedPanel.UILayer);
        }

        if (GUILayout.Button("Save Configurations"))
        {
            SaveUIPanelConfigs();
        }
    }

    private void AddUIPanel()
    {
        UIPanelInfo panelInfo = new UIPanelInfo
        {
            UIName = uiName,
            UIPath = uiPath,
            UILayer = uiLayer
        };

        uiPanelInfos.Add(panelInfo);
        ClearInputFields();
    }

    private void RemoveUIPanel(UIPanelInfo panelInfo)
    {
        uiPanelInfos.Remove(panelInfo);
        string path = Path.Combine(Application.dataPath, "UIConfig", panelInfo.UIName + ".json");
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"UI Panel '{panelInfo.UIName}' config removed from '{path}'.");
        }
        selectedPanelIndex = -1;
    }

    private void ClearInputFields()
    {
        uiName = "";
        uiPath = "";
        uiLayer = UILayerType.Main;
    }

    private void SaveUIPanelConfigs()
    {
        foreach (var panelInfo in uiPanelInfos)
        {
            string json = JsonUtility.ToJson(panelInfo, true);
            string path = Path.Combine(Application.dataPath, "UIConfig", panelInfo.UIName + ".json");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, json);
            Debug.Log($"UI Panel '{panelInfo.UIName}' config saved at '{path}' with layer '{panelInfo.UILayer}'.");
        }
    }

    private void LoadUIPanelConfigs()
    {
        uiPanelInfos.Clear();
        string configDirectory = Path.Combine(Application.dataPath, "UIConfig");
        if (Directory.Exists(configDirectory))
        {
            string[] files = Directory.GetFiles(configDirectory, "*.json");
            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                UIPanelInfo panelInfo = JsonUtility.FromJson<UIPanelInfo>(json);
                uiPanelInfos.Add(panelInfo);
            }

            Debug.Log("Loaded UI panel configs into editor.");
        }
        else
        {
            Debug.LogWarning("UIConfig directory not found.");
        }
    }

    private void SelectUIPanel(int index)
    {
        selectedPanelIndex = index;
        var panelInfo = uiPanelInfos[index];
        uiName = panelInfo.UIName;
        uiPath = panelInfo.UIPath;
        uiLayer = panelInfo.UILayer;
    }
}

[System.Serializable]
public class UIPanelInfo
{
    public string UIName;
    public string UIPath;
    public UILayerType UILayer;
}
