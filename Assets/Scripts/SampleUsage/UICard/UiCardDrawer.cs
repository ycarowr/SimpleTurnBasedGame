using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(UiCardSelector))]
    public class UiCardDrawer : MonoBehaviour
    {
        [SerializeField] [Tooltip("Prefab of the Card C#")]
        private UiCardHandSystem cardPrefabCs;

        [SerializeField] [Tooltip("Prefab of the Card MB")]
        private UiCardHandSystemMB cardPrefabSystemMb;

        private UiCardSelector CardSelector { get; set; }

        private void Awake()
        {
            CardSelector = GetComponent<UiCardSelector>();
        }

        private void Start()
        {
            //starting cards
            for (var i = 0; i < 6; i++)
                DrawCard();
        }

        [Button]
        public void DrawCard()
        {
            //TODO: Consider replace Instantiate by an Object Pool Pattern

            //pure c# card
            var card = Instantiate(cardPrefabCs, transform);

            //monobehavior components card
//            var card = Instantiate(cardPrefabSystemMb, transform);

            CardSelector.AddCard(card);
        }

        [Button]
        public void PlayCard()
        {
            if (CardSelector.Cards.Count > 0)
            {
                var randomCard = CardSelector.Cards.RandomItem();
                CardSelector.PlayCard(randomCard);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) DrawCard();
            if (Input.GetKeyDown(KeyCode.Space)) PlayCard();
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}