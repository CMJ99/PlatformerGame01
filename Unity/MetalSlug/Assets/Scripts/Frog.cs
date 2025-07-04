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
        isTimmer = true; //타이머 시작
        yield return new WaitForSeconds(time);//time에 시간동안 기다린다.
        //Jump(); // 점프

        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
        isJump = true; //점프 시작


        isTimmer = false;//타이머 종료
        Debug.Log("ProcessTimer() end");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isJump) //점프중일때만
        transform.position += Vector3.left * speed * Time.deltaTime;//왼쪽으로 이동한다.

        


        /*if (isJump == false)
        {



            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
            isJump = true;
        }*/


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false; //점프 종료
        StartCoroutine(ProcessTimer());//타이머 시작
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
        if (isJump == false) //점프가 끝났을 때
        {
            //점프한다.
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
            isJump = true; //점프 시작
        }
        
    }
}
