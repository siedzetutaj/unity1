using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerCheckerScript : MonoBehaviour
{
    public GameObject WhoDisplayed;

    private void OnMouseDown()
    {
        if (WhoDisplayed != null)
        {
            WhoDisplayed.GetComponent<Defenders>().DisabeHud();
        }
    }
}