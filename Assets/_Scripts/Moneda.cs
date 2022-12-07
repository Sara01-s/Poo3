using UnityEngine;

namespace SaraSanMartin {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Moneda : MonoBehaviour//, IObjetoInteractivo 
    {

        internal void DestruirMonedaYAñadirPuntuaciónUsandoTriggerYUnTag() {
            Puntaje.AñadirPuntaje();
            Destroy(gameObject);
        }

        // Otra forma aprovechando la interfaz
        // public void EjecutarAcciónInteractiva() {
        //     Puntaje.AñadirPuntaje();
        //     Destroy(gameObject);
        // }
    }
}