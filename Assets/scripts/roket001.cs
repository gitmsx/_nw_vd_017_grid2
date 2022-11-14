using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class roket001 : MonoBehaviour
{

    [NonSerialized] public Rigidbody rb;
    
    private float speed_1 = 11.0f;
    private float SpeedRocket = 10.0f;
    private float DeltaSpeedRocket = 0.1123f;
    private bool SpeedChanged = true;
    [NonSerialized] private int multip = 1;

    [SerializeField] AudioClip engine;
    [SerializeField] AudioClip engineMult;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;


    [SerializeField] ParticleSystem Jet;
    [SerializeField] private ParticleSystem ExplosionParticles;
    [SerializeField] ParticleSystem finishPartiles;

    bool collisionOff = false;



    public Text Text1;
    public GameObject Text2;

    // private Text Text22;
    [SerializeField] private Text Text12;

    [NonSerialized] private State state;

    enum State { good, crash, finish };

    AudioSource audioSource;





    void Start()
    {

        state=State.good;
        Text2 = GameObject.Find("Text");
        //  Text2.transform.Translate(1,1,1);
        Text12 = Text2.GetComponent<Text>();
        Text12.text = "111111111";


    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //        rb.angularDrag = 2;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject22;
        gameObject22=collision.gameObject;


        switch (gameObject22.tag)
        {

            case "enemy":

                Debug.Log("Enemy");
                Console.WriteLine("Enemy");
                audioSource.Stop();
                audioSource.PlayOneShot(crash);
                ExplosionParticles.Play();
                break;


            case "base":

                Debug.Log("base");
                Console.WriteLine("base");
                audioSource.Stop();
                audioSource.PlayOneShot(finish);
                finishPartiles.Play();
                break;




            default:
                break;
        }


    }

    void Sstabil()
    {
        Vector3 pos55 = transform.position;
        transform.position = new Vector3(0, pos55.y, 0);

    }
    void Sstabil2()
    {
        Vector3 pos55 = transform.position;
        transform.position = new Vector3(Mathf.Round(pos55.x), pos55.y, Mathf.Round(pos55.z));
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            multip += Mathf.FloorToInt(Input.GetAxis("Mouse ScrollWheel") * 10);
            SpeedChanged = true;

            audioSource.Stop();
            audioSource.PlayOneShot(engineMult);
            Jet.Play();

        }



        if (Input.GetKey(KeyCode.W))
        {
            SpeedRocket += DeltaSpeedRocket;
            SpeedChanged = true;
            audioSource.Stop();
            audioSource.PlayOneShot(engine);
            //    Sstabil();
        }
        if (Input.GetKey(KeyCode.S))
        {
            SpeedRocket -= DeltaSpeedRocket;
            SpeedChanged = true;
            audioSource.Stop();
            audioSource.PlayOneShot(engine);
            //    Sstabil();
        }
        if (SpeedChanged == true)
        {
           
            Text12.text = "Импульс "+Math.Round(SpeedRocket, digits: 3).ToString() + "  Mult " + Math.Round(multip, digits: 3).ToString();
            SpeedChanged = false;

        }
        {
            rb.AddRelativeForce(0, SpeedRocket * multip * Time.deltaTime, 0, ForceMode.Impulse);

        }


        float rotation_1 = Input.GetAxis("Horizontal") * speed_1 * Time.deltaTime;

        rb.AddRelativeTorque(rotation_1, 0, 0, ForceMode.Impulse);


    }
}
