using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSYSTEM
{
    public class GameLoseUI : MonoBehaviour
    {
        private void Start()
        {
            UnitManager.Instance.OnFriendlyUnitListEmpty += UnitManager_OnFriendlyUnitListEmpty;
            Hide();
        }

        private void UnitManager_OnFriendlyUnitListEmpty(object sender, System.EventArgs e)
        {
            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }

}