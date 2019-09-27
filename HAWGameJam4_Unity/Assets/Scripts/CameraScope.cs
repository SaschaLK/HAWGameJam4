using UnityEngine;

public class CameraScope : MonoBehaviour {

    [SerializeField] Transform[] targets;
    [SerializeField] float boundingBoxPadding = 2f;
    [SerializeField] float minimumOrthographicSize = 8f;
    [SerializeField] float zoomSpeed = 20f;
    [SerializeField] float upperBoundFactor = 3f;
    
    private Camera _camera;
    
    private float _startingMinX;
    private float _startingMaxX;
    private float _startingMinY;
    private float _startingMaxY;
    
    private float _flexMaxY;

    void Awake() 
    {
        _camera = GetComponent<Camera>();
        _camera.orthographic = true;
    }

    void Start()
    {
        CalculateStartingBounds();
    }

    void LateUpdate()
    {
        Rect boundingBox = CalculateBoundsByTargets();
        transform.position = CalculateCameraPosition(boundingBox);
        _camera.orthographicSize = CalculateOrthographicSize(boundingBox);
    }
    
    void CalculateStartingBounds()
    {
        foreach (Transform target in targets) 
        {
            Vector3 position = target.position;

            _startingMinX = Mathf.Min(_startingMinX, position.x);
            _startingMaxX = Mathf.Max(_startingMaxX, position.x);
            _startingMinY = Mathf.Min(_startingMinY, position.y);
            _startingMaxY = Mathf.Max(_startingMaxY, position.y);
        }
    }

    private Rect CalculateBoundsByTargets()
    {
         _flexMaxY = Mathf.NegativeInfinity;

        foreach (Transform target in targets) 
        {
            Vector3 position = target.position;

            _flexMaxY = Mathf.Max(_flexMaxY, position.y);
        }

        return Rect.MinMaxRect(
            _startingMinX - boundingBoxPadding, 
            _flexMaxY + boundingBoxPadding, 
            _startingMaxX + boundingBoxPadding, 
            _startingMinY - boundingBoxPadding);
    }

    private Vector3 CalculateCameraPosition(Rect boundingBox)
    {
        Vector2 boundingBoxCenter = boundingBox.center;

        return new Vector3(boundingBoxCenter.x, boundingBoxCenter.y, _camera.transform.position.z);
    }

    private float CalculateOrthographicSize(Rect boundingBox)
    {
        float orthographicSize = _camera.orthographicSize;
        Vector3 topRight = new Vector3(boundingBox.x + boundingBox.width, boundingBox.y, 0f);
        Vector3 topRightAsViewport = _camera.WorldToViewportPoint(topRight);
       
        if (topRightAsViewport.x >= topRightAsViewport.y)
            orthographicSize = Mathf.Abs(boundingBox.width) / _camera.aspect / 2f;
        else
            orthographicSize = Mathf.Abs(boundingBox.height) / 2f;

        return Mathf.Clamp(Mathf.Lerp(_camera.orthographicSize, orthographicSize, Time.deltaTime * zoomSpeed), minimumOrthographicSize, Mathf.Infinity);
    }
}