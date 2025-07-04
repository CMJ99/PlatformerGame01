using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;//주머니쥐의 위치를 왼쪽으로 정해진 속도에 맞게 이동시킨다
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name == "Player")//플레이어의 이름을 가진 오브젝트와 충돌되었을 때 
            if (collision.gameObject.tag == "Player")
            {
            Destroy(collision.gameObject);// 삭제시킨다.
            }
       
    }
}
