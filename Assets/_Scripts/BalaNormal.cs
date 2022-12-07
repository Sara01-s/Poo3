using UnityEngine;

namespace SaraSanMartin {


    internal sealed class BalaNormal : Bala {

        [field: SerializeField]
        protected override float Velocidad { get; set; }
        
        private void Update() {
            transform.position += transform.up * (Velocidad * Time.deltaTime);
        }
    }

}
