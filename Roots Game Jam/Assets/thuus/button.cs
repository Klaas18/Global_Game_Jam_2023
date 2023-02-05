using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public GameObject text;
    public bool yes;
    // Start is called before the first frame update
    void Start()
    {
        if (yes == false)
        {
            text.SetActive(false);
            yes = true;
        }
        else yes = false;
    }

    public void Resetlevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void Closetext()
    {
        if(yes == false)
        {
            text.SetActive(false);
            yes = true;
        }
        else if (yes == true)
        {
            text.SetActive(true);
            yes = false;
        }
       
        

    }
}
