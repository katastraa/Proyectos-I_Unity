using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelevisorScript : MonoBehaviour
{
    public int canal = 1;
    public List<GameObject> canales;
    private bool[] Comprobacion;
    public Button Izquierda;
    public Button Derecha;
    public Button OnButton;
    public Button OffButton;
    public Button Cerrar;
    public bool todosloscanales = false;


    // Start is called before the first frame update
    void Start()
    {
        Izquierda.enabled = false;
        Derecha.enabled = false;
        Cerrar.gameObject.SetActive(false);
        

        if (canales == null || canales.Count == 0)
        {
            Debug.LogError("No hay canales asignados en la lista.");
            return; // Salir si no hay canales
        }

        Comprobacion = new bool[canales.Count];

        // Desactivar todos los canales al inicio
        for (int i=0; i<canales.Count; i++)
        {
            GameObject canalObj = canales[i];
            canalObj.SetActive(false);
            Comprobacion[i] = false;
        }

        canales[canal - 1].SetActive(false);
        Debug.Log("Canal inicial: " + canal);
        Comprobacion[canal - 1] = true;
        todosloscanales = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void desactivarbotones()
    {
       Izquierda.gameObject.SetActive(false);
       Derecha.gameObject.SetActive(false);
        OnButton.gameObject.SetActive(false);
        OffButton.gameObject.SetActive(false);
        Cerrar.gameObject.SetActive(true);
    }

   public void Sumar()
    {
        canal = (canal % canales.Count) + 1;
        //canal = 1 + canal % 10;
       
        ActualizarCanal();
    }

    public void Restar()
    {

        canal = (canal == 1) ? 10 : canal - 1;
        
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
        Comprobacion[canal - 1] = true;

        bool auxiliar = true;
        
        for (int i = 0; i < canales.Count; i++)
        {
            auxiliar &= Comprobacion[i];
        }
        
        if (auxiliar)
        {
            
            todosloscanales = true;
        }
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
