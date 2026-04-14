using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference coverAction;
    public InputActionReference shootAction;

    private bool isInCover = true;



    // ********** CONTROLS **********
    private void OnEnable()
    {
        coverAction.action.Enable();
        shootAction.action.Enable();
    }

    private void OnDisable()
    {
        coverAction.action.Disable();
        shootAction.action.Disable();
    }

    private void Awake()
    {
        coverAction.action.performed += ToggleCover;
        shootAction.action.performed += HandleShoot;
    }


    // ********** COVER **********
    private void ToggleCover(InputAction.CallbackContext context)
    {
        isInCover = !isInCover;
        Debug.Log($"isInCover: {isInCover}");
    }


    // ********** SHOOTING **********
    private void HandleShoot(InputAction.CallbackContext context)
    {
        if (isInCover)
        {
            Debug.Log("Cannot shoot while in cover!");
            return;
        }

        Shoot();
    }

    private void Shoot()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 rayOrigin = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        Vector3 rayDirection = Vector2.zero;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);

        Debug.Log($"Shooting from {rayOrigin}");
        if (hit.collider != null)
        {
            // Debug.Log($"Hit: {hit.collider.name}");
            GameObject hitObject = hit.collider.gameObject;
            Target target = hitObject.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log("Hitting target...");
                target.Hit();
            }
        }
    }
    


}
