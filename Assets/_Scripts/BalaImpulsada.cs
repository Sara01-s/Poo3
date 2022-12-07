using UnityEngine;

namespace SaraSanMartin {


    internal sealed class BalaImpulsada : Bala {

        [field: SerializeField]
        protected override float Velocidad { get; set; }
        [SerializeField] private float _velocidadMínima = 0f;
        [SerializeField] private float _velocidadMáxima = 15f;
        [SerializeField] private AnimationCurve _curvaDeImpulso;

        private float _tiempoInicial;

        private void Awake() {
            _tiempoInicial = Time.time;
        }
        
        private void Update() {
            Velocidad =  Mathf.Lerp(_velocidadMínima, _velocidadMáxima, 
                                    _curvaDeImpulso.Evaluate(Mathf.Sin(Time.time - _tiempoInicial)));
                                    
            transform.position += transform.up * (Velocidad * Time.deltaTime);
        }
    }

}
