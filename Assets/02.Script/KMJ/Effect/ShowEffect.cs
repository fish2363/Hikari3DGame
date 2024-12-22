using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowEffect : MonoBehaviour
{
    public ParticleSystem[] _particles;

    public float _duration;
    private WaitForSeconds _particleDuration;

    public UnityEvent OnStartEffectEvent;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
        _duration = _particles[0].main.duration;
        _particleDuration = new WaitForSeconds(_duration + 2);
    }

    public void SetPositionAndPlay(Vector3 position, Transform parent)
    {
        transform.SetParent(parent);
        transform.position = position;
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }

        OnStartEffectEvent?.Invoke();
        StartCoroutine(DelayAndGotoPoolCoroutine());
    }

    private IEnumerator DelayAndGotoPoolCoroutine()
    {
        yield return _particleDuration;
        Destroy(gameObject);
    }
}
