using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    bool occupied = false;
    GameObject enemyObject;
    Enemy enemy;

    // Use this for initialization
    void Start()
    {
        enemyObject = transform.parent.gameObject;
        enemy = enemyObject.GetComponent<Enemy>();
    }

    // Update is called once per frame

    IEnumerator StopChase()
    {
        float wait = Random.Range(0.6f, 2f);

        yield return new WaitForSeconds(wait);

        if (!occupied)
        {
            
            Debug.Log("Chase Target reset");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            occupied = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            occupied = false;
            StartCoroutine(StopChase());
        }
    }



}
