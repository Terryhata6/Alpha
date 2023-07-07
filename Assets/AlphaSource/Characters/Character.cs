using Rewired;
using UnityEngine;
using Zenject;

namespace AlphaSource.Characters
{
    public class Character : MonoBehaviour
    {
        private InputManager _inputManager;

        [Inject]
        public void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
            BindInput(_inputManager);
        }

        private void BindInput(InputManager inputManager)
        {
            
        }
    }
}
