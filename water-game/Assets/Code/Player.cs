using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour, IPlayer
{
    public PowerUp currentPowerUp { get; set; }

    public void ApplyPowerEffect(PowerUp powerUp)
    {
        currentPowerUp = powerUp;
    }

    public void RemovePowerEffect()
    {
        currentPowerUp = null;
    }

    public void UseEffect()
    {
        currentPowerUp.Use();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentPowerUp != null)
        {
            UseEffect();
        }
    }
}