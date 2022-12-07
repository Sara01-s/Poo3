using UnityEngine;

namespace SaraSanMartin {


    internal sealed class Disparador : MonoBehaviour {


        [SerializeField] private Bala[] _balas = new Bala[3];
        [SerializeField] private Camera _cámara;
        [SerializeField] private Texture2D _mira;
        
        private void Awake() {
            var centroMira = new Vector2 (_mira.width >> 1, _mira.height >> 1);
            Cursor.SetCursor(_mira, centroMira, CursorMode.Auto);
        }

        private void Update() {

            var posiciónMouse = _cámara.ScreenToWorldPoint(Input.mousePosition);
            var distanciaMouse = posiciónMouse - transform.position;
            var rotaciónZ = Mathf.Atan2(distanciaMouse.x, distanciaMouse.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, -rotaciónZ);

            if (GetInput("Fire1"))
                Instantiate(_balas[0], transform.position, transform.rotation);

            else if (GetInput("Fire2")) 
                Instantiate(_balas[1], transform.position, transform.rotation);
                
            else if (GetInput("Fire3"))
                Instantiate(_balas[2], transform.position, transform.rotation);
        }

        private bool GetInput(string input) {
            return Input.GetButtonDown(input);
        }
    }
}