using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Disparador : MonoBehaviour {


        [SerializeField] private Bala[] _balas = new Bala[3];

        private void Update() {
            if (GetInput("Fire1"))
                print("Bala 1");
                
            else if (GetInput("Fire2"))
                print("Bala 2");
                
            else if (GetInput("Fire3"))
                print("Bala 3");
        }

        private bool GetInput(string input) {
            return Input.GetButtonDown(input);
        }
    }
}