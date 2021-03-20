/// <summary>
/// ���i
/// </summary>
public class Personality
{
    public string Name { get; private set; } = "";
    public PersonalityType Type { get; private set; } = PersonalityType.Lonely;
    public CharaStatusType UpwardStausType { get; private set; } = CharaStatusType.Hp;
    public CharaStatusType DownwardStausType { get; private set; } = CharaStatusType.Hp;

    private Personality(string name, PersonalityType type, CharaStatusType upwardStausType, CharaStatusType downwardStausType)
    {
        Name = name;
        Type = type;
        UpwardStausType = upwardStausType;
        DownwardStausType = downwardStausType;
    }

    /// <summary>
    /// ���i����
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Personality CreatePresonality(PersonalityType type)
    {
        Personality personality = null;
        switch (type)
        {
            case PersonalityType.Lonely: personality = new Personality("���݂�����", type, CharaStatusType.PhysicsAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Adamant: personality = new Personality("�������ς�", type, CharaStatusType.PhysicsAttack, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Naughty: personality = new Personality("��񂿂�", type, CharaStatusType.PhysicsAttack, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Brave: personality = new Personality("�䂤����", type, CharaStatusType.PhysicsAttack, CharaStatusType.Speed); break;
            case PersonalityType.Bold: personality = new Personality("���ԂƂ�", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Impish: personality = new Personality("���ς�", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Lax: personality = new Personality("�̂��Ă�", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Relaxed: personality = new Personality("�̂�", type, CharaStatusType.PhysicsDamage, CharaStatusType.Speed); break;
            case PersonalityType.Modest: personality = new Personality("�Ђ�����", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Mild: personality = new Personality("�����Ƃ�", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Rash: personality = new Personality("���������", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Quiet: personality = new Personality("�ꂢ����", type, CharaStatusType.SpecialAttack, CharaStatusType.Speed); break;
            case PersonalityType.Calm: personality = new Personality("�����₩", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Gentle: personality = new Personality("���ƂȂ���", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Careful: personality = new Personality("���񂿂傤", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Sassy: personality = new Personality("�Ȃ܂���", type, CharaStatusType.PhysicsDamage, CharaStatusType.Speed); break;
            case PersonalityType.Timid: personality = new Personality("�����т傤", type, CharaStatusType.Speed, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Hasty: personality = new Personality("��������", type, CharaStatusType.Speed, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Jolly: personality = new Personality("�悤��", type, CharaStatusType.Speed, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Naive: personality = new Personality("�ނ��Ⴋ", type, CharaStatusType.Speed, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Bashful: personality = new Personality("�Ă��", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Hardy: personality = new Personality("����΂��", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Docile: personality = new Personality("���Ȃ�", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Quirky: personality = new Personality("���܂���", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Serious: personality = new Personality("�܂���", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            default: break;
        }

        return personality;
    }

    /// <summary>
    /// �␳�l���擾����
    /// </summary>
    /// <returns></returns>
    public float GetCorrection(CharaStatusType type)
    {
        if (type == CharaStatusType.Hp) { return 1.0f; }

        if (UpwardStausType == type) { return 1.1f; }
        else if (DownwardStausType == type) { return 0.9f; }

        return 1.0f;
    }
}
