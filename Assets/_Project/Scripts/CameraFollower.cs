using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float smoothSpeed = 0.2f;
    [SerializeField] private Vector2 offset = Vector2.zero;


    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera Target not assigned. Please assign a target in the inspector.");
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z
        );

        transform.DOMove(desiredPosition, smoothSpeed).SetEase(Ease.OutQuad);
    }
}
