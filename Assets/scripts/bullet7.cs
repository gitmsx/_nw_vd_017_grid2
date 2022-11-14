using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class bullet7 : MonoBehaviour 
 {

    public float StartTime=0;
    public float DestroyTime = 0.2f;
    public float SShift1 = 0.02f;
    public float SShift2 = 0.02f;
    private GameObject bulletClone;
    private GameObject bulletClone2;

    public float bulletSpeed = 100;
    //public Rigidbody bullet;
    public GameObject BulletPF;
    public GameObject SperePF;
    private List<GameObject> listObj = new List <GameObject>();


    private void Start()
    {
        for (int i = 0; i < 22; i++)
        {
            Fire();
        }
    }

    void Fire()
    {

        bulletClone = Instantiate(BulletPF, transform.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

       // var color_obj = bulletClone.GetComponent<Color>();
        var material_obj = bulletClone.GetComponent<Material>();

        listObj.Add(bulletClone);

        // Debug.Log(color_obj);
       // Debug.Log(material_obj);

        var x1 = (float)Random.Range(-3, 5);
        var y1 = (float)Random.Range(-3, 5);
        var z1 = (float)Random.Range(-3, 5);

        Vector3 posi1 = new Vector3(x1, y1, z1);
        Destroy(bulletClone, 5.5f);






        bulletClone2 = Instantiate(SperePF, posi1, transform.rotation);
        listObj.Add(bulletClone2);

        var Rend2 = bulletClone2.GetComponent<Renderer>();

        var color1 = (int)Random.Range(0, 255);
        var color2 = (int)Random.Range(0, 255);
        var color3 = (int)Random.Range(0, 255);

        var ColorN= new UnityEngine.Color(color1 / 255.0f, color2 / 255.0f, color3 / 255.0f);

        Rend2.material.SetColor("_Color",ColorN) ;


        Destroy(bulletClone2, 5.5f);



    }
 

    void make10units()
    {
      //  Debug.Log(listObj.Count);
        // for (int i = 0; i < listObj.Count; i++)

        int i = 1;
        foreach (var obj in listObj)
        {
            i++;
      ///      Destroy(obj, i * DestroyTime / 10);

        }



    }

    void MotionMod()
    {


        //foreach (var obj in listObj)
        //{

        //    var x1 = (float)Random.Range(-SShift1, SShift2);
        //    var y1 = (float)Random.Range(-SShift1, SShift2);
        //    var z1 = (float)Random.Range(-SShift1, SShift2);

        //    var objtransform = obj.transform;
        //    // objtransform.localScale = new Vector3(x1, y1, z1);
        //    objtransform.localPosition = new Vector3(obj.transform.position.x + x1, obj.transform.position.y + y1, obj.transform.position.z + z1);




        //}


    }

    void Update () 
     {


        if (Input.GetKey(KeyCode.Q))
        {
            MotionMod();

        }

        if (Input.GetButtonDown("Fire2"))
        {
            make10units();

        }
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            
        }

        MotionMod();
    }
}