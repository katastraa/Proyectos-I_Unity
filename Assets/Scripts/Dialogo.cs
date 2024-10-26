using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo {
    public string nombrePersonaje;

    public int modoDialogo=3;

    public int posicionVector;

    [TextArea(2,10)]
    public string[] frases;

}
