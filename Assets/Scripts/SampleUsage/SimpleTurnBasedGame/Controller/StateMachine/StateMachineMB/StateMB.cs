using UnityEngine;

namespace SimpleTurnBasedGame
{
    public abstract class StateMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        ///     Reference for the parent Finite StateMB Machine
        /// </summary>
        public T Fsm { get; private set; }

        /// <summary>
        ///     Called by the GameController's Awake
        /// </summary>
        public virtual void OnInitialize()
        {
            Log("OnInitialize!");
        }

        /// <summary>
        ///     Called by the GameController's Start
        /// </summary>
        public virtual void OnStart()
        {
            Log("OnStart!");
        }

        /// <summary>
        ///     Called by the GameController's Update
        /// </summary>
        public virtual void OnUpdate()
        {
            Log("OnUpdate!");
        }

        /// <summary>
        ///     Called right after enter the state
        /// </summary>
        public virtual void OnEnterState()
        {
            Log("OnEnterState <---------", "green");
        }

        /// <summary>
        ///     Called right after left the state
        /// </summary>
        public virtual void OnExitState()
        {
            Log("OnExitState <---------", "red");
        }

        /// <summary>
        ///     Setter for Internal State Machine
        /// </summary>
        /// <param name="stateMachine"></param>
        public void InjectStateMachine(StateMachineMB<T> stateMachine)
        {
            Fsm = stateMachine as T;
            Log("StateMachine Assigned");
        }

        private void Log(string log, string colorName = "black")
        {
            log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
            Debug.Log(log);
        }
    }
}