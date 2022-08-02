using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public abstract class PowerUp : MonoBehaviour
{
    public abstract void ApplyPowerUp(ArcadeKart arcadeKart);
}
