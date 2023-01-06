using System.Net.Mime;
using System.Text.Json.Serialization;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace EssenceCorruptionHelper;

public class Settings : ISettings
{
    public Settings()
    {
        Enable = new ToggleNode(true);
        ToggleMeds = new ToggleNode(true);
        AmountOfEssence = new RangeNode<int>(6, 0, 10);
        ToggleAmount = new ToggleNode(true);
        TextSize = new RangeNode<int>(3, 0, 10);
    }

    [Menu("Enable")] 
    public ToggleNode Enable { get; set; }

    [Menu("Corrupt Meds? (Misery, envy, dread, scorn)")]
    public ToggleNode ToggleMeds { get; set; }

    [Menu("Corrupt X Amount ?")]
    public ToggleNode ToggleAmount { get; set; }

    [Menu("Amount: ")]
    public RangeNode<int> AmountOfEssence { get; set; }

    [Menu("Text Size: ")]
    public RangeNode<int> TextSize { get; set; }
}