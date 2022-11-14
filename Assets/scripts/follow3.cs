using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;




public class follow3 : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Transform lookat;
    [SerializeField] private float smoothTime = 1.5f; //��������
    [SerializeField] private float smoothTime2 = 0.005f; //��������

    private Vector3 vel;


    // Start is called before the first frame update
    void Start()
    {

      //  Debug.Log("Start");
      //  Debug.Log(character);
        if (character == null) {// Debug.Log("character is  Null");
                                Application.Quit(); }


    }
    void Awake()
    {
      //  Debug.Log("Awake");
      //  Debug.Log(character);
        if (character == null) {
           // Debug.Log("character is  Null"); 
            Application.Quit(); }


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, character.position, ref vel, smoothTime); //������ ���������� ������ � ����� ���������� ���������
        transform.forward = Vector3.SmoothDamp(transform.forward, character.forward, ref vel, smoothTime2); //������ ���������� forward (������������) cameraRig ����� �������� � �� �� �����, ���� � ��������.
        
        transform.LookAt(lookat.position); // ������� �� ���������




    }

}







