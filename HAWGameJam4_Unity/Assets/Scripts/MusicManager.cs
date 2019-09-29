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
    float transitionTime = 0.4f;

    public AudioSource endSoundSource;

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
    
    public void PlayEndSound(){
        endSoundSource.Play();
    }
    
}
