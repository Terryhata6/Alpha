using Rewired;
using UnityEngine;
using Zenject;

namespace CoreScripts.Services.DI
{
    public class BootstrapInstaller : MonoInstaller
    {
        [Header("Prefabs")] [SerializeField] private InputManager _inputManager;
        
        
        public override void InstallBindings()
        {
            BindInputManager();
        }

        private void BindInputManager()
        {
            var input = Instantiate(_inputManager, transform);
            Container.Bind<InputManager>().FromInstance(input).AsSingle().NonLazy();
        }
    }
}
