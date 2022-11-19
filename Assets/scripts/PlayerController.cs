using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public float speed = 10f;
    public float jumpPower = 10f;
    public float sprintingMultiplayer; //velocidad al correr
    public bool isSprinting = false; //correr
    public CharacterController controller;
    public LayerMask groundMask; //suelo
    public Transform groundDetectionTransform; //detector del suelo
    public bool isCrouching = false; //agacharse
    public float crouchHeight = 1.25f; //altura agachado
    public float standingHeigth = 1.8f; //altura normal
    public float crouchingSpeed = -5; //velocidad agachado
    public float gravity = -9.8f; //gravedad
    public float currentVelY = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();        
    }

    void Update()
    {      
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded == true) //saltar mientras estas en el suelo
        {
            currentVelY = 0;
            currentVelY = jumpPower;
            anim.Play("Jump");
        }
        //Debug.Log(currentVelY);
        currentVelY += gravity * Time.deltaTime;
        Vector3 movement = new Vector3();
        movement = x * transform.right + z * transform.forward;
        controller.Move(movement * speed * Time.deltaTime);
        controller.Move(new Vector3(0, currentVelY * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching) //correr y no poder agacharte mientras corres
        {
            controller.Move(movement * sprintingMultiplayer * Time.deltaTime); //usar la velocidad de sprint 
            isSprinting = true;
          
        }
        else
        {
            isSprinting = false;          
        }
        if (Input.GetKey(KeyCode.LeftControl) && !isSprinting) //agacharse y no poder correr mientras te agachas
        {
            controller.Move(movement * crouchingSpeed * Time.deltaTime); //usar la velocidad de agachado
            controller.height = crouchHeight; //pasar de altura normal a agachado
            isCrouching = true;
            
        }
        else
        {
            controller.height = standingHeigth; //pasar de altura agachado a normal
            isCrouching = false;
  
        }
    }
}
