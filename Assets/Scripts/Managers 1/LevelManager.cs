using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int startingLives;
    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SpawnPlayer(spawnLocation);
        GameManager.instance.lives = startingLives;
        GameManager.instance.currentLevel = GetComponent<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
