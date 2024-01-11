using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    Image healthFill;
    [SerializeField]
    float healthUpdateTime;      //how many seconds it take to lose 1% of health when thirst or saturation is 0
    float timeSinceHealthUpdate;

    void Start()
    {
        healthFill.fillAmount = health / 100;
    }

    void Update()
    {
        updateStats();
    }

    void updateStats()
    {
        timeSinceHealthUpdate += Time.deltaTime;

        if (timeSinceHealthUpdate >= healthUpdateTime)
        {
            timeSinceHealthUpdate = 0;
            changeHealth(1);
        }
    }

    public void changeHealth(float healthChange)
    {
        health += healthChange;
        if (health < 0)
            health = 0;
        else if (health > 100)
            health = 100;


        healthFill.fillAmount = health / 100;
    }

    public void setHealth(float healthChange)
    {
        health = healthChange;

        healthFill.fillAmount = health / 100;
    }

    public float getHealth()
    {
        return health;
    }

}
