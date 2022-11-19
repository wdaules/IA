using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healtbar;  
    public float life = 100;
    void Update()
    {
        life = Mathf.Clamp(life, 0, 100);
        healtbar.fillAmount = life / 100;
        if (life <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
   } 
}
