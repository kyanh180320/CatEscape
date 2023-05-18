using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool stateGame;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetStateGame(bool state)
    {
        stateGame = state;
    }
    public bool GetStateGame()
    {
        return stateGame;   
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }


}
