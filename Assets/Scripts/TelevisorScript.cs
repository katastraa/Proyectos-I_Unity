using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisorScript : MonoBehaviour
{
    public int canal;
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

    public void Restar()//esto no furula pero weno lo intenta
    {
        canal = 1 - canal % 10;
    }

}
