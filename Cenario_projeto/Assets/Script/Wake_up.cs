using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Wake_up : MonoBehaviour
{
    public Transform player_acordado; 
    public GameObject hora; 
    public GameObject cronometro; 
    private Animator anima ;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMecanic(InputValue value){

        player_acordado.gameObject.SetActive(true);
        Destroy(gameObject); 
        //cronometro.gameObject.SetActive(false); 
        //hora.gameObject.SetActive(false); 
        Debug.Log("come");  
    }
}
