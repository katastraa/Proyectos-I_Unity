using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PisoDeEstuadiantes : MonoBehaviour
{
    public Button Guille;
    public Button Guille2;
    public Button Guille3;
    public Button Luis;
    public Button Luis2;
    public Button Derecha;

    //botones pasillo interrogación

    public Button CuartoA;
    public Button CuartoB;
    public Button CuartoC;
    public Button Baño;

    //botones pasillo descubierto

    public Button CuartoADEscubierto;
    public Button CuartoBDEscubierto;
    public Button CuartoCDescubierto;
    public Button BañoDescubierto;

    //botones de la niña emo que te vigila para que no te fanges nada

    public Button Izquierda;
    public Button Recto;
    public Button IzquierdaTexto;
    public Button RectoTexto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioDialogoGuille()
    {
        Guille.gameObject.SetActive(false);
        Guille2 .gameObject.SetActive(true);
    }

    public void DescubrirCuartoA()
    {
        CuartoA.gameObject.SetActive(false);
        CuartoADEscubierto.gameObject.SetActive(true);
    }

    public void DescubrirCuartoB()
    {
        CuartoB.gameObject.SetActive(false);
        CuartoBDEscubierto .gameObject.SetActive(true);
    }

    public void DescubrirCuartoC()
    {
        CuartoC.gameObject.SetActive(false);
        CuartoCDescubierto.gameObject.SetActive(true);
    }

    public void DescubrirBaño()
    {
        Baño.gameObject.SetActive(false);
        BañoDescubierto .gameObject.SetActive(true);
    }

    public void HablaConGuille()
    {
        Izquierda.gameObject.SetActive(true);
        Recto.gameObject.SetActive(true);
        IzquierdaTexto.gameObject.SetActive(false);
        RectoTexto.gameObject.SetActive(false);
    }

    public void HablaConLuis()
    {
        Luis.gameObject.SetActive(false);
        Luis2.gameObject.SetActive(true);
        Guille2.gameObject.SetActive(false);
        Guille3.gameObject.SetActive(true);
        Derecha.gameObject.SetActive(true);
    }
}
