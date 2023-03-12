using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{

    [SerializeField] float force = 100f;
    private Vector3 hitDir;

    void OnCollisionEnter(Collision collision)
    {
        //��� ������� ���������������
        foreach (ContactPoint contact in collision.contacts)
        {
            //���� �������������� � �������� � ����� Player
            if (collision.gameObject.tag == "Player")
            {
                //������ �����������, � ������� ��������� ������
                hitDir = contact.normal;
                //��������� ������� ������� � ������� ��������������� ������� ���������������
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
                return;
            }
        }
    }
}