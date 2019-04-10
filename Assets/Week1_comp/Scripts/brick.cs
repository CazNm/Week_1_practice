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

        this_positoin = GetComponent<Transform>();
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
        

        if (col.gameObject.tag == "bricks")
        {
            Destroy(col.gameObject);
        }
    }

}
