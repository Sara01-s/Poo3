using UnityEngine;

namespace SaraSanMartin {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Botón : MonoBehaviour, IObjetoInteractivo {
        
        private void Awake() => GetComponent<Collider2D>().isTrigger = true;


        [SerializeField] private GameObject _puerta;
        private bool _interruptor = true;


        public void EjecutarAcciónInteractiva() {
            _interruptor = !_interruptor;
            _puerta.SetActive(_interruptor);
        }
    }
}
