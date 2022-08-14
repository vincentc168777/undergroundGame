using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermov : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] int sensitivity;
    [SerializeField] Rigidbody playerbod;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask floor;
    [SerializeField] int jumpForce;
    
    public int stamina;
    private Vector3 playerInput;
    private Vector2 camInput;
    private float xRot;
    private bool canJump;
    private bool run;
    private bool canPress;
    private float speed = 2f;
    


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canPress = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause.paused)
        {
            inputManage();

            fpsCam();
        }
        
    }

    private void FixedUpdate()
    {
        moving();

        if (canJump)
            jump();
    }
    private void inputManage()
    {
        playerInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        camInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        

        if(Input.GetKey(KeyCode.LeftShift) && canPress)
        {
            run = true;           
        }          
        else
        {
            run = false;
        }
    }

    private void fpsCam()
    {
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        xRot -= camInput.y * sensitivity;
        // up and down
        cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        //left to right
        transform.Rotate(0f, camInput.x * sensitivity, 0f);
     
    }

    private void moving()
    {
        if(run)
        {
            stamina--;
            sprintStamina();
        }
        else
        {
            speed = 2f;
            if(stamina <= 0)
            {
                Invoke("resetStamina", 3);
            }
            
        }
               
        Vector3 moveVec = transform.TransformDirection(playerInput) * speed;
        playerbod.velocity = new Vector3(moveVec.x, playerbod.velocity.y, moveVec.z);
    }

    private void jump()
    {
        canJump = false;
        if(Physics.OverlapSphere(groundCheck.position, 0.1f, floor).Length > 0)
        {
            playerbod.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    private void sprintStamina()
    {              
        speed = 4f;
        
        if(stamina <= 0)
        {
            canPress = false;
            run = false;
        }        
    }

    private void resetStamina()
    {
        
        stamina = 200;
        Invoke("resetPress", 2);

    }

    private void resetPress()
    {
        canPress = true;
    }

}
