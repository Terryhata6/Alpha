using AlphaSource.Characters;
using AlphaSource.Services.Camera;
using AlphaSource.Services.Damage;
using UnityEngine;
using Zenject;

namespace AlphaSource.Services.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [Header("Instances")][SerializeField]
        private CharacterFabric _characterFabricInstance;

        [Header("Examples")][SerializeField] 
        private SceneCameraManager _sceneCameraManagerExample;
        private DamageGlobalExecutor _damageGlobalExecutor;
        
        [Inject]
        public void Construct()
        {
            
        }
        
        public override void InstallBindings()
        {
            BindCharacterFabric();
            BindGlobalDamageExe();
            BindCameraManagement();
        }

        private void BindCameraManagement()
        {
            var cameraManager = Instantiate(_sceneCameraManagerExample, transform);
            Container.Bind<SceneCameraManager>().FromInstance(cameraManager).AsSingle().NonLazy();
        }

        private void BindGlobalDamageExe()
        {
            Container.Bind<DamageGlobalExecutor>().FromInstance(new DamageGlobalExecutor()).AsSingle().NonLazy();
        }

        private void BindCharacterFabric()
        {
            Container.Bind<CharacterFabric>().FromInstance(_characterFabricInstance).AsSingle().NonLazy();
            
        }
    }
}