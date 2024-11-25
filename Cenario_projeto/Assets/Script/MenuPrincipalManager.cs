using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPrincipalManager : MonoBehaviour
{
    public GameObject wallpaper; 
    public GameObject menuSom;
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private GameObject painelMenuConfig; 
    [SerializeField] private GameObject painelMenuVolume; 
    [SerializeField] private GameObject painelMenuConfirmar; 
    [SerializeField] private GameObject painelMenuResolution; 

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }

    public void AbrirOpcoes()
    {
        painelMenuConfig.SetActive(true);
        
    }

    public void AbrirMenuVolume()
    {
        painelMenuVolume.SetActive(true); 

        if (Input.GetKeyDown(KeyCode.Space))
        {

            wallpaper.SetActive(false); 
            menuSom.SetActive(true); 
        }
    }

    public void AbrirResolution()
    {
        painelMenuResolution.SetActive(true);
    }

    public void FecharResolution()
    {
        painelMenuResolution.SetActive(false);
    }

     public void FecharOpcoes()
    {
        painelMenuConfig.SetActive(false); 
    }

    public void FecharOpcoesVolume(){

        painelMenuVolume.SetActive(false);
    }

    public void Sair()
    {
        painelMenuConfirmar.SetActive(true);
    }

    public void FecharConfirmacao()
    {
        painelMenuConfirmar.SetActive(false);
    }

    public void FecharJogo()
    {
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
