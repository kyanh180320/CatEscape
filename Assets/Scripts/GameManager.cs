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
    [SerializeField] GameObject continueGameDisplay, replayGameDisplay;
    int levelOrder;
    GameObject currentLevel;
    GameObject tempLevel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        if (PlayerPrefs.HasKey("levelOrder"))
        {
            levelOrder = PlayerPrefs.GetInt("levelOrder");
        }
        else
        {
            levelOrder = 1;
        }
        LoadCurrentLevel();
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
    //public void ReplayGame()
    //{
    //    print("H");
    //    SceneManager.LoadScene(0);
    //}
    public void NextLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        continueGameDisplay.gameObject.SetActive(false);
        levelOrder++;
        PlayerPrefs.SetInt("levelOrder", levelOrder);
        LoadCurrentLevel();

    }
    public void Replaylevel()
    {
        replayGameDisplay.SetActive(false);
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        LoadCurrentLevel();
    }
    public void LoadCurrentLevel()
    {
        string levelName = "Level/Level" + levelOrder;
        GameObject levelPrefabs = Resources.Load<GameObject>(levelName);
        if (levelPrefabs != null)
        {
            currentLevel = Instantiate(levelPrefabs);
        }
        else
        {
            Debug.LogError("Loi khong load dc level tu Resources");
        }
    }
    public void ResetGame()
    {
        Destroy(currentLevel);
        PlayerPrefs.DeleteKey("levelOrder");
        levelOrder = 1;
        LoadCurrentLevel();
    }




}
