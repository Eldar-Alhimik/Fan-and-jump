using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGuysMove : MonoBehaviour
{
    [SerializeField] float speed; //скорость персонажа
    Rigidbody rb; //ссылка на Rigidbody
    Vector3 direction; //Направление движения
    [SerializeField] float jumpSpeed; //высота прыжка
    bool isGrounded; //переменная, которая будет указывать на земле мы или нет
    Vector3 startPosition;

    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);

        //меняем анимацию персонажа
      //  if (direction.magnitude > 0)
      //  {
        //    anim.SetBool("Run", true);
      //  }
      //  else anim.SetBool("Run", false);
        //

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
}