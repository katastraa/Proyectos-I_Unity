using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadorDialogos : MonoBehaviour {

    public static LanzadorDialogos instancia;
    public DialogoTrigger[] dialogosTriggers;
    public float[] segundosDeEspera;

    // Start is called before the first frame update
    void Awake() {
        if (instancia != null){    // singleton
            Destroy(this);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    int i = 0;
    public bool finalizado = false;
    bool esperaActivada = false;

    // Update is called once per frame
    void Update() {
        if (!finalizado && !esperaActivada)   // Aunque ya está el gestor de dialogos, hay que asegurar el tiempo de espera entre diálogos
            if (!GestorDialogos.instancia.dialogoEmpezado)
                if (dialogosTriggers[i] != null && segundosDeEspera[i] > 0.0f) {
                    dialogosTriggers[i].TriggerDialogo();
                    StartCoroutine(corrutinaDeEspera(segundosDeEspera[i]));
                    esperaActivada = true;
                    i = i+1;
                    finalizado = i >= dialogosTriggers.Length;
                }
    }

    IEnumerator corrutinaDeEspera(float segundos){
        while(GestorDialogos.instancia.dialogoEmpezado){
            yield return null;
        }
        yield return new WaitForSeconds(segundos);
        esperaActivada = false;
    }

}
