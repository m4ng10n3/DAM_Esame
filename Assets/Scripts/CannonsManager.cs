using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class CannonsManager : MonoBehaviour
    {
        public LayerMask cannonLayerMask;

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector3 mousePos = Mouse.current.position.ReadValue();
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
                RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100, cannonLayerMask);
                if (hit.collider != null)
                {
                    Cannon cannon = hit.collider.GetComponent<Cannon>();
                    if (cannon != null)
                    {
                        cannon.OnClick();
                    }

                }
            }
        }
    }
}