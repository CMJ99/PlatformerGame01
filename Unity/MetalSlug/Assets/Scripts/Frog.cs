using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public int jumpPower = 0;
    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.up * jumpPower * Time.deltaTime;
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {


            Destroy(this.gameObject);
           //Destory(this.gameObjcet);
        }
    }
}
