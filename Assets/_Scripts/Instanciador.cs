using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Instanciador : MonoBehaviour {

        [SerializeField] [Range(1f, 10f)] float _distanciaDeAparición;
        [SerializeField] private GameObject _objetoAInstanciar;
        [SerializeField] private Sprite[] _numeros = new Sprite[3];
        [SerializeField] private SpriteRenderer _spriteNumero;

        private sbyte _iteradorDeSprites;

        private void Start() {
            InvokeRepeating(nameof(InstanciarObjeto), 0f, 3f);
            InvokeRepeating(nameof(MostrarSiguienteNúmero), 0f, 1f);
        }

        private void MostrarSiguienteNúmero() {
            _spriteNumero.sprite = _numeros[_iteradorDeSprites++ % _numeros.Length];
        }

        private void InstanciarObjeto() {
            var objInstanciado = Instantiate(_objetoAInstanciar, transform, transform);
            var posiciónRandom = new Vector2(
                transform.position.x + Random.Range(-_distanciaDeAparición, _distanciaDeAparición), 
                transform.position.y + Random.Range(-_distanciaDeAparición, _distanciaDeAparición));

            objInstanciado.transform.position = posiciónRandom;

        }
    }
}
