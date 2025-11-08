using UnityEngine;

public  abstract class Pickup : MonoBehaviour //abstract olduğu için tek başına hiçbir işe yaramaz.
{
    [SerializeField] float rotationSpeed = 100f;
    const string playerString = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other) //CapsuleCollider isTrigger'dan geliyor.
    {
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }

    }

    protected abstract void OnPickup();
    
}
