using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerUp : MonoBehaviour
{
    public PowerUp powerUp;
    public Player playerCode;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerCode = player.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            powerUp.gameObject.SetActive(false);
            playerCode.ApplyPowerEffect(powerUp);
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }

    abstract public void Use();
}
