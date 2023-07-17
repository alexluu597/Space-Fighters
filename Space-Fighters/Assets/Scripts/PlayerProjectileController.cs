using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    SoundHub soundHub;
    GameState gameState;
    private void Awake()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
    }

    public Transform explosionPrefab;
    public float speed;
    public Vector3 direction;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            soundHub.PlayExplosionSound();
            Transform explosion = Instantiate(explosionPrefab);
            explosion.position = this.transform.position;
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
            gameState.score += 1;
        }
        if(collider.CompareTag("EnemyProjectile"))
        {
            soundHub.PlayExplosionSound();
            Transform explosion = Instantiate(explosionPrefab);
            explosion.position = this.transform.position;
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}
