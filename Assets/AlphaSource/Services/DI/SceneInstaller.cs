using System;
using AlphaSource.Characters;
using AlphaSource.Services.Camera;
using AlphaSource.Services.Damage;
using AlphaSource.Services.PlayerDirectory;
using AlphaSource.Services.SaveLoad;
using AlphaSource.Services.SceneRunners;
using AlphaSource.Services.Updater;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace AlphaSource.Services.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [Header("Instances")][SerializeField]
        private SceneRunner _sceneRunner;

        [Space][Header("Examples")]
        [SerializeField] private CharacterFabric _characterFabricInstance;
        [SerializeField] private SceneCameraManager _sceneCameraManagerExample;
        private DamageGlobalExecutor _damageGlobalExecutor;
        
        
        [Header("Dependencies")]
        private PlayerManager _playerManager;
        private ISaveLoadSystem _saveLoad;
        private UpdateRunner _updRunner;

        [Inject]
        public void Construct(UpdateRunner updRunner,PlayerManager playerManager, ISaveLoadSystem saveLoad)
        {
            _updRunner = updRunner;
            _saveLoad = saveLoad;
            _playerManager = playerManager;
        }
        
        
        public override void InstallBindings()
        {
            var damageGlobalExecutor = BindGlobalDamageExecutor();
            var cameraManager = BindCameraManagement();
            var fabric = BindCharacterFabric(_updRunner, damageGlobalExecutor, cameraManager);
            BindSceneRunner(fabric);

        }

        private void BindSceneRunner(CharacterFabric fabric)
        {
            Container.Bind<SceneRunner>().FromInstance(_sceneRunner).AsSingle().NonLazy();
            _sceneRunner.Init(_playerManager, fabric);
        }
        
        private SceneCameraManager BindCameraManagement()
        {
            var cameraManager = Instantiate(_sceneCameraManagerExample, transform);
            Container.Bind<SceneCameraManager>().FromInstance(cameraManager).AsSingle().NonLazy();
            return cameraManager;
        }

        private DamageGlobalExecutor BindGlobalDamageExecutor()
        {
            var damageGlobalExecutor = new DamageGlobalExecutor();
            Container.Bind<DamageGlobalExecutor>().FromInstance(damageGlobalExecutor).AsSingle().NonLazy();
            return damageGlobalExecutor;
        }

        private CharacterFabric BindCharacterFabric(UpdateRunner updateRunner,
            DamageGlobalExecutor damageGlobalExecutor, SceneCameraManager sceneCameraManager)
        {
            var fabric = Instantiate(_characterFabricInstance, transform);
            Container.Bind<CharacterFabric>().FromInstance(fabric).AsSingle().NonLazy();
            fabric.Init(updateRunner, damageGlobalExecutor, sceneCameraManager);
            return fabric;
        }

        
        
       
    }
}