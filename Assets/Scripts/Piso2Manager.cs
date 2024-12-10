using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piso2Manager : MonoBehaviour
{
    public Button Entrar;
    // Start is called before the first frame update
    public void CambiodeEscena()
    {
        Entrar.gameObject.SetActive(true);
    }
}
