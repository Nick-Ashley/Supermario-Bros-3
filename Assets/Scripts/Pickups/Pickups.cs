using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
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
                collision.GetComponent<PlayerMovement>().lives++;
                Destroy(gameObject);
                break;
            case CollectibleType.RMUSHROOM:
                Debug.Log("Rmushroom");
                collision.GetComponent<PlayerMovement>().score++;
                Destroy(gameObject);
                break;
            case CollectibleType.GLEAF:
                Debug.Log("Gleaf");
                collision.GetComponent<PlayerMovement>().score++;
                Destroy(gameObject);
                break;
            case CollectibleType.COIN:
                Debug.Log("Coin");
                collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                Destroy(gameObject);
                break;
            case CollectibleType.STAR:
                Debug.Log("Star");
                collision.GetComponent<PlayerMovement>().score++;
                Destroy(gameObject);
                break;
        }
    }

}
