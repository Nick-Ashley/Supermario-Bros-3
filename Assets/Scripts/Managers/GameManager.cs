using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;



public class GameManager : MonoBehaviour
{
    

    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }
    int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("current score is " + _score);
        }
    }
    public int maxLives = 3;
    int _lives = 3;
    public int lives
    {
        get { return _lives; }
        set
        {
            if(_lives > value)
            {
                
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

    // Update is called once per frame
    void Update()
    {
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
                _score = 0;
                SceneManager.LoadScene("TitleScreen");
            }

        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
