using System;
using Unity.VisualScripting;
using UnityEngine;
public interface IHitBox
{
    void Enable();
    void Disable();
    void OnTriggerEnter2D(Collider2D collision);
    void OnTriggerExit2D(Collider2D collision);
}