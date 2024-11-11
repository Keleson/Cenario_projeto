using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class BlinkingText : MonoBehaviour
{

    public TextMeshProUGUI blinkingText;      // Referencia ao objeto de texto
    public float blinkInterval = 0.7f; // Intervalo de piscada em segundos

    // Start is called before the first frame update
    void Start()
    {
        // Inicia a Coroutine de piscada
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // Alterna a visibilidade do texto
            blinkingText.enabled = !blinkingText.enabled;

            // Espera o tempo do intervalo antes de alternar novamente
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
