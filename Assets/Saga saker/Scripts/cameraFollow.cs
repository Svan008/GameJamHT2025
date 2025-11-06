using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;

    private Bounds  _cameraBounds;//nova
    private Vector3 _targetPostion;//nova
    private Camera _mainCamera;//nova
    

    private void Awake() => _mainCamera = Camera.main;//nova



    void Start()
    {
        offset = transform.position - target.position;

        var height = _mainCamera.orthographicSize;//nova
        var width = height * _mainCamera.aspect;//nova

        var minX = Globals.WorldBounds.min.x;//noav
        var minY = Globals.WorldBounds.min.y;//nova

        var maxX = Globals.WorldBounds.max.x;//nova
        var maxY = Globals.WorldBounds.max.y;//nova

        _cameraBounds = new Bounds();//nova
        _cameraBounds.SetMinMax(
            new Vector3 (minX , minY , 0.0f),
            new Vector3 (maxX , maxY , 0.0f)
            );//nova
    }

    // Update is called once per frame
    void Update()
    {
        _targetPostion = target.position + offset;//nova
        _targetPostion = GetCameraBounds();//nova

        transform.position = _targetPostion;
    }

    private Vector3 GetCameraBounds()//nova
    {
        return new Vector3(
            Mathf.Clamp(_targetPostion.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(_targetPostion.y, _cameraBounds.min.y, _cameraBounds.max.y),
            transform.position.z
            );//nova
    }

    private void OnDrawGizmos()//nova
    {
        Gizmos.DrawSphere(new Vector3(_cameraBounds.min.x, 0, 0),1);
        Gizmos.DrawCube(new Vector3(_cameraBounds.max.x, 0, 0), Vector3.one);
        Gizmos.DrawCube(new Vector3(0, _cameraBounds.min.y, 0), Vector3.one);
        Gizmos.DrawCube(new Vector3(0, _cameraBounds.max.y, 0), Vector3.one);
    }
}
