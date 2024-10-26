using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DialogoTrigger : MonoBehaviour {

    public Dialogo dialogo;
    public Dialogo[] dialogosAlternativos;

    public bool autoCarga;
    public bool autoDesactivar;

    int siguienteDialogAlter = 0;

    public void DialogAlterCambiar(int siguiente){
        siguienteDialogAlter = siguiente;
    }
    
    public void DialogAlterSiguente(){
        if (siguienteDialogAlter < dialogosAlternativos.Length - 1) {
            siguienteDialogAlter++;
        }
    }

    public void DialogAlterBucle(){
        siguienteDialogAlter++;
        siguienteDialogAlter = siguienteDialogAlter % dialogosAlternativos.Length;
    }

    public void TriggerDialogoAlter(){

        GestorDialogos.instancia.IncluirDialogo(dialogosAlternativos[siguienteDialogAlter]);

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

    public void TriggerDialogo() {

        if (dialogosAlternativos != null){
            Random rand = new Random();
            if (dialogosAlternativos.Length > 0)
                dialogo = dialogosAlternativos[rand.Next()%dialogosAlternativos.Length];
        }

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
