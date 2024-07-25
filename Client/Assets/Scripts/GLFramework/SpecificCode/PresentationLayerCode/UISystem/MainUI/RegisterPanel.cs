using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 描述：RegisterPanel 脚本
/// 作者：Gragon
/// 邮箱：1526532001@qq.com
/// </summary>
public class RegisterPanel : BasePanel
{
    private InputField if_UserID;
    private InputField if_Password;
    private InputField if_ReInputPassword;
    private Button btn_Cancel;
    private Button btn_Regist;
    public override void OnInit()
    {
        base.OnInit();
        if_UserID = transform.Find("Grid_Tip/IF_UserID").GetComponent<InputField>();
        if_Password = transform.Find("Grid_Tip/IF_Password").GetComponent<InputField>();
        if_ReInputPassword = transform.Find("Grid_Tip/IF_ReInputPassword").GetComponent<InputField>();
        btn_Cancel = transform.Find("Grid_Tip/Btn_Cancel").GetComponent<Button>();
        btn_Cancel.onClick.AddListener(()=>{ClosePanel<RegisterPanel>();});
        btn_Regist = transform.Find("Grid_Tip/Btn_Regist").GetComponent<Button>();
        btn_Regist.onClick.AddListener(OnBtnRegistClick);
    }

    private void OnBtnRegistClick(){
        if(if_UserID.text == ""){
            OpenPanel<TipPanel>("用户名不能为空");
            return;
        }
        if(if_Password.text.Length < 6){
            OpenPanel<TipPanel>("密码长度不能低于6位");
            return;
        }
        if(!if_Password.text.Equals( if_ReInputPassword.text)){
            OpenPanel<TipPanel>("两次密码输入不一致");
            return;
        }

        //TODO 发送网络验证

        ClosePanel<RegisterPanel>();
        OpenPanel<TipPanel>("注册成功");
    }
}
