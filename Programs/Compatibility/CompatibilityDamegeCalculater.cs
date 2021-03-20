/// <summary>
/// タイプ相性ダメージ倍率
/// </summary>
public class CompatibilityDamegeCalculater
{
    /// <summary>
    /// 1タイプダメージ倍率
    /// </summary>
    private class CompatibilityDamegeCalculation
    {
        private AttributeType[] attackOutstandings_ = null;
        private AttributeType[] attackHalfs_ = null;
        private AttributeType[] attackInvalids_ = null;

        /// <summary>
        /// 抜群タイプを設定
        /// </summary>
        /// <param name="compatibilityTypes"></param>
        public void AddAttackOutstandings(AttributeType[] compatibilityTypes)
        {
            attackOutstandings_ = compatibilityTypes;
        }

        /// <summary>
        /// 半減タイプを設定
        /// </summary>
        /// <param name="compatibilityTypes"></param>
        public void AddAttackHalfs(AttributeType[] compatibilityTypes)
        {
            attackHalfs_ = compatibilityTypes;
        }

        /// <summary>
        /// 無効タイプを設定
        /// </summary>
        /// <param name="compatibilityTypes"></param>
        public void AddAttackInvalids(AttributeType[] compatibilityTypes)
        {
            attackInvalids_ = compatibilityTypes;
        }

        /// <summary>
        /// ダメージ倍率を取得する
        /// </summary>
        /// <param name="receiveType"></param>
        /// <returns></returns>
        public float GetCalculation(AttributeType receiveType)
        {
            // 抜群倍率
            if (attackOutstandings_ != null)
            {
                foreach (AttributeType type in attackOutstandings_)
                {
                    if (type == receiveType) { return 2.0f; }
                }
            }

            // 半減倍率
            if (attackHalfs_ != null)
            {
                foreach (AttributeType type in attackHalfs_)
                {
                    if (type == receiveType) { return 0.5f; }
                }
            }

            // 無効倍率
            if (attackInvalids_ != null)
            {
                foreach (AttributeType type in attackInvalids_)
                {
                    if (type == receiveType) { return 0.0f; }
                }
            }

            // 通常倍率
            return 1.0f;
        }
    }

    private CompatibilityDamegeCalculation[] compatibility_ = new CompatibilityDamegeCalculater.CompatibilityDamegeCalculation[System.Enum.GetValues(typeof(AttributeType)).Length];

    public CompatibilityDamegeCalculater()
    {
        int type = 0;
        int length = System.Enum.GetValues(typeof(AttributeType)).Length;
        for (int i = 0; i < length; i++) { compatibility_[i] = new CompatibilityDamegeCalculation(); }

        // ノーマル
        type = (int)AttributeType.Normal;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Rock, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Ghost });
        // 炎
        type = (int)AttributeType.Fire;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Ice, AttributeType.Insect, AttributeType.Steel });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Water, AttributeType.Rock, AttributeType.Dragon });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // 水
        type = (int)AttributeType.Water;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fire, AttributeType.Ground, AttributeType.Rock });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Water, AttributeType.Grass, AttributeType.Dragon });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // 電気
        type = (int)AttributeType.Electricity;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Water, AttributeType.AirPlane });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Electricity, AttributeType.Grass, AttributeType.Dragon});
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Ground });
        // 草
        type = (int)AttributeType.Grass;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Water, AttributeType.Ground, AttributeType.Rock });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Grass, AttributeType.Poison,　AttributeType.AirPlane, AttributeType.Insect, AttributeType.Dragon, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // 氷
        type = (int)AttributeType.Ice;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Ground, AttributeType.AirPlane, AttributeType.Dragon });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Water, AttributeType.Ice, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // 格闘
        type = (int)AttributeType.Fighting;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Normal, AttributeType.Ice, AttributeType.Rock, AttributeType.Evil, AttributeType.Steel });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Poison, AttributeType.AirPlane, AttributeType.Esper, AttributeType.Insect, AttributeType.Fairy });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Ghost });
        // 毒
        type = (int)AttributeType.Poison;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Fairy });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Poison, AttributeType.Ground, AttributeType.Rock, AttributeType.Ghost });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Steel });
        // 地面
        type = (int)AttributeType.Ground;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fire, AttributeType.Electricity, AttributeType.Poison, AttributeType.Rock, AttributeType.Steel });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Grass, AttributeType.Insect });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.AirPlane });
        // 飛行
        type = (int)AttributeType.AirPlane;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Fighting, AttributeType.Insect });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Electricity, AttributeType.Rock, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // エスパー
        type = (int)AttributeType.Esper;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fighting, AttributeType.Poison });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Esper, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Evil });
        // 虫
        type = (int)AttributeType.Insect;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Esper, AttributeType.Evil });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Fighting, AttributeType.Poison, AttributeType.AirPlane, AttributeType.Ghost, AttributeType.Steel, AttributeType.Steel, AttributeType.Fairy });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // 岩
        type = (int)AttributeType.Rock;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fire, AttributeType.Ice, AttributeType.AirPlane, AttributeType.Insect });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fighting, AttributeType.Ground, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // ゴースト
        type = (int)AttributeType.Ghost;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Esper, AttributeType.Ghost });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Evil });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Normal });
        // ドラゴン
        type = (int)AttributeType.Dragon;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Dragon });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Fairy });
        // 悪
        type = (int)AttributeType.Evil;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Esper, AttributeType.Ghost });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fighting, AttributeType.Evil, AttributeType.Fairy });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // 鋼
        type = (int)AttributeType.Steel;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Ice, AttributeType.Rock, AttributeType.Fairy });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Water, AttributeType.Electricity, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // フェアリー
        type = (int)AttributeType.Fairy;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fighting, AttributeType.Dragon, AttributeType.Evil });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Poison, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
    }

    /// <summary>
    /// タイプ相性
    /// </summary>
    /// <param name="attackType">攻撃側タイプ</param>
    /// <param name="receiverTypes">防御側タイプ</param>
    /// <returns></returns>
    public float GetCompatibilityCalculation(AttributeType attackType, AttributeType[] receiverTypes)
    {
        if (receiverTypes == null) { return 1.0f; }

        float calculation = 1.0f;
        foreach (AttributeType receiverType in receiverTypes)
        {
            int type = (int)attackType;
            calculation *= compatibility_[type].GetCalculation(receiverType);
        }

        return calculation;
    }
}
