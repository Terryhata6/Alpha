using System;
using System.Collections.Generic;
using AlphaSource.Characters;
using Cinemachine;
using UnityEngine;

namespace AlphaSource.Services.Camera
{
    public class SceneCameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCameraExample;
        public List<CameraIDPair> Cameras = new List<CameraIDPair>();
        
        public void SetupCharacterCamera(CharacterMediator mediator)
        {
            var camera = Instantiate(_virtualCameraExample, transform);
            camera.LookAt = mediator.transform;
            camera.Follow = mediator.transform;
            var pair = new CameraIDPair();
            pair.Camera = camera;
            pair.ID = mediator.ID;
            Cameras.Add(pair);
        }
    }

    [Serializable]
    public struct CameraIDPair
    {
        public string ID;
        public CinemachineVirtualCamera Camera;
    }
}