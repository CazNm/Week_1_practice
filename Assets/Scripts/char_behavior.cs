using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_behavior : MonoBehaviour
{

    public Vector2 stat_velocity;
    public int run = 0;


    Rigidbody2D player_rig;

    // Start is called before the first frame update
    void Start()
    {
        player_rig = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        onMovemnet();
    }

    void FixedUpdate()
    {
        
    }

    void onMovemnet()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D down");
            player_rig.velocity = stat_velocity;
            
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D up");
            player_rig.velocity = Vector2.zero;
        }
    }
}
