using System.Collections.Generic;

/// <summary>
/// �ŏI�␳
/// </summary>
public class FinalCorrection
{
    public bool IsMultipleTargets { get; set; } = false;      // �����Ώ�
    public bool IsParentalBond { get; set; } = false;         // ���₱����
    public bool IsWeakenedWeather { get; set; } = false;      // �V��㉻
    public bool IsWeatherEnhancement { get; set; } = false;   // �V�󋭉�
    public bool IsHitKeyPoint { get; set; } = false;          // �}��
    public float RandomNumber { get; set; } = 0.85f;          // ����
    public bool IsTypeMatch { get; set; } = false;            // �^�C�v��v
    public bool IsCapacityToAdapt { get; set; } = false;      // �K����
    public float TypeCompatibility { get; set; } = 1.0f;      // �^�C�v����
    public bool IsBurn { get; set; } = false;                 // �Ώ�
    public float[] DamageCorrections { get; set; } = null;    // �_���[�W�␳
    public bool IsProtectPenetration { get; set; } = false;   // �܂���ђ�(Z�܂���A�_�C�}�b�N�X�܂���)

    /// <summary>
    /// �ŏI�_���[�W���擾����
    /// </summary>
    /// <returns></returns>
    public int GetDamage(int damage)
    {
        // ���ʂȂ�
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