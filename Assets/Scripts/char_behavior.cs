using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_behavior : MonoBehaviour
{

    public Vector2 stat_velocity;
    public Vector2 check_velocity;
    public int run = 0;


    Rigidbody2D player_rig;

    // Start is called before the first frame update
    void Start()
    {
        player_rig = GetComponent<Rigidbody2D>();
        //player_rig.

    }
 
    // Update is called once per frame
    void Update()
    {
        check_velocity = player_rig.velocity;
        onMovemnet();
    }

    void FixedUpdate()
    {
        if (run == 1)
        {
            player_rig.velocity = stat_velocity;
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if( col.collider != null)
        {
            Debug.Log("on the brick");
        }
        else
        {
            Debug.Log("Noo..");
            player_rig.AddForce(new Vector2(0.0f, -2.0f));
        }
    }


    void onMovemnet()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D down");
            player_rig.AddForce(new Vector2(100.0f, 0.0f));
            run = 1;
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D up");
            run = 0;

        }

    }
}
