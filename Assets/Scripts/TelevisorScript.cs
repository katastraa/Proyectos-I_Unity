using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelevisorScript : MonoBehaviour
{
    public int canal = 1;
    public List<GameObject> canales;

    public Button Izquierda;
    public Button Derecha;
    public Button OnButton;
    public Button OffButton;

    // Start is called before the first frame update
    void Start()
    {
        Izquierda.enabled = false;
        Derecha.enabled = false;

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

        canales[canal - 1].SetActive(false);
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
        Debug.Log("Canal después de sumar: " + canal);

        ActualizarCanal();
    }

    public void Restar()
    {

        canal = (canal == 1) ? 10 : canal - 1;
        Debug.Log("Canal después de restar: " + canal);
        ActualizarCanal();
    }

    public void ActualizarCanal()
    {
        if (canal < 1 || canal > canales.Count)
        {
            Debug.LogError("El canal está fuera de rango.");
            return; // Salir si el canal es inválido
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

    public void On ()
    {
        canales[canal - 1].SetActive(true);
        Izquierda.enabled = true;
        Derecha.enabled = true;
        OnButton.gameObject.SetActive(false);
        OffButton.gameObject.SetActive(true);
    }

    public void Off()
    {
        canales[canal - 1].SetActive(false);
        Izquierda.enabled = false;
        Derecha.enabled = false;
        OnButton.gameObject.SetActive(true);
        OffButton.gameObject.SetActive(false);
    }
} 
