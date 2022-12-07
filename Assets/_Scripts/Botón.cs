using UnityEngine;

namespace SaraSanMartin {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Botón : MonoBehaviour, IObjetoInteractivo {
        

        [SerializeField] private Puerta _puerta;


        private void Awake() => GetComponent<Collider2D>().isTrigger = true;

        public void EjecutarAcciónInteractiva() {
            _puerta.Abrir();
        }
    }
}
