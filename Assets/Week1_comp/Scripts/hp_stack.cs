using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_stack : MonoBehaviour
{
    // Start is called before the first frame update
    public int stack_number;

    // Update is called once per frame
    void Update()
    {
        
    }

    void input_number(int x) {
        stack_number = x;
    }
}
