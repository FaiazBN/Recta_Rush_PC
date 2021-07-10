using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] float scoreEachKill = 11f;
    [SerializeField] float highScoreForOne = 100f;
    [SerializeField] float currentScore = 0f;

    EnemyBar enemyBar;
    int currentScene;
    Player player;
    void Start()
    {
        enemyBar = FindObjectOfType<EnemyBar>();
        enemyBar.SetMaxScoreToPassLevel(highScoreForOne);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        SceneLoader();
    }

    private void SceneLoader()
    {
        if (currentScore >= highScoreForOne)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(player.ReturnPlayerHealth() <= 0)
        {
            StartCoroutine(DelayBeforeLoad());
        }
    }
    private IEnumerator DelayBeforeLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(7);
    }

    public void AddtoScore()
    {
        currentScore += scoreEachKill;
        enemyBar.SetScore(currentScore);
    }
    

}
