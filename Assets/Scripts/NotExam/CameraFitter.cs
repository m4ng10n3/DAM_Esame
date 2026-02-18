using UnityEngine;

public class CameraFitter : MonoBehaviour
{
    [Header("Configurazione")]
    public float sceneWidth = 20f; 

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        AdjustCamera();
    }
    
    void Update()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        
        cam.orthographicSize = desiredHalfHeight;
    }
}