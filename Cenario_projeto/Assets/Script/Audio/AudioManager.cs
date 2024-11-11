using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
     [Header("audioManage")]
    public static AudioManager instance;


    //adicionar gameobjet do slider que controla o  mastervolume
    public Slider masterVolumeSlider;


    [Header("Volume")]
    public float masterVolume = 0.5f;
    public float musicaVolume = 0.5f;
    

    private Bus masterBus;
    private Bus musicaBus;


    private const string MasterVolumeKey = "MasterVolume";
    private const string MusicaVolumeKey = "MusicaVolume";

    private void Awake(){
        instance = this;

        masterBus = RuntimeManager.GetBus("bus:/");
        // musicaBus = RuntimeManager.GetBus("bus:/Musica");

          // Carregar volume salvo
        masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);
        musicaVolume = PlayerPrefs.GetFloat(MusicaVolumeKey, 0.5f);

        if (masterVolumeSlider != null){
            masterVolumeSlider.value = masterVolume;
            SetVolumeMaster(masterVolume)    ;
        }
    }
    private void Start(){
        if (masterVolumeSlider != null){
            masterVolumeSlider.onValueChanged.AddListener(SetVolumeMaster);
        }
    }

    public void SetVolumeMaster(float nVolume)
    {
        masterVolume = nVolume;
        masterBus.setVolume(masterVolume);  
         // Salva o volume do master
        PlayerPrefs.SetFloat(MasterVolumeKey, masterVolume);
                PlayerPrefs.Save();

    }
    public void SetVolumeMusica(float nVolume)
    {
        musicaVolume = nVolume;
        masterBus.setVolume(musicaVolume);  
          // Salva o volume da música
        PlayerPrefs.SetFloat(MusicaVolumeKey, musicaVolume);
                PlayerPrefs.Save();

    }
}
