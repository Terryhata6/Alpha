using AlphaSource.Characters;
using UnityEngine;
using Zenject;

namespace AlphaSource.Services.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private CharacterFabric _characterFabricInstance;
        
        [Inject]
        public void Construct()
        {
            
        }
        
        public override void InstallBindings()
        {
            BindCharacterFabric();
        }

        private void BindCharacterFabric()
        {
            Container.Bind<CharacterFabric>().FromInstance(_characterFabricInstance).AsSingle().NonLazy();
        }
    }
}