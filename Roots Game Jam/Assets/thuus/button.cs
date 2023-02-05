using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class button : MonoBehaviour
{
    public GameObject text;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    // Start is called before the first frame update
    public void Resetlevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void Awake()
    {
        if (SceneManager.GetActiveScene().name != "tutorial")
        {
            text.SetActive(false);
        }
    }
    public void Next()
    {
        if (SceneManager.GetActiveScene().name == "tutorial")
        {
            if (text2.gameObject.activeSelf)
            {
                text.SetActive(false);
                return;
            }
            if (text1.gameObject.activeSelf)
            {
                text1.gameObject.SetActive(false);
                text2.gameObject.SetActive(true);
            }
        }
        
    }
}
