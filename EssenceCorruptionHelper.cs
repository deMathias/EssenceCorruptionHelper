using System.Diagnostics;
using System.Drawing;
using ExileCore;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.Elements;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using SharpDX;
using Color = SharpDX.Color;
using RectangleF = SharpDX.RectangleF;
using Vector2 = System.Numerics.Vector2;

namespace EssenceCorruptionHelper;

public class EssenceCorruptionHelper : BaseSettingsPlugin<Settings>
{
    private IngameState ingameState;
    private List<LabelOnGround> listGroundLabels;

    public override bool Initialise()
    {
        ingameState = GameController.Game.IngameState;
        Name = "Essence Corruption Helper";
        return base.Initialise();
    }

    public override void Render()
    {
        if (!Settings.Enable) return;
        Draw();
    }

    private void FilterLabels()
    {
        listGroundLabels = GameController.IngameState.IngameUi.ItemsOnGroundLabelsVisible
                .Where(x => x.ItemOnGround.Path == "Metadata/MiscellaneousObjects/Monolith").ToList();
    }

    private bool MonolithHasMeds()
    {
        //check if there is Misery, Envy, Dread or Scorn Essence.
        return true;
    }

    private bool MonolithHasSixOrMoreEssence()
    {
        //check if there is 6 or more essences
        return true;
    }

    private void Draw()
    {

    }
    
    private void DisplayLabel(Vector2 pos, string text)
    {
        pos.Y += 20; // Offset the label slightly so it's not on top of the monolith
        pos.X += 20; // Offset the label horizontally

        Graphics.DrawText(text,pos,Color.Red);
    }
}