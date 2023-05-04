using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Transform target;
    public int DamageDealed;
    public GameObject TargetGameObj;
    private string EnemieName;
    private void Start()
    {
        
        switch (this.gameObject.name)
        {
            case "Projectile1(Clone)":
                EnemieName = "Enemie1";
                break;
            case "Projectile2(Clone)":
                EnemieName = "Enemie2";
                break;

            default:
                break;
        }
    }


    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        else
        {
            Destruction();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(EnemieName))
        {
            Destruction();
            other.GetComponent<Damage>().life -= DamageDealed;
        }
    }
    void Destruction()
    {
        Destroy(gameObject); 
        if (TargetGameObj !=null)
        {
            TargetGameObj.GetComponent<Damage>().BeingTargeted -= DamageDealed;
        }
        
    }
}
