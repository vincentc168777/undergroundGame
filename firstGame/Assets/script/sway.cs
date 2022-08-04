using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sway : MonoBehaviour
{
    [SerializeField] int smooth;
    [SerializeField] int swayMulitplier;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMulitplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMulitplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.left);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion rotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, smooth);
    }
}
