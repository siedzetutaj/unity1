using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrCtr : MonoBehaviour
{
    public Button AqtuallyPressedButton;
    public GameObject MyPersonalDefender;
    private int Money;
    public GameObject MoneyKeeper;
    private void Update()
    {
        Money = MoneyKeeper.GetComponent<MakeEnemies>().money;
    }
    public void RangeUpgrade()
    {
        if (Money >= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice)
        {
            AqtuallyPressedButton.interactable = false;
            MyPersonalDefender.GetComponent<Defenders>().Range.transform.localScale += new Vector3(1, 1, 1);
            MoneyKeeper.GetComponent<MakeEnemies>().money -= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice;
            AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().DisplayPrice.gameObject.SetActive(false);
        }


    }
    public void FireRate1()
    {
        if (Money >= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice)
        {
            AqtuallyPressedButton.interactable = false;
            MyPersonalDefender.GetComponent<Defenders>().ShootFrequency -= 0.5f;
            MoneyKeeper.GetComponent<MakeEnemies>().money -= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice;
            AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().DisplayPrice.gameObject.SetActive(false);

        }
    }
    public void FireRate2()
    {
        if (Money >= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice)
        {
            AqtuallyPressedButton.interactable = false;
            MyPersonalDefender.GetComponent<Defenders>().ShootFrequency -= 0.5f;
            MoneyKeeper.GetComponent<MakeEnemies>().money -= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice;
            AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().DisplayPrice.gameObject.SetActive(false);

        }
    }
    public void Damage1()
    {
        if (Money >= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice)
        {
            AqtuallyPressedButton.interactable = false;
            MyPersonalDefender.GetComponent<Defenders>().DamegeIncrease++;
            MoneyKeeper.GetComponent<MakeEnemies>().money -= AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().MyPrice;
            AqtuallyPressedButton.GetComponent<UpgradeButtonScript>().DisplayPrice.gameObject.SetActive(false);

        }
    }
}
