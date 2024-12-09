using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerInteraction : MonoBehaviour
{
    private Camera cam;  
    public float rayDistance = 10f; 
    private bool pegar = false;
    public Transform objectViewer;
    public UnityEvent OnFinishView;  
    public UnityEvent OnView; 
    public GameObject despertador; 
    public GameObject offClick;
    private Interactable currentInteractable; 
    public GameObject screenPc; 
    public GameObject came; 
    private Vector3 originPosition; 
    private Quaternion originRotation; 
    public bool isViewing = false; 
    public bool canFinish = false;
    
 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main ; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables(); 
    }

    private void CheckInteractables(){

        if (isViewing){

            if(canFinish && pegar){
                FinishView(); 
                pegar = false; 
            }
            return; 
        }

        RaycastHit hit; 
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f)); 

        if(Physics.Raycast(rayOrigin, cam.transform.forward, out hit, rayDistance)){

            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null){

                UIManager.instance.AtiveCursor(true); 

                if (pegar){

                        if(interactable.isMoving) 
                        {
                            return;
                        }
                        currentInteractable = interactable ;    
                         isViewing = true; 
                         pegar = false; 
                         
                         
                        if(currentInteractable.item.pegavel){
                            originPosition = currentInteractable.transform.position;
                            originRotation = currentInteractable.transform.rotation; 
                            StartCoroutine(MovingObject(currentInteractable, objectViewer.position)); 
                            currentInteractable.gameObject.transform.rotation = Quaternion.Euler(0,90,180);
                            Invoke("CanFinish", 2f);

                            
                        } else{

                             Destroy(offClick);
                             Destroy(despertador); 
                             canFinish = true;
                             isViewing = false;

                        }

                          if(currentInteractable.item.computer){
                            
                            gameObject.SetActive(false); 
                            screenPc.SetActive(true); 
                            came.SetActive(true); 
                            
                        }
                        
                
                }

            } 
            else{

                UIManager.instance.AtiveCursor(false); 

            }
        }
        else{

            UIManager.instance.AtiveCursor(false); 

        }
    }
    void OnMecanic(InputValue value){

        pegar = true; 

    }

    void CanFinish()
    {
        canFinish = true; 
        UIManager.instance.SetBackImage(true); 
    }

    void FinishView()
    {
        canFinish = false; 

        isViewing = false;

        UIManager.instance.SetBackImage(false); 

        if(currentInteractable.item.pegavel){

            currentInteractable.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentInteractable,originPosition)); 

        }

        OnFinishView.Invoke(); 
    }
    IEnumerator MovingObject (Interactable obj, Vector3 position){

        obj.isMoving = true;
        float timer = 0f; 

        while(timer < 1){

            obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5); 
            timer += Time.deltaTime; 
            yield return null ; 

        }

        obj.transform.position = position; 
        obj.isMoving = false; 


    }
}
