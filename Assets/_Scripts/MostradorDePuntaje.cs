using UnityEngine;
using TMPro;

namespace SaraSanMartin {


    internal sealed class MostradorDePuntaje : MonoBehaviour {

        private TextMeshProUGUI _uiTexto;

        private void Awake() {
            _uiTexto = GetComponent<TextMeshProUGUI>();
            ActualizarPuntaje();
        } 

        private void OnEnable() => Puntaje.AlAñadirPuntaje += ActualizarPuntaje;
        private void OnDisable() => Puntaje.AlAñadirPuntaje -= ActualizarPuntaje;

        private void ActualizarPuntaje() => _uiTexto.text = $"Puntuación: { Puntaje.Puntuación }";
    }
}
