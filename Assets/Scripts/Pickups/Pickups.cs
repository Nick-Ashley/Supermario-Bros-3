using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickups : MonoBehaviour
{
    public AudioSource audioSourceCoin;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (currentCollectible)
        {
            case CollectibleType.FLOWER:
                Debug.Log("Flower");
                collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                Destroy(gameObject);
                break;
            case CollectibleType.RLEAF:
                Debug.Log("Rleaf");
                GameManager.instance.lives++;
                
                Destroy(gameObject);
                break;
            case CollectibleType.RMUSHROOM:
                Debug.Log("Rmushroom");
                CanvisManager canvisManager = FindObjectOfType<CanvisManager>();
                canvisManager.MushroomImage.SetActive(true);
                GameManager.instance.score++;
                Destroy(gameObject);
                break;
            case CollectibleType.GLEAF:
                Debug.Log("Gleaf");
                GameManager.instance.score++;
                Destroy(gameObject);
                break;
            case CollectibleType.COIN:
                Debug.Log("Coin");
                audioSourceCoin.Play();
                GameManager.instance.score++;
                collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                Destroy(gameObject);
                break;
            case CollectibleType.STAR:
                Debug.Log("Star");
                GameManager.instance.score++;
                Destroy(gameObject);
                break;
        }
    }

    private static void NewMethod(CanvisManager canvisManager)
    {
        canvisManager.ShowMushromImage();
    }
}
