using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float saturation;
    [SerializeField]
    float thirst;
    [SerializeField]
    float health;
    [SerializeField]
    Image saturationFill;
    [SerializeField]
    Image thirstFill;
    [SerializeField]
    Image healthFill;
    [SerializeField]
    float decreaseTime;     //how many seconds it take to lose 1% of thirst and saturation
    [SerializeField]
    float healthUpdateTime;      //how many seconds it take to lose 1% of health when thirst or saturation is 0
    float timeSinceUpdate;
    float timeSinceHealthUpdate;

    void Start()
    {
        saturationFill.fillAmount = saturation / 100;
        thirstFill.fillAmount = thirst / 100;
        healthFill.fillAmount = health / 100;
    }

    void Update()
    {
        updateStats();
    }

    void updateStats()
    {
        timeSinceUpdate += Time.deltaTime;

        if (timeSinceUpdate >= decreaseTime)
        {
            timeSinceUpdate = 0;
            changeSaturation(-1);
            changeThirst(-1);
        }

        timeSinceHealthUpdate += Time.deltaTime;

        if (timeSinceHealthUpdate >= healthUpdateTime)
        {
            timeSinceHealthUpdate = 0;
            if (saturation == 0 || thirst == 0)
                changeHealth(-1);
            else
                changeHealth(1);
        }
    }

    public void changeSaturation(float saturationChange)
    {
        saturation += saturationChange;
        if (saturation < 0)
            saturation = 0;
        else if (saturation > 100)
            saturation = 100;

        saturationFill.fillAmount = saturation / 100;
    }
    public void changeThirst(float thirstChange)
    {
        thirst += thirstChange;
        if (thirst < 0)
            thirst = 0;
        else if (thirst > 100)
            thirst = 100;

        thirstFill.fillAmount = thirst / 100;
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

    public void setSaturation(float saturationChange)
    {
        saturation = saturationChange;

        saturationFill.fillAmount = saturation / 100;
    }
    public void setThirst(float thirstChange)
    {
        thirst = thirstChange;

        thirstFill.fillAmount = thirst / 100;
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

    public float getSaturation()
    {
        return saturation;
    }

    public float getThirst()
    {
        return thirst;
    }

    public void loadData(float saturation, float thirst, float health)
    {
        this.saturation = saturation;
        this.thirst = thirst;
        this.health = health;

        saturationFill.fillAmount = saturation / 100;
        thirstFill.fillAmount = thirst / 100;
        healthFill.fillAmount = health / 100;
    }
}
