using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{


    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    int _score = 0000000;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("current score is " + _score);
        }
    }
    int _coin = 0;
    public int coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            Debug.Log("current score is " + _score);
        }
    }
    public int maxLives = 3;
    int _lives;


    public int lives
    {
        get { return _lives; }
        set
        {
            if(_lives > value)
            {
                SpawnPlayer(currentLevel.spawnLocation);
            }
            _lives = value;
            if (_lives >maxLives)
            {
                _lives = maxLives;
            }
            
            else if (_lives < 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            Debug.Log("current lives is " + _lives);
        }
    }
    public double  Timer = 120.0;
    

    // Start is called before the first frame update
    void Start()
    {

        if (instance)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
       
        
    }

    public GameObject playerPrefab;
    public LevelManager currentLevel;
    
    // Update is called once per frame
    void Update()
    {
       if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if(Timer < 0)
        {
            Timer = 0;
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("TitleScreen");

            }
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                
                SceneManager.LoadScene("Level1");
                
            }
            else if (SceneManager.GetActiveScene().name == "GameOver")
            {
                _lives = 3;
                _score = 0000000;
                Timer = 120.0;
                SceneManager.LoadScene("TitleScreen");
            }

        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
        }
      
        
        
    }
    public void SpawnPlayer(Transform spawnLocation)
    {
        EnemyTurrent turrentEnemy = FindObjectOfType<EnemyTurrent>();
        CameraFollow2D mainCamera = FindObjectOfType<CameraFollow2D>();
        if (mainCamera)
        {
            mainCamera.player = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);

            if (turrentEnemy)
            {
                turrentEnemy.player = mainCamera.player;
            }

        }
        else
        {
            SpawnPlayer(spawnLocation);
        }

    }
    public void StartGame()
    {
       
        SceneManager.LoadScene("Level1");
       
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("TitleScreen");

    }
    
}
