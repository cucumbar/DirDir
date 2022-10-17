using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovDirChar : MonoBehaviour
{
    public CharacterController contrl;

    public Transform cam;
    public Transform CarRotationTrans;

    public float speed = 15f;
    public float RotSmoothness = 0.1f;
    float turnSmoothnessVelo;

    [Header("Gravity")]
    public float gravity;
    public float currentGravity;
    public float constantGravity;
    public float maxGravity;

    private Vector3 gravityDirection = Vector3.down;
    private Vector3 gravityMovement;
    //public 

    #region - Gravity -
    private bool IsGrounded()
    {
        return contrl.isGrounded;
    }
    private void CalculateGravity()
    {
        if (IsGrounded())
        {
            currentGravity = constantGravity;
        }
        else
        {
            if (currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            
            }
        }

        gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;
    }
    #endregion

    void Update()
    {
        CalculateGravity();


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (movementDir.magnitude >= 0.1f && (Input.GetKey("w") || Input.GetKey("s")))
        {
            if (Input.GetKey("s"))
            {
                RotSmoothness = 0.2f;
                turnSmoothnessVelo = 0.2f;
            }

            float tAngle = Mathf.Atan2(movementDir.x, movementDir.z) * Mathf.Rad2Deg + CarRotationTrans.eulerAngles.y;


            //float RealAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tAngle, ref turnSmoothnessVelo, RotSmoothness);
            //transform.rotation = Quaternion.Euler(0f, RealAngle, 0f);

            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                float RealAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tAngle, ref turnSmoothnessVelo, RotSmoothness);
                transform.rotation = Quaternion.Euler(0f, RealAngle, 0f);


                //abobaview.Tractor.leftRoule.transform.rotation = Quaternion.Euler(0f, RealAngle, 0f);
                //abobaview.Tractor.rightRoule.transform.rotation = Quaternion.Euler(0f, RealAngle, 0f);
            }

            Vector3 realDir = Quaternion.Euler(0f, tAngle, 0f) * Vector3.forward;
            contrl.Move(realDir.normalized * speed * Time.deltaTime + gravityMovement);
        }
    }
}
