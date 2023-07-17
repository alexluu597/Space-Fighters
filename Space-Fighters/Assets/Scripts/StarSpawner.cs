using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public int upperRandomRange;

    const float xPosition = 19.5f;
    const float minYPosition = -7.2f;
    const float maxYPosition = 7.2f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, .2f);
    }
    private void Update()
    {
        if (!Pause.gameIsPaused)
        {
            int randomSpawn = Random.Range(1, upperRandomRange);
            if (randomSpawn == 1)
            {
                GameObject star = Instantiate(starPrefab);

                int randomPosition = Random.Range((int)minYPosition, (int)maxYPosition);
                star.transform.position = new Vector3(xPosition, randomPosition, 0);
            }
        }
    }
}
