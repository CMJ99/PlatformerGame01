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
        if (Input.GetKey(KeyCode.RightArrow))//������ ����Ű�� ������ �νİ����ϰ� ��
                                             //������ ����Ű�� ������ ���������� �÷��̾ ������ �ӵ��� ���缭 ������
            transform.position += Vector3.right * speed * Time.deltaTime;
        //���� ����Ű�� ������ �νİ����ϰ� ��
        if (Input.GetKey(KeyCode.LeftArrow))
            //���� ����Ű�� ������ �������� �÷��̾ ������ �ӵ��� ���缭 ������
            transform.position += Vector3.left * speed * Time.deltaTime;
        //�����̽��ٸ� ������ �νİ����ϰ� ��
        if (Input.GetKeyDown(KeyCode.Space))
            //�÷��̾�� Rigidbody�� �ο��ϰ� �����̽��ٸ� ������ �÷��̾ (�߰��� ��) �����Ŀ��� �ް� ���� �����Ѵ�
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
        //���� ��ġ���� ��Ȱ��
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
        *�������� �ְ��� ������ ����� ���� �þ�� �ڵ带 �����ؾ��Ѵ�.
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
            Destroy(this.gameObject); // opossum ����
        }*/

        
    }

}
