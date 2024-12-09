using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Notes : MonoBehaviour
{
    
    private Vector3 standardPosition; 
    private Vector3 interecctionPosition; 
    public GameObject notes; 
    public Transform canvas; 
    public float timer; 
    public bool isMoved = false; 
    // Start is called before the first frame update
    void Start()
    {
        standardPosition = gameObject.transform.position; 
    
    }

    // Update is called once per frame
    void Update()
    {
        interecctionPosition = gameObject.transform.position;

         if (interecctionPosition != standardPosition)
        {
        Vector3 worldPosition = notes.transform.position;

        Quaternion worldRotation = notes.transform.rotation;

         Vector3 worldScale = notes.transform.lossyScale; // Salva a escala global

        timer += Time.deltaTime; 

        if(timer >= 1.3 && !isMoved){

        notes.transform.SetParent(canvas, false);
        // Reaplica a posição e rotação para manter sua aparência no mundo
        notes.transform.position = worldPosition;
        notes.transform.rotation = worldRotation;
        notes.transform.localScale = worldScale; // Reaplica a escala original
        isMoved = true; 
        }

        }
        else if (interecctionPosition == standardPosition)
        {
            timer = 0; // Reinicia o temporizador
            isMoved = false; // Permite mover novamente
        }
            
       
    }

}
