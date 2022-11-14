using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;




public class camerafollow : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float smoothTime = 7.5f; //примерно
    [SerializeField] private Transform lookat;
    private Vector3 vel;


    // Start is called before the first frame update
    void Start()
    {
        if (character == null) { Debug.Log("character is  Null"); Application.Quit(); }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, character.position, ref vel, smoothTime); //плавно перемещает камеру в точку координату персонажа
        transform.forward = Vector3.SmoothDamp(transform.forward, character.forward, ref vel, smoothTime); //плавно перемещает forward (поворачивает) cameraRig чтобы смотреть в то же место, куда и персонаж.

        //можно еще иметь ссылку на саму камеру и сделать что-то типа
        transform.LookAt(character.position); // смотрит на персонажа
        transform.LookAt(lookat.position); // смотрит на персонажа

    }

}







