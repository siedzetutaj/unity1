using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leveling : MonoBehaviour
{
    public GameObject EnemieMaker;
    public bool PouseBtwWaves = false;
    private int WavesCounter = 0;
    public Button AqtuallyPressedButton;
    public TextMeshProUGUI Wave;
    void Start()
    {
        EnemieMaker.GetComponent<MakeEnemies>().BaseToDefend = this.gameObject;
    }

    private void Update()
    {
        if (PouseBtwWaves)
        {
            WavesCounter++;
            Enemie1();
            Enemie2();
            EnemieMaker.GetComponent<MakeEnemies>().enemiesCurrent[0] = 0;
            EnemieMaker.GetComponent<MakeEnemies>().Fire();
            PouseBtwWaves = false;
            Wave.text = WavesCounter.ToString();
            AqtuallyPressedButton.interactable = false;
        }
    }
    void Enemie1()
    {   //enemies speed and life
        if (WavesCounter % 5 == 0 && EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[0] < 4)
        {
            EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[0]++;
            EnemieMaker.GetComponent<MakeEnemies>().speed[0] = 70;
            EnemieMaker.GetComponent<MakeEnemies>().maxenemie[0] /= 3;
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[0] = 2.0f;

        }
        else if (EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[0] == 4)
        {
            EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[0] = 4;
            EnemieMaker.GetComponent<MakeEnemies>().speed[0] += 10;
        }
        else if (EnemieMaker.GetComponent<MakeEnemies>().speed[0] >= 150)
        {
            EnemieMaker.GetComponent<MakeEnemies>().speed[0] = 150;
        }
        else
        {
            EnemieMaker.GetComponent<MakeEnemies>().speed[0] += 5;
        }
        //enemies frequency
        if (EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[0] > 0.7f)
        {
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[0] -= 0.3f;
        }
        else
        {
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[0] = 0.7f;
        }
        //enemies numbers
        if (EnemieMaker.GetComponent<MakeEnemies>().maxenemie[0] >= 60)
        {
            EnemieMaker.GetComponent<MakeEnemies>().maxenemie[0] = 60;
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[0] = 0.3f;
        }
        else
        {
            EnemieMaker.GetComponent<MakeEnemies>().maxenemie[0] += 7 * WavesCounter/2 ;
        }
    }
    void Enemie2()
    {

        //enemies speed and life
        if (WavesCounter % 10 == 0 && EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[1] < 6)
        {
            EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[1]+=2;
            EnemieMaker.GetComponent<MakeEnemies>().speed[1] = 50;
            EnemieMaker.GetComponent<MakeEnemies>().maxenemie[1] /= 3;
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[1] = 2.3f;

        }
        else if (EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[1] >= 6)
        {
            EnemieMaker.GetComponent<MakeEnemies>().LifeChanges[1] = 6;
            EnemieMaker.GetComponent<MakeEnemies>().speed[1] += 10;
        }
        else if (EnemieMaker.GetComponent<MakeEnemies>().speed[1] >= 100)
        {
            EnemieMaker.GetComponent<MakeEnemies>().speed[1] = 100;
        }
        else if(WavesCounter >= 5)
        {
            EnemieMaker.GetComponent<MakeEnemies>().speed[1] += 5;
        }
        //enemies frequency
        if (EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[1] > 1f)
        {
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[1] -= 0.1f;
        }
        else
        {
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[1] = 1f;
        }
        //enemies numbers
        if (EnemieMaker.GetComponent<MakeEnemies>().maxenemie[1] >= 40)
        {
            EnemieMaker.GetComponent<MakeEnemies>().maxenemie[1] = 40;
            EnemieMaker.GetComponent<MakeEnemies>().EnemiesSpawnSpeed[1] = 0.3f;
        }
        else if(WavesCounter >= 5)
        {
            EnemieMaker.GetComponent<MakeEnemies>().maxenemie[1] += 2 * WavesCounter ;
        }
    }
    public void StartButton()
    {
        PouseBtwWaves = true;
        AqtuallyPressedButton.interactable = false;
    }
    public void StartButtonRefresh()
    {
        AqtuallyPressedButton.interactable = true;
    }
}
