using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisorScript : MonoBehaviour
{
    public int canal;
    public List<GameObject> canales;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Sumar()
    {
        canal = 1 + canal % 10;
    }

    public void Restar()
    {
        canal = (canal == 1) ? 10 : canal - 1;
    }

    public void ActualizarCanal()
    {
        // Desactivar todos los canales
        foreach (GameObject canalObj in canales)
        {
            canalObj.SetActive(false);
        }

        // Activar solo el canal correspondiente
        canales[canal - 1].SetActive(true);
    }



}
