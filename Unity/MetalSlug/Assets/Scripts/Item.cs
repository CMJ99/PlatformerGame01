using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//아이템스크립트를 사용하면 오브젝트가 늘어나더라도,
//점수가 다른아이템은 쉽게 늘릴수 있다.
public class Item : MonoBehaviour
{
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //??
    {
        Debug.Log($"OnCollisionEnter2D:{collision.gameObject.name}"); //실행했을 때 오류가 있는지 확인 할 수 있음
        if (collision.gameObject.name == "player") //플레이어가 오브젝트와 충돌했을 때
        {
            //collision.GetComponent<Dynamic>().score++;
            collision.GetComponent<Dynamic>().score+= score; //점수증가

            Destroy(this.gameObject); //오브젝트 삭제
            //Destory(this.gameObjcet)
        }
    }
}
