/*
 * Filename:  AloeVera.cs
 * Developer: Logan Finley
 * Purpose:   This file defines the "AloeVera" class.
 */

using System.Collections;
using UnityEngine;

/*
 * This file implements the effect of the Aloe Vera item
 * which is to increase the player's health
 *
 * Member Variables:
 */
public class AloeVera : AttributeItem
{
    public float shieldIncrease = 25f;
    private GameObject heroObject;
    private Hero heroScript;

    protected override void Awake()
    {
        this.SetType(ItemType.AloeVera);
    }

    public override IEnumerator UseEffect()
    {
        float currentShield;

        heroObject = GameObject.FindGameObjectWithTag("Hero");
        heroScript = heroObject.GetComponent<Hero>();

        currentShield = heroScript.GetShield();
        heroScript.SetShield(currentShield + shieldIncrease);
        Debug.Log("Aloe Vera was used");
        yield return null;
    }
}
