using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private bool isSwiping;
    public float tiltAngle = 10f; // Угол наклона
    public float tiltSpeed = 2f; // Скорость наклона
    public float maxTiltAngle = 15f; // Максимальный угол наклона

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    startTouchPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                   
                    if (isSwiping)
                    {
                        endTouchPosition = touch.position;
                        HandleSwipe();
                    }
                    break;

                case TouchPhase.Ended:
                   
                    isSwiping = false;
                    break;
            }
        }
    }

    private void HandleSwipe()
    {
        Vector2 swipeDirection = endTouchPosition - startTouchPosition;
      
        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.x < 0)
            {
                TiltPlatform(Vector3.left);
            }
            else
            {
                TiltPlatform(Vector3.right);
            }
        }
        else
        {
            if (swipeDirection.y < 0)
            {
                TiltPlatform(Vector3.back);
            }
            else
            {
                TiltPlatform(Vector3.forward);
            }
        }
    }

    private void TiltPlatform(Vector3 direction)
    {
        float currentTiltAngle = transform.rotation.eulerAngles.x;

        if (currentTiltAngle > 180)
            currentTiltAngle -= 360;

        if (Mathf.Abs(currentTiltAngle) < maxTiltAngle)
        {
            Quaternion targetRotation = Quaternion.Euler(direction * tiltAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
        }
    }
}
