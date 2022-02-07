using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New SoundDatabase", menuName = "VIA2.0/SoundDatabase")]
public class SoundDatabase : Database
{
    [SerializeField]
    Sound[] sounds;

    Dictionary<string, AudioClip> soundDic;
    Dictionary<string, float> delayDic;

    public AudioClip getSound(string name) {
        return soundDic[name];
    }

    public float getDelay(string name) {
        return delayDic[name];
    }

    #if UNITY_EDITOR
    private void setDictionary()
    {
        soundDic = new Dictionary<string, AudioClip>();
        foreach (Sound sound in sounds) {
            soundDic.Add(sound.Name, sound.SoundFile);
        }
        delayDic = new Dictionary<string, float>();
        foreach (Sound sound in sounds) {
            delayDic.Add(sound.Name, sound.Delay);
        }
    }

    protected override void LoadItems()
    {
        sounds = Helper.FindAssetsByType<Sound>("Assets/Resources/Sounds");
        setDictionary();
    }

    #endif
}
