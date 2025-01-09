using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bajo : MonoBehaviour
{
    
    public Button Abajo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Volver ()

    {
        Abajo.gameObject.SetActive(true);
    }
}
