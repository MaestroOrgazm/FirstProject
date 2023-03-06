using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private GameObject _wheelOne;
    [SerializeField] private GameObject _wheelTwo;
    [SerializeField] private Transform _target;
    [SerializeField] private EnemySpawner _spawner;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(MoveToHome());
        _spawner.SetTarget(_target);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Teleport(float value)
    {
        Vector3 target = new Vector3(transform.position.x - value,
                         transform.position.y, transform.position.z);

        transform.position = target;
    }

    private IEnumerator MoveToHome()
    {
        while (transform.position != _target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
