using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomGiveAP : FSM
{
    private AudioClip gainAPAudioClip;
    private AudioSource audioSource;

    public TileRandomGiveAP(AudioSource audio, AudioClip clip) {
        audioSource = audio;
        gainAPAudioClip = clip;

        audioSource.PlayOneShot(gainAPAudioClip);
    }

    override public bool update() {
        // TODO: sounds would be nice
        return true;
    }
}
