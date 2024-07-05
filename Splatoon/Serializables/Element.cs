﻿using ECommons.LanguageHelpers;
using Splatoon.Serializables;
using Splatoon.Utils;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Splatoon;

[Serializable]
public class Element
{
    [NonSerialized]
    public static string[] ElementTypes = Array.Empty<string>();
    [NonSerialized] public static string[] ActorTypes = Array.Empty<string>();
    [NonSerialized] public static string[] ComparisonTypes = Array.Empty<string>();

    [NonSerialized]
    public Dictionary<int, string> ObjectTypeOptions = new Dictionary<int, string>
    {
        {0, "Any"},
        {1, "NPC"},
        {2, "Player"}
    };

    [NonSerialized]
    public Dictionary<int, string> HostileOptions = new Dictionary<int, string>
    {
        {0, "Any"},
        {1, "Is Hostile"},
        {2, "Not Hostile"}
    };

    [NonSerialized]
    public Dictionary<int, string> InCombatOptions = new Dictionary<int, string>
    {
        {0, "Any"},
        {1, "In Combat"},
        {2, "Out of Combat"}
    };

    [NonSerialized]
    public Dictionary<int, string> IsAliveOptions = new Dictionary<int, string>
    {
        {0, "Any"},
        {1, "Is Alive"},
        {2, "Is Dead"}
    };

    [NonSerialized]
    public Dictionary<byte, string> RoleOptions = new Dictionary<byte, string>
    {
        {0, "Any"},
        {1, "Tank"},
        {4, "Healer"},
        {2, "Melee DPS"},
        {3, "Ranged DPS"}
    };

    public static void Init()
    {
        ElementTypes = new string[]{
            "Circle at fixed coordinates".Loc(),
            "Circle relative to object position".Loc(),
            "Line between two fixed coordinates".Loc(),
            "Line relative to object position".Loc(),
            "Cone relative to object position".Loc(),
            "Cone at fixed coordinates".Loc()
        };
        ActorTypes = new string[] {
            "Game object with specific data".Loc(),
            "Self".Loc(),
            "Targeted character".Loc()
        };
        ComparisonTypes = new string[]{
            "Name (case-insensitive, partial)".Loc(),
            "Model ID".Loc(),
            "Object ID".Loc(),
            "Data ID".Loc(),
            "NPC ID".Loc(),
            "Placeholder".Loc(),
            "NPC Name ID".Loc(),
            "VFX Path".Loc(),
            "Object Effect".Loc()
        };
    }


    public string Name = "";
    [NonSerialized] internal string GUID = Guid.NewGuid().ToString();
    [NonSerialized] internal bool Delete = false;
    /// <summary>
    /// 0: Object at fixed coordinates |
    /// 1: Object relative to actor position | 
    /// 2: Line between two fixed coordinates | 
    /// 3: Line relative to object pos | 
    /// 4: Cone relative to object position |
    /// 5: Cone at fixed coordinates
    /// </summary>
    public int type;
    /// <summary>
    /// 0: Object at fixed coordinates |
    /// 1: Object relative to actor position | 
    /// 2: Line between two fixed coordinates | 
    /// 3: Line relative to object pos | 
    /// 4: Cone relative to object position |
    /// 5: Cone at fixed coordinates
    /// </summary>
    public Element(int t)
    {
        type = t;
    }
    [DefaultValue(true)] public bool Enabled = true;
    [DefaultValue(0f)] public float refX = 0f;
    [DefaultValue(0f)] public float refY = 0f;
    [DefaultValue(0f)] public float refZ = 0f;
    [DefaultValue(0f)] public float offX = 0f;
    [DefaultValue(0f)] public float offY = 0f;
    [DefaultValue(0f)] public float offZ = 0f;
    [DefaultValue(0.35f)] public float radius = 0.35f; // if it's 0, draw it as point, otherwise as circle
    [DefaultValue(0)] public float Donut = 0f;
    [DefaultValue(0)] public int coneAngleMin = 0;
    [DefaultValue(0)] public int coneAngleMax = 0;
    [DefaultValue(0xc80000ff)] public uint color = 0xc80000ff;
    [DefaultValue(true)] public bool Filled = true;
    [DefaultValue(null)] public float? fillIntensity = null;
    [DefaultValue(false)] public bool overrideFillColor = false;
    [DefaultValue(null)] public uint? originFillColor = null;
    [DefaultValue(null)] public uint? endFillColor = null;
    [DefaultValue(0x70000000)] public uint overlayBGColor = 0x70000000;
    [DefaultValue(0xC8FFFFFF)] public uint overlayTextColor = 0xC8FFFFFF;
    [DefaultValue(0f)] public float overlayVOffset = 0f;
    [DefaultValue(1f)] public float overlayFScale = 1f;
    [DefaultValue(false)] public bool overlayPlaceholders = false;
    [DefaultValue(2f)] public float thicc = 2f;
    [DefaultValue("")] public string overlayText = "";
    [DefaultValue("")] public string refActorName = "";
    public InternationalString refActorNameIntl = new();
    [DefaultValue(0)] public uint refActorModelID = 0;
    [DefaultValue(0)] public uint refActorObjectID = 0;
    [DefaultValue(0)] public uint refActorDataID = 0;
    [DefaultValue(0)] public uint refActorNPCID = 0;
    [DefaultValue(0)] public uint refActorTargetingYou = 0;
    [DefaultValue("")] public List<string> refActorPlaceholder = new();
    [DefaultValue(0)] public uint refActorNPCNameID = 0;
    [DefaultValue(false)] public bool refActorComparisonAnd = false;
    [DefaultValue(false)] public bool refActorRequireCast = false;
    [DefaultValue(false)] public bool refActorCastReverse = false;
    public List<uint> refActorCastId = new();
    [DefaultValue(false)] public bool refActorUseCastTime = false;
    [DefaultValue(0f)] public float refActorCastTimeMin = 0f;
    [DefaultValue(0f)] public float refActorCastTimeMax = 0f;
    [DefaultValue(false)] public bool refActorUseOvercast = false;
    [DefaultValue(false)] public bool refTargetYou = false;
    [DefaultValue(false)] public bool refActorRequireBuff = false;
    public List<uint> refActorBuffId = new();
    [DefaultValue(false)] public bool refActorRequireAllBuffs = false;
    [DefaultValue(false)] public bool refActorRequireBuffsInvert = false;
    [DefaultValue(false)] public bool refActorUseBuffTime = false;
    [DefaultValue(false)] public bool refActorUseBuffParam = false;
    [DefaultValue(0)] public int refActorBuffParam = 0;
    [DefaultValue(0f)] public float refActorBuffTimeMin = 0f;
    [DefaultValue(0f)] public float refActorBuffTimeMax = 0f;
    [DefaultValue(false)] public bool refActorLowMp = false;
    [DefaultValue(false)] public bool refActorObjectLife = false;
    [DefaultValue(0)] public float refActorLifetimeMin = 0;
    [DefaultValue(0)] public float refActorLifetimeMax = 0;
    /// <summary>
    /// 0: Name |
    /// 1: Model ID |
    /// 2: Object ID |
    /// 3: Data ID | 
    /// 4: NPC ID |
    /// 5: Placeholder |
    /// 6: Name ID | 
    /// 7: VFX Path |
    /// 8: Object Effect
    /// </summary>
    [DefaultValue(0)] public int refActorComparisonType = 0;
    /// <summary>
    /// 0: Game object with specific name |
    /// 1: Self |
    /// 2: Targeted character
    /// </summary>
    [DefaultValue(0)] public int refActorType = 0;
    [DefaultValue(false)] public bool includeHitbox = false;
    [DefaultValue(false)] public bool includeOwnHitbox = false;
    [DefaultValue(false)] public bool includeRotation = false;
    [DefaultValue(false)] public bool onlyTargetable = false;
    [DefaultValue(false)] public bool onlyUnTargetable = false;
    [DefaultValue(false)] public bool onlyVisible = false;
    [DefaultValue(false)] public bool tether = false;
    [DefaultValue(0f)] public float ExtraTetherLength = 0f;
    [DefaultValue(LineEnd.None)] public LineEnd LineEndA = LineEnd.None;
    [DefaultValue(LineEnd.None)] public LineEnd LineEndB = LineEnd.None;
    [DefaultValue(0f)] public float AdditionalRotation = 0f;
    [DefaultValue(false)] public bool LineAddHitboxLengthX = false;
    [DefaultValue(false)] public bool LineAddHitboxLengthY = false;
    [DefaultValue(false)] public bool LineAddHitboxLengthZ = false;
    [DefaultValue(false)] public bool LineAddHitboxLengthXA = false;
    [DefaultValue(false)] public bool LineAddHitboxLengthYA = false;
    [DefaultValue(false)] public bool LineAddHitboxLengthZA = false;
    [DefaultValue(false)] public bool LineAddPlayerHitboxLengthX = false;
    [DefaultValue(false)] public bool LineAddPlayerHitboxLengthY = false;
    [DefaultValue(false)] public bool LineAddPlayerHitboxLengthZ = false;
    [DefaultValue(false)] public bool LineAddPlayerHitboxLengthXA = false;
    [DefaultValue(false)] public bool LineAddPlayerHitboxLengthYA = false;
    [DefaultValue(false)] public bool LineAddPlayerHitboxLengthZA = false;
    [DefaultValue(false)] public bool FaceMe = false;
    [DefaultValue(false)] public bool LimitDistance = false;
    [DefaultValue(false)] public bool LimitDistanceInvert = false;
    [DefaultValue(0f)] public float DistanceSourceX = 0f;
    [DefaultValue(0f)] public float DistanceSourceY = 0f;
    [DefaultValue(0f)] public float DistanceSourceZ = 0f;
    [DefaultValue(0f)] public float DistanceMin = 0f;
    [DefaultValue(0f)] public float DistanceMax = 0f;
    [DefaultValue("")] public string refActorVFXPath = "";
    [DefaultValue(0)] public int refActorVFXMin = 0;
    [DefaultValue(0)] public int refActorVFXMax = 0;
    [DefaultValue(false)] public bool LimitRotation = false;
    [DefaultValue(0)] public float RotationMax = 0;
    [DefaultValue(0)] public float RotationMin = 0;
    [DefaultValue(0)] public uint refActorObjectEffectData1 = 0;
    [DefaultValue(0)] public uint refActorObjectEffectData2 = 0;
    [DefaultValue(0)] public int refActorObjectEffectMin = 0;
    [DefaultValue(0)] public int refActorObjectEffectMax = 0;
    [DefaultValue(false)] public bool refActorObjectEffectLastOnly = false;
    [DefaultValue(false)] public bool refActorUseTransformation = false;
    [DefaultValue(0)] public int refActorTransformationID = 0;
    [DefaultValue(0)] public int refActorObjectType = 0;
    [DefaultValue(0)] public int refActorHostile = 0;
    [DefaultValue(0)] public int refActorInCombat = 0;
    [DefaultValue(0)] public int refActorIsAlive = 0;
    [DefaultValue(0)] public byte refActorRole = 0;
    [DefaultValue(false)] public bool excludeTarget = false;
    [DefaultValue(MechanicType.Unspecified)] public MechanicType mechanicType = MechanicType.Unspecified;
    [Obsolete("Not used. Use mechanicType.")]
    [DefaultValue(false)] public bool Unsafe = false;
    [DefaultValue(false)] public bool refMark = false;
    [DefaultValue(0)] public int refMarkID = 0;
    [DefaultValue("<1>")] public string faceplayer = "<1>";
    [Obsolete("Not used. Use fillIntensity or originFillColor and endFillColor to change color and transparency.")]
    [DefaultValue(0.5f)] public float FillStep = 0.5f;
    [Obsolete("Not used. Use mechanicType.")]
    [DefaultValue(false)] public bool LegacyFill = false;

    [OnDeserialized]
    public void OnDeserialized(StreamingContext context)
    {
        if (Unsafe && mechanicType == MechanicType.Unspecified)
        {
            mechanicType = MechanicType.Danger;
        }
    }

    internal float DefaultFillIntensity()
    {
        // Generate a default fill transparency based on the stroke transparency and fillstep relative to their defaults.
        uint strokeAlpha = (color >> 24);
        const uint defaultStrokeAlpha = 0xC8;
        float transparencyFromStroke = (float)strokeAlpha / defaultStrokeAlpha;
        float transparencyFromFillStep = 0.5f / FillStep;
        if (type.EqualsAny(0, 1))
        {
            // Donut
            if (Donut > 0)
            {
                transparencyFromFillStep /= 2;
            }
            // Circle
            else
            {
                transparencyFromFillStep *= 2;
            }
        }
        // Cone
        if (type.EqualsAny(4, 5))
        {
            transparencyFromFillStep *= 4;
        }
        uint fillAlpha = Math.Clamp((uint)(0x45 * transparencyFromFillStep * transparencyFromStroke), 0x19, 0x64);
        float fillIntensity = (float)fillAlpha / strokeAlpha;
        return Math.Clamp(fillIntensity, 0, 1);
    }

    [IgnoreDataMember]
    public DisplayStyle Style
    {
        set
        {
            color = value.strokeColor;
            thicc = value.strokeThickness;
            Filled = value.filled;
            overrideFillColor = value.overrideFillColor;
            fillIntensity = value.fillIntensity;
            originFillColor = value.originFillColor;
            endFillColor = value.endFillColor;
        }

        get
        {
            // Most elements used line fill with Filled = false and need fill migration.
            bool needsPolygonalFillMigration = this.fillIntensity == null;
            float fillIntensity = this.fillIntensity ?? DefaultFillIntensity();
            if (needsPolygonalFillMigration)
            {
                // Non-donut circles are the only shapes that don't need fill migration because they had functioning Fill.
                bool isCircle = type.EqualsAny(0, 1) && Donut == 0;
                if (!isCircle)
                {
                    Filled = true;
                }
            }

            uint originFillColor = this.originFillColor ?? Colors.MultiplyAlpha(color, fillIntensity);
            uint endFillColor = this.endFillColor ?? Colors.MultiplyAlpha(color, fillIntensity);

            return new DisplayStyle(color, thicc, fillIntensity, originFillColor, endFillColor, Filled, overrideFillColor);
        }
    }


    [IgnoreDataMember]
    public DisplayStyle StyleWithOverride
    {
        get
        {
            DisplayStyle style = Style;

            if (P.Config.StyleOverrides.ContainsKey(mechanicType))
            {
                (var overrideEnabled, var overrideStyle) = P.Config.StyleOverrides[mechanicType];
                if (overrideEnabled)
                {
                    style = overrideStyle;
                }
            }
            if (!style.overrideFillColor)
            {
                uint defaultColor = Colors.MultiplyAlpha(style.strokeColor, style.fillIntensity);
                style.originFillColor = defaultColor;
                style.endFillColor = defaultColor;
            }

            style.originFillColor = P.Config.ClampFillColorAlpha(style.originFillColor);
            style.endFillColor = P.Config.ClampFillColorAlpha(style.endFillColor);
            return style;
        }
    }

    [IgnoreDataMember]
    public bool IsDangerous
    {
        get => mechanicType == MechanicType.Danger;
    }

    public bool ShouldSerializerefActorTransformationID()
    {
        return refActorUseTransformation;
    }

    public bool ShouldSerializerefActorObjectEffectLastOnly()
    {
        return refActorComparisonType == 8 || refActorComparisonAnd;
    }
    public bool ShouldSerializerefActorObjectEffectMax()
    {
        return refActorComparisonType == 8 || refActorComparisonAnd;
    }
    public bool ShouldSerializerefActorObjectEffectMin()
    {
        return refActorComparisonType == 8 || refActorComparisonAnd;
    }
    public bool ShouldSerializerefActorObjectEffectData2()
    {
        return refActorComparisonType == 8 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorObjectEffectData1()
    {
        return refActorComparisonType == 8 || refActorComparisonAnd;
    }

    public bool ShouldSerializeRotationMax()
    {
        return this.ShouldSerializeRotationMin();
    }

    public bool ShouldSerializeRotationMin()
    {
        return this.LimitRotation;
    }

    public bool ShouldSerializerefActorVFXPath()
    {
        return refActorComparisonType == 7 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorVFXMin()
    {
        return refActorComparisonType == 7 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorVFXMax()
    {
        return refActorComparisonType == 7 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorNameIntl()
    {
        return ShouldSerializerefActorName() && !refActorNameIntl.IsEmpty();
    }

    public bool ShouldSerializeconeAngleMax()
    {
        return ShouldSerializeconeAngleMin();
    }

    public bool ShouldSerializeconeAngleMin()
    {
        return type == 4 || type == 5;
    }

    public bool ShouldSerializerefActorLifetimeMax()
    {
        return ShouldSerializerefActorLifetimeMin();
    }

    public bool ShouldSerializerefActorLifetimeMin()
    {
        return refActorObjectLife;
    }

    public bool ShouldSerializerefActorCastId()
    {
        return refActorRequireCast && refActorCastId.Count > 0;
    }

    public bool ShouldSerializerefActorBuffId()
    {
        return refActorRequireBuff && refActorBuffId.Count > 0;
    }

    public bool ShouldSerializerefActorBuffParam()
    {
        return refActorRequireBuff && refActorUseBuffParam;
    }

    public bool ShouldSerializerefActorName()
    {
        return refActorComparisonType == 0 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorModelID()
    {
        return refActorComparisonType == 1 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorObjectID()
    {
        return refActorComparisonType == 2 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorDataID()
    {
        return refActorComparisonType == 3 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorNPCID()
    {
        return refActorComparisonType == 4 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorPlaceholder()
    {
        return refActorComparisonType == 5 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefActorNPCNameID()
    {
        return refActorComparisonType == 6 || refActorComparisonAnd;
    }

    public bool ShouldSerializerefX()
    {
        return type != 1;
    }
    public bool ShouldSerializerefY() { return ShouldSerializerefX(); }
    public bool ShouldSerializerefZ() { return ShouldSerializerefX(); }

    public bool ShouldSerializeDonut()
    {
        return type.EqualsAny(0, 1) && Donut > 0;
    }
}
