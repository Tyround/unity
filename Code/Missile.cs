using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 20f;
    public int radius = 30;

    public float damageMax = 30;
    public float damageRadius = 150;
    public float damageRadiusStable = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.right*speed*Time.deltaTime);

        

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "des")
        {
            collision.gameObject.GetComponent<DestructibleSprite>().ApplyDamage(collision.contacts[0].point, radius);

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
