using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject topObstaclePrefab;
    public GameObject bottomObstaclePrefab;
    public GameObject addScorePrefab;

    public int scale;

    protected float timerMillis;

    const float MaxTimerMillis = 125f;
    const float xPosition = 20f;
    const float minYPosition = -8.8f;
    const float maxYPosition = 8.8f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, .2f);
    }

    private void Update()
    {
        if (!Pause.gameIsPaused)
        {
            timerMillis += 1f;
            if (timerMillis >= MaxTimerMillis)
            {
                GameObject topObstacle = Instantiate(topObstaclePrefab);
                topObstacle.transform.position = new Vector3(xPosition, maxYPosition, 0);

                GameObject bottomObstacle = Instantiate(bottomObstaclePrefab);
                bottomObstacle.transform.position = new Vector3(xPosition, minYPosition, 0);

                GameObject addScore = Instantiate(addScorePrefab);
                addScore.transform.position = new Vector3(xPosition, 0, 0);

                int randomScale = Random.Range(0, 14);
                int randomObstacle = Random.Range(0, 2);

                if (randomObstacle == 0)
                {
                    topObstacle.transform.localScale = new Vector3(1, scale - randomScale, 1);
                    bottomObstacle.transform.localScale = new Vector3(1, scale + randomScale, 1);
                }
                else if (randomObstacle == 1)
                {
                    topObstacle.transform.localScale = new Vector3(1, scale + randomScale, 1);
                    bottomObstacle.transform.localScale = new Vector3(1, scale - randomScale, 1);
                }

                timerMillis = 0;
            }
        }
    }
}
