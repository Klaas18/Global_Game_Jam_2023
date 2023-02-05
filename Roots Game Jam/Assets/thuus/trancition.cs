using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trancition : MonoBehaviour
{
    public string scene;
    public Animator animate;
    public Animator animator;
    public GameObject player;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.GetComponent<PlayerController>().speed = 0;
        StartCoroutine(PlayerAnimation()); 

    }
    IEnumerator PlayerAnimation()
    {
        animator.SetBool("tree", true);
        yield return new WaitForSeconds(4);
        StartCoroutine(Waitbeforedestroyy());
    }

    IEnumerator Waitbeforedestroyy()
    {
        animate.SetBool("transition", true);
        yield return new WaitForSeconds(3);
        Debug.Log("z");
        SceneManager.LoadScene(scene);
    }

}
