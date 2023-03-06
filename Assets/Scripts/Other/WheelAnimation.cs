using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        transform.Rotate(new Vector3 (0, _rotationSpeed * Time.deltaTime, 0));
    }
}
