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
        Instantiate(powerUpPrefab, player.transform.position, Quaternion.identity, null);
    }
}