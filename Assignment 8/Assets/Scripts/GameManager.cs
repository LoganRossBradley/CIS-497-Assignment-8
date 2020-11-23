//Logan Ross
//Assignment 8
//Keeps track of all of the UI along with tracking/updating the score

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtGameOver;
    public Button btnRestart;

    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    public GameObject TitleScreen;
  
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            //wait 1 sec
            yield return new WaitForSeconds(spawnRate);

            //pick random index between 0 and num prefabs
            int index = Random.Range(0, targets.Count);

            //spawn object
            Instantiate(targets[index]);

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        txtScore.text = "Score: " + score;
    }

    public void GameOver()
    {
        txtGameOver.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(true);
        isGameActive = false;
    }

}
