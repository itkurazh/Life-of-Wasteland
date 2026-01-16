using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Config/UnitConfig")]
public class UnitConfig : ScriptableObject
{
    [BoxGroup("Locomotion")] public float SpeedWalk = 1.35f;
    [BoxGroup("Locomotion")] public float SpeedRun = 2.1f;
}