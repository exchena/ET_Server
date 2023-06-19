﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ET
{
    public class World: IDisposable
    {
        [StaticField]
        public static World Instance = new();

        private World()
        {
        }

        private readonly ConcurrentDictionary<Type, ISingleton> singletons = new();

        public T AddSingleton<T>() where T : Singleton<T>, ISingletonAwake, new()
        {
            T singleton = new();
            singleton.Awake();

            AddSingleton(singleton);
            return singleton;
        }
        
        public T AddSingleton<T, A>(A a) where T : Singleton<T>, ISingletonAwake<A>, new()
        {
            T singleton = new();
            singleton.Awake(a);

            AddSingleton(singleton);
            return singleton;
        }
        
        public T AddSingleton<T, A, B>(A a, B b) where T : Singleton<T>, ISingletonAwake<A, B>, new()
        {
            T singleton = new();
            singleton.Awake(a, b);

            AddSingleton(singleton);
            return singleton;
        }
        
        public T AddSingleton<T, A, B, C>(A a, B b, C c) where T : Singleton<T>, ISingletonAwake<A, B, C>, new()
        {
            T singleton = new();
            singleton.Awake(a, b, c);

            AddSingleton(singleton);
            return singleton;
        }

        public void AddSingleton(ISingleton singleton)
        {
            singletons[singleton.GetType()] = singleton;
            singleton.Register();
        }

        public void Dispose()
        {
            foreach (ISingleton singleton in this.singletons.Values)
            {
                singleton.Dispose();
            }
        }
    }
}