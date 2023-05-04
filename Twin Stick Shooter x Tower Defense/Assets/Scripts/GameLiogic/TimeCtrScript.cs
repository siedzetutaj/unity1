using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCtrScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    
    public void TimeForward()
    {
        Time.timeScale += 0.1f;
    }
    public void TimeBackward()
    {
        Time.timeScale -= 0.1f;
    }
    private void Update()
    {
        timeText.text = Time.timeScale.ToString();
    }
}
