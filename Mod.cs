using metaphor.yuki.skillnames.Configuration;
using metaphor.yuki.skillnames.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using CriFs.V2.Hook.Interfaces;
using CriFsV2Lib.Definitions;
using FileEmulationFramework.Lib.Utilities;

namespace metaphor.yuki.skillnames
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase // <= Do not Remove.
    {
        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks? _hooks;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;

        private ICriFsRedirectorApi _criFsApi = null!;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;

            var modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId); // modDir variable for file emulation

            // For more information about this template, please see
            // https://reloaded-project.github.io/Reloaded-II/ModTemplate/

            // If you want to implement e.g. unload support in your mod,
            // and some other neat features, override the methods in ModBase.

            // TODO: Implement some mod logic

            // Define controllers and other variables, set warning messages

            var criFsController = _modLoader.GetController<ICriFsRedirectorApi>();
            if (criFsController == null || !criFsController.TryGetTarget(out var criFsApi))
            {
                _logger.WriteLine($"Something in CriFS shit its pants! Normal files will not load properly!", System.Drawing.Color.Red);
                return;
            }

            //Load Garu w/o Barion
            if (_configuration.windType == Config.Skill2.Garu & _configuration.severeType == Config.Skill1.Normal)
            {
                criFsApi.AddProbingPath("GaruNorm/CPK");
            }

            //Load Zan w/o Barion
            else if (_configuration.windType == Config.Skill2.Zan & _configuration.severeType == Config.Skill1.Normal)
            {
                criFsApi.AddProbingPath("ZanNorm/CPK");
            }

            //Load Garu w/ Barion
            if (_configuration.windType == Config.Skill2.Garu & _configuration.severeType == Config.Skill1.Barion)
            {
                criFsApi.AddProbingPath("GaruBarion/CPK");
            }

            //Load Zan w/ Barion
            else if (_configuration.windType == Config.Skill2.Zan & _configuration.severeType == Config.Skill1.Barion)
            {
                criFsApi.AddProbingPath("ZanBarion/CPK");
            }

        }
        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}