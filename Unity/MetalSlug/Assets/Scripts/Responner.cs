using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject prefabPlayer;  //복제될 원본 프리팹
    public GameObject objPlayer; //복제된 플레이어

    public float time = 1; 

    public bool isTimmer;
    // Start is called before the first frame update

    IEnumerator ProcessTimer()
    {
        Debug.Log("ProcessTimer() start"); 
        isTimmer = true; //타이머 시작
        yield return new WaitForSeconds(time);//time에 시간동안 기다린다.

        objPlayer = Instantiate(prefabPlayer, transform.position, Quaternion.identity); //(플레이어를 복제(원본,위치,회전초기화)) 플레이어리스포너에 플레이어를 복제한다

        isTimmer = false; //타이머 종료
        Debug.Log("ProcessTimer() end");
    }
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if (objPlayer == null && isTimmer == false) //플레이어가 없고 타이머가 종료될때
        {
            StartCoroutine(ProcessTimer()); //플레이어 복제
        }
    }
}
