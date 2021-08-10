using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hp_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hp_container;


    public GameObject[] hp_bar;
    private GameObject hp_cont;
    public int current_hp = 110;
    void Start()
    {
        hp_bar = new GameObject [11];
        //hp_container = Resources.Load("Image") as GameObject;
        for (int x = 0; x < hp_bar.Length; x++) { 
            hp_bar[x] = hp_container;
            hp_cont = Instantiate(hp_bar[x], new Vector3(120.0f+(40.0f*x), 959.0f, 0.0f), Quaternion.identity);
            hp_cont.SendMessage("input_number", x);
            hp_bar[x] = hp_cont;
            GameObject some = GameObject.Find("hp_manager");
            hp_cont.GetComponent<Transform>().SetParent(some.transform);

            var getRectPosition = hp_cont.GetComponent<RectTransform>();
            hp_cont.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 + (40.0f * x), -50);

            }
    }

    // Update is called once per frame
    void Update()
    {
        current_hp = current_hp / 10;
        if(current_hp == 0) { SceneManager.LoadScene("End"); }
    }

    void Health (int health) {
        current_hp = health;
    }

    void onDamage(int x)
    {
        Destroy(hp_bar[x]);
    }
}
