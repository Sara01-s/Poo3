using UnityEngine;

namespace SaraSanMartin {

    [RequireComponent(typeof(BoxCollider2D))]
    public class Moneda : MonoBehaviour, IObjetoInteractivo {

        public void EjecutarAcciónInteractiva() {

            Puntaje.AñadirPuntaje();
            Destroy(gameObject);

        }
    }
}