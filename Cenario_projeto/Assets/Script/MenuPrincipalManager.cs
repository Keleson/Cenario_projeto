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

     public void FecharOpcoes()
    {
        painelMenuConfig.SetActive(false); 
    }

    public void FecharOpcoesVolume(){

        painelMenuVolume.SetActive(false);
    }

    public void Sair()
    {

    }
}
