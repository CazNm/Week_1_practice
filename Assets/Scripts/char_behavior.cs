using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_behavior : MonoBehaviour
{

    public Vector2 stat_velocity;
    public Vector2 check_velocity;
    public Vector2 player_pos;
    public Vector3 player_data;
    public int run = 0;
    public int no_ground = 0;
    public float jump_r = 200 ;
    public float movespeed;
    public int jump = 0;

    bool reverse = false;
    int x_way = 1;
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

        char_ani.SetBool("run", false);
        char_ani.SetBool("run_R", false);

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

        if (run == 1 && reverse == false)
        {
            char_ani.SetBool("walk", false);
            char_ani.SetBool("run", true);

            if (check_velocity.x < 20.0f && check_velocity.x > -20.0f) player_rig.AddForce(new Vector2((x_way) * 100.0f, 0.0f));
            else{ }
            //player_rig.MovePosition(Vector2.zero);
        }

        else if(run == 1 && reverse == true)
        {
            char_ani.SetBool("walk", false);
            char_ani.SetBool("run", true);

            if (check_velocity.x < 20.0f && check_velocity.x > -20.0f) player_rig.AddForce(new Vector2((x_way) * 100.0f, 0.0f));
            else { }
            //player_rig.MovePosition(Vector2.zero);

        }

        else
        {
            char_ani.SetBool("run", false);
            char_ani.SetBool("walk", true);

           
        }

        if(jump == 1)
        {
            if(jump_r > 40.0f)
            {
                if (player_pos.y <= player_data.y + 6)
                {
                    Debug.Log("true");
                    player_rig.AddForce(new Vector2(0.0f, jump_r));
                    jump_r -= 10.0f;
                }
                else jump_r = 40.0f;
            }
            else
            {
                if (no_ground == 1) { jump = 0; jump_r = 200.0f; }
                player_rig.AddForce(new Vector2(0.0f, -30.0f));

            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
        no_ground = 0; // there is no ground under the character
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        no_ground = 1; // there is ground under the character
    }


    void onMovemnet()
    {
        if (run == 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("D down");
                x_way = 1;
                reverse = false;
                char_ani.SetBool("reverse", false);
                char_ani.SetBool("reverse_t", true);
                run = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A down");
                x_way = -1;
                reverse = true;
                char_ani.SetBool("reverse", true);
                char_ani.SetBool("reverse_t", false);
                run = 1;
            }

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D up");
            run = 0;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A up");
            run = 0;
        }

        if (no_ground == 1 && jump == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jump");
                jump = 1;
                player_data.y = GetComponent<Transform>().position.y;
            }
        }
    }
}
