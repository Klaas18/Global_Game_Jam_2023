using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class pause : MonoBehaviour
{
    private void Awake()
    {
    }
    public void exit()
    {
        Application.Quit();
    }
    public void reset()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
