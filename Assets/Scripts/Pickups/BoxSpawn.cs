using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public Pickups[] pickuplist;
    private bool isQbox = false;

    public void StartBoxSpawn()
    {

        Instantiate(pickuplist[Random.Range(0, pickuplist.Length)].gameObject, transform.position, Quaternion.identity);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            isQbox = true;
            Debug.Log("Spawn Stuff");
            StartCoroutine(qboxDelay());
           // StartBoxSpawn();


        }
    }

    IEnumerator qboxDelay()
    {
        isQbox = true;
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.5f);
        isQbox = false;
        StartBoxSpawn();
        Destroy(gameObject);
    }
    
}
