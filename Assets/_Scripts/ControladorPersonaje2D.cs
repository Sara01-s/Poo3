using UnityEngine;

namespace SaraSanMartin {


    public class ControladorPersonaje2D : MonoBehaviour {

        internal struct InputActual {
            internal float DirecciónX;
            internal bool SaltoPresionado;
            internal bool SaltoSoltado;
        }
        internal InputActual _input;
        
        
        internal Vector3 Dirección { get; private set; }

        public float _últimoSalto;
        public Vector3 _últimaPosición;
        public float _factorDeAceleración, _factorDeDesaceleración;
        public float _velocidadVertical, _velocidadHorizontal;
        public float _máximoDeVelocidad;


        private void Update() {
            // Calcular velocity (similar a rigidbody.velocity)
            Dirección = (transform.position - _últimaPosición) / Time.deltaTime;
            _últimaPosición = transform.position;

            _input = new InputActual {
                DirecciónX = Input.GetAxis("Horizontal"),
                SaltoPresionado = Input.GetButtonDown("Jump"),
                SaltoSoltado = Input.GetButtonUp("Jump")
            };

            if (_input.SaltoPresionado)
                _últimoSalto = Time.time;


            CalcularCaminata();
        }

        private void CalcularCaminata() {
            
            if (_input.DirecciónX != 0) {

                _velocidadHorizontal = _input.DirecciónX * (_factorDeAceleración * Time.deltaTime);
                _velocidadHorizontal = Mathf.Clamp(_velocidadHorizontal, -_máximoDeVelocidad, _máximoDeVelocidad);
            }
            else { // No hay input, desacelerar personaje
                _velocidadHorizontal = Mathf.MoveTowards(_velocidadHorizontal, 0, _factorDeDesaceleración * Time.deltaTime);
            }
        }
    }
}
