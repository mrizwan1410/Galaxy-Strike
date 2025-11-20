using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float xRange = 20f;
    [SerializeField] float yRange = 8f;
    Vector2 movement;
   
    void Update()
    {
        ProcessTranslation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x - xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}
