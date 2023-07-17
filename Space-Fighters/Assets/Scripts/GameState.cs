using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public int score;
    public int highScore;
    public string messsage;
    public int ammo;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameState");
        if (objs.Length > 1)
        {
            //I'm not unique, destroy myself
            Destroy(this.gameObject);
        }
        //I'm the only one, make sure I survive between scenes
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        if(score > highScore)
        {
            highScore = score;
        }
        messsage = "Game Over";
        SceneManager.LoadScene(0);
    }
}
