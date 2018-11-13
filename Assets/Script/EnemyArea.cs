using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    [SerializeField] GameObject guard;
    bool occupied = false;
    Enemy enemy;

    // Use this for initialization
    void Start()
    {
        enemy = guard.GetComponent<Enemy>();
    }

    // Update is called once per frame

    IEnumerator StopChase()
    {
        float wait = Random.Range(0.6f, 2f);

        yield return new WaitForSeconds(wait);

        if (!occupied)
        {
            enemy.SetTarget(null);
            Debug.Log("Chase Target reset");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.SetTarget(other.transform);
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
