using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;


    [SerializeField]
    private GameObject gameOverPanel;


    private int coin = 0;


    [HideInInspector]
    public bool isGameOver = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        if (coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade();
            }

        }
    }


    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner enemySpawner = FindAnyObjectByType<EnemySpawner>();


        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();

        }

        Invoke(nameof(ShowGameOverPanel), 1f);

    }


    void ShowGameOverPanel()
    {

        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

}