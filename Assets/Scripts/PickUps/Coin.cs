using UnityEngine;

public class Coin : Pickup // inheritance
{

    protected override void OnPickup()
    {
        Debug.Log("Add 100 points");
    }
}
