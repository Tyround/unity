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
            //����Ҫд��ɫ����
            Living = false;
        }

        //����Ѫ����
        HealthBar.fillAmount = Life / LifeMax;
        



    }

    public void Damage(float damage)//���˼���Ѫ��
    {
        if (Life > 0)
        {
            Life -= damage;
        }
    }
}
