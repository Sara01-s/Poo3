using UnityEngine;

namespace SaraSanMartin {


    [RequireComponent(typeof(Rigidbody2D))]
    public class ControladorPersonaje2D : MonoBehaviour {


        private struct InputActual {
            internal float DirecciónX;
            internal bool SaltoPresionado;
        } private InputActual _input;

        
        private Rigidbody2D _físicaPersonaje;

        [Header("Movimiento")]
        [SerializeField] private float _factorDeDesaceleración;
        [SerializeField] private float _factorDeAceleración;
        [SerializeField] private float _velocidadHorizontal;
        [SerializeField] private float _velocidadVertical;
        [SerializeField] private float _máximoDeVelocidad;

        [Header("Salto")]
        [SerializeField] private LayerMask _capaSuelo;
        [SerializeField] private float _acceleraciónSubida;
        [SerializeField] private float _acceleraciónCaída;
        [SerializeField] private float _tamañoRayoAlSuelo;
        [SerializeField] private float _fuerzaSalto;


        private void Awake() {
            _físicaPersonaje = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            // Calcular velocity (similar a rigidbody.velocity)
            _input.DirecciónX = Input.GetAxis("Horizontal");
            _input.SaltoPresionado = Input.GetButtonDown("Jump");

            var direcciónMovimiento = new Vector3(_velocidadHorizontal, 0f) * Time.deltaTime; 
            transform.position += direcciónMovimiento;
            CalcularCaminata();

            if (_input.SaltoPresionado && EnElSuelo()) {
                _físicaPersonaje.velocity = Vector2.up * _fuerzaSalto;
            }
        }

        private void FixedUpdate() {
            var subiendo = _físicaPersonaje.velocity.y > 0;

            if (subiendo)
                Acelerar(_acceleraciónSubida);
            else //bajando
                Acelerar(_acceleraciónCaída);                           
	    }


        private void Acelerar(float magnitud) {
            _físicaPersonaje.velocity += ((Physics2D.gravity.y * (magnitud - 1)) * Time.deltaTime) * Vector2.up;

            if (_físicaPersonaje.velocity.y < 0f) {
                transform.position += Vector3.zero;
                _físicaPersonaje.velocity += Vector2.zero;
            }
        }


        private bool EnElSuelo() {
            return Physics2D.Raycast(transform.position, Vector2.down, _tamañoRayoAlSuelo, _capaSuelo);
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


        private void OnDrawGizmos() {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Vector2.down * _tamañoRayoAlSuelo);
        }
    }
}
