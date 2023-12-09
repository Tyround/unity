using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public int radius;
    float waitTime = 0f;
    float waitTimeMax = 3f;
    bool grow = false;

    public float damageMax = 30;
    public float damageRadius = 150;
    public float damageRadiusStable = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(grow)
        {
            waitTime += Time.deltaTime;
        }


    }

   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "des")
        {
            grow = true;
            if(waitTime >= waitTimeMax)
            {
                collision.gameObject.GetComponent<DestructibleSprite>().ApplyDamage(collision.contacts[0].point, radius);
                
                //ExplodeDamage()

                Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, damageRadius, 1 << LayerMask.NameToLayer("Player"));
                for (int i = 0; i < collider2Ds.Length; i++)
                {
                    Rigidbody2D rb = collider2Ds[i].GetComponent<Rigidbody2D>();
                    float _radius = Mathf.Sqrt((rb.transform.position.x - transform.position.x) * (rb.transform.position.x - transform.position.x) + (rb.transform.position.y - transform.position.y) * (rb.transform.position.y - transform.position.y));
                    float damage = 0;
                    if (_radius <= damageRadiusStable)
                    {
                        damage = damageMax;
                    }
                    else if (_radius > damageRadiusStable)
                    {
                        damage = damageMax * damageRadiusStable / _radius;
                    }
                    GameObject player = rb.gameObject;
                    player.GetComponent<LifeDamage>().Damage(damage);                   
                }
                Destroy(gameObject);
            }
           
        }
    }
    
}
