/// <summary>
/// キャラステータス
/// </summary>
public class CharaStatus
{
    public int[] Values { get; set; } = new int[System.Enum.GetValues(typeof(CharaStatusType)).Length];

    /// <summary>
    /// 実数値を取得する
    /// </summary>
    /// <param name="level">レベル</param>
    /// <param name="raceValue">種族値</param>
    /// <param name="effortValue">努力値</param>
    /// <param name="individualValue">個体値</param>
    public static CharaStatus GetRealStatus(int level, Personality personality, CharaStatus raceValue, CharaStatus effortValue, CharaStatus individualValue)
    {
        CharaStatus realStatus = new CharaStatus();
        for (int i = 0; i < System.Enum.GetValues(typeof(CharaStatusType)).Length; i++)
        {
            CharaStatusType type = (CharaStatusType)i;
            if (type == CharaStatusType.Hp)
            {
                realStatus.Values[i] = GetRealHp(level, raceValue.Values[i], effortValue.Values[i], individualValue.Values[i]);
            }
            else
            {
                float personalityCorrection = personality.GetCorrection(type);
                realStatus.Values[i] = GetRealOtherThanHp(level, personalityCorrection, raceValue.Values[i], effortValue.Values[i], individualValue.Values[i]);
            }
        }

        return realStatus;
    }

    /// <summary>
    /// HP実数値を取得する
    /// </summary>
    /// <returns></returns>
    public static int GetRealHp(int level, int raceValue, int effortValue, int individualValue)
    {
        int hp = raceValue * 2 + individualValue + (int)((float)effortValue / 4.0f);
        hp = (int)((float)(hp * level) / 100) + level + 10;
        return hp;
    }

    /// <summary>
    /// HP以外の実数値を取得する
    /// </summary>
    /// <param name="level">レベル</param>
    /// <param name="personalityCorrection">性格補正</param>
    /// <param name="raceValue">種族値</param>
    /// <param name="effortValue">努力値</param>
    /// <param name="individualValue">個体値</param>
    /// <returns></returns>
    public static int GetRealOtherThanHp(int level, float personalityCorrection, int raceValue, int effortValue, int individualValue)
    {
        int realValue = raceValue * 2 + individualValue + (int)((float)effortValue / 4.0f);
        realValue = (int)((float)(realValue * level) / 100) + 5;
        realValue = (int)((float)realValue * personalityCorrection);
        return realValue;
    }
}
