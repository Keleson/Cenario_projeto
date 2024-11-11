using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sleep_Camera : MonoBehaviour
{
    public float mouseSensi = 100.0f;
    public Transform cameraFPS; 
    float yRotation = 0f; 
    float xRotation = 0f; 
    float mouseX ;
    float mouseY;
    public Vector2 cameraF ;
    private Transform transform; 

    

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
       transform = GetComponent<Transform>(); 

       xRotation = -83f; 
       yRotation = 1f;
       cameraFPS.transform.localRotation = Quaternion.Euler(xRotation, yRotation , 0f) ;

    }

    // Update is called once per frame
    void Update()
    {
        // float rotationX = transform.eulerAngles.y; 

        // vai pegar o valor do mouse x e y multiplicado pela sensibilidade 
        mouseX =  cameraF.x * mouseSensi * Time.deltaTime; 

        mouseY =  cameraF.y * mouseSensi * Time.deltaTime; 
        
        yRotation += mouseX; 

        xRotation -= mouseY; 

        xRotation = Mathf.Clamp(xRotation, -83f, 20f); 

        // impede que o player nao olhe muito para os lados
        yRotation = Mathf.Clamp(yRotation, -65f, 65f); 
       
        cameraFPS.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f ) ; 
            

        
        
    }
   void OnMoveCamera(InputValue value){
       
       cameraF = value.Get<Vector2>(); 

   }
}
