using System;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class registers and manages all the States of this specific
    ///     Type of state Machine that are attached to the same GameObject. All the states
    ///     have to be assign to the gameobject BEFORE the Initialization. So if you are
    ///     using AddComponent calls, be sure this is called before the state's registration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StateMachineMB<T> : SingletonMB<T> where T : MonoBehaviour
    {
        //Push-Pop stack of States of this Type of Finite state Machine
        private readonly Stack<StateMB<T>> stack = new Stack<StateMB<T>>();

        //This StatesRegister doesn't allowed you to have two states with the same Type
        protected readonly Dictionary<Type, StateMB<T>> statesRegister = new Dictionary<Type, StateMB<T>>();
        public bool EnableLogs = true;
        public bool IsInitialized { get; private set; }


        /// <summary>
        ///     Register and Initialize all the states. It is done on Start callback
        ///     because the states and the fsm have GameData as dependency, which is done on Awake.
        /// </summary>
        public void Initialize()
        {
            OnBeforeInitialize();

            //grab all states of this StateMachine Type attached to this gameobject
            var allStates = GetComponents<StateMB<T>>();

            //StatesRegister all states
            foreach (var state in allStates)
            {
                var type = state.GetType();
                statesRegister.Add(type, state);
                state.InjectStateMachine(this);
            }

            IsInitialized = true;

            OnInitialize();

            Log("Initialized!", "green");
        }

        /// <summary>
        ///     If you need to do something before the initialization, override this method.
        /// </summary>
        protected virtual void OnBeforeInitialize()
        {
        }

        /// <summary>
        ///     If you need to do something after the initialization, override this method.
        /// </summary>
        protected virtual void OnInitialize()
        {
            foreach (var state in statesRegister.Values)
                state.OnInitialize();

            Log("States Initialized", "blue");
        }

        public virtual void Restart()
        {
            statesRegister.Clear();
            stack.Clear();
            IsInitialized = false;
        }

        private void Log(string log, string colorName = "black")
        {
            if (EnableLogs)
            {
                log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
                Debug.Log(log);
            }
        }

        #region Unity Callbacks

        /// <summary>
        ///     Initialize the StateMachine
        /// </summary>
        protected override void OnAwake()
        {
        }


        /// <summary>
        ///     Start all registered states
        /// </summary>
        protected virtual void Start()
        {
            Initialize();

            foreach (var state in statesRegister.Values)
                state.OnStart();

            Log("States Started", "blue");
        }

        /*
        /// <summary>
        /// Update all registered states (uncomment it if you need this callback).
        /// TODO: Consider to replace 'foreach' by 'for' to minimize the garbage collection.
        /// </summary>
        protected virtual void Update()
        {
            var current = this.PeekState();
            if (current != null)
                current.OnUpdate();
        }

        */

        #endregion

        # region Operations

        /// <summary>
        ///     Pushes a state by Type triggering OnEnterState for the pushed
        ///     state and if not silent OnExitState for the previous state in the stack.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        public void PushState<T1>(bool isSilent = false) where T1 : StateMB<T>
        {
            var stateType = typeof(T1);
            var state = statesRegister[stateType];
            PushState(state, isSilent);
        }

        /// <summary>
        ///     Pushes state by instance of the class triggering OnEnterState for the
        ///     pushed state and if not silent OnExitState for the previous state in the stack.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="isSilent"></param>
        public void PushState(StateMB<T> state, bool isSilent = false)
        {
            Log("Operation: Push, state: " + state.GetType(), "purple");
            if (stack.Count > 0 && !isSilent)
            {
                var previous = stack.Peek();
                previous.OnExitState();
            }

            stack.Push(state);
            state.OnEnterState();
        }

        /// <summary>
        ///     Peeks a state from the stack. A peek returns null if the stack is empty. It doesn't trigger any call.
        /// </summary>
        /// <returns></returns>
        public StateMB<T> PeekState()
        {
            StateMB<T> state = null;

            if (stack.Count > 0)
                state = stack.Peek();

            return state;
        }

        /// <summary>
        ///     Pops a state from the stack. It triggers OnExitState for the
        ///     popped state and if not silent OnEnterState for the subsequent stacked state.
        /// </summary>
        /// <param name="isSilent"></param>
        public void PopState(bool isSilent = false)
        {
            if (stack.Count > 0)
            {
                var state = stack.Pop();
                Log("Operation: Pop, state: " + state.GetType(), "purple");
                state.OnExitState();
            }

            if (stack.Count > 0 && !isSilent)
            {
                var state = stack.Peek();
                state.OnEnterState();
            }
        }

        #endregion
    }
}