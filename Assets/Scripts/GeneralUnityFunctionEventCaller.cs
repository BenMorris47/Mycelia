using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralUnityFunctionEventCaller : MonoBehaviour
{
    public UnityEvent onAwake;
    public UnityEvent onStart;
    public UnityEvent onEnable;
    public UnityEvent onDisable;
    public UnityEvent onUpdate;
    public UnityEvent onDestroy;

    private void Awake()
    {
        onAwake?.Invoke();
    }
    private void Start()
    {
        onStart?.Invoke();
    }
    private void OnEnable()
    {
        onEnable?.Invoke();
    }
    private void OnDisable()
    {
        onDisable?.Invoke();
    }
    private void Update()
    {
        onUpdate?.Invoke();
    }
    private void OnDestroy()
    {
        onDestroy?.Invoke();
    }
}
