using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiClock : UiListener, IDoTick, IPreGameStart, IFinishPlayerTurn
    {
        //----------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            Text = GetComponent<TMP_Text>();
            TimeText = Localization.Instance.Get(LocalizationIds.Time) + ":";
        }

        private void Update()
        {
            if (!IsBlinking)
                return;

            currentBlinkTime += Time.deltaTime;
            if (!(currentBlinkTime >= maxBlinkTime))
                return;

            currentBlinkTime = 0;
            Text.enabled = !Text.enabled;
        }

        private void Restart()
        {
            IsBlinking = false;
            Text.enabled = false;
        }
        //----------------------------------------------------------------------------------------------------------

        #region Fields and Properties 

        private const float BlinkFactor = 0.1f;
        private const int BlinkStart = 3;
        private float currentBlinkTime;
        private float maxBlinkTime;
        [SerializeField] private PlayerSeat seat;
        private TMP_Text Text { get; set; }
        private string TimeText { get; set; }
        private bool IsBlinking { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IDoTick.OnTickTime(int time, IPrimitivePlayer player)
        {
            if (player.Seat != seat)
                return;

            Text.text = TimeText + time;
            Text.enabled = true;

            if (time > BlinkStart)
                return;

            IsBlinking = true;

            if (time > 0)
                maxBlinkTime = time * BlinkFactor;
        }

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
        {
            Restart();
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            Restart();
        }

        #endregion
    }
}