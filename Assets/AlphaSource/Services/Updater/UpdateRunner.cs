﻿using System;
using System.Collections.Generic;
using AlphaSource.Services.Updater.Interfaces;
using UnityEngine;

namespace AlphaSource.Services.Updater
{
    public class UpdateRunner : MonoBehaviour
    {
        public event Action FixedUpdateEvent;
        public event Action LateUpdateEvent;
        public event Action UpdateEvent;

        public void Subscribe<T>(T instance) where T : IExecutor
        {
            if (instance is IFixedUpdatable fixedUpdatable) FixedUpdateEvent += fixedUpdatable.FixedExecute;
            if (instance is ILateUpdatable lateUpdatable) LateUpdateEvent += lateUpdatable.LateExecute;
            if (instance is IUpdatable updatable) UpdateEvent += updatable.Execute;
        }

        public void Unsubscribe<T>(T instance) where T : IExecutor
        {
            if (instance is IFixedUpdatable fixedUpdatable) FixedUpdateEvent -= fixedUpdatable.FixedExecute;
            if (instance is ILateUpdatable lateUpdatable) LateUpdateEvent -= lateUpdatable.LateExecute;
            if (instance is IUpdatable updatable) UpdateEvent -= updatable.Execute;
        }

        private void FixedUpdate() => FixedUpdateEvent?.Invoke();
        private void LateUpdate() => LateUpdateEvent?.Invoke();
        private void Update() => UpdateEvent?.Invoke();
    }
}