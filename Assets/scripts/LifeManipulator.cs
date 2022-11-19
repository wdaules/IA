using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManipulator : MonoBehaviour
{
    HealthBar healthBar;
    public int amount;
    public float dmgTime;
    public float currentDmgTime;
    void Start()
    {
        healthBar = GameObject.FindWithTag("Player").GetComponent<HealthBar>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDmgTime += Time.deltaTime;
            if (currentDmgTime > dmgTime)
            {
                healthBar.life += amount;
                currentDmgTime = 0.0f;
            }
        }
    }
}
