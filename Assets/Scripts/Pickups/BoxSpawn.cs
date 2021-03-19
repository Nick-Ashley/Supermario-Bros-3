using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class BoxSpawn : MonoBehaviour
{
   
   
    public Pickups[] pickuplist;
    private bool isQbox = false;

    public AudioClip audioSourceBoxSpawn;
    AudioSource boxSpawnAudio;

    public void StartBoxSpawn()
    {

        Instantiate(pickuplist[Random.Range(0, pickuplist.Length)].gameObject, transform.position , Quaternion.identity);
       // gameObject.AddForce(Vector2.up * Time.deltaTime);
    }
    public void Start()
    {
        boxSpawnAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<PlayerMovement>() && other.contacts[0].normal.y > 0.5f)
        {
            isQbox = true;
            Debug.Log("Spawn Stuff");
            boxSpawnAudio.loop = false;
            boxSpawnAudio.clip = audioSourceBoxSpawn;
            boxSpawnAudio.Play();
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
