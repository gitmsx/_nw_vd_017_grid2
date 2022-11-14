using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    private Rigidbody rigidbody;

    [SerializeField] private Text Text14;
    [SerializeField]  private float speed;
    [SerializeField]  private float speedTorque;
    [NonSerialized] private int multip = 1;
    [NonSerialized] private bool SpeedChanged = true;
    private GameObject Text7;

    // Start is called before the first frame update
    void Start()
    {
        Text7 = GameObject.Find("TextInfo");
        //  Text2.transform.Translate(1,1,1);
        Text14 = Text7.GetComponent<Text>();
        Text14.text = "111111111";

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // EXAMPLE 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(0, 0, v * speed);
        Vector3 Torque = new Vector3(0, h*speedTorque, 0);



        
        
        rigidbody.AddRelativeForce(velocity * multip, ForceMode.Impulse);
        rigidbody.AddRelativeTorque(Torque, ForceMode.Impulse);

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            multip += Mathf.FloorToInt(Input.GetAxis("Mouse ScrollWheel") * 10);
            SpeedChanged = true;

 
        }

        if (SpeedChanged == true)
        {

            Text14.text = "Импульс " + Math.Round(v * speed * multip, digits: 3).ToString() + "  Mult " + Math.Round(multip, digits: 3).ToString();
            SpeedChanged = false;

        }





        // rigidbody.freezeRotation = false;



        //        transform.Rotate(Vector3.up *h* speedTorque);

    }
}