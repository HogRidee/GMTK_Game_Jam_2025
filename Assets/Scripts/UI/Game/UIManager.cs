using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PauseBehavior pauseBehavior;
    [SerializeField] private ResourceBarTracking resourceBarTracking;

    private float resourceTimer = 0f;
    private const float interval = 1f;
    
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseBehavior.PauseGame();
        }
        DecrementTimeBar();
    }

    private void DecrementTimeBar()
    {
        resourceTimer += Time.deltaTime;
        if (resourceTimer >= interval)
        {
            resourceBarTracking.ChangeResourceByAmount(-1);
            resourceTimer -= interval;
        }
    }
}
