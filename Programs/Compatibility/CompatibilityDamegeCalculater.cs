/// <summary>
/// �^�C�v�����_���[�W�{��
/// </summary>
public class CompatibilityDamegeCalculater
{
    /// <summary>
    /// 1�^�C�v�_���[�W�{��
    /// </summary>
    private class CompatibilityDamegeCalculation
    {
        private AttributeType[] attackOutstandings_ = null;
        private AttributeType[] attackHalfs_ = null;
        private AttributeType[] attackInvalids_ = null;

        /// <summary>
        /// ���Q�^�C�v��ݒ�
        /// </summary>
        /// <param name="compatibilityTypes"></param>
        public void AddAttackOutstandings(AttributeType[] compatibilityTypes)
        {
            attackOutstandings_ = compatibilityTypes;
        }

        /// <summary>
        /// �����^�C�v��ݒ�
        /// </summary>
        /// <param name="compatibilityTypes"></param>
        public void AddAttackHalfs(AttributeType[] compatibilityTypes)
        {
            attackHalfs_ = compatibilityTypes;
        }

        /// <summary>
        /// �����^�C�v��ݒ�
        /// </summary>
        /// <param name="compatibilityTypes"></param>
        public void AddAttackInvalids(AttributeType[] compatibilityTypes)
        {
            attackInvalids_ = compatibilityTypes;
        }

        /// <summary>
        /// �_���[�W�{�����擾����
        /// </summary>
        /// <param name="receiveType"></param>
        /// <returns></returns>
        public float GetCalculation(AttributeType receiveType)
        {
            // ���Q�{��
            if (attackOutstandings_ != null)
            {
                foreach (AttributeType type in attackOutstandings_)
                {
                    if (type == receiveType) { return 2.0f; }
                }
            }

            // �����{��
            if (attackHalfs_ != null)
            {
                foreach (AttributeType type in attackHalfs_)
                {
                    if (type == receiveType) { return 0.5f; }
                }
            }

            // �����{��
            if (attackInvalids_ != null)
            {
                foreach (AttributeType type in attackInvalids_)
                {
                    if (type == receiveType) { return 0.0f; }
                }
            }

            // �ʏ�{��
            return 1.0f;
        }
    }

    private CompatibilityDamegeCalculation[] compatibility_ = new CompatibilityDamegeCalculater.CompatibilityDamegeCalculation[System.Enum.GetValues(typeof(AttributeType)).Length];

    public CompatibilityDamegeCalculater()
    {
        int type = 0;
        int length = System.Enum.GetValues(typeof(AttributeType)).Length;
        for (int i = 0; i < length; i++) { compatibility_[i] = new CompatibilityDamegeCalculation(); }

        // �m�[�}��
        type = (int)AttributeType.Normal;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Rock, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Ghost });
        // ��
        type = (int)AttributeType.Fire;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Ice, AttributeType.Insect, AttributeType.Steel });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Water, AttributeType.Rock, AttributeType.Dragon });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // ��
        type = (int)AttributeType.Water;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fire, AttributeType.Ground, AttributeType.Rock });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Water, AttributeType.Grass, AttributeType.Dragon });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �d�C
        type = (int)AttributeType.Electricity;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Water, AttributeType.AirPlane });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Electricity, AttributeType.Grass, AttributeType.Dragon});
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Ground });
        // ��
        type = (int)AttributeType.Grass;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Water, AttributeType.Ground, AttributeType.Rock });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Grass, AttributeType.Poison,�@AttributeType.AirPlane, AttributeType.Insect, AttributeType.Dragon, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �X
        type = (int)AttributeType.Ice;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Ground, AttributeType.AirPlane, AttributeType.Dragon });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Water, AttributeType.Ice, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �i��
        type = (int)AttributeType.Fighting;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Normal, AttributeType.Ice, AttributeType.Rock, AttributeType.Evil, AttributeType.Steel });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Poison, AttributeType.AirPlane, AttributeType.Esper, AttributeType.Insect, AttributeType.Fairy });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Ghost });
        // ��
        type = (int)AttributeType.Poison;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Fairy });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Poison, AttributeType.Ground, AttributeType.Rock, AttributeType.Ghost });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Steel });
        // �n��
        type = (int)AttributeType.Ground;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fire, AttributeType.Electricity, AttributeType.Poison, AttributeType.Rock, AttributeType.Steel });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Grass, AttributeType.Insect });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.AirPlane });
        // ��s
        type = (int)AttributeType.AirPlane;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Fighting, AttributeType.Insect });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Electricity, AttributeType.Rock, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �G�X�p�[
        type = (int)AttributeType.Esper;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fighting, AttributeType.Poison });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Esper, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Evil });
        // ��
        type = (int)AttributeType.Insect;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Grass, AttributeType.Esper, AttributeType.Evil });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Fighting, AttributeType.Poison, AttributeType.AirPlane, AttributeType.Ghost, AttributeType.Steel, AttributeType.Steel, AttributeType.Fairy });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // ��
        type = (int)AttributeType.Rock;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fire, AttributeType.Ice, AttributeType.AirPlane, AttributeType.Insect });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fighting, AttributeType.Ground, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �S�[�X�g
        type = (int)AttributeType.Ghost;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Esper, AttributeType.Ghost });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Evil });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Normal });
        // �h���S��
        type = (int)AttributeType.Dragon;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Dragon });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { AttributeType.Fairy });
        // ��
        type = (int)AttributeType.Evil;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Esper, AttributeType.Ghost });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fighting, AttributeType.Evil, AttributeType.Fairy });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �|
        type = (int)AttributeType.Steel;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Ice, AttributeType.Rock, AttributeType.Fairy });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Water, AttributeType.Electricity, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
        // �t�F�A���[
        type = (int)AttributeType.Fairy;
        compatibility_[type].AddAttackOutstandings(new AttributeType[] { AttributeType.Fighting, AttributeType.Dragon, AttributeType.Evil });
        compatibility_[type].AddAttackHalfs(new AttributeType[] { AttributeType.Fire, AttributeType.Poison, AttributeType.Steel });
        compatibility_[type].AddAttackInvalids(new AttributeType[] { });
    }

    /// <summary>
    /// �^�C�v����
    /// </summary>
    /// <param name="attackType">�U�����^�C�v</param>
    /// <param name="receiverTypes">�h�䑤�^�C�v</param>
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
