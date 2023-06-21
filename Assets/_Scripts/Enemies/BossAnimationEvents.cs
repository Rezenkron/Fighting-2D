using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    [SerializeField] Collider2D col;
    public void TurnOnCollider()
    {
        col.enabled = true;
    }
    public void TurnOffCollider()
    {
        col.enabled = false;
    }
}
