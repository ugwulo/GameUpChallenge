using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public static int numPassedRings;
    public Slider gameProgressSlider;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;

    public static bool isGameOver;
    public static bool isLevelCompleted;
    public static bool isMuted = false;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        numPassedRings = 0;
        isGameOver = isLevelCompleted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // update UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex +1).ToString();

        int progress = numPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level 1");
            }
        }

        if (isLevelCompleted)
        {
            levelCompletedPanel.SetActive(true);
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex +1);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level 1");
            }
        }
    }
}
