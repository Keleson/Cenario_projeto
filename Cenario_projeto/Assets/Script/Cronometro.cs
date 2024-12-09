using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI textHora;
    public TextMeshProUGUI textHora_desp;
    public TextMeshProUGUI textHora_pc;
    public int contaHora = 7; 
    public int contaDec = 3; 
    public float contaseg; 
    private int countMin; 
    public int multi = 2; 
    private bool horaMenor = true; 
    public GameObject Alarm; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        contaseg += Time.deltaTime * multi; 

        if (contaseg >= 60){
            countMin +=1; 
            contaseg = 0;
            multi+= 2; 
        }
        if(horaMenor){
        textHora.text = "0"+ contaHora+ ":"+ contaDec + countMin;
        textHora_desp.text = "0"+ contaHora+ ":"+ contaDec + countMin; 
        textHora_pc.text = "0"+ contaHora+ ":"+ contaDec + countMin; 
        }

        if (countMin == 10){
            contaDec +=1; 
            countMin = 0; 
        }
        if (contaDec == 6){
            contaHora +=1; 
            contaDec = 0; 
        }
        if (contaHora >=10){
            horaMenor = false; 
            textHora.text = contaHora+ ":"+ contaDec + countMin;
            textHora_desp.text = contaHora+ ":"+ contaDec + countMin;
            textHora_pc.text = contaHora+ ":"+ contaDec + countMin;
        }

        if (countMin == 5 && Alarm){
                  #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
    }
}
