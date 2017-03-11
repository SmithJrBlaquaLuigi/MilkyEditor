using MilkyEditor.GalaxyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    public class ObjectModelSubstitution
    {
        // why did whitehole even use the LevelObject?
        public static string returnModelName(string name)
        {
            switch (name)
            {
                case "ArrowSwitchMulti": return "ArrowSwitch";
                case "AstroDomeBlueStar": return "GCaptureTarget";
                case "AttackRockFinal":
                case "AttackRockTutorial": return "AttackRock";
                case "BenefitItemInvincible": return "PowerUpInvincible";
                case "BenefitItemLifeUp": return "KinokoLifeUp";
                case "BenefitItemOneUp": return "KinokoOneUp";
                case "BigBubbleGenerator":
                case "BigObstructBubbleGenerator": return "AirBubbleGenerator";
                case "Bomb": return "BombHei";
                case "BombLauncher": return "BombHeiLauncher";
                case "BossKameck2": return "BossKameck";
                case "BreakableCageRotate": return "BreakableCage";
                case "ButlerExplain":
                case "ButlerMap": return "Butler";
                case "CoinReplica": return "Coin";
                case "Creeper": return "CreeperFlower";
                case "CutBushGroup": return "CutBush";
                case "DemoKoopaJrShip": return "KoopaJrShip";
                case "DharmaSambo": return "DharmaSamboParts";
                case "FireBallBeamKameck": return "Kameck";
                case "FirePressureRadiate": return "FirePressure";
                case "FishGroupA": return "FishA";
                case "FishGroupB": return "FishB";
                case "FishGroupC": return "FishC";
                case "FishGroupD": return "FishD";
                case "FishGroupE": return "FishE";
                case "FishGroupF": return "FishF";
                case "FlowerBlueGroup": return "FlowerBlue";
                case "FlowerGroup": return "Flower";
                case "GhostPlayer": return "GhostMario";
                case "GliBirdNpc": return "GliBird";
                case "GoldenTurtle": return "KouraShine";
                case "Hanachan": return "HanachanHead";
                case "HanachanBig": return "HanachanHeadBig";
                case "DrillBullet": return "Horino";
                case "InstantInferno": return "InfernoMario";
                case "ItemBlockSwitch": return "CoinBlock";
                case "JetTurtle": return "Koura";
                case "KameckKuriboMini":
                case "KameckMeramera": return "Kameck";
                case "Karikari": return "Karipon";
                case "KirairaRail": return "Kiraira";
                case "KoopaBattleMapCoinPlate": return "KoopaPlateCoin";
                case "KoopaBattleMapPlate": return "KoopaPlate";
                case "KoopaBattleMapStairturnAppear": return "KoopaBattleMapStairTurn";
                case "KoopaNpc": return "Koopa";
                case "KoopaStatueVomit": return "KoopaStatue";
                case "KoopaLv2":
                case "KoopaLv3":
                case "KoopaLv4": return "Koopa";
                case "LavaProminenceWithoutShadow": return "LavaProminence";
                case "SpinLeverSwitchForceAnim": return "SpinLeverSwitch";
                case "LuigiTalkNpc":
                case "LuigiIntrusively": return "LuigiNpc";
                case "MagicBell": return "Bell";
                case "MameMuimuiAttackMan": return "ScoreAttackMan";
                case "MeteorCannon":
                case "MeteorStrikeEnvironment": return "MeteorStrike";
                case "MiniKoopaBattleVs1Galaxy":
                case "MiniKoopaBattleVs2Galaxy":
                case "MiniKoopaBattleVs3Galaxy": return "MiniKoopaGalaxy";
                case "MorphItemCollectionBee": return "PowerUpBee";
                case "MorphItemCollectionCloud": return "PowerUpCloud";
                case "MorphItemCollectionDrill": return "ItemDrill";
                case "MorphItemCollectionFire": return "PowerUpFire";
                case "MorphItemCollectionHopper": return "PowerUpHopper";
                case "MorphItemCollectionTeresa": return "PowerUpTeresa";
                case "MorphItemCollectionRock": return "PowerUpRock";
                case "MorphItemNeoBee": return "PowerUpBee";
                case "MorphItemNeoFire": return "PowerUpFire";
                case "MorphItemNeoFoo": return "PowerUpFoo";
                case "MorphItemNeoHopper": return "PowerUpHopper";
                case "MorphItemNeoIce": return "PowerUpIce";
                case "MorphItemNeoTeresa": return "PowerUpTeresa";
                case "MorphItemRock": return "PowerUpRock";
                case "NoteFairy": return "Note";
                case "OnimasuPivot": return "Onimasu";
                case "PenguinSkater":
                case "PenguinStudent": return "Penguin";
                case "Plant": return "PlantSeed";
                case "PlayAttackMan": return "ScoreAttackMan";
                case "PrologueDirector": return "DemoLetter";
                case "PukupukuWaterSurface": return "Pukupuku";
                case "Rabbit": return "MoonRabbit";
                case "RockCreator": return "Rock";
                case "RunawayRabbitCollect": return "TrickRabbit";
                case "SeaGullGroup":
                case "SeaGullGroupMarioFace": return "SeaGull";
                case "ShellfishBlueChip":
                case "ShellfishCoin":
                case "ShellfishKinokoOneUp":
                case "ShellfishYellowChip": return "Shellfish";
                case "SignBoardTamakoro": return "SignBoard";
                case "SkeletalFishBaby": return "SnakeFish";
                case "SpiderAttachPoint": return "SpiderThreadAttachPoint";
                case "SpiderCoin": return "Coin";
                case "SpinCloudItem":
                case "SpinCloudMarioItem": return "PowerUpCloud";
                case "SplashCoinBlock":
                case "SplashPieceBlock": return "CoinBlock";
                case "SuperDreamer": return "HelperWitch";
                case "SuperSpinDriverGreen":
                case "SuperSpinDriverPink": return "SuperSpinDriver";
                case "SurpBeltConveyerExGalaxy":
                case "SurpCocoonExGalaxy":
                case "SurpCubeBubbleExLv2Galaxy":
                case "SurpFishTunnelGalaxy":
                case "SurpPeachCastleFinalGalaxy":
                case "SurpSnowCapsuleGalaxy":
                case "SurpSurfingLv2Galaxy":
                case "SurpTamakoroExLv2Galaxy":
                case "SurpTearDropGalaxy":
                case "SurpTeresaMario2DGalaxy":
                case "SurpTransformationExGalaxy": return "MiniSurprisedGalaxy";
                case "TalkSyati": return "Syati";
                case "TamakoroWithTutorial": return "Tamakoro";
                case "Teresa":
                case "TeresaChief": return "TeresaWater";
                case "TicoAstro":
                case "TicoDomeLecture": return "Tico";
                case "TicoFatCoin":
                case "TicoFatStarPiece":
                case "TicoGalaxy": return "TicoFat";
                case "TicoRail":
                case "TicoReading":
                case "TicoStarRing": return "Tico";
                case "TimerCoinBlock":
                case "TimerPieceBlock": return "CoinBlock";
                case "TogepinAttackMan": return "ScoreAttackMan";
                case "Tongari2D": return "Tongari";
                case "TreasureBoxBlueChip":
                case "TreasureBoxCoin": return "TreasureBox";
                case "TreasureBoxCrackedAirBubble":
                case "TreasureBoxCrackedBlueChip":
                case "TreasureBoxCrackedCoin":
                case "TreasureBoxCrackedEmpty":
                case "TreasureBoxCrackedKinokoLifeUp":
                case "TreasureBoxCrackedKinokoOneUp":
                case "TreasureBoxCrackedPowerStar":
                case "TreasureBoxCrackedYellowChip": return "TreasureBoxCracked";
                case "TreasureBoxEmpty": return "TreasureBox";
                case "TreasureBoxGoldEmpty": return "TreasureBoxGold";
                case "TreasureBoxKinokoLifeUp":
                case "TreasureBoxKinokoOneUp":
                case "TreasureBoxYellowChip": return "TreasureBox";
                case "TrickRabbitFreeRun":
                case "TrickRabbitFreeRunCollect":
                case "TrickRabbitGhost": return "TrickRabbit";
                case "TripodBossCoin": return "Coin";
                case "TripodBossBottomKillerCannon":
                case "TripodBossKillerGenerator": return "TripodBossKillerCannon";
                case "TripodBossKinokoOneUp": return "KinokoOneUp";
                case "TripodBossUnderKillerCannon":
                case "TripodBossUpperKillerCannon": return "TripodBossKillerCannon";
                case "TubeSliderDamageObj": return "NeedlePlant";
                case "TubeSliderEnemy": return "Togezo";
                case "TubeSliderHana": return "HanachanHeadBig";
                case "TurtleBeamKameck": return "Kameck";
                case "TwoLegsBullet": return "Horino";
                case "WingBlockCoin":
                case "WingBlockStarPiece": return "WingBlock";
                case "YoshiCapture": return "YCaptureTarget";
            }

            return name;
        }
    }
}
