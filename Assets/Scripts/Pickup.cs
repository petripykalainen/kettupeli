using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    private AudioPlayer audio;
    private AudioSource source;
    public GameObject itemButton;
    public GameObject effect;
    public int objectID;
    GameObject player;
    PlayerHealth playerHealth;
    ItemSpawner powerSpawner;
    ItemSpawner itemSpawner;
    

    private void Start()
    {
        itemSpawner = GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>();
        powerSpawner = GameObject.Find("PowerSpawner").GetComponent<ItemSpawner>();

        //source = GetComponent<AudioSource>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        audio = GameObject.Find("audioManager").GetComponent<AudioPlayer>();
        source = GetComponent<AudioSource>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        
    }

    public void Update()
    {       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.tag != "Powerup")
        {
            // spawn the sun button at the first available inventory slot ! 

            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                { // check whether the slot is EMPTY
                    Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    StatUpdateOnPickUp(objectID);
                    audio.playPickupAudio();
                    itemSpawner.itemSpawned = false;
                    Destroy(gameObject);
                    break;
                }
                if (i == inventory.items.Length - 1 && inventory.items[i] == 1)
                {
                    //source.PlayOneShot(audio.inventoryAudio, 1f);
                    audio.playInventoryAudio();
                    //Debug.Log("Haista paska");
                }
            }
        }

        else
        {
            if (other.CompareTag("Player")) // jotta viholliset eivät voi poimia poweruppeja pelaajan puolesta
            {
                StatUpdateOnPickUp(objectID);
                Destroy(gameObject);
            }
        }
    }
    public void StatUpdateOnPickUp(int objectID)
    {

        switch (objectID)
        {
            case 1:

                playerHealth.TakeDamage(-20);
                break;

            case 2:
                audio.playSpeedAudio();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SpeedBoost(5f);
                break;

            case 3:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().ShieldActivation();
                break;

            default:
                Debug.Log("Default case");
                break;
        }
        powerSpawner.itemSpawned = false;
    }

}
