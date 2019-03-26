using Patterns;
using SimpleTurnBasedGame.ControllerCs;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class initializes all components and kicks the start game.
    /// </summary>
    public class Bootstrapper : SingletonMB<Bootstrapper>
    {
        /// <summary>
        ///     Boots all the game instantiating the necessary prefabs in the correct order.
        /// </summary>
        private void InitializeGame()
        {
            if (IsInitialized)
                return;

            //the order matters
            
            //First. Create game events Singleton
            GameEvents = Instantiate(GameEventsPrefab);

            //Second. Create game ui
            Ui = Instantiate(UIPrefab);

            //Third. Create game data Singleton
            GameData = Instantiate(GameDataPrefab);

            //Fourth. Create game controller Singleton
            GameController = Instantiate(GameControllerPrefab);

            IsInitialized = true;
        }


        #region Fields

        [Header("Prefabs")] [SerializeField] private GameObject UIPrefab;

        [SerializeField] private GameData GameDataPrefab;
        [SerializeField] private GameEvents GameEventsPrefab;
        [SerializeField] private GameController GameControllerPrefab;

        #endregion

        #region Properties

        private GameObject Ui { get; set; }
        private GameData GameData { get; set; }
        private GameEvents GameEvents { get; set; }
        private GameController GameController { get; set; }

        public bool IsInitialized { get; private set; }

        #endregion

        #region Unity Callbacks

        /// <summary>
        ///     Main. First Awake that happens in the entire game.
        /// </summary>
        protected override void OnAwake()
        {
            Logger.Instance.Log<Bootstrapper>("Awake");
            InitializeGame();
        }

        /// <summary>
        ///     First Start in the game.
        /// </summary>
        private void Start()
        {
            Logger.Instance.Log<Bootstrapper>("Start");
        }

        #endregion
    }
}