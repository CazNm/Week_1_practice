using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_behavior : MonoBehaviour
{
    GameObject brick;
    GameObject manager;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        brick = GetComponent<GameObject>();
        trans = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 convert = Camera.main.WorldToScreenPoint(new Vector3(0.0f, trans.position.y, 0.0f));

        if (convert.y < 0.0f) Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hit");
    }
}
