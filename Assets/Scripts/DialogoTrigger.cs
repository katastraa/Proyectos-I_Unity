using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTrigger : MonoBehaviour {

    public Dialogo dialogo;
    public bool autoCarga;
    public bool autoDesactivar;

    public void TriggerDialogo() {

        GestorDialogos.instancia.IncluirDialogo(dialogo);

        if (autoCarga){
            if (GestorDialogos.instancia == null) {
                Debug.Log("No hay instancia? estmos lokos");
            } else {
                GestorDialogos.instancia.SacarSiguienteFrase();
            }
        }

        if (autoDesactivar)
            this.gameObject.SetActive(false);  
    }


}
