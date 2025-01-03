using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planta3rellano : MonoBehaviour
{
    public Button Guiri;
    public Button Cartel;
    public Button CambioEscena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiálogoGuiri ()
    {
        CambioEscena.gameObject.SetActive (true);
        Guiri.gameObject.SetActive(false);
        Cartel.gameObject.SetActive(false);


    }
}
