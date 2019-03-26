using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.UI.Card
{
    public interface IUiCardSelector
    {
        void AddCard(IUiCard uiCard);
        void RemoveCard(IUiCard uiCard);
        void PlayCard(IUiCard uiCard);
        void SelectCard(IUiCard uiCard);
        void UnselectCard(IUiCard uiCard);
    }

    /// <summary>
    ///     Card Selector holds a register of UI cards of a player.
    /// </summary>
    public class UiCardSelector : MonoBehaviour, IUiCardSelector
    {
        //UI cards of the player
        public List<IUiCard> Cards { get; private set; }

        //UI Card currently selected by the player
        public IUiCard SelectedCard { get; private set; }

        /// <summary>
        ///     Event raised when add or remove a card.
        /// </summary>
        public event Action<IUiCard[]> OnHandChanged = hand => { };

        /// <summary>
        ///     Event raised when a card is selected.
        /// </summary>
        public event Action<IUiCard> OnCardSelected = card => { };


        private void Awake()
        {
            //initialize register
            Cards = new List<IUiCard>();

            Clear();
        }

        #region Operations

        /// <summary>
        ///     Select UI Card implementation.
        /// </summary>
        /// <param name="card"></param>
        public void SelectCard(IUiCard card)
        {
            SelectedCard = card ?? throw new ArgumentNullException("Null is not a valid argument.");

            //disable all cards
            DisableCards();

            NotifyCardSelected();
        }

        /// <summary>
        ///     Play UI Card implementation.
        /// </summary>
        /// <param name="card"></param>
        public void PlayCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Destroy(card.gameObject);
            RemoveCard(card);
            EnableCards();
        }

        /// <summary>
        ///     Unselect UI Card implementation.
        /// </summary>
        /// <param name="card"></param>
        public void UnselectCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            EnableCards();
            NotifyHandChange();
        }

        /// <summary>
        ///     Add an UI Card to the player hand.
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Add(card);
            card.transform.SetParent(transform);
            card.Enable();
            NotifyHandChange();
        }


        /// <summary>
        ///     Remove an UI Card to the player hand.
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);

            NotifyHandChange();
        }

        #endregion


        #region Extra

        /// <summary>
        ///     Disable input for all cards.
        /// </summary>
        public void DisableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Disable();
        }

        /// <summary>
        ///     Enable input for all cards.
        /// </summary>
        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        private void Clear()
        {
            var childCards = GetComponentsInChildren<IUiCard>();
            foreach (var uiCardHand in childCards)
                Destroy(uiCardHand.gameObject);

            Cards.Clear();
        }

        [Button]
        private void NotifyHandChange()
        {
            OnHandChanged.Invoke(Cards.ToArray());
        }

        [Button]
        private void NotifyCardSelected()
        {
            OnCardSelected.Invoke(SelectedCard);
        }

        #endregion
    }
}