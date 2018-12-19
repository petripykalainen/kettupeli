using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    private AudioPlayer audioPickup;
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
        audioPickup = GameObject.Find("audioManager").GetComponent<AudioPlayer>();
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
                    audioPickup.playPickupAudio();
                    //itemSpawner.timer -= itemSpawner.spawnDelay;
                    if(itemButton.name != "pickup_bacon_image")
                    {
                        itemSpawner.timer = 0f;
                        itemSpawner.itemSpawned = false;
                    }
                    Destroy(gameObject);
                    break;
                }
                if (i == inventory.items.Length - 1 && inventory.items[i] == 1)
                {
                    //source.PlayOneShot(audio.inventoryAudio, 1f);
                    audioPickup.playInventoryAudio();
                    //Debug.Log("Haista paska");
                }
            }
        }

        else
        {
            if (other.CompareTag("Player")) // jotta viholliset eivät voi poimia poweruppeja pelaajan puolesta
            {
                StatUpdateOnPickUp(objectID);
                //powerSpawner.timer -= powerSpawner.spawnDelay;
                powerSpawner.timer = 0f;
                powerSpawner.itemSpawned = false;
                Destroy(gameObject);
            }
        }
    }
    public void StatUpdateOnPickUp(int objectID)
    {

        switch (objectID)
        {
            case 1:
                audioPickup.playDamageAudio();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().DamageBoost();
                break;

            case 2:
                audioPickup.playSpeedAudio();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SpeedBoost(5f);
                break;

            case 3:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().ShieldActivation();
                break;

            default:
                //Debug.Log("Default case");
                break;
        }
    }

}
