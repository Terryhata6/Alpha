using AlphaSource.Services.PlayerDirectory;
using AlphaSource.Services.SaveLoad;
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
            var saveLoad = BindSaveLoad();
            BindInputManager();
            BindRunner();
            BindUI();
            BindPlayerManager(saveLoad);
        }

        private ISaveLoadSystem BindSaveLoad()
        {
            var saveLoad = new SaveLoadSystem();
            Container.Bind<ISaveLoadSystem>().FromInstance(saveLoad).AsSingle().NonLazy();
            return saveLoad;
        }

        private void BindPlayerManager(ISaveLoadSystem saveLoadSystem)
        {
            var playerManager = new PlayerManager(saveLoadSystem);
            Container.Bind<PlayerManager>().FromInstance(playerManager).AsSingle().NonLazy();
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
