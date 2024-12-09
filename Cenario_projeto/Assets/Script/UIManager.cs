using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; 

    public GameObject handCursor ;
    public GameObject backItem; 
    
    private void Awake(){

        instance = this; 

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtiveCursor (bool state){

        handCursor.SetActive(state); 
        
    }
    public void SetBackImage(bool state)
    {

        backItem.SetActive(state);

    }
}
