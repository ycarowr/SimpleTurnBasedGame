using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This class holds ai submodules that interact with
    ///     a game and player to accomplish its own goals
    /// </summary>
    public class AiModule
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public AiModule(IPrimitivePlayer player, IPrimitiveGame game)
        {
            //add all submodules 
            subModules.Add(AiArchetype.Random, GetAi(AiArchetype.Random, player, game));
            subModules.Add(AiArchetype.Survive, GetAi(AiArchetype.Survive, player, game));
            subModules.Add(AiArchetype.Aggressive, GetAi(AiArchetype.Aggressive, player, game));
            subModules.Add(AiArchetype.VeryLucky, GetAi(AiArchetype.VeryLucky, player, game));
            subModules.Add(AiArchetype.Unlucky, GetAi(AiArchetype.Unlucky, player, game));
            subModules.Add(AiArchetype.SelfHeal, GetAi(AiArchetype.SelfHeal, player, game));
            subModules.Add(AiArchetype.Good, GetAi(AiArchetype.Good, player, game));

            //define current ai randomly
            CurrentAi = subModules.Keys.ToList().RandomItem();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Factory

        /// <summary>
        ///     Small factory to create sub ai modules.
        /// </summary>
        /// <param name="archetype"></param>
        /// <param name="player"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        private static AiBase GetAi(AiArchetype archetype, IPrimitivePlayer player, IPrimitiveGame game)
        {
            switch (archetype)
            {
                case AiArchetype.Random: return new AiRandom(player, game);
                case AiArchetype.Survive: return new AiSurvive(player, game);
                case AiArchetype.Aggressive: return new AiAggressive(player, game);
                case AiArchetype.VeryLucky: return new AiVeryLucky(player, game);
                case AiArchetype.Unlucky: return new AiUnlucky(player, game);
                case AiArchetype.SelfHeal: return new AiSelfHeal(player, game);
                case AiArchetype.Good: return new AiGood(player, game);
                default:
                    throw new ArgumentOutOfRangeException(nameof(archetype), archetype, null);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties and Fields 

        /// <summary>
        ///     Register with all the AiConfigs submodules.
        /// </summary>
        private readonly Dictionary<AiArchetype, AiBase> subModules = new Dictionary<AiArchetype, AiBase>();

        /// <summary>
        ///     AiConfigs that is current operating.
        /// </summary>
        private AiArchetype CurrentAi { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations 

        /// <summary>
        ///     Returns the best move according to the current ai submodule.
        /// </summary>
        /// <returns></returns>
        public MoveType GetBestMove()
        {
            if (!subModules.ContainsKey(CurrentAi))
                throw new ArgumentOutOfRangeException(
                    CurrentAi + " is not registered as a valid archetype in this module.");

            return subModules[CurrentAi].GetBestMove();
        }

        /// <summary>
        ///     Change the current archetype.
        /// </summary>
        /// <param name="archetype"></param>
        public void SwapAiToArchetype(AiArchetype archetype)
        {
            CurrentAi = archetype;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}