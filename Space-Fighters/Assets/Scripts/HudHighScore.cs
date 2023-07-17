using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudHighScore : MonoBehaviour
{
    GameState gameState;

    private void Awake()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText("High Score: " + gameState.highScore);
    }
}
