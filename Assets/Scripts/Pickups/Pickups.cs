using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickups : MonoBehaviour
{
    public AudioClip audioSourceCoin;
    AudioSource pickupAudio;
    BoxCollider2D trigger;

    // Start is called before the first frame update
    public enum CollectibleType
    {
        FLOWER,
        RMUSHROOM,
        RLEAF,
        COIN,
        QCOIN,
        GLEAF,
        STAR
    }
    public CollectibleType currentCollectible;
    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
        trigger = GetComponent<BoxCollider2D>();
        if (pickupAudio)
        {
            pickupAudio.loop = false;
            pickupAudio.clip = audioSourceCoin;
           
        }
    }
    private void Update()
    {
        if(!pickupAudio.isPlaying && !trigger.enabled)
        {
            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanvisManager canvisManager = FindObjectOfType<CanvisManager>();

        switch (currentCollectible)
        {
            case CollectibleType.FLOWER:
                Debug.Log("Flower");
                collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                GetComponent<SpriteRenderer>().sprite = null;                
                canvisManager.FlowerImage.SetActive(true);
                pickupAudio.Play();
                trigger.enabled = false;                
                break;
            case CollectibleType.RLEAF:
                Debug.Log("Rleaf");
                GameManager.instance.lives++;
                GetComponent<SpriteRenderer>().sprite = null;
                pickupAudio.Play();
                trigger.enabled = false;
                break;
            case CollectibleType.RMUSHROOM:
                Debug.Log("Rmushroom");
                GetComponent<SpriteRenderer>().sprite = null;
                canvisManager.MushroomImage.SetActive(true);
                GameManager.instance.score++;
                pickupAudio.Play();
                trigger.enabled = false;           
                break;
            case CollectibleType.GLEAF:
                Debug.Log("Gleaf");
                GameManager.instance.score+= 5;
                GetComponent<SpriteRenderer>().sprite = null;
                pickupAudio.Play();
                trigger.enabled = false;
                break;
            case CollectibleType.COIN:
                Debug.Log("Coin");
                collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                Destroy(GetComponent<Animator>());
                GetComponent<SpriteRenderer>().sprite = null;                              
                GameManager.instance.coin++;
                GameManager.instance.score++;
                pickupAudio.Play();
                trigger.enabled = false;
                
                
                break;
            case CollectibleType.STAR:
                Debug.Log("Star");
                canvisManager.StarImage.SetActive(true);
                GameManager.instance.score+=10;
                Destroy(gameObject);
                break;
        }
    }

    private static void NewMethod(CanvisManager canvisManager)
    {
        canvisManager.ShowMushromImage();
        canvisManager.ShowFlowerImage();
        canvisManager.ShowStarImage();
    }
}
