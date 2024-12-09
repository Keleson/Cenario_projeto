using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazyBar : MonoBehaviour
{
    public Slider lazySlider; // Referência ao Slider
    public float increaseRate = 5f; // Velocidade de aumento da barrinha
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementa o valor do Slider ao longo do tempo
        if (lazySlider.value < lazySlider.maxValue)
        {
            lazySlider.value += increaseRate * Time.deltaTime;
        }
    }
}
