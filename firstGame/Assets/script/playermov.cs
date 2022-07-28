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
    private Vector3 playerInput;
    private Vector2 camInput;
    private float xRot;
    private bool canJump;
    private bool run;
    private float speed = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        inputManage();

        fpsCam();
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

        if (Input.GetKey(KeyCode.LeftShift))
            run = true;        
        else
            run = false;
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
        if (run)
            speed = 3.5f;
        else
            speed = 2.5f;
        
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
}
