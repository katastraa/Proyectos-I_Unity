using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasaDelaPili : MonoBehaviour
{
    public Button Madre;
    public Button MadreCocina;
    public Button DialogoDerecha;
    public Button DialogoAbajo;
    public Button NavegacionDerecha;
    public Button NavegacionIzquierda;
    public Button Madre2;
    public Button Niña1;
    public Button Niña2;
    public Button Salir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void madreDialogo ()
    {
        NavegacionDerecha.gameObject.SetActive(true);
        NavegacionIzquierda.gameObject.SetActive(true);
        DialogoDerecha.gameObject.SetActive(false);
        DialogoAbajo.gameObject.SetActive(false);
        Madre.gameObject.SetActive(false);
        Madre2.gameObject.SetActive(true);
    }

    public void dialogoniña ()
    {
        Madre2.gameObject.SetActive(false);
        MadreCocina.gameObject.SetActive(true);
        Niña1.gameObject.SetActive(false);
        Niña2.gameObject.SetActive(true);
    }

    public void salir ()
    {
        Salir.gameObject.SetActive(true);
    }
}
