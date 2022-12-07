using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Interactuador : MonoBehaviour {

    
        private void OnTriggerEnter2D(Collider2D objetoColisionado) {

            if (objetoColisionado.TryGetComponent<IObjetoInteractivo>(out var objInteractivo)) {
                
                objInteractivo.EjecutarAcciónInteractiva();

            }
        }
    }
}