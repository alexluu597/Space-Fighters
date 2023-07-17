using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speedHorizontal;

    // Update is called once per frame
    void Update()
    {
        float xTransition = speedHorizontal * Time.deltaTime;
        transform.Translate(new Vector3(-xTransition, 0, 0), Space.Self);
    }
}
