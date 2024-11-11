using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteraction : MonoBehaviour
{
    private Camera cam;  
    public float rayDistance = 10f; 
    private bool pegar = false;
    public Transform objectViewer; 
    private Interactable currentInteractable; 
    private Vector3 originPosition; 
    private Quaternion originRotation; 
    public bool isViewing; 

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

        RaycastHit hit; 
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f)); 

        if(Physics.Raycast(rayOrigin, cam.transform.forward, out hit, rayDistance)){

            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null){

                UIManager.instance.AtiveCursor(true); 

                if (pegar){

                        currentInteractable = interactable ;    
                         isViewing = true; 

                        if(currentInteractable.item.pegavel){
                            originPosition = currentInteractable.transform.position;
                            originRotation = currentInteractable.transform.rotation; 
                            StartCoroutine(MovingObject(currentInteractable, objectViewer.position)); 
                            currentInteractable.gameObject.transform.rotation = Quaternion.Euler(0,90,180);
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
    IEnumerator MovingObject (Interactable obj, Vector3 position){

        float timer = 0f; 

        while(timer < 1){

            obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5); 
            timer += Time.deltaTime; 
            yield return null ; 

        }

        obj.transform.position = position; 


    }
}
