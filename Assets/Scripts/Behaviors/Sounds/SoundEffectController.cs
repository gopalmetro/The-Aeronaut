using UnityEngine;
using System.Collections;

public class SoundEffectController : MonoBehaviour {

    public AudioClip pop;


    void Start() {
        DontDestroyOnLoad(this);
        NotificationCenter.defaultCenter.addListener(BalloonPopSoundEffect, NotificationType.BalloonPop);
    }
	
	// Update is called once per frame
	void BalloonPopSoundEffect(Notification note){
        audio.PlayOneShot(pop);
	}
}
