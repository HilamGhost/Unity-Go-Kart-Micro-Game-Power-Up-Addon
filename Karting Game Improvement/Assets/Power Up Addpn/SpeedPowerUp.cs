using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class SpeedPowerUp : PowerUp
{
    [SerializeField] float speed;
    [SerializeField] float powerUpTime;
    
    private void Update()
    {
        transform.Rotate(0,45*Time.deltaTime,0);
    }
    public override void ApplyPowerUp(ArcadeKart arcadeKart)
    {
        StartCoroutine(ApplySpeedPowerUp(arcadeKart));
    }
    public IEnumerator ApplySpeedPowerUp(ArcadeKart arcadeKart)
    {
        float oldSpeed = arcadeKart.baseStats.TopSpeed;
        arcadeKart.baseStats.TopSpeed = speed;
        yield return new WaitForSeconds(powerUpTime);
        arcadeKart.baseStats.TopSpeed = oldSpeed;
        Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.TryGetComponent(out ArcadeKart arcadeKart)) 
        {
            ApplyPowerUp(arcadeKart);
        }
    }
}
