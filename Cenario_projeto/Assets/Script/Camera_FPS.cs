using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_FPS : MonoBehaviour
{
    public float mouseSensi = 100.0f;
    public Transform playerBody ;
    public Transform cameraFPS; 
    float xRoatation = 0f; 
    float mouseX ;
    float mouseY;
    public Vector2 cameraF ;
    private Animator anima; 
    

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
       anima= GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        // vai pegar o valor do mouse x e y multiplicado pela sensibilidade 
        mouseX =  cameraF.x * mouseSensi * Time.deltaTime; 

        mouseY =  cameraF.y * mouseSensi * Time.deltaTime; 
        
        xRoatation -= mouseY; 

        xRoatation = Mathf.Clamp(xRoatation, -80f, 80f); 

        playerBody.Rotate(Vector3.up * mouseX) ;

        cameraFPS.transform.localRotation = Quaternion.Euler(xRoatation, 0f, 0f) ; 
        
        
    }
   void OnMoveCamera(InputValue value){
       
       cameraF = value.Get<Vector2>(); 

   }
}
