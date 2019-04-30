using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_test : MonoBehaviour
{
    // Start is called before the first frame update
    public void destroy_me()
    {
        Destroy(this.gameObject);
    }

    public void start_Game()
    {
        SceneManager.LoadScene("Week1_complete");
    }
}
