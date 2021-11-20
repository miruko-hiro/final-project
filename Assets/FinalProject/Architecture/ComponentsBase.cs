using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture
{
    public sealed class ComponentsBase<T> where T : IArchitectureComponent
    {
        private Dictionary<Type, T> _componentMap;

        private Coroutines _coroutines;
        
        [Inject]
        public ComponentsBase(Coroutines coroutines, string[] classReferences)
        {
            _coroutines = coroutines;
            _componentMap = CreateInstances<T>(classReferences);
        }

        private Dictionary<Type, T> CreateInstances<T>(string[] classReferences) where T : IArchitectureComponent
        {
            var createMap = new Dictionary<Type, T>();

            foreach (var reference in classReferences)
            {
                var type = Type.GetType(reference);
                var result = Activator.CreateInstance(type);
                var resultComponent = (T) result;
                createMap[type] = resultComponent;
            }

            return createMap;
        }

        public void SendMessageOnCreate()
        {
            var allComponents = _componentMap.Values;
            foreach (var component in allComponents) 
                component.OnCreate();
        }

        public void SendMessageOnInitialize()
        {
            var allComponents = _componentMap.Values;
            foreach (var component in allComponents) 
                component.OnInitialize();
        }

        public void SendMessageOnStart()
        {
            var allComponents = _componentMap.Values;
            foreach (var component in allComponents) 
                component.OnStart();
        }

        public Coroutine InitializeAllComponentsStarter()
        {
            return _coroutines.StartRoutine(InitializeAllComponentsCoroutine());
        }

        private IEnumerator InitializeAllComponentsCoroutine()
        {
            var allComponents = _componentMap.Values;
            foreach (var component in allComponents)
                if (!component.IsInitialized)
                    yield return component.InitializeStarter();
        }

        public TP GetComponent<TP>() where TP : T
        {
            var type = typeof(TP);
            var founded = _componentMap.TryGetValue(type, out var resultComponent);
            
            if(founded)
                return (TP) resultComponent;

            var allComponents = _componentMap.Values;
            foreach (var component in allComponents)
                if (component is TP resultComponent2)
                    return resultComponent2;
            
            throw new KeyNotFoundException($"Key: {type}");
        }

        public IEnumerable<TP> GetComponents<TP>() where TP : IArchitectureComponent
        {
            var allComponents = _componentMap.Values;
            var requiredComponents = new HashSet<TP>();
            foreach (var component in allComponents)
                if (component is TP requiredComponent)
                    requiredComponents.Add(requiredComponent);

            return requiredComponents;
        }
    }
}