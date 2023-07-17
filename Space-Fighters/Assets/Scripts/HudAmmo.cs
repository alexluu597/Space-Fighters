using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudAmmo : MonoBehaviour
{
    GameState gameState;
    private void Awake()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText("Ammo: " + gameState.ammo);
    }
}
