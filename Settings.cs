using System.Net.Mime;
using System.Text.Json.Serialization;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace DefaultNamespace;

public class Settings : ISettings
{
    public Settings()
    {
        Enable = new ToggleNode(true);
        ToggleSixEssence = new ToggleNode(true);
        ToggleMeds = new ToggleNode(true);
        TextNodeComponentNumber = new TextNode();
    }

    [Menu("Enable")] public ToggleNode Enable { get; set; }

    [Menu("Corrupt 6+ Essence?")]
    [JsonIgnore]
    public ToggleNode ToggleSixEssence { get; set; }

    [Menu("Corrupt Meds? (Misery, envy, dread, scorn")]
    [JsonIgnore]
    public ToggleNode ToggleMeds { get; set; }

    [Menu("Component Number")]
    public TextNode TextNodeComponentNumber { get; set; }

    }