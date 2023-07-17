using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudScore : MonoBehaviour
{
    GameState gameState;

    private void Awake()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText("" + gameState.score);
    }
}
