using System.Collections.Generic;

/// <summary>
/// 最終補正
/// </summary>
public class FinalCorrection
{
    public bool IsMultipleTargets { get; set; } = false;      // 複数対象
    public bool IsParentalBond { get; set; } = false;         // おやこあい
    public bool IsWeakenedWeather { get; set; } = false;      // 天候弱化
    public bool IsWeatherEnhancement { get; set; } = false;   // 天候強化
    public bool IsHitKeyPoint { get; set; } = false;          // 急所
    public float RandomNumber { get; set; } = 0.85f;          // 乱数
    public bool IsTypeMatch { get; set; } = false;            // タイプ一致
    public bool IsCapacityToAdapt { get; set; } = false;      // 適応力
    public float TypeCompatibility { get; set; } = 1.0f;      // タイプ相性
    public bool IsBurn { get; set; } = false;                 // 火傷
    public float[] DamageCorrections { get; set; } = null;    // ダメージ補正
    public bool IsProtectPenetration { get; set; } = false;   // まもる貫通(Zまもる、ダイマックスまもる)

    /// <summary>
    /// 最終ダメージを取得する
    /// </summary>
    /// <returns></returns>
    public int GetDamage(int damage)
    {
        // 効果なし
        if (TypeCompatibility == 0.0f) { return 0; }

        List<float> correctionList = new List<float>();
        if (IsMultipleTargets) { correctionList.Add(0.75f); }
        if (IsParentalBond) { correctionList.Add(0.25f); }
        if (IsWeakenedWeather) { correctionList.Add(0.5f); }
        if (IsWeatherEnhancement) { correctionList.Add(1.5f); }
        if (IsHitKeyPoint) { correctionList.Add(1.5f); }
        damage = DamageCalculatier.GetTotalCorrection(damage, correctionList.ToArray(), true);
        correctionList.Clear();
        damage = (int)((float)damage * RandomNumber);
        if (IsCapacityToAdapt) { damage = DamageCalculatier.GetTotalCorrection(damage, new float[] { 2.0f }, true); }
        else if(IsTypeMatch) { damage = DamageCalculatier.GetTotalCorrection(damage, new float[] { 1.5f }, true); }
        damage = DamageCalculatier.GetTotalCorrection(damage, new float[] { TypeCompatibility }, true);
        if (IsBurn) { correctionList.Add(0.5f); }
        if (DamageCorrections != null && DamageCorrections.Length > 0) { correctionList.AddRange(DamageCorrections); }
        if (IsProtectPenetration) { correctionList.Add(0.25f); }
        damage = DamageCalculatier.GetTotalCorrection(damage, correctionList.ToArray(), true);
        correctionList.Clear();
        return damage;
    }
}