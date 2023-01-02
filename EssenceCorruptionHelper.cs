using DefaultNamespace;
using ExileCore;
using ExileCore.PoEMemory.MemoryObjects;
using SharpDX;

namespace EssenceCorruptionHelper;

public class EssenceCorruptionHelper : BaseSettingsPlugin<Settings>
{
    private const double CameraAngle = 38.7 * Math.PI / 180;
    private static readonly float CameraAngleCos = (float)Math.Cos(CameraAngle);
    private static readonly float CameraAngleSin = (float)Math.Sin(CameraAngle);
    private const float GridToWorldMultiplier = 250 / 23f;
    private double _mapScale;
    private Vector2 _mapCenter;
    private bool _largeMapOpen;
    
    private Camera Camera => GameController.Game.IngameState.Camera;
    
    private void Draw
}