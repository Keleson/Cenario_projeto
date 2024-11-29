using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acordado : MonoBehaviour
{   
    // variavel pra guardar o script
    public MonoBehaviour scriptToDisable;
    public MonoBehaviour scriptToDisableCam;
    public float disableDuration = 2f; // tempo que vai ficar desativadp em segundos
    [SerializeField] private GameObject closedEyes; 

    public float crono; 
    private bool start = true;

    // Start is called before the first frame update
    void Start()
    {   
        //StartCoroutine(DisableScriptTemporarily());
    }

    // Update is called once per frame
    void Update()
    {
       crono += Time.deltaTime; 
       if(crono >= 0.1 && start)
       {
        StartCoroutine(DisableScriptTemporarily());
        start = false; 
       }
    }

    IEnumerator DisableScriptTemporarily()
    {
        // Desativa o script
        if (scriptToDisable != null)
        {
            scriptToDisable.enabled = false;
            Debug.Log("Script desativado!");
            closedEyes.SetActive(true);

            // Espera o tempo definido
            yield return new WaitForSeconds(disableDuration);

            // Reativa o script
            scriptToDisable.enabled = true;
            Debug.Log("Script reativado!");
            scriptToDisableCam.enabled = true;
            closedEyes.SetActive(false);
        }
    }
}
