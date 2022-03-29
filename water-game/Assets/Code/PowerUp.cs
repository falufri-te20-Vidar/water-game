using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerUp : MonoBehaviour
{
    public PowerUp powerUp;
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUp.gameObject.SetActive(false);
        player.ApplyPowerEffect(powerUp);
    }

    abstract public void Use();
}
