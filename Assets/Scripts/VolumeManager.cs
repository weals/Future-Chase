using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    
    

    public void UpdateVolume(float soundLevel) {
        mixer.SetFloat("groupVol", Mathf.Log(soundLevel) * 20);
    }
}
