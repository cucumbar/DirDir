using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3dScript : MonoBehaviour
{
    public CharacterController car_control;
    public float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movdir = new Vector3(horizontal, 0f, vertical).normalized;

        if (movdir.magnitude >= 0f)
        {
            float anglRot = Mathf.Atan2(movdir.x, movdir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, anglRot, 0f);

            car_control.Move(movdir * speed * Time.deltaTime);
        }
    }
}
