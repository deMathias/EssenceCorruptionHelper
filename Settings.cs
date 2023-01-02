using System.Text.Json.Serialization;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace DefaultNamespace;

public class Settings : ISettings
{
    public Settings()
    {
        
    }
    
    public ToggleNode Enable { get; set; } = new ToggleNode(false);

    [Menu("6+ Essence?")]
    [JsonIgnore] 
    public ToggleNode SettingsOnCount { get; set; } = new ToggleNode(true);

    [Menu("MEDS? (Misery or Envy or Dread or Scorn)")]
    [JsonIgnore]
    public ToggleNode SettingsOnMeds { get; set; } = new ToggleNode(true);

}