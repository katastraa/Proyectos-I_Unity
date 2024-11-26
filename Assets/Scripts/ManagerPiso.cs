using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangerPiso : MonoBehaviour
{
    public Button dialogoPuerta;
    public Button salirPuerta;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void salida()
    {
        dialogoPuerta.gameObject.SetActive(false);
        salirPuerta .gameObject.SetActive(true);
    }
}
