using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public int brick_health;
    Transform this_positoin;
    
    

    // Start is called before the first frame update
    void Start()
    {
       this_positoin.position = GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        

        if (col.gameObject != null)
        {
            GameObject col_object = col.gameObject;
            
            Vector3 Save_cal = GetComponent<Transform>().position - col_object.transform.position;

            //원 반지름 1 상자 중심 0,0.15 상자 크기 3.6 * 1.1
            //왼쪽면에 맞았을 경우 x의 고정 y의 변화

            Debug.Log(Save_cal);


        }
    }

}
