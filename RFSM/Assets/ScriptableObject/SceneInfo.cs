using UnityEngine.Audio;
using UnityEngine;
using System.Drawing.Drawing2D;


[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject
{
 
    public AudioMixer audioMixer;
    public AudioMixer SFXMixer;

    public static bool hasIntro = true;

    public static float MusicValue;
    public static float SfxValue;

    public static bool fpsOn = false;
    public static bool fpsEnabled = false;

    public static bool effectOn = true;
    public static bool effectEnabled = true;

    public void BGM(float volume)
    {
        audioMixer.SetFloat("BGMvol", volume);
        MusicValue = volume;
    }

    
    public void sFX(float sfxVolume)
    {
        SFXMixer.SetFloat("SFxVol", sfxVolume);
        SfxValue = sfxVolume;
    }

    public SceneInfo(GameData data)
    {
        MusicValue = data.MusicValue;
        SfxValue = data.SfxValue;
        fpsOn = data.fpsOn;
        fpsEnabled = data.fpsEnabled;
        effectOn = data.effectOn;
        effectEnabled = data.effectEnabled;
    }
}

