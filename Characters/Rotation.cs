using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Rotation : MonoBehaviour
{
    [Range(0f, 90f)][SerializeField] float _yRotationLimit = 88f;
    Vector2 _rotation = Vector2.zero;

    void Start()
    {

    }
    public void RotateByAxisY(float yAxis, float sensitivity = 1)
    {
        _rotation.y += yAxis*sensitivity;
        _rotation.y = Mathf.Clamp(_rotation.y, -_yRotationLimit, _yRotationLimit);
        var yQuat = Quaternion.AngleAxis(_rotation.y, Vector3.left) ;
        transform.localRotation = yQuat;
    }

    public void RotateByAxisX(float xAxis, float sensitivity = 1)
    {
        _rotation.x += xAxis*sensitivity;
        var xQuat = Quaternion.AngleAxis(_rotation.x, Vector3.up);
        transform.localRotation = xQuat;
    }
}
