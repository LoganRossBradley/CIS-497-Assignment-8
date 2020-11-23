//Logan Ross
//Assignment 8
//makes it so menu buttons effect rate that items spawn at

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gm;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        gm.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
