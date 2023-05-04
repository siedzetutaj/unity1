using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    private float timeBtwShots;
    public float ShootFrequency;
    public GameObject projectile;

    public bool hasTarget=false;
    public Transform targeted;
    public GameObject TargetedEnemie;

    private Camera cam;
    public bool DragState=false;

    public GameObject Range;
    private bool RangeVisibility=false;
    private Color RangeColor = new Color(1f, 1f, 1f, 0.28f);
    private Color RangeBlank = new Color(1f, 1f, 1f, 0.0f);
    private SpriteRenderer RangeRenderer;

    public GameObject ClikckChck;
    public bool IfDisplayHud=false;
    public GameObject UpgradeHud;
    private GameObject myupgradeHud;
    public int DamegeIncrease = 1;
    public GameObject EnemieMaker;

    void Start()
    {
        EnemieMaker = GameObject.FindGameObjectWithTag("Attacker");
        ClikckChck = GameObject.Find("ClickedChecker");
        timeBtwShots = 0;
        cam = Camera.main;
        Range = transform.GetChild(0).gameObject;
        RangeRenderer = Range.gameObject.GetComponent<SpriteRenderer>();
        myupgradeHud = Instantiate(UpgradeHud);
        myupgradeHud.transform.SetParent(this.transform);
        myupgradeHud.gameObject.SetActive(false);
        myupgradeHud.GetComponentInChildren<ButtonUpgrCtr>().MyPersonalDefender = this.gameObject;
        myupgradeHud.GetComponentInChildren<ButtonUpgrCtr>().MoneyKeeper = EnemieMaker;

    }

  
    void Update()
    {
        if (DragState)
        {
            if (!RangeVisibility)
            {
                RangeRenderer.color = RangeColor;
                RangeVisibility = true;
            }
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
            if (Input.GetMouseButtonDown(0))
            {
                DragState = false;
                RangeRenderer.color = RangeBlank;
                RangeVisibility = false;
                myupgradeHud.gameObject.SetActive(false);
            }
        }
        else
        {
            if (TargetedEnemie != null)
            {
                if (timeBtwShots <= 0 && hasTarget && TargetedEnemie.GetComponent<Damage>().canShoot)
                {
                    Shooting();

                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
            
        }

        
    }
    private void OnMouseDown()
    {
        if (ClikckChck.GetComponent<ClickerCheckerScript>().WhoDisplayed != null)
        {
            ClikckChck.GetComponent<ClickerCheckerScript>().WhoDisplayed.GetComponent<Defenders>().DisabeHud();

        }



        if (!RangeVisibility)
        {
            RangeRenderer.color = RangeColor;
            RangeVisibility = true;
        }
        if (!IfDisplayHud)
        {
            myupgradeHud.gameObject.SetActive(true);
            IfDisplayHud = true;
        }
        ClikckChck.GetComponent<ClickerCheckerScript>().WhoDisplayed = this.gameObject;
    }
    public void DisabeHud()
    {
        RangeRenderer.color = RangeBlank;
        myupgradeHud.gameObject.SetActive(false);
        IfDisplayHud = false;
        RangeVisibility = false;
    }
    public void Shooting()
    {
        
        GameObject activeProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        activeProjectile.transform.parent = gameObject.transform;
        activeProjectile.GetComponent<Projectile>().TargetGameObj = TargetedEnemie;
        activeProjectile.GetComponent<Projectile>().target = targeted;
        activeProjectile.GetComponent<Projectile>().DamageDealed = DamegeIncrease;
        timeBtwShots = ShootFrequency;
        TargetedEnemie.GetComponent<Damage>().BeingTargeted+= DamegeIncrease;
        
        
    }
}
