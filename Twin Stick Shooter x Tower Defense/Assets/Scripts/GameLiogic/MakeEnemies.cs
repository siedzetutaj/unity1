using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public float[] speed = new float[2];
    public int[] enemiesCurrent = new int[2];
    public int[] maxenemie = new int[2];
    public float[] EnemiesSpawnSpeed = new float[2];
    public GameObject BaseToDefend;
    public int[] LifeChanges = new int[2];

    public int money;
    public TextMeshProUGUI DisplayMoney;

    void Start()
    {
        Application.targetFrameRate = 60;
        EnemiesSpawnSpeed[0] = 2.0f;
        LifeChanges[0] = 1;
        enemiesCurrent[0] = 0;
        EnemiesSpawnSpeed[1] = 3.0f;
        LifeChanges[1] = 2;
        enemiesCurrent[1] = 0;
        speed[0] = 100;
        speed[1] = 50;
    }


    void Update()
    {
        if (enemiesCurrent[0] > maxenemie[0])
        {
            CancelInvoke(nameof(MakingEnemies1));
            
        }
        if (enemiesCurrent[1] > maxenemie[1])
        {
            CancelInvoke(nameof(MakingEnemies2));
        }
        if (enemiesCurrent[1] >= maxenemie[1]&& enemiesCurrent[0] >= maxenemie[0])
        {
            BaseToDefend.GetComponent<Leveling>().StartButtonRefresh();
        }
        DisplayMoney.text = money.ToString()+" $";
    }
    void MakingEnemies1()
    {
        GameObject ActiveProjectile1 = Instantiate(enemies[0], transform.position, transform.rotation);
        ActiveProjectile1.transform.parent = gameObject.transform;
        ActiveProjectile1.GetComponent<Damage>().life = LifeChanges[0];
        ActiveProjectile1.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(speed[0], 0, 0));
        enemiesCurrent[0]++;
    }
    void MakingEnemies2()
    {
        GameObject ActiveProjectile2 = Instantiate(enemies[1], transform.position, transform.rotation);
        ActiveProjectile2.transform.parent = gameObject.transform;
        ActiveProjectile2.GetComponent<Damage>().life = LifeChanges[1];
        ActiveProjectile2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(speed[1], 0, 0));
        enemiesCurrent[1]++;
    }
    public void Fire()
    {
        if (enemiesCurrent[0] < maxenemie[0])
        {
            InvokeRepeating(nameof(MakingEnemies1), 0.0f, EnemiesSpawnSpeed[0]);
        }
        if (enemiesCurrent[1] < maxenemie[1])
        {
            InvokeRepeating(nameof(MakingEnemies2), 0.0f, EnemiesSpawnSpeed[1]);
        }
    } 
}
