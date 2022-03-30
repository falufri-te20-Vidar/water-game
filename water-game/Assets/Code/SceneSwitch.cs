using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private int thisLevel; //Keeps track of which level the player is on
    public Transform Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            SceneManager.LoadScene(thisLevel); //Changes level depending on what level the player is on
        }
    }
}
