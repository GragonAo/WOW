using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 描述：TipPanel 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class TipPanel : BasePanel
{
    private Text txt_Tip;
    private Text txt_Tip2;
    private Button btn_OK;
    public override void OnInit()
    {
        base.OnInit();
        txt_Tip = transform.Find("Grid_Tip/Text_Tip").GetComponent<Text>();
        txt_Tip2 = transform.Find("Grid_Tip/Text_Tip2").GetComponent<Text>();
        btn_OK = transform.Find("Grid_Tip/Btn_OK").GetComponent<Button>();
        btn_OK.onClick.AddListener(() => { ClosePanel<TipPanel>(); });
    }
    public override void OnEnter(params object[] objs)
    {
        base.OnEnter(objs);
        if (objs.Length > 0)
            txt_Tip.text = (string)objs[0];
        else txt_Tip.text = "";
        if (objs.Length > 1)
            txt_Tip.text = (string)objs[1];
        else txt_Tip2.text = "";
    }
    public override void OnExit()
    {
        base.OnExit();
        txt_Tip.text = "";
        txt_Tip2.text = "";
    }
}
