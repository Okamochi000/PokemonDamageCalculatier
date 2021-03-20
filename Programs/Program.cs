using System;

namespace PokemonDamageCalculatier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("攻撃側 : [リザードン][レベル50][いじっぱり][6V][AS252振り][もうか][もくたん][フレアドライブ][攻撃ランク+2][晴れ]");
            Console.WriteLine("防御側 : [ゴンベ][レベル50][わんぱく][6V][HB252振り][あついしぼう][しんかのきせき][リフレクター][防御ランク-1]");

            CharaStatus attacker = GetAttackerStatus();
            CharaStatus defender = GetDefenderStatus();

            int techniquePower = 120;               // 攻撃側技 フレアドライブ 威力120
            float attackerItem = 1.2f;              // 攻撃側持ち物 もくたん 威力*1.2倍
            float attackerCharacteristic = 1.5f;    // 攻撃側特性 もうか こうげき*1.5倍
            int attackerRank = 2;                   // 攻撃側ランク補正 +2
            float defenderItem = 1.5f;              // 攻撃側持ち物 しんかのきせき ぼうぎょ*1.5倍
            float defenderCharacteristic = 0.5f;    // 防御側特性 あついしぼう 攻撃側のこうげき*0.5倍
            int defenderRank = -1;                  // 防御側ランク補正 -1
            float defenderReflector = 0.5f;         // 防御側リフレクター 0.5倍

            int finalPower = DamageCalculatier.GetFinalPower(techniquePower, new float[] { attackerItem });
            int finalAttackPower = DamageCalculatier.GetFinalAttackPower(attacker.Values[(int)CharaStatusType.PhysicsAttack], attackerRank, false, false, new float[] { attackerCharacteristic, defenderCharacteristic });
            int finalDefensePower = DamageCalculatier.GetFinalDefensePower(defender.Values[(int)CharaStatusType.PhysicsDamage], defenderRank, false, true, new float[] { defenderItem });
            FinalCorrection finalCorrection = new FinalCorrection();
            finalCorrection.IsTypeMatch = true;     // タイプ一致 1.5倍
            finalCorrection.RandomNumber = 1.0f;    // 乱数 1.0倍(最高乱数)
            finalCorrection.IsWeatherEnhancement = true;    // 天候晴れ補正 1.5倍
            finalCorrection.DamageCorrections = new float[] { defenderReflector };   // リフレクター 0.5倍 (急所の場合は設定しない)
            int maxDamage = DamageCalculatier.GetFinalDamage(50, finalPower, finalAttackPower, finalDefensePower, finalCorrection);
            finalCorrection.RandomNumber = 0.85f;    // 乱数 1.0倍(最高乱数)
            int minDamage = DamageCalculatier.GetFinalDamage(50, finalPower, finalAttackPower, finalDefensePower, finalCorrection);

            Console.WriteLine("ダメージ : " + minDamage + " ～ " + maxDamage);
            Console.ReadLine();
        }

        /// <summary>
        /// [リザードン][レベル50][いじっぱり][6V][AS252振り]のステータス実数値を取得する
        /// </summary>
        /// <returns></returns>
        private static CharaStatus GetAttackerStatus()
        {
            // レベルを設定する
            int level = 50;
            // 性格を設定する
            Personality personality = Personality.CreatePresonality(PersonalityType.Adamant);
            // 種族値を設定する
            CharaStatus raceValue = new CharaStatus();
            raceValue.Values[(int)CharaStatusType.Hp] = 78;
            raceValue.Values[(int)CharaStatusType.PhysicsAttack] = 84;
            raceValue.Values[(int)CharaStatusType.PhysicsDamage] = 78;
            raceValue.Values[(int)CharaStatusType.SpecialAttack] = 109;
            raceValue.Values[(int)CharaStatusType.SpecialDamage] = 185;
            raceValue.Values[(int)CharaStatusType.Speed] = 100;
            // 努力値を設定する
            CharaStatus effortValue = new CharaStatus();
            for (int i = 0; i < System.Enum.GetValues(typeof(CharaStatusType)).Length; i++) { effortValue.Values[i] = 0; }
            effortValue.Values[(int)CharaStatusType.Hp] = 4;
            effortValue.Values[(int)CharaStatusType.PhysicsAttack] = 252;
            effortValue.Values[(int)CharaStatusType.Speed] = 252;
            // 個体値を設定する
            CharaStatus individualValue = new CharaStatus();
            for (int i = 0; i < System.Enum.GetValues(typeof(CharaStatusType)).Length; i++) { individualValue.Values[i] = 31; }
            return CharaStatus.GetRealStatus(level, personality, raceValue, effortValue, individualValue);
        }

        /// <summary>
        /// [ゴンベ][レベル50][わんぱく][6V][HB252振り]のステータス実数値を取得する
        /// </summary>
        /// <returns></returns>
        private static CharaStatus GetDefenderStatus()
        {
            // レベルを設定する
            int level = 50;
            // 性格を設定する
            Personality personality = Personality.CreatePresonality(PersonalityType.Impish);
            // 種族値を設定する
            CharaStatus raceValue = new CharaStatus();
            raceValue.Values[(int)CharaStatusType.Hp] = 135;
            raceValue.Values[(int)CharaStatusType.PhysicsAttack] = 85;
            raceValue.Values[(int)CharaStatusType.PhysicsDamage] = 40;
            raceValue.Values[(int)CharaStatusType.SpecialAttack] = 40;
            raceValue.Values[(int)CharaStatusType.SpecialDamage] = 85;
            raceValue.Values[(int)CharaStatusType.Speed] = 5;
            // 努力値を設定する
            CharaStatus effortValue = new CharaStatus();
            for (int i = 0; i < System.Enum.GetValues(typeof(CharaStatusType)).Length; i++) { effortValue.Values[i] = 0; }
            effortValue.Values[(int)CharaStatusType.Hp] = 252;
            effortValue.Values[(int)CharaStatusType.PhysicsDamage] = 252;
            effortValue.Values[(int)CharaStatusType.SpecialDamage] = 4;
            // 個体値を設定する
            CharaStatus individualValue = new CharaStatus();
            for (int i = 0; i < System.Enum.GetValues(typeof(CharaStatusType)).Length; i++) { individualValue.Values[i] = 31; }
            return CharaStatus.GetRealStatus(level, personality, raceValue, effortValue, individualValue);
        }
    }
}
