using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisorScript : MonoBehaviour
{
    public int canal = 1;
   
    public List<GameObject> canales;

    // Start is called before the first frame update
    void Start()
    {
        if (canales == null || canales.Count == 0)
        {
            Debug.LogError("No hay canales asignados en la lista.");
            return; // Salir si no hay canales
        }

        // Desactivar todos los canales al inicio
        foreach (GameObject canalObj in canales)
        {
            canalObj.SetActive(false);
        }

        canales[canal - 1].SetActive(true);
        Debug.Log("Canal inicial: " + canal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Sumar()
    {
        canal = (canal % canales.Count) + 1;
        //canal = 1 + canal % 10;
        Debug.Log("Canal despu�s de sumar: " + canal);

        ActualizarCanal();
    }

    public void Restar()
    {

        canal = (canal == 1) ? 10 : canal - 1;
        Debug.Log("Canal despu�s de restar: " + canal);
        ActualizarCanal();
    }

    public void ActualizarCanal()
    {
        if (canal < 1 || canal > canales.Count)
        {
            Debug.LogError("El canal est� fuera de rango.");
            return; // Salir si el canal es inv�lido
        }

        // Desactivar todos los canales
        foreach (GameObject canalObj in canales)
        {
            canalObj.SetActive(false);
        }

        // Activar solo el canal correspondiente
        canales[canal - 1].SetActive(true);
        Debug.Log("Canal activado: " + canal);
    }



}
