using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planetPrefab;

    protected float timerMillis;

    const float MaxTimerMillis = 500f;
    const float xPosition = 24f;
    const float minYPosition = -8.8f;
    const float maxYPosition = 8.8f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, .2f);
    }
    private void Update()
    {
        if (!Pause.gameIsPaused)
        {
            timerMillis += 1f;
            if (timerMillis >= MaxTimerMillis)
            {
                int randomPlanet = Random.Range(0, planetPrefab.Length);
                GameObject planet = Instantiate(planetPrefab[randomPlanet]);

                int randomPosition = Random.Range((int)minYPosition, (int)maxYPosition);
                planet.transform.position = new Vector3(xPosition, randomPosition, 0);
                timerMillis = 0;
            }
        }
    }
}
