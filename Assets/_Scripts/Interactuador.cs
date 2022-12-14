using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Interactuador : MonoBehaviour {

    
        private void OnTriggerEnter2D(Collider2D objetoColisionado) {
            
            if (objetoColisionado.CompareTag("Moneda")) {
                var moneda = objetoColisionado.GetComponent<Moneda>();
                moneda.DestruirMonedaYA├▒adirPuntuaci├│nUsandoTriggerYUnTag();
            }

            if (objetoColisionado.TryGetComponent<IObjetoInteractivo>(out var objInteractivo)) {
                
                objInteractivo.EjecutarAcci├│nInteractiva();

            }
        }
    }
}