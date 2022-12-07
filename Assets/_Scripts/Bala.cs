using UnityEngine;

namespace SaraSanMartin {


    internal abstract class Bala : MonoBehaviour {


        internal abstract void Disparar();

        private void OnBecameInvisible() {
            Destroy(gameObject);
        }

    }
}