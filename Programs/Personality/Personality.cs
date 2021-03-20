/// <summary>
/// ê´äi
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
    /// ê´äiê∂ê¨
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Personality CreatePresonality(PersonalityType type)
    {
        Personality personality = null;
        switch (type)
        {
            case PersonalityType.Lonely: personality = new Personality("Ç≥Ç›ÇµÇ™ÇË", type, CharaStatusType.PhysicsAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Adamant: personality = new Personality("Ç¢Ç∂Ç¡ÇœÇË", type, CharaStatusType.PhysicsAttack, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Naughty: personality = new Personality("Ç‚ÇÒÇøÇ·", type, CharaStatusType.PhysicsAttack, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Brave: personality = new Personality("Ç‰Ç§Ç©ÇÒ", type, CharaStatusType.PhysicsAttack, CharaStatusType.Speed); break;
            case PersonalityType.Bold: personality = new Personality("Ç∏Ç‘Ç∆Ç¢", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Impish: personality = new Personality("ÇÌÇÒÇœÇ≠", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Lax: personality = new Personality("ÇÃÇ§ÇƒÇÒÇ´", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Relaxed: personality = new Personality("ÇÃÇÒÇ´", type, CharaStatusType.PhysicsDamage, CharaStatusType.Speed); break;
            case PersonalityType.Modest: personality = new Personality("Ç–Ç©Ç¶Çﬂ", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Mild: personality = new Personality("Ç®Ç¡Ç∆ÇË", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Rash: personality = new Personality("Ç§Ç¡Ç©ÇËÇ‚", type, CharaStatusType.SpecialAttack, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Quiet: personality = new Personality("ÇÍÇ¢ÇπÇ¢", type, CharaStatusType.SpecialAttack, CharaStatusType.Speed); break;
            case PersonalityType.Calm: personality = new Personality("Ç®ÇæÇ‚Ç©", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Gentle: personality = new Personality("Ç®Ç∆Ç»ÇµÇ¢", type, CharaStatusType.PhysicsDamage, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Careful: personality = new Personality("ÇµÇÒÇøÇÂÇ§", type, CharaStatusType.PhysicsDamage, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Sassy: personality = new Personality("Ç»Ç‹Ç¢Ç´", type, CharaStatusType.PhysicsDamage, CharaStatusType.Speed); break;
            case PersonalityType.Timid: personality = new Personality("Ç®Ç≠Ç—ÇÂÇ§", type, CharaStatusType.Speed, CharaStatusType.PhysicsAttack); break;
            case PersonalityType.Hasty: personality = new Personality("ÇπÇ¡Ç©Çø", type, CharaStatusType.Speed, CharaStatusType.PhysicsDamage); break;
            case PersonalityType.Jolly: personality = new Personality("ÇÊÇ§Ç´", type, CharaStatusType.Speed, CharaStatusType.SpecialAttack); break;
            case PersonalityType.Naive: personality = new Personality("ÇﬁÇ∂Ç·Ç´", type, CharaStatusType.Speed, CharaStatusType.SpecialDamage); break;
            case PersonalityType.Bashful: personality = new Personality("ÇƒÇÍÇ‚", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Hardy: personality = new Personality("Ç™ÇÒÇŒÇËÇ‚", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Docile: personality = new Personality("Ç∑Ç»Ç®", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Quirky: personality = new Personality("Ç´Ç‹ÇÆÇÍ", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            case PersonalityType.Serious: personality = new Personality("Ç‹Ç∂Çﬂ", type, CharaStatusType.Hp, CharaStatusType.Hp); break;
            default: break;
        }

        return personality;
    }

    /// <summary>
    /// ï‚ê≥ílÇéÊìæÇ∑ÇÈ
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
