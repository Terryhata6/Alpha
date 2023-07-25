using AlphaSource.Services.UI;
using AlphaSource.Services.Updater;
using Rewired;
using UnityEngine;
using Zenject;

namespace AlphaSource.Services.DI
{
    public class BootstrapInstaller : MonoInstaller
    {
        [Header("Prefabs")] 
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private UpdateRunner _updateRunner;
        [SerializeField] private UIMediator _uiMediator;
        public override void InstallBindings()
        {
            BindInputManager();
            BindRunner();
            BindUI();
        }

        private void BindUI()
        {
            var uiMediator = Instantiate(_uiMediator, transform);
            Container.Bind<UIMediator>().FromInstance(uiMediator).AsSingle().NonLazy();
        }

        private void BindRunner()
        {
            var runner = Instantiate(_updateRunner, transform);
            Container.Bind<UpdateRunner>().FromInstance(runner).AsSingle().NonLazy();
        }

        private void BindInputManager()
        {
            var input = Instantiate(_inputManager, transform);
            Container.Bind<InputManager>().FromInstance(input).AsSingle().NonLazy();
        }
    }
}
