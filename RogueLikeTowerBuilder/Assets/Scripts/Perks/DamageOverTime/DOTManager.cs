using Unity.VisualScripting;
using UnityEngine;

public enum DOT
{
    Burn
}

public class DOTManager : MonoBehaviour
{
    public void CheckDOTEffect(Enemy pTarget, DOT pType, float pDamage, int pTicks, float pTickSpeed)
    {
        pTarget.gameObject.TryGetComponent<DOTEffect>(out DOTEffect currentEffect);

        if (currentEffect != null)
        {
            if(currentEffect.type == pType && currentEffect.damage < pDamage)
            {
                DOTEffect current = pTarget.AddComponent<DOTEffect>();
                current.Initialize(pTarget,pType,pDamage,pTicks,pTickSpeed);
            }
        }
        else
        {
            DOTEffect current = pTarget.AddComponent<DOTEffect>();
            current.Initialize(pTarget, pType, pDamage, pTicks, pTickSpeed);
        }
    }
}
