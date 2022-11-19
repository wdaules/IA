using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    Animator anim;
    public int isSprintingHash;
    public int isRunningHash;
    public int isRunningBackHash;
    public int isRunningLeftHash;
    public int isRunningRightHash;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("IsRunning");
        isSprintingHash = Animator.StringToHash("IsSprinting");
        isRunningBackHash = Animator.StringToHash("IsRunningBack");
        isRunningLeftHash = Animator.StringToHash("IsRunningLeft");
        isRunningRightHash = Animator.StringToHash("IsRunningRight");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = anim.GetBool(isRunningHash);
        bool IsSrpinting = anim.GetBool(isSprintingHash);
        bool isRunningBack = anim.GetBool(isRunningBackHash);
        bool isRunningLeft = anim.GetBool(isRunningLeftHash);
        bool isRunningRight = anim.GetBool(isRunningRightHash);       
        bool forwardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey("left shift");  
        if (!isRunning && forwardPressed)
        {
            anim.SetBool("IsRunning", true);
        }       
        if (isRunning && !forwardPressed)
        {
            anim.SetBool("IsRunning", false);
        }
        if (!isRunning && backPressed)
        {
            anim.SetBool("IsRunningBack", true);
        }
        else
        {
            anim.SetBool("IsRunningBack", false);
        }
        if (!isRunning && leftPressed)
        {
            anim.SetBool("IsRunningLeft", true);
        }
        else
        {
            anim.SetBool("IsRunningLeft", false);
        }
        if (!isRunning && rightPressed)
        {
            anim.SetBool("IsRunningRight", true);
        }
        else
        {
            anim.SetBool("IsRunningRight", false);
        }
        if (!IsSrpinting && (forwardPressed && runPressed))
        {
            anim.SetBool("IsSprinting", true);
        }
        if (IsSrpinting && !forwardPressed && !runPressed)
        {
            anim.SetBool("IsSprinting", false);
        }
        if (!isRunning && !forwardPressed && !backPressed && !leftPressed && !rightPressed)
        {
            anim.Play("Idle");
        }
    }
}
