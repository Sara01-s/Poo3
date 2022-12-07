using UnityEngine;

namespace SaraSanMartin {


    internal abstract class Bala : MonoBehaviour {

        protected abstract float Velocidad { get; set; }

        private void OnBecameInvisible() {
            Destroy(gameObject);
        }
        
    }
}