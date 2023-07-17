using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SoundHub soundHub;
    GameState gameState;
    private void Awake()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
    }

    public Transform explosionPrefab;
    public GameObject projectilePrefab;
    public float speedVertical;

    protected bool canShoot;
    
    private void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        float yTransition = speedVertical * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, yTransition, 0), Space.Self);

        if (!Pause.gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canShoot)
            {
                soundHub.PlayPlayerShootSound();
                GameObject projectile = Instantiate(projectilePrefab);

                projectile.transform.position = this.gameObject.transform.GetChild(0).transform.position;
                gameState.ammo--;
            }
            if (gameState.ammo <= 0)
            {
                canShoot = false;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameState.ammo = 5;
                canShoot = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Ceiling") || collider.CompareTag("Ground") || collider.CompareTag("Obstacle"))
        {
            soundHub.PlayExplosionSound();
            Transform explosion = Instantiate(explosionPrefab);
            explosion.position = this.transform.position;
            Destroy(this.gameObject);
            gameState.LoadGameOver();
        }
        if(collider.CompareTag("Scorer"))
        {
            soundHub.PlayScoreSound();
            gameState.score += 1;
        }
    }
}
