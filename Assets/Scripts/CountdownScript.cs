using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace maxkonrad
{
    public class CountdownScript : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TextMeshProUGUI countdownText;
        [SerializeField] private float countdownTime = 3f;
        [SerializeField] private float countdownTimer;
        [SerializeField] private bool isCountingDown = false;
        #endregion

        #region MainMethods
        private void Start()
        {
            countdownTimer = countdownTime;
            StartCountdown();
        }
        private void Update()
        {
            if (isCountingDown)
            {
                countdownTimer -= Time.deltaTime;
                countdownText.text = Mathf.Round(countdownTimer).ToString();
                if (countdownTimer <= 0)
                {
                    countdownText.text = "";
                    isCountingDown = false;
                }
            }
        }
        #endregion

        #region CustomMethods
        public void StartCountdown()
        {
            isCountingDown = true;
        }
        #endregion
    }
}
