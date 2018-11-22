using UnityEngine;
using System.Collections;

public class MinimapCamera : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, player.transform.position.z + offset.z);
    }
}