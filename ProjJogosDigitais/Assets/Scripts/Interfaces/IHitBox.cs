using System;
using Unity.VisualScripting;
using UnityEngine;
public interface IHitBox
{
    void Enable();
    void Disable();
    void OnTriggerEnter2d(Collider2D collision);
    void OnTriggerExit2d(Collider2D collision);
}