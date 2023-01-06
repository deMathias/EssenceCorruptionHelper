using System.Diagnostics;
using System.Drawing;
using ExileCore;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.Elements;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using SharpDX;
using static System.Net.Mime.MediaTypeNames;
using Color = SharpDX.Color;
using RectangleF = SharpDX.RectangleF;
using Vector2 = System.Numerics.Vector2;

namespace EssenceCorruptionHelper;

public class EssenceCorruptionHelper : BaseSettingsPlugin<Settings>
{
    private IngameState ingameState;

    public override bool Initialise()
    {
        Graphics.InitImage("Plugins\\Compiled\\EssenceCorruptionHelper\\corruption.png", false);
        ingameState = GameController.Game.IngameState;
        Name = "Essence Corruption Helper";
        return base.Initialise();
    }

    public override void Render()
    {
        if (!Settings.Enable) return;
        Draw();
    }

    bool boolMonolithHasMeds()
    {
        Func<string, bool> shouldHighlight = (text) => {
            if (string.IsNullOrEmpty(text)) return false;
            if (text.Contains("Misery"))
            {
                return true;
            }
            if (text.Contains("Envy"))
            {
                return true;
            }
            if (text.Contains("Dread"))
            {
                return true;
            }
            if (text.Contains("Scorn"))
            {
                return true;
            }            

            // No matches, return false
            return false;
        };

        return GameController.IngameState.IngameUi.ItemsOnGroundLabelsVisible
                    .Where(x => x.ItemOnGround.Path == "Metadata/MiscellaneousObjects/Monolith")
                    .First().Label.Children[1].Children
                    .Select(x => x.Text)
                    // Returns true if any of the properties text 
                    .Any(t => shouldHighlight(t));
    }

    private bool boolHasMonolithAmountOfEssence()
    {
        return GameController.IngameState.IngameUi.ItemsOnGroundLabelsVisible
            .Where(x => x.ItemOnGround.Path == "Metadata/MiscellaneousObjects/Monolith")
            .First().Label.Children[1].Children.Count() - 4 >= Settings.AmountOfEssence;
    }

    private void Draw()
    {
        var camera = ingameState.Camera;
        var playerPos = GameController.Player.PosNum;

        var entities = GameController.Entities
            .Where(entity => entity.HasComponent<Render>() &&
                             entity.Address != GameController.Player.Address &&
                             entity.IsValid &&
                             entity.IsTargetable &&
                             entity.HasComponent<Monolith>());

        foreach (var entity in entities)
        {
            var entityPos = entity.PosNum;
            var entityScreenPos = camera.WorldToScreen(entityPos.Translate(0, 0, 0));
            var playerScreenPos = camera.WorldToScreen(playerPos.Translate(0, 0, 0));

            if (Settings.ToggleMeds)
            {
                //highlight MEDS Shrine
                if (boolMonolithHasMeds())
                {
                    using (Graphics.SetTextScale(Settings.TextSize))
                    {
                        Graphics.DrawText("Corrupt me", entityScreenPos, Color.Red, FontAlign.Center);
                    }
                    Graphics.DrawImage("corruption.png", new RectangleF(entityScreenPos.X-25, entityScreenPos.Y-125, 64, 63));
                }
            }

            if (Settings.ToggleAmount)
            {
                if(boolHasMonolithAmountOfEssence())
                {
                    using (Graphics.SetTextScale(Settings.TextSize))
                    {
                        Graphics.DrawText("Corrupt me", entityScreenPos, Color.Red, FontAlign.Center);
                    }
                    Graphics.DrawImage("corruption.png", new RectangleF(entityScreenPos.X-25, entityScreenPos.Y-125, 64, 63));
                }
            }
        }
    }
}