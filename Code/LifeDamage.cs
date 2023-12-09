using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDamage : MonoBehaviour
{
    public float LifeMax = 100f;
    public float Life = 100f;

    public Image HealthBar;

    public bool Living = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            //这里要写角色死亡
            Living = false;
        }

        //控制血量条
        HealthBar.fillAmount = Life / LifeMax;
        



    }

    public void Damage(float damage)//受伤减少血量
    {
        if (Life > 0)
        {
            Life -= damage;
        }
    }
}
