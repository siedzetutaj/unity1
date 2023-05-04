using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    [SerializeField]
    private GameObject Turret1;
    [SerializeField]
    private GameObject Turret2;
    [SerializeField]
    private GameObject ShopTurret1;
    [SerializeField]
    private GameObject ShopTurret2;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject ShopKeeper;
    private void Start()
    {
        cam = Camera.main;
    }
    public void CreatingTurret1()
    {
        if (ShopKeeper.GetComponent<MakeEnemies>().money>= ShopTurret1.GetComponent<ShopButtonScript>().CurrentPrice)
        {
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            GameObject Turret = Instantiate(Turret1, mouseWorldPos, Quaternion.identity);
            Turret.GetComponent<Defenders>().DragState = true;
            
            ShopKeeper.GetComponent<MakeEnemies>().money -= ShopTurret1.GetComponent<ShopButtonScript>().CurrentPrice;
            ShopTurret1.GetComponent<ShopButtonScript>().CurrentPrice += 3;
        }
    }
    public void CreatingTurret2()
    {
        if (ShopKeeper.GetComponent<MakeEnemies>().money >= ShopTurret2.GetComponent<ShopButtonScript>().CurrentPrice)
        {
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            GameObject Turret = Instantiate(Turret2, mouseWorldPos, Quaternion.identity);
            Turret.GetComponent<Defenders>().DragState = true;
            
            ShopKeeper.GetComponent<MakeEnemies>().money -= ShopTurret2.GetComponent<ShopButtonScript>().CurrentPrice;
            ShopTurret2.GetComponent<ShopButtonScript>().CurrentPrice += 5;
        }
    }
}
