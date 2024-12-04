using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
    public void HitEnemy(float damage, float knockbackPower);
}
