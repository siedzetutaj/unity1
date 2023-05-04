using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour
{
    public List<GameObject> enemiesCurrnet = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    private string EnemieName;

    private void Start()
    {
        switch (transform.parent.name)
        {
            case "Turret1(Clone)":
                EnemieName = "Enemie1";
                break;
            case "Turret2(Clone)":
                EnemieName = "Enemie2";
                break;

            default:
                break;
        }
    }


    private void Update()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].GetComponent<Damage>().canShoot)
                {
                    GetComponentInParent<Defenders>().hasTarget = true;
                    GetComponentInParent<Defenders>().TargetedEnemie = enemies[i];
                    GetComponentInParent<Defenders>().targeted = enemies[i].transform;

                    break;
                }
            }
            
        }
        else 
        {
            GetComponentInParent<Defenders>().hasTarget = false;
            enemies = enemiesCurrnet;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(EnemieName))
        {
            enemiesCurrnet.Remove(other.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag(EnemieName))
        {
            if (other.GetComponent<Damage>().canShoot)
            {
                enemiesCurrnet.Add(other.gameObject);
            }
        }
    }
}
