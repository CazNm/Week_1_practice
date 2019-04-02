using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_behavior : MonoBehaviour
{

    public Vector2 stat_velocity;
    public Vector2 check_velocity;
    public Vector2 player_pos;
    public int run = 0;
    public int no_ground = 0;
    public float movespeed;



    int provide_int = 0;
    int x_way = 0;
    Rigidbody2D player_rig;
    GameObject player;
    Transform pl_trans;


    Animator char_ani;

    // Start is called before the first frame update
    void Start()
    {
        player_rig = GetComponent<Rigidbody2D>();
        char_ani = GetComponent<Animator>();
        player = GetComponent<GameObject>();
        pl_trans = GetComponent<Transform>();

        //player_rig.

    }

    // Update is called once per frame
    void Update()
    {
        player_pos = new Vector2(pl_trans.position.x, pl_trans.position.y);
        check_velocity = player_rig.velocity;
        onMovemnet();
    }



    void FixedUpdate()
    {

        if (run == 1)
        {
            char_ani.SetBool("walk", false);
            char_ani.SetBool("run", true);
            if (check_velocity.x < 10.0f && check_velocity.x > -10.0f) player_rig.AddForce(new Vector2((x_way) * 100.0f, 0.0f));
            else
            {

            }
            //player_rig.MovePosition(Vector2.zero);

        }
        else
        {
            char_ani.SetBool("run", false);
            char_ani.SetBool("walk", true);


        }

    }

    void onMovemnet()
    {

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D down");
            x_way = 1;
            //player_rig.AddForce(new Vector2(100.0f, 0.
            run = 1;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D up");
            // GetComponent<Collider2D>().f = 0.4f;
            run = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A down");
            x_way = -1;
            //player_rig.AddForce(new Vector2(100.0f, 0.
            run = 1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A up");
            // GetComponent<Collider2D>().f = 0.4f;
            run = 0;

        }
    }
}
