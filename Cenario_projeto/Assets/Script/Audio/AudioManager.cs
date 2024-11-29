using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
     //[Header("audioManage")]
    public static AudioManager instance;


    //adicionar gameobjet do slider que controla o  mastervolume
    public Slider masterVolumeSlider;

    // so para deixar bonitinho
    [Header("Volume")]
    public float masterVolume = 0.5f;
    public float musicaVolume = 0.5f;
    
    // bus é uma claase do fmod para aumentar e diminuir o som: master bus volume geral do jogo e musica e da musica referenciada
    private Bus masterBus;
    private Bus musicaBus;

    // essa const é para nao ser alterado o nome: MasterVolume 
    private const string MasterVolumeKey = "MasterVolume";
    //private const string MusicaVolumeKey = "MusicaVolume";

    private void Awake(){
        instance = this;
        // o RuntimeManager é do propio fmod para pegar o volume 
        masterBus = RuntimeManager.GetBus("bus:/"); // ("bus:/") seria o nome do volume do fmod

          // Carregar volume salvo no jogo
        masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);

        if (masterVolumeSlider != null){
            masterVolumeSlider.value = masterVolume;
            // funcao para altera o valor do bus; 
            SetVolumeMaster(masterVolume);

        }
    }
    private void Start(){
        if (masterVolumeSlider != null){
            // toda vez que mudar o valor chama a funcao setvolumemaster para colocar o novo do setvolume
            masterVolumeSlider.onValueChanged.AddListener(SetVolumeMaster);
        }
    }

    public void SetVolumeMaster(float nVolume)
    {
        masterVolume = nVolume;

        masterBus.setVolume(masterVolume);  
        // Salva o volume do master 
        PlayerPrefs.SetFloat(MasterVolumeKey, masterVolume);
        //salvando novo valor
        PlayerPrefs.Save();

    }
    
}
