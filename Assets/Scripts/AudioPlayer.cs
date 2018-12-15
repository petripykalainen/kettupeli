using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    private Inventory inventory;
    public AudioClip pickupAudio;
    public AudioClip inventoryAudio;
    public AudioClip baconAudio;
    public AudioClip speedAudio;
    public AudioClip igniteAudio;
    public AudioClip explosionAudio;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stop()
    {
        source.Stop();
    }

    public void playInventoryAudio()
    {
        source.PlayOneShot(inventoryAudio, 1f);
    }
    public void playPickupAudio()
    {
        source.PlayOneShot(pickupAudio, 1f);
    }
    public void playBaconAudio()
    {
        source.PlayOneShot(baconAudio, 1f);
    }
    public void playSpeedAudio()
    {
        source.PlayOneShot(speedAudio, 1f);
    }
    public void playIgniteAudio()
    {
        source.PlayOneShot(igniteAudio, 1f);
    }
    public void playExplosionAudio()
    {
        source.PlayOneShot(explosionAudio, 1f);
    }
}
