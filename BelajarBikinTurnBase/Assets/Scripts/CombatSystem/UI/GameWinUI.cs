using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSYSTEM
{
    public class GameWinUI : MonoBehaviour
    {
        private void Start()
        {
            UnitManager.Instance.OnEnemyUnitListEmpty += UnitManager_OnEnemyUnitListEmpty;
            Hide();
        }

        private void UnitManager_OnEnemyUnitListEmpty(object sender, System.EventArgs e)
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
