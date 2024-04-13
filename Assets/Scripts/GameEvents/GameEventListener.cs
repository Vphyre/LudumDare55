using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListener<T> : MonoBehaviour
{
    [SerializeField] private GameEvent<T> _gameEvent;

    public UnityEvent<T> OnInvoke;

    private void OnEnable()
    {
        _gameEvent.OnInvoked.AddListener(GameEventInvoked);
    }

    private void OnDisable()
    {
        _gameEvent.OnInvoked.RemoveListener(GameEventInvoked);
    }

    private void GameEventInvoked(T param)
    {
        if (_gameEvent.Log) Debug.Log($"{_gameEvent.name} triggered Event Listener on the object {gameObject.name}");
        OnInvoke.Invoke(param);
    }
}
