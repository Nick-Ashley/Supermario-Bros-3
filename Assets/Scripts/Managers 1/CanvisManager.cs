using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvisManager : MonoBehaviour
{
    [Header ("Buttons")]
    public Button startButton;
    public Button quitbutton;
    public Button BackToMenubutton;
    public Button returnToGamebutton;
    public Button returnToMenubutton;
    public Button Settingsbutton;
    public Button SettingsbuttonPause;
    public Button BackToPausebutton;
    [Header("Text")]
    public Text LivesText;
    public Text ScoreText;
    public Text VolText;
    public Text TimeText;
    public Text PauseVolText;
    [Header("Menus")]
    public GameObject PauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseSettingsMenu;

    [Header("Sliders")]
    public Slider Vslider;
    public Slider PauseVslider;
    public int volume;
    [Header("Powerup")]
    public GameObject MushroomImage;

    public static bool IsGamePaused = false;
    public static bool IsMushroom = true;
    // Start is called before the first frame update
    void Start()
    {
       


        


        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
        }
        if (quitbutton)
        {

            quitbutton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }
        if (returnToGamebutton)
        {
            returnToGamebutton.onClick.AddListener(() => Resume());
            if (returnToMenubutton)
            {
                returnToMenubutton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());

            }
                                

        }
        if (BackToMenubutton)
        {
            BackToMenubutton.onClick.AddListener(() => ShowMainMenu());
        }
        if (Settingsbutton)
        {
            Settingsbutton.onClick.AddListener(() => ShowSettingsMenu());
        }
        if (SettingsbuttonPause)
        {
            SettingsbuttonPause.onClick.AddListener(() => ShowSettingsMenuPause());
        }
        if (BackToPausebutton)
        {
            BackToPausebutton.onClick.AddListener(() => ShowPauseMenuPause());
        }
    }
        // Update is called once per frame
    void Update()
    {
        if (MushroomImage)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                MushroomImage.SetActive(!MushroomImage.activeSelf);
                
            }
        }

            if (LivesText)
            {
                LivesText.text = GameManager.instance.lives.ToString();
            }

            if (ScoreText)
            {
                ScoreText.text = GameManager.instance.score.ToString();
            }
            if (TimeText)
            {
                TimeText.text = GameManager.instance.Timer.ToString();
            }

        if (PauseMenu)
        {
                if (Input.GetKeyDown(KeyCode.P))
                {


                    if (IsGamePaused)
                    {
                        Resume();

                    }
                    else
                    {
                        PauseGame();
                    }
                }
        }
            if (settingsMenu)
            {
                if (settingsMenu.activeSelf)
                {
                VolText.text = (Vslider.value * 100).ToString();

                    //VolText.text = Vslider.value.ToString();
                }
            }
        if (pauseSettingsMenu)
        {
            if (pauseSettingsMenu.activeSelf)
            {
                PauseVolText.text = (PauseVslider.value * 100).ToString();

                //VolText.text = Vslider.value.ToString();
            }
        }
    }

        void Resume()
        {
            PauseMenu.SetActive(false);
            IsGamePaused = false;
            Time.timeScale = 1f;
        }
        void PauseGame()
        {
            IsGamePaused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }


        void ShowMainMenu()
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);

        }
        void ShowSettingsMenu()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        void ShowSettingsMenuPause()
        {
             PauseMenu.SetActive(false);
             pauseSettingsMenu.SetActive(true);
        }
         void ShowPauseMenuPause()
         {
             PauseMenu.SetActive(true);
             pauseSettingsMenu.SetActive(false);
         }
         public void ShowMushromImage()
         {

            IsMushroom = true;
            MushroomImage.SetActive(true);
                  
                   
           
         }
         public void NoMushromImage()
         {

           IsMushroom = false;
           MushroomImage.SetActive(false);



         }
}

