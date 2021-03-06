/// <summary>
/// 性格
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
    /// 性格生成
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Personality CreatePresonality(PersonalityType type)
    {
        Personality personality = null;
        switch (type)
        {
            case PersonalityType.Lonely: personality = new Personality("さみしがり", type, CharaStatusType.PhysicsAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Adamant: personality = new Personality("いじっぱり", type, CharaStatusType.PhysicsAttack, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Naughty: personality = new Personality("やんちゃ", type, CharaStatusType.PhysicsAttack, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Brave: personality = new Personality("ゆうかん", type, CharaStatusType.PhysicsAttack, CharaStatusType.Speed); break;
            case PersonalityType.Bold: personality = new Personality("ずぶとい", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Impish: personality = new Personality("わんぱく", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Lax: personality = new Personality("のうてんき", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Relaxed: personality = new Personality("のんき", type, CharaStatusType.PhysicsDamage, CharaStatusType.Speed); break;
            case PersonalityType.Modest: personality = new Personality("ひかえめ", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Mild: personality = new Personality("おっとり", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Rash: personality = new Personality("うっかりや", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Quiet: personality = new Personality("れいせい", type, CharaStatusType.SpecialAttack, CharaStatusType.Speed); break;
            case PersonalityType.Calm: personality = new Personality("おだやか", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Gentle: personality = new Personality("おとなしい", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Careful: personality = new Personality("しんちょう", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Sassy: personality = new Personality("なまいき", type, CharaStatusType.PhysicsDamage, CharaStatusType.Speed); break;
            case PersonalityType.Timid: personality = new Personality("おくびょう", type, CharaStatusType.Speed, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Hasty: personality = new Personality("せっかち", type, CharaStatusType.Speed, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Jolly: personality = new Personality("ようき", type, CharaStatusType.Speed, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Naive: personality = new Personality("むじゃき", type, CharaStatusType.Speed, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Bashful: personality = new Personality("てれや", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Hardy: personality = new Personality("がんばりや", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Docile: personality = new Personality("すなお", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Quirky: personality = new Personality("きまぐれ", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Serious: personality = new Personality("まじめ", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            default: break;
        }

        return personality;
    }

    /// <summary>
    /// 補正値を取得する
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
