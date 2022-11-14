using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;




public class camerafollow : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float smoothTime = 7.5f; //��������
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
        transform.position = Vector3.SmoothDamp(transform.position, character.position, ref vel, smoothTime); //������ ���������� ������ � ����� ���������� ���������
        transform.forward = Vector3.SmoothDamp(transform.forward, character.forward, ref vel, smoothTime); //������ ���������� forward (������������) cameraRig ����� �������� � �� �� �����, ���� � ��������.

        //����� ��� ����� ������ �� ���� ������ � ������� ���-�� ����
        transform.LookAt(character.position); // ������� �� ���������
        transform.LookAt(lookat.position); // ������� �� ���������

    }

}







