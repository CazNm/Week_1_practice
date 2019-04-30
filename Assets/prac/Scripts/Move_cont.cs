using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_cont : MonoBehaviour
{
    Rigidbody2D char_rig;
    Animator char_ani;
    int run = 0;
    // Start is called before the first frame update
    void Start()
    {
        char_rig = GetComponent<Rigidbody2D>(); //AddForce(Vector2 force)  new Vector2(0.0f, 0.0f)
        char_ani = GetComponent<Animator>(); //SetBool(Str name, bool now_state)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)){
            char_ani.SetBool("run", true);
            char_ani.SetBool("state", false);
            run = 1;
        }
        if (Input.GetKeyUp(KeyCode.D)){
            char_ani.SetBool("run", false);
            char_ani.SetBool("state", true);
            run = 0;
        }
    }

    // bool Input.GetKey() , GetKeyDown() GetKeyUp()  Keycode.D 
    private void FixedUpdate()
    {
        if(run == 1) {
            char_rig.AddForce(new Vector2(30.0f, 0.0f));
        }
        else { char_rig.AddForce(Vector2.zero); }
    }
}


