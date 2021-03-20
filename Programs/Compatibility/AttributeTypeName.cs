/// <summary>
/// �^�C�v��
/// </summary>
public static class AttributeTypeName
{
    /// <summary>
    /// �^�C�v�����擾����
    /// </summary>
    /// <param name="type">�^�C�v</param>
    /// <returns></returns>
    public static string GetTypeName(AttributeType type)
    {
        switch (type)
        {
            case AttributeType.Normal:return "�m�[�}��";
            case AttributeType.Fire: return "�ق̂�";
            case AttributeType.Water: return "�݂�";
            case AttributeType.Electricity: return "�ł�";
            case AttributeType.Grass: return "����";
            case AttributeType.Ice: return "������";
            case AttributeType.Fighting: return "�����Ƃ�";
            case AttributeType.Poison: return "�ǂ�";
            case AttributeType.Ground: return "���߂�";
            case AttributeType.AirPlane: return "�Ђ���";
            case AttributeType.Esper: return "�G�X�p�[";
            case AttributeType.Insect: return "�ނ�";
            case AttributeType.Rock: return "����";
            case AttributeType.Ghost: return "�S�[�X�g";
            case AttributeType.Dragon: return "�h���S��";
            case AttributeType.Evil: return "����";
            case AttributeType.Steel: return "�͂���";
            case AttributeType.Fairy: return "�t�F�A���[";
        }

        return "";
    }
}
