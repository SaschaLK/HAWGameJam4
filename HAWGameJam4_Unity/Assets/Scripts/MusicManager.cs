using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerSnapshot animeMusic;
    public AudioMixerSnapshot chiptuneMusic;
    public AudioMixerSnapshot shittyFluteMusic;
    public AudioMixerSnapshot soundfontMusic;
    float transitionTime = 0.4;

    public void TransitionToAnime() {
        animeMusic.TransitionTo(transitionTime);
    }

    public void TransitionToChiptune() {
        chiptuneMusic.TransitionTo(transitionTime);
    }

    public void TransitionToShittyFlute() {
        shittyFluteMusic.TransitionTo(transitionTime);
    }

    public void TransitionToSoundFont() {
        soundfontMusic.TransitionTo(transitionTime);
    }
    
    //only for testing
    void Update() {
        if (Input.GetKey("up")) {
            TransitionToAnime();
        }
        if (Input.GetKey("left")) {
            TransitionToChiptune();
        }
        if (Input.GetKey("right")) {
            TransitionToShittyFlute();
        }
        if (Input.GetKey("down")) {
            TransitionToSoundFont();
        }
    }

}
