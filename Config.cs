using metaphor.yuki.skillnames.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;
using static metaphor.yuki.skillnames.Configuration.Config;

namespace metaphor.yuki.skillnames.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.
    
            By default, configuration saves as "Config.json" in mod user config folder.    
            Need more config files/classes? See Configuration.cs
    
            Available Attributes:
            - Category
            - DisplayName
            - Description
            - DefaultValue

            // Technically Supported but not Useful
            - Browsable
            - Localizable

            The `DefaultValue` attribute is used as part of the `Reset` button in Reloaded-Launcher.
        */
        [Category("Skills")]
        [DisplayName("Zan over Garu")]
        [Description("Choose between Garu or Zan for Wind skills (Garu changes Wind to Force).")]
        [DefaultValue(Skill2.Garu)]
        public Skill2 windType { get; set; } = Skill2.Garu;

        public enum Skill2
        {
            Garu,
            Zan
        }

        [Category("Skills")]
        [DisplayName("Severe Skill Names")]
        [Description("Choose between normal severe skill names or -barion names.")]
        [DefaultValue(Skill1.Normal)]
        public Skill1 severeType { get; set; } = Skill1.Normal;

        public enum Skill1
        {
            Normal,
            Barion
        }

        
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}
