using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    private AudioPlayer audio;
    private AudioSource source;
    public GameObject itemButton;
    public GameObject effect;

    private void Start()
    {
        //source = GetComponent<AudioSource>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        audio = GameObject.Find("audioManager").GetComponent<AudioPlayer>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // spawn the sun button at the first available inventory slot ! 

            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                { // check whether the slot is EMPTY
                    Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    audio.playPickupAudio();
                    Destroy(gameObject);
                    break;
                }
                if (i == inventory.items.Length - 1 && inventory.items[i] == 1) {
                    //source.PlayOneShot(audio.inventoryAudio, 1f);
                    audio.playInventoryAudio();
                    Debug.Log("Haista paska");
                }
            }
        }

    }

}
