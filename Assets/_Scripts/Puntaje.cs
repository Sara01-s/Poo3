using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Puntaje : MonoBehaviour {

        internal static int Puntuación;
        internal static System.Action AlAñadirPuntaje;

        internal static void AñadirPuntaje() {
            Puntuación++;
            AlAñadirPuntaje?.Invoke();
        } 

    }
}