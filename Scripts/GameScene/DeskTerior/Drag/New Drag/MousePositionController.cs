using UnityEngine;
using UnityEngine.InputSystem;

// FindMousePlace의 역할을 가져옴.
public class MousePositionController : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] public Vector3 mousePos;
    [SerializeField] public Vector3 worldPos;

    private float borderLine = -504f;    
    [field: SerializeField] public bool IsOnSub {  get; private set; }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        mousePos.x = Mathf.Clamp(mousePos.x, 0f, Screen.width);
        mousePos.y = Mathf.Clamp(mousePos.y, 0f, Screen.height);

        worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;
        MouseIsOnSub();
    }

    private void MouseIsOnSub()
    {
        if (worldPos.x < borderLine)
        {
            IsOnSub = true;
        }
        else
        {
            IsOnSub = false;
        }
    }
}
