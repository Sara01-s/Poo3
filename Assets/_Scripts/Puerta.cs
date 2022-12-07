using UnityEngine;

namespace SaraSanMartin {
    
    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Puerta : MonoBehaviour {

        internal void Abrir() => Destroy(gameObject);
    }
}