using System.Drawing;
using DefaultNamespace;
using ExileCore;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.Elements;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using SharpDX;
using Color = SharpDX.Color;

namespace EssenceCorruptionHelper;

public class EssenceCorruptionHelper : BaseSettingsPlugin<Settings>
{
    private IngameState ingameState; 
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

    private void Draw()
    {
        //add drawing.
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
                Graphics.DrawText("Corrupt me", entityScreenPos, Color.Red, FontAlign.Center);
            }

            if (Settings.ToggleSixEssence)
            {
                //highlight 6+ Essence Shrine
                Graphics.DrawText("Corrupt me", entityScreenPos, Color.Red, FontAlign.Center);
            }
        }
    }
}