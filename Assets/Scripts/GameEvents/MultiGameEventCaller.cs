using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiGameEventCaller : MonoBehaviour
{
    [SerializeField] private GameEventRaiseFlag _raiseEvent;
    [SerializeField] private UnityEvent _onAwakeEvent;
    [SerializeField] private UnityEvent _onEnableEvent;
    [SerializeField] private UnityEvent _onStartEvent;
    [SerializeField] private UnityEvent _onFixedUpdateEvent;
    [SerializeField] private UnityEvent _onUpdateEvent;
    [SerializeField] private UnityEvent _onLateUpdateEvent;
    [SerializeField] private UnityEvent _onDisableEvent;
    [SerializeField] private UnityEvent _onDestroyEvent;

    private void Awake()
    {
        if (HasEventFlag(GameEventRaiseFlag.Awake)) _onAwakeEvent.Invoke();
    }

    private void OnEnable()
    {
        if (HasEventFlag(GameEventRaiseFlag.OnEnable)) _onEnableEvent.Invoke();
    }

    private void Start()
    {
        if (HasEventFlag(GameEventRaiseFlag.Start)) _onStartEvent.Invoke();
    }

    private void FixedUpdate()
    {
        if (HasEventFlag(GameEventRaiseFlag.FixedUpdate)) _onFixedUpdateEvent.Invoke();
    }

    private void Update()
    {
        if (HasEventFlag(GameEventRaiseFlag.Update)) _onUpdateEvent.Invoke();
    }

    private void LateUpdate()
    {
        if (HasEventFlag(GameEventRaiseFlag.LateUpdate)) _onLateUpdateEvent.Invoke();
    }

    private void OnDisable()
    {
        if (HasEventFlag(GameEventRaiseFlag.OnDisable)) _onDisableEvent.Invoke();
    }

    private void OnDestroy()
    {
        if (HasEventFlag(GameEventRaiseFlag.OnDestroy)) _onDestroyEvent.Invoke();
    }

    private bool HasEventFlag(GameEventRaiseFlag flag)
    {
        return ((_raiseEvent & flag) == flag);
    }

    [System.Flags]
    public enum GameEventRaiseFlag
    {
        Awake = 1 << 1,
        OnEnable = 1 << 2,
        Start = 1 << 3,
        FixedUpdate = 1 << 4,
        Update = 1 << 5,
        LateUpdate = 1 << 6,
        OnDisable = 1 << 7,
        OnDestroy = 1 << 8
    }
}
