using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trancition : MonoBehaviour
{
    public int scene;
    public Animator animate;
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        animate.SetBool("transition", true);
        StartCoroutine(Waitbeforedestroyy());    }
    
    IEnumerator Waitbeforedestroyy()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("z");
        SceneManager.LoadScene(sceneBuildIndex: scene);
    }

}
