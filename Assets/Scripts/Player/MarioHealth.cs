using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioHealth : MonoBehaviour
{
    public int lives;
    public int numOfMario;
    public Image[] marioHealth;
    public Sprite fullMario;
    public Sprite emptyMario;
    // Start is called before the first frame update
    void Start()
    {
        lives = GameManager.instance.lives;
    }

    // Update is called once per frame
    void Update()
    {

        
        
            if (GameManager.instance.lives > numOfMario)
            {
            GameManager.instance.lives = numOfMario;
            }

            for (int i = 0; i < marioHealth.Length; i++)
            {
                if (i < GameManager.instance.lives)
                {
                    marioHealth[i].sprite = fullMario;
                }
                else
                {
                    marioHealth[i].sprite = emptyMario;
                }

                if (i < numOfMario)
                {
                    marioHealth[i].enabled = true;

                }
                else
                {
                    marioHealth[i].enabled = false;
                }
            }
        
    }
}
