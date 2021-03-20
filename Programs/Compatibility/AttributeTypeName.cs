/// <summary>
/// タイプ名
/// </summary>
public static class AttributeTypeName
{
    /// <summary>
    /// タイプ名を取得する
    /// </summary>
    /// <param name="type">タイプ</param>
    /// <returns></returns>
    public static string GetTypeName(AttributeType type)
    {
        switch (type)
        {
            case AttributeType.Normal:return "ノーマル";
            case AttributeType.Fire: return "ほのお";
            case AttributeType.Water: return "みず";
            case AttributeType.Electricity: return "でんき";
            case AttributeType.Grass: return "くさ";
            case AttributeType.Ice: return "こおり";
            case AttributeType.Fighting: return "かくとう";
            case AttributeType.Poison: return "どく";
            case AttributeType.Ground: return "じめん";
            case AttributeType.AirPlane: return "ひこう";
            case AttributeType.Esper: return "エスパー";
            case AttributeType.Insect: return "むし";
            case AttributeType.Rock: return "いわ";
            case AttributeType.Ghost: return "ゴースト";
            case AttributeType.Dragon: return "ドラゴン";
            case AttributeType.Evil: return "あく";
            case AttributeType.Steel: return "はがね";
            case AttributeType.Fairy: return "フェアリー";
        }

        return "";
    }
}
