using UnityEngine;

public class SwirlingNova : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 10f);
        if (GetComponent<VariationCheck>().VariationName != "")
        {
            AdditiveEffects.NovaEffect(gameObject, 8);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<EnemyAttacking>().IDied();
        }
    }
}
