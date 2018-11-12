using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    [SerializeField] GameObject guard;
    Enemy enemy;

    // Use this for initialization
    void Start()
    {
        enemy = guard.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StopChase()
    {
        yield return new WaitForSeconds(2);
        enemy.SetTarget(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.SetTarget(other.transform);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StopChase());
        }
    }



}
