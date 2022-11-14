using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;




public class follow2 : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float smoothTime = 2.5f; //��������

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
        transform.forward = Vector3.SmoothDamp(transform.forward, character.forward, ref vel, smoothTime); //������ ���������� forward (������������) cameraRig ����� �������� � �� �� �����, ���� � ��������.

        transform.LookAt(character.position); // ������� �� ���������


    }

}







