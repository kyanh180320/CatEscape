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
    [SerializeField] GameObject endGameScreen;
    int levelOrder;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        levelOrder = 1;
        string levelName = "Level/Level" + levelOrder;
        GameObject levelPrefab = Resources.Load<GameObject>(levelName);
        if (levelPrefab != null)
        {
            GameObject levelInstance = Instantiate(levelPrefab);
            // Code khởi tạo và xử lý các thành phần của LevelInstance (nếu cần)
            levelOrder++;

        }
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
        print("H");
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        
        Debug.Log("NextLevl");
        string levelName = "Level/Level" + levelOrder; // Đường dẫn tới tài nguyên Level2 (đúng tên tài nguyên và đúng đường dẫn)
        GameObject levelPrefab = Resources.Load<GameObject>(levelName);
        if (levelPrefab != null)
        {
            GameObject levelInstance = Instantiate(levelPrefab);
            // Code khởi tạo và xử lý các thành phần của LevelInstance (nếu cần)
            levelOrder++;
        }
        else
        {
            Debug.LogError("Không thể tải tài nguyên Level2 từ thư mục Resources!");
        }
        endGameScreen.SetActive(false);

    }



}
