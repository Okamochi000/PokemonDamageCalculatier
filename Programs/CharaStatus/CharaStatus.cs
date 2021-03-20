/// <summary>
/// �L�����X�e�[�^�X
/// </summary>
public class CharaStatus
{
    public int[] Values { get; set; } = new int[System.Enum.GetValues(typeof(CharaStatusType)).Length];

    /// <summary>
    /// �����l���擾����
    /// </summary>
    /// <param name="level">���x��</param>
    /// <param name="raceValue">�푰�l</param>
    /// <param name="effortValue">�w�͒l</param>
    /// <param name="individualValue">�̒l</param>
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
    /// HP�����l���擾����
    /// </summary>
    /// <returns></returns>
    public static int GetRealHp(int level, int raceValue, int effortValue, int individualValue)
    {
        int hp = raceValue * 2 + individualValue + (int)((float)effortValue / 4.0f);
        hp = (int)((float)(hp * level) / 100) + level + 10;
        return hp;
    }

    /// <summary>
    /// HP�ȊO�̎����l���擾����
    /// </summary>
    /// <param name="level">���x��</param>
    /// <param name="personalityCorrection">���i�␳</param>
    /// <param name="raceValue">�푰�l</param>
    /// <param name="effortValue">�w�͒l</param>
    /// <param name="individualValue">�̒l</param>
    /// <returns></returns>
    public static int GetRealOtherThanHp(int level, float personalityCorrection, int raceValue, int effortValue, int individualValue)
    {
        int realValue = raceValue * 2 + individualValue + (int)((float)effortValue / 4.0f);
        realValue = (int)((float)(realValue * level) / 100) + 5;
        realValue = (int)((float)realValue * personalityCorrection);
        return realValue;
    }
}
