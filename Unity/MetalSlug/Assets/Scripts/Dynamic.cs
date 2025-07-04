using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Dynamic : MonoBehaviour
{
    public int score;
    public float speed = 1;
    public float jumpPower = 100;

    public bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))//오른쪽 방향키를 누르면 인식가능하게 함
                                             //오른쪽 방향키를 누르면 오른쪽으로 플레이어가 정해진 속도에 맞춰서 움직임
            transform.position += Vector3.right * speed * Time.deltaTime;
        //왼쪽 방향키를 누르면 인식가능하게 함
        if (Input.GetKey(KeyCode.LeftArrow))
            //왼쪽 방향키를 누르면 왼쪽으로 플레이어가 정해진 속도에 맞춰서 움직임
            transform.position += Vector3.left * speed * Time.deltaTime;
        //스페이스바를 누르면 인식가능하게 함
        if (Input.GetKeyDown(KeyCode.Space))
            //플레이어에게 Rigidbody를 부여하고 스페이스바를 누르면 플레이어가 (추가된 힘) 점프파워를 받고 위로 점프한다
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
        /*if (isJump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
                isJump = true;


            }
        }*/
    }
    private void OnDestroy()
    {
        //죽은 위치에서 부활함
        //GameOject objPlayer = Instantiate(this.gameObject);
        //objPlayer.SetActive(true);
    }
    private void OnGUI()//??
    {
        GUI.Box(new Rect(0, 0, 200, 20), "Score:" + score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
   // private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Debug.Log($"OnCollisionEnter2D:{collision.gameObject.name}");
        *아이템이 주가될 때마다 경우의 수가 늘어나고 코드를 변경해야한다.
        if(collision.gameObject.name == "cherry")
        {

            collision.GetComponent<Dynamic>().score++;

            Destroy(collision.gameObject);
            //Destory(this.gameObjcet)
        }
       if (collision.gameObject.name == "gem")
       {

           score += 100;
           Destroy(collision.gameObject);
           //Destory(this.gameObjcet)
       }*/
        /*if (collision.gameObject.name == "opossum")
        {
            Destroy(this.gameObject); // opossum 제거
        }*/

        
    }

}
