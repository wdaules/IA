using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Proyectile : MonoBehaviour
{

    public float speed = 5f;
    public float lifetime = 2f;

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    void Update()
    {
       
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {     
        PlayerController Player = other.GetComponent<PlayerController>();
        if (Player != null)
        {
            Destroy(gameObject);
        }       
    }
}
