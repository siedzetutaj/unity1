using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonScript : MonoBehaviour
{
    public Button ME;
    public int MyPrice;
    public TextMeshProUGUI DisplayPrice;
    void Start()
    {
        ME = this.gameObject.GetComponent<Button>();
        DisplayPrice.text = MyPrice.ToString() + " $";
    }

    public void SendMeTo()
    {
        GetComponentInParent<ButtonUpgrCtr>().AqtuallyPressedButton= ME;
    }
}
