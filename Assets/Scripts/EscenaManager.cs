using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenaManager : MonoBehaviour {

    public GameObject[] navegaciones, objetosEnEscena, fondos;
    
    public GameObject UI_Dialogos, UI_Opciones;

    public void AlterDialogoNavegacion(){
        UI_Dialogos.SetActive(!UI_Dialogos.activeSelf);
        UI_Opciones.SetActive(!UI_Opciones.activeSelf);

        navegaciones[lastPos].SetActive(!navegaciones[lastPos].activeSelf);
        objetosEnEscena[lastPos].SetActive(!objetosEnEscena[lastPos].activeSelf);
    }

    int lastPos = 0;
    public int pos = 0;
    void Intercambiar(int posicion, int lastPosicion){
        fondos[lastPosicion].gameObject.SetActive(false);
        fondos[posicion].gameObject.SetActive(true);

        navegaciones[lastPosicion].SetActive(false);
        navegaciones[posicion].SetActive(true);

        objetosEnEscena[lastPosicion].SetActive(false);
        objetosEnEscena[posicion].SetActive(true);
    }

    public int contadorCambios = 0;
    public int escena = 0;

    public DialogoTrigger screamerLechuza;
    public GameObject murcielagoRicardoBye,lechuzaBye, erizoSpineteHello;
    public AudioClip musicaMiedo;

    public void PrepararSalida(int posicion) {
        this.pos = posicion;
    }

    public void AddContador() {contadorCambios++;}

    private void EventosEscena() {  // Codigo aquí super-hardcoded
        switch(escena){
            case 0: // Escena: Planta baja
                ///// <=
                break;  
            case 1: // Escena: Piso 2
                break;
            case 2: // Escena: Piso 4
                if (contadorCambios >= 2) {

                    //dialgoRicardo = dialogoR_2;
                    
                    contadorCambios++;
                    if (contadorCambios == 6) {
                        screamerLechuza.TriggerDialogo();
                        murcielagoRicardoBye.SetActive(false);
                        lechuzaBye.SetActive(false);
                        erizoSpineteHello.SetActive(true);
                        if (musicaMiedo != null) {
                            SoundManager.instancia.StopMusica();
                            SoundManager.instancia.PlayMusica(musicaMiedo);
                        }
                    }
                }
                break;
            case 3: // final
                break;
        }
    }

    public void CambiarImagen(int posicion) {
        pos = posicion;
        Intercambiar(pos, lastPos);
        lastPos=pos;
        EventosEscena();
    }

    public void EntrarDialogo(int posicion){
        AlterDialogoNavegacion();
        Intercambiar(posicion, lastPos);
        pos = posicion;
    }

    bool salirSiguienteEscena = false;
    bool reiniciar = false;

    public void SiguienteEscena() {
        salirSiguienteEscena = true;
    }

    public void ReiniciarJuego() {
        reiniciar = true;
    }

    public void SalirDialogo() {
        AlterDialogoNavegacion();
        Intercambiar(lastPos, pos);
        if (salirSiguienteEscena) {
            if (reiniciar){
                MainManager.instancia.LoadSceneIndex(0);
            }else{
                MainManager.instancia.LoadNextLevelNum();
            }
        }
    }

}
