using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestorDialogos : MonoBehaviour {

    // https://www.youtube.com/watch?v=_nRzoTzeyxU

    private Queue<string> dialogos; // Usamos cola FIFO
    private Queue<int> modoDialogo; // Usamos cola FIFO
    public static GestorDialogos instancia = null;
    public TextMeshProUGUI campoNombreUI;
    public TextMeshProUGUI campoDialogoUI;
    public float segundosPorCaracter;
    public bool dialogoEmpezado;
    public AudioClip[] sonidosHablar;
    public GameObject botonPasar, botonFinal;
    public EscenaManager escenaManager;
    public float valoranterior;

    public void SetSegundosPorCaracter(float tiempo){
        segundosPorCaracter = tiempo;
        valoranterior = tiempo;
    }

    void Awake() {

        if (GestorDialogos.instancia != null){    // singleton
            Debug.Log("queee" + GestorDialogos.instancia.gameObject.name);
            Destroy(this);
            return;
        }

        GestorDialogos.instancia = this;

        /// ESTRUCTURAS DE DATOS DE LA CLASE
        dialogos = new Queue<string>();
        modoDialogo = new Queue<int>();
        dialogoEmpezado = false;
        valoranterior = segundosPorCaracter;
    }

    public void IncluirDialogo(Dialogo dialogo) {
        dialogos.Clear();
        campoNombreUI.text = dialogo.nombrePersonaje;
        //campoNombreUI.text = ""; // Cambiar la linea de arriba por esta para la versión final
        
        foreach (string frase in dialogo.frases) {
            dialogos.Enqueue(frase);
        }
    
        modoDialogo.Enqueue(dialogo.modoDialogo);

        sonidosHablar = dialogo.voces;

        escenaManager.EntrarDialogo(dialogo.posicionVector);

        botonPasar.SetActive(false);
        botonFinal.SetActive(false);
    }

    public void CompletarFrase() //la guarrada que esta haciendo luh pa que el flow del dialogo quede bien
    {
        segundosPorCaracter = 0;
    }

    public void SacarSiguienteFrase(){ // bool limpiarCuadroDialogo, bool desactivarCuadroDialogo
        dialogoEmpezado = true;

        if (ultimaFraseCoru != null)
            StopCoroutine(ultimaFraseCoru);
        botonPasar.SetActive(false);
        
        segundosPorCaracter = valoranterior;

        string frase = dialogos.Dequeue();
        ultimaFraseCoru = StartCoroutine(EscribirFrase(frase));
    }

    Coroutine ultimaFraseCoru = null;

    IEnumerator EscribirFrase(string frase){
        campoDialogoUI.text = "";
        foreach (char caracter in frase.ToCharArray())
        {
            //botonComplertar.SetActive(true);
            campoDialogoUI.text += caracter;
            float tiempoEspera = Random.Range( 0.8f*segundosPorCaracter, 1.2f*segundosPorCaracter );

            SoundManager.instancia.RandomSoundDialogue(sonidosHablar);
            
            yield return new WaitForSeconds(tiempoEspera);
        }

        if (dialogos.Count == 0){
            FinalizarFrases(modoDialogo.Dequeue());
        }else{
            botonPasar.SetActive(true);
            //botonComplertar.SetActive(false);
        }

        ultimaFraseCoru = null; // Esto debe de estar aquí siempre para no dar una excepción nullReference
    }

    

    public void FinalizarFrases(int modo) {
        Debug.Log(modo);
        //botonComplertar.SetActive(false) ;
        botonPasar.SetActive(false);
        if (modo == 1 || modo == 2) {   // 1 o 2
            campoDialogoUI.text = campoNombreUI.text = "";
        }
        dialogoEmpezado = false;
        if (modo == 2 || modo == 3) {  // 2 o 3, usa 0 para no activar ninguno
            botonFinal.SetActive(true);
        }
    }

    private void OnDestroy() {
        Debug.Log("Me ha destruido " + this.gameObject.name);    
    }

}
