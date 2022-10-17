using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contorlTestScript : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] wheelsFake;
    public float HorsePowers = 100;
    public float SteerPowers = 100;

    public GameObject pointOfForce;
    public Rigidbody rigidbody;

    public GameObject Vehicle;

    private float cooldown1 = 0f;
    //private float cooldown3 = 0f;
    private float cooldown2 = 0f;
    public int woodNum = 0;
    public int money = 0;

    public qdialog1 Qdialog1;
    public qdialog2 Qdialog2;
    public qdialog3 Qdialog3;
    public MainScreenButtons MainMenu;

    void Start()
    {
        woodNum = 0;
        money = 0;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = pointOfForce.transform.localPosition;
    }

    //public class Generic<T>
    //{
    //    public void OpenerDialogue()
    //    {
    //        this->gameObject.SetActive(true);
    //    }

    //    public void OpenerDialogue()
    //    {
    //        this->gameObject.SetActive(true);
    //    }
    //}
    
    void OpenerDialogue1()
    {
        Qdialog1.gameObject.SetActive(true);
    }

    void OpenerDialogue2()
    {
        Qdialog2.gameObject.SetActive(true);
    }

    void OpenerDialogue3()
    {
        Qdialog3.gameObject.SetActive(true);
    }

    void OpenerMainMenu()
    {
        MainMenu.gameObject.SetActive(true);
    }

    void CloserMainMenu()
    {
        MainMenu.gameObject.SetActive(false);
    }

    int FlagOpened = 2;

    void FixedUpdate()
    {
        //int Rpm = (wheels[0].rpm * (wheel.radius * 2 * Mathf.PI) * 60 / 1000);

        foreach (var wheel in wheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * HorsePowers;
        }

        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * SteerPowers;
                
            }
        }

        //foreach (var wheelFak in wheelsFake)
        //{
        //    wheelFak.transform.rotation = new Quaternion(wheelFak.transform.rotation.x + rigidbody.velocity.x * 1f,
        //            wheelFak.transform.rotation.y,
        //            wheelFak.transform.rotation.z,
        //            wheelFak.transform.rotation.w);
        //}

        //for (int i = 0; i < 2; i++)
        //{
        //    float koef = 1f;
        //    if (Input.GetKey("a"))
        //    {
        //        koef = 1.0f;
        //    }
        //    else if(Input.GetKey("d"))
        //    {
        //        koef = -1.0f;
        //    }
        //    print(wheelsFake[i].transform.rotation.x.ToString() + " " + wheelsFake[i].transform.rotation.y.ToString() + " " + wheelsFake[i].transform.rotation.z.ToString());
        //    wheelsFake[i].transform.rotation = new Quaternion(wheelsFake[i].transform.rotation.x,
        //            wheelsFake[i].transform.rotation.y + rigidbody.velocity.y * 1f,
        //            wheelsFake[i].transform.rotation.z,
        //            wheelsFake[i].transform.rotation.w);
        //}



        if (Input.GetKey("k"))
        {
            Vehicle.transform.position = new Vector3(76.0599976f, 3.6099999f, 136.080002f);
            Vehicle.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (Input.GetKey("2"))
        {
            Vehicle.transform.position = new Vector3(817.900024f, 0.25999999f, 305.359985f);
            Vehicle.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (Input.GetKey("3"))
        {
            Vehicle.transform.position = new Vector3(142.440002f, 7.40999985f, 835.150024f);
            Vehicle.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        }

        if (Input.GetKeyDown("m")) // Input.GetKeyDown(KeyCode.Escape)
        {
            if (FlagOpened % 2 == 1)
            {
                OpenerMainMenu();
            }
            else
            {
                CloserMainMenu();
            }

            FlagOpened++;

            print(FlagOpened);
        }
        

    }

    void OnTriggerEnter(Collider quest)
    {
        if (quest.gameObject.tag == "questPoint1") // раздает бесплатно
        {
            //rb = new GetComponent<Rigidbody>();
            //print("Enter" + woodNum.ToString());
            if (cooldown1 > 0)
            {
                cooldown1 -= Time.deltaTime;
            }
            else
            {
                OpenerDialogue1();
                woodNum += 100;
                //rb.Mass += 1000;
                cooldown1 = 120f;
            }
        }

        if (quest.gameObject.tag == "questPoint3") // ему надо все
        {
            //rb = new GetComponent<Rigidbody>();
            OpenerDialogue2();
            
            money += woodNum;
            woodNum = 0;
            //rb.Mass -= 10 * woodNum;
        }

        if (quest.gameObject.tag == "questPoint2") // ему ниче не надо
        {
            //rb = new GetComponent<Rigidbody>();
            if (cooldown2 > 0)
            {
                cooldown2 -= Time.deltaTime;
            }
            else
            {
                if (money >= 100)
                {
                    OpenerDialogue3();
                    woodNum += 300;
                    money -= 100;
                    //rb.Mass += 3000;
                    cooldown2 = 480f;
                }
            }
        }
    }
}
