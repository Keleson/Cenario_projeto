using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Cell : MonoBehaviour
{
    public Transform phoneTransform; // Referência ao celular no mundo 3D
    public Camera mainCamera;        // Referência à câmera principal
    public RectTransform canvasRect; // Referência ao RectTransform do Canvas
    private RectTransform rectTransform; // Referência ao RectTransform da imagem
    private bool isPhonePicked = false; 

    // Start is called before the first frame update
    void Start()
    {
         rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
       // Converte a posição do celular para coordenadas de tela
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(phoneTransform.position);

        // Verifica se o celular está dentro do campo de visão da câmera
        if (screenPosition.z > 0)
        {
            // Converte as coordenadas de tela para coordenadas locais do Canvas
            Vector2 canvasPosition = mainCamera.ScreenToWorldPoint(screenPosition);

            // Atualiza a posição da imagem no Canvas
            rectTransform.anchoredPosition = canvasPosition;
        }
    }

}
