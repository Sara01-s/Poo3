using UnityEngine;

namespace SaraSanMartin {


    internal sealed class BalaEspiral : Bala {

        [field: SerializeField]
        protected override float Velocidad { get; set; }
        [SerializeField] private float _potenciaDeGiro = 1f;
        
        private float _tiempoInicial;
        private const float TAU = 6.283185307179586F; // 2 PI  
        private const float LIMITE_DE_INCLINACIÓN = 1.3F;
        
        private void Awake() {
            _tiempoInicial = Time.time;
        }

        private void Update() {
            var factorDeInclinación = 
                Mathf.Sin((Time.time - _tiempoInicial + LIMITE_DE_INCLINACIÓN) * TAU) * _potenciaDeGiro;

            
            transform.Rotate(0f, 0f, factorDeInclinación);
            transform.position += transform.up * (Velocidad * Time.deltaTime);
        }
    }

}
