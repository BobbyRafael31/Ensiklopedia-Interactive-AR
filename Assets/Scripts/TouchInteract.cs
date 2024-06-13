using UnityEngine;

public class TouchInteract : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    public float inertiaDamping = 0.95f;
    private Vector3 rotationVelocity;

    public enum RotationAxis { XAxis, YAxis, ZAxis, Free }
    public RotationAxis rotationAxis = RotationAxis.Free;

    private bool isRotating = false;

    private float initialDistance;
    private Vector3 initialScale;

    public float minScale = 0.1f;
    public float maxScale = 3.0f;

    private bool isTouchingObject = false;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouchingObject = IsTouchingObject(touch.position);
            }

            if (isTouchingObject)
            {
                HandleRotation(touch);
            }
        }
        else if (Input.touchCount == 2)
        {
            HandlePinch();
        }
        else
        {
            if (!isRotating)
            {
                ApplyInertia();
            }
        }
    }

    bool IsTouchingObject(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                return true;
            }
        }
        return false;
    }

    void HandleRotation(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            isRotating = true;
            Vector2 touchDeltaPosition = touch.deltaPosition;

            switch (rotationAxis)
            {
                case RotationAxis.XAxis:
                    rotationVelocity = new Vector3(touchDeltaPosition.y * rotationSpeed, 0, 0);
                    break;
                case RotationAxis.YAxis:
                    rotationVelocity = new Vector3(0, -touchDeltaPosition.x * rotationSpeed, 0);
                    break;
                case RotationAxis.ZAxis:
                    rotationVelocity = new Vector3(0, 0, touchDeltaPosition.x * rotationSpeed);
                    break;
                case RotationAxis.Free:
                    rotationVelocity = new Vector3(touchDeltaPosition.y * rotationSpeed, -touchDeltaPosition.x * rotationSpeed, 0);
                    break;
            }

            ApplyRotation();
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            isRotating = false;
            isTouchingObject = false;
        }
    }

    void HandlePinch()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
        {
            initialDistance = Vector2.Distance(touch1.position, touch2.position);
            initialScale = transform.localScale;
        }
        else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
        {
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);
            if (Mathf.Approximately(initialDistance, 0))
            {
                return;
            }

            float factor = currentDistance / initialDistance;
            Vector3 newScale = initialScale * factor;

            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

            transform.localScale = newScale;
        }
    }

    void ApplyRotation()
    {
        transform.Rotate(rotationVelocity, Space.World);
    }

    void ApplyInertia()
    {
        rotationVelocity *= inertiaDamping;

        if (rotationVelocity.magnitude > 0.01f)
        {
            transform.Rotate(rotationVelocity, Space.World);
        }
    }
}
