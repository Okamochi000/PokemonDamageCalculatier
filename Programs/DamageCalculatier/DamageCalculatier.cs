/// <summary>
/// ダメージ計算
/// </summary>
public static class DamageCalculatier
{
    public static CompatibilityDamegeCalculater CompatibilityCalculatier = new CompatibilityDamegeCalculater();
    public static int InitialCorrectionValue = 4096;

    /// <summary>
    /// 最終ダメージを取得する
    /// </summary>
    /// <param name="level">レベル</param>
    /// <param name="finalPower">最終威力</param>
    /// <param name="finalAttackPower">最終攻撃力</param>
    /// <param name="finalDefensePower">最終防御力</param>
    /// <param name="finalCorrection">最終補正</param>
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
    /// 最終威力を取得する
    /// </summary>
    /// <param name="techniquePower"></param>
    /// <param name="magnificationCorrections"></param>
    /// <returns></returns>
    public static int GetFinalPower(int techniquePower, float[] magnificationCorrections)
    {
        // 威力補正
        int power = GetTotalCorrection(InitialCorrectionValue, magnificationCorrections, false);
        float fPower = (float)((double)(techniquePower * power) / (double)InitialCorrectionValue);
        if (fPower - System.Math.Floor(fPower) > 0.5f) { power = (int)System.Math.Round(fPower); }
        else { power = (int)fPower; }
        // 威力を1以上確保する
        if (power <= 0) { power = 1; }

        return power;
    }

    /// <summary>
    /// 最終攻撃力を取得する
    /// </summary>
    /// <param name="attackPower">攻撃力</param>
    /// <param name="attackRank">ランク</param>
    /// <param name="isTension">はりきり</param>
    /// <param name="isHitKeyPoint">急所</param>
    /// <param name="magnificationCorrections">補正値</param>
    /// <returns></returns>
    public static int GetFinalAttackPower(int attackPower, int attackRank, bool isTension, bool isHitKeyPoint, float[] magnificationCorrections)
    {
        // 急所補正
        if (isHitKeyPoint && attackRank < 0) { attackRank = 0; }
        // ランク補正
        float attackRankMagnification = 1.0f;
        if (attackRank >= 0) { attackRankMagnification = (float)(attackRank + 2) / 2.0f; }
        else { attackRankMagnification = 2.0f / (float)(-attackRank + 2); }
        int power = (int)((float)attackPower * attackRankMagnification);
        // はりきり補正
        if (isTension) { power = (int)((double)(power * 6144) / (double)InitialCorrectionValue); }
        // 攻撃補正
        int attackCorrection = GetTotalCorrection(InitialCorrectionValue, magnificationCorrections, false);
        float fPower = (float)((double)(power * attackCorrection) / (double)InitialCorrectionValue);
        if (fPower - System.Math.Floor(fPower) > 0.5f) { power = (int)System.Math.Round(fPower); }
        else { power = (int)fPower; }
        // 攻撃力を1以上確保する
        if (power <= 0) { power = 1; }

        return power;
    }

    /// <summary>
    /// 最終防御力を取得する
    /// </summary>
    /// <param name="defensePower">防御力</param>
    /// <param name="defenseRank">ランク</param>
    /// <param name="isSandstorm">すなあらし</param>
    /// <param name="isHitKeyPoint">急所</param>
    /// <param name="magnificationCorrections">補正値</param>
    /// <returns></returns>
    public static int GetFinalDefensePower(int defensePower, int defenseRank, bool isSandstorm, bool isHitKeyPoint, float[] magnificationCorrections)
    {
        // 急所補正
        if (isHitKeyPoint && defenseRank > 0) { defenseRank = 0; }
        // ランク補正
        float defenseRankMagnification = 1.0f;
        if (defenseRank >= 0) { defenseRankMagnification = (float)(defenseRank + 2) / 2.0f; }
        else { defenseRankMagnification = 2.0f / (float)(-defenseRank + 2); }
        int power = (int)((float)defensePower * defenseRankMagnification);
        // すなあらし補正
        if (isSandstorm) { power = (int)((double)(power * 6144) / (double)InitialCorrectionValue); }
        // 攻撃補正
        int defenseCorrection = GetTotalCorrection(InitialCorrectionValue, magnificationCorrections, false);
        float fPower = (float)((double)(power * defenseCorrection) / (double)InitialCorrectionValue);
        if (fPower - System.Math.Floor(fPower) > 0.5f) { power = (int)System.Math.Round(fPower); }
        else { power = (int)fPower; }
        // 攻撃力を1以上確保する
        if (power <= 0) { power = 1; }

        return power;
    }

    /// <summary>
    /// 合計補正値を取得する
    /// </summary>
    /// <param name="initialCorrection">初期補正値</param>
    /// <param name="magnificationCorrections">補正値</param>
    /// <param name="isFiveSuper">五捨五超入を使用するか</param>
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
                // 五捨五超入
                if ((dCorrection - (double)(int)dCorrection) > 0.5) { correction = (int)dCorrection + 1; }
                else { correction = (int)dCorrection; }
            }
            else
            {
                // 四捨五入
                correction = (int)System.Math.Round(dCorrection);
            }
        }

        return correction;
    }
}
