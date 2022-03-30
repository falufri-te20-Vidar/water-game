using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerUp : MonoBehaviour
{
    public PowerUp powerUp;
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            powerUp.gameObject.SetActive(false);
            player.ApplyPowerEffect(powerUp);
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }

    abstract public void Use();
}
