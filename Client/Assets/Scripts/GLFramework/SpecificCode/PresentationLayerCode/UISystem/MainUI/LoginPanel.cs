using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 描述：LoginPanel 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class LoginPanel : BasePanel
{
    private Button btn_Login;
    private Button btn_Regist;
    private Button btn_Exit;
    private InputField if_UserId;
    private InputField if_Password;
    public override void OnInit()
    {
        base.OnInit();
        btn_Login = transform.Find("Btn_Login").GetComponent<Button>();
        btn_Login.onClick.AddListener(OnBtnLoginClick);
        btn_Regist = transform.Find("Btn_Regist").GetComponent<Button>();
        btn_Regist.onClick.AddListener(()=>{OpenPanel<RegisterPanel>();});
        btn_Exit = transform.Find("Btn_Exit").GetComponent<Button>();
        btn_Exit.onClick.AddListener(()=>{Application.Quit();});
        if_UserId = transform.Find("IF_UserID").GetComponent<InputField>();
        if_Password = transform.Find("IF_PassWord").GetComponent<InputField>();
    }
    public override void OnEnter(params object[] objs)
    {
        base.OnEnter();
    }
    private void OnBtnLoginClick(){
        if(if_UserId.text==""){
            OpenPanel<TipPanel>("账号不能为空");
            return;
        }
        if(if_Password.text == "" || if_Password.text.Length<6){
            OpenPanel<TipPanel>("密码长度不能小于6位");
            return;
        }
        OpenPanel<ChoicePanel>();
        ClosePanel<LoginPanel>();
    }
}
