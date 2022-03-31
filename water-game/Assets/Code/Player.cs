using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour, IPlayer
{
    public static Player Instance;
    public PowerUp currentPowerUp { get; set; }

    [SerializeField] private Rigidbody2D playerRigidbody;

    public Collider2D playerCollider;

    private Vector3 startPos;

    private void Start()
    {
        Instance = this;
        startPos = transform.position;
    }

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DamagePlayer()
    {
        FindObjectOfType<AudioManager>().Play("HitSound");
        KillPlayer();
    }

    public void KillPlayer()
    {
        transform.position = startPos;
        playerRigidbody.velocity = Vector2.zero;
    }
}