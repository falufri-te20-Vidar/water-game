using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private int thisLevel; //Keeps track of which level the player is on
    public Animator animator;
    private float timer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            animator.SetBool("Open", true);      
        }
    }

    private void Update()
    {
        if (animator.GetBool("Open") == true)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                SceneManager.LoadScene(thisLevel); //Changes level depending on what level the player is on
                animator.SetBool("Open", false);
                timer = 0f;
            }
        }

    }
}
