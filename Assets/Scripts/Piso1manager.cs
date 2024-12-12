using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piso1manager : MonoBehaviour
{
    public Button navegacion;
    // Start is called before the first frame update
    void Start()
    {
        navegacion.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Vecino()
    {
        navegacion.gameObject.SetActive(true);
    }
}
