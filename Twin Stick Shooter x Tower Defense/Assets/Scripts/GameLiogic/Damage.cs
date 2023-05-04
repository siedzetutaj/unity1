using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int income;
    public int life;
    public int BeingTargeted;
    public int maxTargets;
    public bool canShoot = true;
    public bool red;

    private void Start()
    {
        income = life;
    }

    void FixedUpdate()
    {
        maxTargets = life;
        if (life <= 0)
        {

            Destroy(gameObject); if (red)
            {
                GetComponentInParent<MakeEnemies>().money += income*2;

            }
            else
            {
                GetComponentInParent<MakeEnemies>().money += income;

            }
        }
        if (BeingTargeted >= maxTargets)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
    }
}
