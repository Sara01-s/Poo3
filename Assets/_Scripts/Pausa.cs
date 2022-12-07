using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Pausa : MonoBehaviour {

        [SerializeField] private GameObject _íconoPausa, _íconoContinuar;
        [SerializeField] private AudioSource _music;
        private bool _juegoPausado = false;

        public void InterrumptorDePause() {
            _juegoPausado = !_juegoPausado;

            if (_juegoPausado) _music.Pause();
            else _music.Play();

            _íconoContinuar.SetActive(_juegoPausado);
            _íconoPausa.SetActive(!_juegoPausado);

            Time.timeScale = (_juegoPausado)? 0 : 1;
            
        }
    }
}
