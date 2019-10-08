using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {
    public static T Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this as T;

            Init();
        }
        else
            Destroy(this);
    }

    /// <summary>
    /// If need Awake() in child class.
    /// </summary>
    protected virtual void Init() {
    }
}