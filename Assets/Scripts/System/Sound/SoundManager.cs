using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {

    [SerializeField]
    private static SoundDatabase soundDatabase = Helper.FindAssetsByType<SoundDatabase>("Assets/Database")[0];
    private static Dictionary<string, float> soundTimer = new Dictionary<string, float>();

    public static bool CanPlaySound(string sound) {
        if(soundTimer.ContainsKey(sound)){
            if(soundTimer[sound] < Time.time) {
                soundTimer[sound] = Time.time + soundDatabase.getDelay(sound);
                return true;
            }
            return false;
        }
        soundTimer[sound] = Time.time + soundDatabase.getDelay(sound);
        return true;
    }

    public static void PlaySound(string soundName, Vector3 position) {
        if (CanPlaySound(soundName)){
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = soundDatabase.getSound(soundName);
            audioSource.Play();
        }
    }

    public static void PlaySound(string soundName) {
        if (CanPlaySound(soundName)){
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            AudioClip sound = soundDatabase.getSound(soundName);
            audioSource.PlayOneShot(sound);
        }
    }
}
