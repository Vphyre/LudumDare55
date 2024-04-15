using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private bool _canAttack;
    public bool CanAttack {get {return _canAttack;}}
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private Transform spawnPoint;
    public UnityEvent OnAttack;

    public void Attack()
    {
        if (_canAttack)
        {
            GameObject newEnemy = Instantiate(_attackPrefab, spawnPoint.position, spawnPoint.rotation);
            newEnemy.SetActive(true);
            OnAttack.Invoke();
        }
    }
    public void SetCanAttack(bool value)
    {
        _canAttack = value;
    }

}
