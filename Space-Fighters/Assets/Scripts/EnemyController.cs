using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
    public float speedHorizontal;
    public float speedVertical;
    public int upperRandomRange;
    // Update is called once per frame
    void Update()
    {
        float xTransition = speedHorizontal * Time.deltaTime;
        float yTransition = speedVertical * Time.deltaTime;

        transform.Translate(new Vector3(xTransition, yTransition, 0), Space.Self);
        if (!Pause.gameIsPaused)
        {
            int random = Random.Range(1, upperRandomRange);
            if (random == 1)
            {
                soundHub.PlayEnemyShootSound();
                GameObject projectile = Instantiate(projectilePrefab);

                projectile.transform.position = this.gameObject.transform.GetChild(0).transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ceiling") || collider.CompareTag("Ground"))
        {
            speedVertical *= -1;
        }
        if(collider.CompareTag("Player"))
        {
            soundHub.PlayExplosionSound();
            Transform explosion = Instantiate(explosionPrefab);
            explosion.position = this.transform.position;
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
            gameState.LoadGameOver();
        }
    }
}
