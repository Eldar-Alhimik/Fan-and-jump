using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] float limit = 30f; //� ���������� ��������� ���� ���, ������� ������ ���� ����������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���� ����� ���������� �� ���������
        float angle = limit * Mathf.Sin(Time.time);
        //�������� ���� ������ ��������   
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
