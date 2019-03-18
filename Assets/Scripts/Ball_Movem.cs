using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movem : MonoBehaviour
{


    
    public Vector2 ball_force;
    public int ball_colision;

    Rigidbody2D ball_body;
    Transform ball_pos;

    // Start is called before the first frame update
    void Start()
    {
        ball_pos = GetComponent<Transform>();
        ball_body = GetComponent<Rigidbody2D>();

        ball_pos.position = Vector3.zero;
        ball_body.AddForce(new Vector2(100.0f, 100.0f));

        ball_colision = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
