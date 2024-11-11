using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
   CharacterController chaC; 
    public float speed = 12f;
    public float gravity = -9.81f; 
    public Transform groundCheck; 
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 
    Vector3 velocity;
    bool isGrounded ;  
    float x;
    float z;
    private Animator anima;


    // Start is called before the first frame update
    void Start()
    {
        chaC = GetComponent<CharacterController>(); 
        anima = GetComponent<Animator>(); 
        anima.SetBool("Sleep", false); 
    }

    // Update is called once per frame
    void Update()
    {   
        anima.SetFloat("vertical", z);
        anima.SetFloat("horizontal", x);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 
        if(isGrounded && velocity.y < 0){

            velocity.y = -2;
        }

        // basicamente, essa bomba faz com que o player ratacione junto com a camera de acordo para onde ele esta olhando
        Vector3 move = transform.right * x + transform.forward * z; 

        chaC.Move (move * speed * Time.deltaTime); 
        // nao entendi quase nada xd, mas pelo visto, a formula para descobrir o delta y, precisa ter a gravidade multiplicado pelo tempo ao quadrado, por isso multipliquei no velocity.y a gravidade pelo time.deltatime uma vez e depois multipliquei a velocity de novo pelo time.deltatime  
        velocity.y += gravity * Time.deltaTime ; 
        chaC.Move (velocity * Time.deltaTime);  
        
    }
     void OnMove(InputValue value){

        x = value.Get<Vector2>().x;
        z = value.Get<Vector2>().y;
     }
}
