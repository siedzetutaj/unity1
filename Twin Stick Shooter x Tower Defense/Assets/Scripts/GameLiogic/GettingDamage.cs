using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingDamage : MonoBehaviour
{
    public int PlayerLife;

    private void Update()
    {
        if (PlayerLife < 0)
        {
            Debug.Log("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Object.Destroy(other.gameObject);
        PlayerLife -= other.gameObject.GetComponent<Damage>().life;
    }
}
