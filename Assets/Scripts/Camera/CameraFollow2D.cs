using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float timeOffSet;

    [SerializeField]
    Vector2 posOffSet;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;
    

    private Vector3 velocity;

    void Update()
    {
        //camera start position
        Vector3 startPos = transform.position;
        //players current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffSet.x;
        endPos.y += posOffSet.y;
        endPos.z = -10;

       
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffSet);

        //this is how you lerp
        //transform.position = Vector3.Lerp(startPos, endPos, timeOffSet * Time.deltaTime);

        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
    }
}
