using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{

    public bool isJump;
    public int jumpPower = 0;
    public int speed = 1;
    

    public float time = 1;

    public bool isTimmer;


    IEnumerator ProcessTimer()
    {
        Debug.Log("ProcessTimer() start");
        isTimmer = true; //Ÿ�̸� ����
        yield return new WaitForSeconds(time);//time�� �ð����� ��ٸ���.
        //Jump(); // ����

        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
        isJump = true; //���� ����


        isTimmer = false;//Ÿ�̸� ����
        Debug.Log("ProcessTimer() end");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isJump) //�������϶���
        transform.position += Vector3.left * speed * Time.deltaTime;//�������� �̵��Ѵ�.

        


        /*if (isJump == false)
        {



            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
            isJump = true;
        }*/


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false; //���� ����
        StartCoroutine(ProcessTimer());//Ÿ�̸� ����
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    // private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            isJump = false;
        }


    }*/

    void Jump()
    {
        if (isJump == false) //������ ������ ��
        {
            //�����Ѵ�.
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
            isJump = true; //���� ����
        }
        
    }
}
