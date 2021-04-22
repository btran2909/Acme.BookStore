using Volo.Abp.Settings;

namespace abp.Settings
{
    public class abpSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(abpSettings.MySetting1));
        }
    }
}
