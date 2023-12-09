using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public Weapons CurrentWeapon;

    public GameObject grenade;
    public GameObject rocket;
    public GameObject missile;


    public bool usingWeapon;

    public float powerAngle;
    public GameObject AimImage;
    public GameObject powerObj;
    public GameObject referObj;

    bool mouseDowning = false;
    public float weaponForce;
    public float weaponMaxForce = 150;
    public Image powerImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckWeaponDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CheckWeaponUp();
        }
        if(usingWeapon)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            powerAngle = Mathf.Atan2(mousePos.y - transform.position.y,mousePos.x - transform.position.x)*Mathf.Rad2Deg;
            AimImage.transform.rotation = Quaternion.Euler(0, 0, powerAngle);
            powerObj.transform.rotation = Quaternion.Euler(0, 0, powerAngle);
        }

        if(mouseDowning) 
        {
            weaponForce += 200 * Time.deltaTime;
            if(weaponForce >= weaponMaxForce) 
            {
                weaponForce = weaponMaxForce;
            }
            powerImage.fillAmount = weaponForce/weaponMaxForce;
        }
    }

    public void CheckWeaponDown()
    {
        switch (CurrentWeapon)
        {
            case Weapons.Grenade:

                break;
            case Weapons.Rocket: 
                
                break;
            case Weapons.Missile:

                break;
        }
        mouseDowning = true;
        AimImage.SetActive(false);
    }
    public void CheckWeaponUp()
    {
        mouseDowning = false;
        powerImage.fillAmount = 0;
        
        AimImage.SetActive(true);
        
        switch (CurrentWeapon)
        {
            case Weapons.Grenade:
                Vector2 mousePosG = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dirG = (mousePosG - new Vector2(transform.position.x, transform.position.y)).normalized;
                GameObject _grenade = Instantiate(grenade, referObj.transform.position, Quaternion.identity, null);
                _grenade.GetComponent<Rigidbody2D>().AddForce(dirG * weaponForce);
                weaponForce = 0;
                //Instantiate(grenade,this.transform.position,Quaternion.identity,null);
                break;
            case Weapons.Rocket:
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = (mousePos - new Vector2(transform.position.x,transform.position.y)).normalized;
                GameObject _rocket = Instantiate(rocket, referObj.transform.position, Quaternion.identity, null);
                _rocket.GetComponent<Rigidbody2D>().AddForce(dir* weaponForce);
                weaponForce = 0;
                break;
            case Weapons.Missile:
                Vector2 mousePosM = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dirM = (mousePosM - new Vector2(transform.position.x, transform.position.y)).normalized;
                GameObject _missile = Instantiate(missile, referObj.transform.position, Quaternion.identity, null);
                _missile.GetComponent<Rigidbody2D>().AddForce(dirM * weaponForce);
                weaponForce = 0;

                if(transform.localScale.x > 0)
                {

                }
                else
                {

                }
                //GameObject _missile = Instantiate(missile, transform.position, Quaternion.identity, null);
                break;
        }
        
    }
}

public enum Weapons
{
    Grenade,
    Rocket,
    Missile
}