using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        

        if (col.gameObject != null)
        {
            GameObject col_object = col.gameObject;
            
            Vector3 Save_cal = GetComponent<Transform>().position - col_object.transform.position;

            //x가 2.8이고 y가 
            Debug.Log(Save_cal);


        }
    }

}
