using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButtonScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI MyPrice;
    public int CurrentPrice;


    void Update()
    {
        MyPrice.text = CurrentPrice.ToString() + " $";
    }
}
