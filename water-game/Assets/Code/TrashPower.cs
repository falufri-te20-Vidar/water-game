using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrashPower : PowerUp
{
    public GameObject powerUpPrefab;


    override public void Use()
    {
        CreateProjectile();
    }
    private void CreateProjectile()
    {
        GameObject Trashball = Instantiate(powerUpPrefab, player.transform.position, Quaternion.identity,null);
        FindObjectOfType<AudioManager>().Play("Shoot");
        if (player.GetComponent<Movement>().facingRight == true)
        {
            Trashball.GetComponent<TrashBall>().SetDirection(true);
        }
        else
        {
            Trashball.GetComponent<TrashBall>().SetDirection(false);
        }
    }
}