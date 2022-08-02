using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class JumpPowerUp : PowerUp
{
    [SerializeField] float jumpSpeed;

    private void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
    }
    public override void ApplyPowerUp(ArcadeKart arcadeKart)
    {
        Rigidbody arcadeCartRB= arcadeKart.transform.GetComponent<Rigidbody>();
        arcadeCartRB.AddForce(new Vector3(0,jumpSpeed,0),ForceMode.VelocityChange);
        Destroy(gameObject);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out ArcadeKart arcadeKart))
        {
            ApplyPowerUp(arcadeKart);
        }
    }
}
