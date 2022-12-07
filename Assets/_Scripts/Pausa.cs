using UnityEngine;

namespace SaraSanMartin {


    public class Pausa : MonoBehaviour {

        [SerializeField] private GameObject _íconoPausa, _íconoContinuar;
        private bool _juegoPausado = false;

        public void InterrumptorDePause() {
            _juegoPausado = !_juegoPausado;

            _íconoContinuar.SetActive(_juegoPausado);
            _íconoPausa.SetActive(!_juegoPausado);

            Time.timeScale = (_juegoPausado)? 0 : 1;
        }
    }
}
