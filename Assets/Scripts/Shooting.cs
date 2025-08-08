using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Player shooting")]
    [SerializeField] GameObject _bulletPrefabs;
    [SerializeField] float _bulletSpeed = 10.0f;
    [SerializeField] float _bulletLifetime = 5.0f;
    [SerializeField] float _baseFireRate = 0.2f;

    [Header("AI shooting")]
    [SerializeField] bool _useAI;
    [SerializeField] float _firingRateVariance = 0.0f;
    [SerializeField] float _minimumFiringRate = 0.1f;

    [HideInInspector] public bool _isFiring;
    Coroutine _firingCoroutine;

    void Start()
    {
        if (_useAI)
        {
            _isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (_isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinously());
        }
        else if (!_isFiring && _firingCoroutine != null)
        { 
            StopAllCoroutines();
            _firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(_bulletPrefabs, transform.position, Quaternion.identity);

            Rigidbody2D rb2D = instance.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                rb2D.velocity = transform.up * _bulletSpeed;
            }

            Destroy(instance, _bulletLifetime);

            float timeToNextProjectile = Random.Range(_baseFireRate - _firingRateVariance, _baseFireRate + _firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, _minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
