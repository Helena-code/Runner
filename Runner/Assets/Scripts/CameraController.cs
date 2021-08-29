using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform PlayerTransform;

    Transform _camTransform;
    Vector3 _newPosCam;
    float _smooth;
    float _camX;
    float _camY;
    float _distZ;

    void Awake()
    {
        _camTransform = transform;
        _camX = _camTransform.position.x;
        _camY = _camTransform.position.y;
        _smooth = 5f;

        Vector3 temp = transform.position - PlayerTransform.position;
        _distZ = temp.z;
    }

    void Update()
    {
        _newPosCam = new Vector3(_camX, _camY, _distZ + PlayerTransform.position.z);
        _camTransform.position = Vector3.Lerp(_camTransform.position, _newPosCam, _smooth * Time.deltaTime);
    }
}
