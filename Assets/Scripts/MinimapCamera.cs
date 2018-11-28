using UnityEngine;
using System.Collections;

public class MinimapCamera : MonoBehaviour
{

    private Transform player;
    private Vector3 offset;

    void Start()
    {
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        player = FindObjectOfType<Player>().transform;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}