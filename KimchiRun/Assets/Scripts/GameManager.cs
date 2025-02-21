using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro,
    Playing,
    Dead
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state =  GameState.Intro;

    public int lives = 3;

    [Header("References")]
    public GameObject introUI;
    public GameObject enemySpawner;
    public GameObject foodSpawner;
    public GameObject goldenSpawner;
    public Player playerScript;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }   
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        introUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            state = GameState.Playing;
            introUI.SetActive(false);
            enemySpawner.SetActive(true);
            foodSpawner.SetActive(true);
            goldenSpawner.SetActive(true);
        }

        if (state == GameState.Playing && lives == 0)
        {
            playerScript.KillPlayer();
            enemySpawner.SetActive(false);
            foodSpawner.SetActive(false);
            goldenSpawner.SetActive(false);
            state = GameState.Dead;
        }

        if (state == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main");
        }
    }
}
