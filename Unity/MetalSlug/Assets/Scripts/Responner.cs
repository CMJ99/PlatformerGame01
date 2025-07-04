using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject prefabPlayer;  //������ ���� ������
    public GameObject objPlayer; //������ �÷��̾�

    public float time = 1; 

    public bool isTimmer;
    // Start is called before the first frame update

    IEnumerator ProcessTimer()
    {
        Debug.Log("ProcessTimer() start"); 
        isTimmer = true; //Ÿ�̸� ����
        yield return new WaitForSeconds(time);//time�� �ð����� ��ٸ���.

        objPlayer = Instantiate(prefabPlayer, transform.position, Quaternion.identity); //(�÷��̾ ����(����,��ġ,ȸ���ʱ�ȭ)) �÷��̾�����ʿ� �÷��̾ �����Ѵ�

        isTimmer = false; //Ÿ�̸� ����
        Debug.Log("ProcessTimer() end");
    }
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if (objPlayer == null && isTimmer == false) //�÷��̾ ���� Ÿ�̸Ӱ� ����ɶ�
        {
            StartCoroutine(ProcessTimer()); //�÷��̾� ����
        }
    }
}
