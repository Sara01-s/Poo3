using UnityEngine;

namespace SaraSanMartin {


    public class ControladorPersonaje2D : MonoBehaviour {

        internal struct InputActual {
            internal float Direcci�nX;
            internal bool SaltoPresionado;
            internal bool SaltoSoltado;
        }
        internal InputActual _input;
        
        
        internal Vector3 Direcci�n { get; private set; }

        public float _�ltimoSalto;
        public Vector3 _�ltimaPosici�n;
        public float _factorDeAceleraci�n, _factorDeDesaceleraci�n;
        public float _velocidadVertical, _velocidadHorizontal;
        public float _m�ximoDeVelocidad;


        private void Update() {
            // Calcular velocity (similar a rigidbody.velocity)
            Direcci�n = (transform.position - _�ltimaPosici�n) / Time.deltaTime;
            _�ltimaPosici�n = transform.position;

            _input = new InputActual {
                Direcci�nX = Input.GetAxis("Horizontal"),
                SaltoPresionado = Input.GetButtonDown("Jump"),
                SaltoSoltado = Input.GetButtonUp("Jump")
            };

            if (_input.SaltoPresionado)
                _�ltimoSalto = Time.time;


            CalcularCaminata();
        }

        private void CalcularCaminata() {
            
            if (_input.Direcci�nX != 0) {

                _velocidadHorizontal = _input.Direcci�nX * (_factorDeAceleraci�n * Time.deltaTime);
                _velocidadHorizontal = Mathf.Clamp(_velocidadHorizontal, -_m�ximoDeVelocidad, _m�ximoDeVelocidad);
            }
            else { // No hay input, desacelerar personaje
                _velocidadHorizontal = Mathf.MoveTowards(_velocidadHorizontal, 0, _factorDeDesaceleraci�n * Time.deltaTime);
            }
        }
    }
}
