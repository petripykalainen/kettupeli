using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    private Inventory inventory;
    public AudioClip pickupAudio;
    public AudioClip inventoryAudio;
    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playInventoryAudio()
    {
        source.PlayOneShot(inventoryAudio, 1f);
    }
    public void playPickupAudio()
    {
        source.PlayOneShot(pickupAudio, 1f);
    }
}
