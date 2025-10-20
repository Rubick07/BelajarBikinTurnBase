using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSYSTEM
{
    public class PlayerPartyUI : MonoBehaviour
    {
        [SerializeField] private Transform playerPartyUIContainerTransform;
        [SerializeField] private Transform unitUIPrefab;

        private void Start()
        {
            Unit.OnAnyUnitSpawned += Unit_OnAnyUnitSpawned;
        }

        private void Unit_OnAnyUnitSpawned(object sender, System.EventArgs e)
        {
            Unit unit = (Unit)sender;

            if (unit.IsEnemy())
                return;

            Transform unitUITransform = Instantiate(unitUIPrefab, playerPartyUIContainerTransform);


            UnitUI unitUI = unitUITransform.GetComponent<UnitUI>();

            unitUI.SetUp(unit);

        }

    }
}

