using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Instanciador : MonoBehaviour {

        [SerializeField] private GameObject _objetoAInstanciar;
        [SerializeField] private float _frecuenciaDeAparición;
        [SerializeField] [Range(1f, 10f)] float _distanciaDeAparición;

        private void Start() {
            InvokeRepeating(nameof(InstanciarObjeto), 0f, _frecuenciaDeAparición);
        }

        private void InstanciarObjeto() {
            var objInstanciado = Instantiate(_objetoAInstanciar, transform, transform);
            var posiciónRandom = new Vector2(
                transform.position.x + Random.Range(-_distanciaDeAparición, _distanciaDeAparición), 
                transform.position.y + Random.Range(-_distanciaDeAparición, _distanciaDeAparición));

            objInstanciado.transform.position = posiciónRandom;
            objInstanciado.AddComponent<Rigidbody2D>();
        }

    }
}
