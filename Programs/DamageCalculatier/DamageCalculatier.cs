/// <summary>
/// �_���[�W�v�Z
/// </summary>
public static class DamageCalculatier
{
    public static CompatibilityDamegeCalculater CompatibilityCalculatier = new CompatibilityDamegeCalculater();
    public static int InitialCorrectionValue = 4096;

    /// <summary>
    /// �ŏI�_���[�W���擾����
    /// </summary>
    /// <param name="level">���x��</param>
    /// <param name="finalPower">�ŏI�З�</param>
    /// <param name="finalAttackPower">�ŏI�U����</param>
    /// <param name="finalDefensePower">�ŏI�h���</param>
    /// <param name="finalCorrection">�ŏI�␳</param>
    /// <returns></returns>
    public static int GetFinalDamage(int level, int finalPower, int finalAttackPower, int finalDefensePower, FinalCorrection finalCorrection)
    {
        int damage = (int)((float)(level * 2) / 5.0f) + 2;
        damage = (int)((double)damage * (double)finalPower * (double)finalAttackPower / (double)finalDefensePower);
        damage = (int)((double)damage / 50) + 2;
        damage = finalCorrection.GetDamage(damage);
        if (damage <= 0 && finalCorrection.TypeCompatibility > 0.0f) { damage = 1; }

        return damage;
    }

    /// <summary>
    /// �ŏI�З͂��擾����
    /// </summary>
    /// <param name="techniquePower"></param>
    /// <param name="magnificationCorrections"></param>
    /// <returns></returns>
    public static int GetFinalPower(int techniquePower, float[] magnificationCorrections)
    {
        // �З͕␳
        int power = GetTotalCorrection(InitialCorrectionValue, magnificationCorrections, false);
        float fPower = (float)((double)(techniquePower * power) / (double)InitialCorrectionValue);
        if (fPower - System.Math.Floor(fPower) > 0.5f) { power = (int)System.Math.Round(fPower); }
        else { power = (int)fPower; }
        // �З͂�1�ȏ�m�ۂ���
        if (power <= 0) { power = 1; }

        return power;
    }

    /// <summary>
    /// �ŏI�U���͂��擾����
    /// </summary>
    /// <param name="attackPower">�U����</param>
    /// <param name="attackRank">�����N</param>
    /// <param name="isTension">�͂肫��</param>
    /// <param name="isHitKeyPoint">�}��</param>
    /// <param name="magnificationCorrections">�␳�l</param>
    /// <returns></returns>
    public static int GetFinalAttackPower(int attackPower, int attackRank, bool isTension, bool isHitKeyPoint, float[] magnificationCorrections)
    {
        // �}���␳
        if (isHitKeyPoint && attackRank < 0) { attackRank = 0; }
        // �����N�␳
        float attackRankMagnification = 1.0f;
        if (attackRank >= 0) { attackRankMagnification = (float)(attackRank + 2) / 2.0f; }
        else { attackRankMagnification = 2.0f / (float)(-attackRank + 2); }
        int power = (int)((float)attackPower * attackRankMagnification);
        // �͂肫��␳
        if (isTension) { power = (int)((double)(power * 6144) / (double)InitialCorrectionValue); }
        // �U���␳
        int attackCorrection = GetTotalCorrection(InitialCorrectionValue, magnificationCorrections, false);
        float fPower = (float)((double)(power * attackCorrection) / (double)InitialCorrectionValue);
        if (fPower - System.Math.Floor(fPower) > 0.5f) { power = (int)System.Math.Round(fPower); }
        else { power = (int)fPower; }
        // �U���͂�1�ȏ�m�ۂ���
        if (power <= 0) { power = 1; }

        return power;
    }

    /// <summary>
    /// �ŏI�h��͂��擾����
    /// </summary>
    /// <param name="defensePower">�h���</param>
    /// <param name="defenseRank">�����N</param>
    /// <param name="isSandstorm">���Ȃ��炵</param>
    /// <param name="isHitKeyPoint">�}��</param>
    /// <param name="magnificationCorrections">�␳�l</param>
    /// <returns></returns>
    public static int GetFinalDefensePower(int defensePower, int defenseRank, bool isSandstorm, bool isHitKeyPoint, float[] magnificationCorrections)
    {
        // �}���␳
        if (isHitKeyPoint && defenseRank > 0) { defenseRank = 0; }
        // �����N�␳
        float defenseRankMagnification = 1.0f;
        if (defenseRank >= 0) { defenseRankMagnification = (float)(defenseRank + 2) / 2.0f; }
        else { defenseRankMagnification = 2.0f / (float)(-defenseRank + 2); }
        int power = (int)((float)defensePower * defenseRankMagnification);
        // ���Ȃ��炵�␳
        if (isSandstorm) { power = (int)((double)(power * 6144) / (double)InitialCorrectionValue); }
        // �U���␳
        int defenseCorrection = GetTotalCorrection(InitialCorrectionValue, magnificationCorrections, false);
        float fPower = (float)((double)(power * defenseCorrection) / (double)InitialCorrectionValue);
        if (fPower - System.Math.Floor(fPower) > 0.5f) { power = (int)System.Math.Round(fPower); }
        else { power = (int)fPower; }
        // �U���͂�1�ȏ�m�ۂ���
        if (power <= 0) { power = 1; }

        return power;
    }

    /// <summary>
    /// ���v�␳�l���擾����
    /// </summary>
    /// <param name="initialCorrection">�����␳�l</param>
    /// <param name="magnificationCorrections">�␳�l</param>
    /// <param name="isFiveSuper">�܎̌ܒ������g�p���邩</param>
    /// <returns></returns>
    public static int GetTotalCorrection(int initialCorrection, float[] magnificationCorrections, bool isFiveSuper)
    {
        if (magnificationCorrections == null) { return initialCorrection; }

        int correction = initialCorrection;
        foreach (float magnificationCorrection in magnificationCorrections)
        {
            float temp = (float)InitialCorrectionValue * magnificationCorrection;
            float floor = (float)System.Math.Floor(temp);
            double dCorrection = 0;
            if (temp - floor <= 0.6f) { dCorrection = (double)correction * (double)temp / (double)InitialCorrectionValue; }
            else { dCorrection = (double)correction * (double)(floor + 1.0f) / (double)InitialCorrectionValue; }
            if (isFiveSuper)
            {
                // �܎̌ܒ���
                if ((dCorrection - (double)(int)dCorrection) > 0.5) { correction = (int)dCorrection + 1; }
                else { correction = (int)dCorrection; }
            }
            else
            {
                // �l�̌ܓ�
                correction = (int)System.Math.Round(dCorrection);
            }
        }

        return correction;
    }
}
