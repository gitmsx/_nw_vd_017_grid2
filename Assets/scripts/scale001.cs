using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;


public class scale001 : MonoBehaviour
{
    [Header("Sling Attributes")]
    [SerializeField] AnimationCurve curve;
    [SerializeField] AnimationCurve curveSling;
    //   [SerializeField][Range(-1, 1)] float Sling = -1.0f; 

    // HideInInspector

    [SerializeField]  float SlingMin = -1.0f;
    [SerializeField]  float SlingMax = 1.0f;

    [SerializeField]  float SlingMinX = -1.0f;
    [SerializeField]  float SlingMaxX = 11.0f;
    [SerializeField]  float SlingMinY = -2.0f;
    [SerializeField]  float SlingMaxY = 7.0f;
    [SerializeField]  float SlingMinZ = -1.0f;
    [SerializeField]  float SlingMaxZ = 21.0f;

    Vector3 transformlocalScale;

    [Header("Other Attributes")]
    [ColorUsage(false, true)] public Color hdrColorWithoutAlpha = Color.white;

    // [NonSerialized] 
    //[HideInInspector]
    // [HideInInspector]


    [SerializeField] float timeSling = 7.0f;
    [SerializeField] float timeColorChange = 220f;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 finishPosition;
    [SerializeField] Quaternion Qrotation;


    public Text Text1;
    public GameObject Text2;

    private Text Text12;


    [Header("elapsedTime Attributes")]

    private float elapsedTimeX;
    private float elapsedTimeY;
    private float elapsedTimeZ;
    private float elapsedTimeRotationX;
    private float elapsedTimeRotationY;
    private float elapsedTimeRotationZ;

    private float elapsedColorTime1;
    private float elapsedColorTime2;
    private float elapsedColorTime3;

    private Renderer Rend2;

    // Start is called before the first frame update
    void Start()
    {

        // GetComponent<Renderer>().material.color = Color.red;
         Rend2 = GetComponent<Renderer>();


        Text2 = GameObject.Find("Text");
        Text12 = Text2.GetComponent<Text>();
        Text12.text = "111111111";




        transformlocalScale = transform.localScale;
        Qrotation = transform.rotation;


        Text12 = Text2.GetComponent<Text>();
        Text12.text = "111111111";

        Reset();
    }
    void Reset()
    {
        elapsedTimeX = 0;
        elapsedTimeY = timeSling/2;
        elapsedTimeZ = timeSling/4;

        elapsedTimeRotationX = 0;
        elapsedTimeRotationY = 180;
        elapsedTimeRotationZ = 90;

        elapsedColorTime1 = 1;
        elapsedColorTime2 = 112;
        elapsedColorTime3 = 70;


    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimeX += Time.deltaTime;
        elapsedTimeY += Time.deltaTime;
        elapsedTimeZ += Time.deltaTime;
        elapsedTimeRotationX += Time.deltaTime;
        elapsedTimeRotationY += Time.deltaTime;
        elapsedTimeRotationZ += Time.deltaTime;

        elapsedColorTime1 += Time.deltaTime;
        elapsedColorTime2 += Time.deltaTime;
        elapsedColorTime3 += Time.deltaTime;


        float VolumeX = Mathf.Lerp(SlingMinX, SlingMaxX, curve.Evaluate(elapsedTimeX / timeSling));
        float VolumeY = Mathf.Lerp(SlingMinY, SlingMaxY, curve.Evaluate(elapsedTimeY / timeSling));
        float VolumeZ = Mathf.Lerp(SlingMinZ, SlingMaxZ, curve.Evaluate(elapsedTimeZ / timeSling));

        Text12.text = "elapsedTime " + Math.Round(elapsedTimeX, digits: 3).ToString() + "X " + Math.Round(VolumeX, digits: 3).ToString() + "  Y " + Math.Round(VolumeY, digits: 3).ToString() + "  Z " + Math.Round(VolumeZ, digits: 3).ToString();
        Text12.text = "X " + Math.Round(VolumeX, digits: 3).ToString() + "  Y " + Math.Round(VolumeY, digits: 3).ToString() + "  Z " + Math.Round(VolumeZ, digits: 3).ToString();

        transform.localScale = new Vector3(transformlocalScale.x + VolumeX, transformlocalScale.y + VolumeY, transformlocalScale.z + VolumeZ);



        // rotation 

          VolumeX = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeX / timeSling));
          VolumeY = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeY / timeSling));
          VolumeZ = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeZ / timeSling));


        float RotationX = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeRotationX / timeSling));
        float RotationY = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeRotationY / timeSling));
        float RotationZ = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeRotationZ / timeSling));

        transform.Rotate(Qrotation.x + VolumeX , Qrotation.x+VolumeY , Qrotation.z + VolumeZ );


        //   transform.position = Vector3.Lerp(startPosition, finishPosition, curve.Evaluate(elapsedTime1 / timeSling));

        // Color



        elapsedColorTime2 = Mathf.Lerp(70, 255, curve.Evaluate(elapsedTimeRotationX / timeSling));
        elapsedColorTime2 = Mathf.Lerp(70, 255, curve.Evaluate(elapsedTimeRotationY / timeSling));
        elapsedColorTime3 = Mathf.Lerp(70, 255, curve.Evaluate(elapsedTimeRotationZ / timeSling));



        // var color1 = (int)Random.Range(0, 255);
        // var color2 = (int)Random.Range(0, 255);
        // var color3 = (int)Random.Range(0, 255);



        var color1 = Mathf.Lerp(70, 255, curve.Evaluate(elapsedColorTime1 / timeColorChange));
        var color2 = Mathf.Lerp(70, 255, curve.Evaluate(elapsedColorTime2 / timeColorChange));
        var color3 = Mathf.Lerp(70, 255, curve.Evaluate(elapsedColorTime3 / timeColorChange));

        var ColorN = new UnityEngine.Color(color1 / 255.0f, color2 / 255.0f, color3 / 255.0f);

       
        Rend2.material.SetColor("_Color", ColorN);






    }
}
