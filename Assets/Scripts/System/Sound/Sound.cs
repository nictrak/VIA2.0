using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "VIA2.0/Sound")]
public class Sound : ScriptableObject
{
    public string Name;
    public AudioClip SoundFile;
    public float Delay;
}
