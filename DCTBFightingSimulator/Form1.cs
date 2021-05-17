using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DCTBFightingSimulator
{
    public partial class DCTBFightingSimulator : Form
    {
        //Character Strings Database Here:
            //Vanilla
                //None
        string josephString = "nX!wj@am!EJosephd@3MDMe#SCJoseph is a proficient melee fighter who is able to deal decent damage and adequately defend, but cannot easily dodge.t192y!@:PE22NONEh!*##p2@<#1600at1!@!W0k130d%%23eFF130a1;c';c80dj1g><e25imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Flurry PunchdDCMv1@@Joseph attacks with a volley of punches. Type:  NONEtDCMmv1@@NONEatmDCMmv1@@1.25accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@MegapunchdDCMv2@@Joseph delivers a heavy punch, dealing significant damage. This attack is hard to land. Type: NONEtDCMmv2@@NONEatmDCMmv2@@1.75accDCMmv2@@55hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Flying KickdDCMv3@@Joseph attacks with a flying kick, dealing damage and raising his own attack. Type: NONEtDCMmv3@@NONEatmDCMmv3@@1.25accDCMmv3@@40hDCMmv3@@0atkDCMmv3@@30defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@RetaliatedDCMv4@@Joseph retaliates with a small amount of damage, but in doing so raises his own defense. Type: NONEtDCMmv4@@NONEatmDCMmv4@@1.3accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@40acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@SkullcrusherdDCMv5@@Joseph crushes his opponent's skull, dealing heavy damage and crippling them. This attack is difficult to land. Type: NONEtDCMmv5@@NONEatmDCMmv5@@3.5accDCMmv5@@10hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnynnnnnindENDMmv5@@_!";
        string davidString = "nX!wj@am!EDavidd@3MDMe#SCDavid is a sword-wielding fighter capable of inflicting bleeding on his opponents. He is strong when attacking but needs to be careful on defense.t192y!@:PE22NONEh!*##p2@<#1550at1!@!W0k150d%%23eFF90a1;c';c90dj1g><e30imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@SlicedDCMv1@@David slices at his opponent, dealing a small amount of damage but inflicting bleeding. Type: NONEtDCMmv1@@NONEatmDCMmv1@@0.6accDCMmv1@@50hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnynnnindENDMmv1@@_!nDCMmv2@@SharpendDCMv2@@David sharpens his swords, increasing his ATK. For this move, opponents' 'dodge' stat represents their ability to prevent him from doing so. Type: NONEtDCMmv2@@NONEatmDCMmv2@@0accDCMmv2@@200hDCMmv2@@0atkDCMmv2@@45defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Super SlashdDCMv3@@David slashes at his opponent, dealing high amounts of damage. Type: NONEtDCMmv3@@NONEatmDCMmv3@@3accDCMmv3@@50hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Combo SwordsdDCMv4@@David unleashes a flurry of combos with his swords, dealing damage and slightly raising his own attack. Type: NONEtDCMmv4@@NONEatmDCMmv4@@0.6accDCMmv4@@50hDCMmv4@@0atkDCMmv4@@20defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Flask AttackdDCMv5@@David uses a dual-utility flask to add attack to his sword and heal himself slightly. Type: NONEtDCMmv5@@NONEatmDCMmv5@@1.3accDCMmv5@@40hDCMmv5@@75atkDCMmv5@@15defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string duncanString = "nX!wj@am!EDuncand@3MDMe#SCDuncan is a heavy-hitting but defensively weak human.t192y!@:PE22NONEh!*##p2@<#1800at1!@!W0k295d%%23eFF50a1;c';c75dj1g><e10imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@HandrocketdDCMv1@@Duncan fires a large rocket at the opponent, dealing devastating damage along with burning and weakening them. Type: NONEtDCMmv1@@NONEatmDCMmv1@@2accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnynnnnynindENDMmv1@@_!nDCMmv2@@Sword SlashdDCMv2@@Duncan slashes his handheld sword, inflicting bleeding. Type: NONEtDCMmv2@@NONEatmDCMmv2@@1accDCMmv2@@60hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnynnnindENDMmv2@@_!nDCMmv3@@King's ClashdDCMv3@@Duncan deals a small amount of damage but raises his ATK slightly. Type: NONEtDCMmv3@@NONEatmDCMmv3@@0.5accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@5defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Bomb PlantdDCMv4@@Duncan plants a large bomb near the opponent, which explodes and deals devastating damage. Duncan takes recoil damage. Type: NONEtDCMmv4@@NONEatmDCMmv4@@3.25accDCMmv4@@50hDCMmv4@@-30atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@The CripplerdDCMv5@@Duncan's signature move, which feigns high damage and instead cripples the opponent. Type: NONEtDCMmv5@@NONEatmDCMmv5@@0.3accDCMmv5@@0hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnynnnnnindENDMmv5@@_!";
        string firiaString = "";
                //Void
        string anomalString = "nX!wj@am!EAnomald@3MDMe#SCAnomal is a void-blooded beast resembling a massive jaguar. What he lacks in defense, he makes up for in durability and attack, and is capable of weakening opponents.t192y!@:PE22VOIDh!*##p2@<#2000at1!@!W0k275d%%23eFF65a1;c';c80dj1g><e10imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Void FangdDCMv1@@Anomal bites his opponent with void-bearing fangs. Type: VOIDtDCMmv1@@VOIDatmDCMmv1@@1.5accDCMmv1@@30hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@PouncedDCMv2@@Anomal pounces on the target, inflicting large damage. This attack also has high accuracy. Type: NONEtDCMmv2@@NONEatmDCMmv2@@2.25accDCMmv2@@80hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@EnshrouddDCMv3@@Anomal encompasses the target in a dark void, dealing a low amount of damage, weakening them, and raising his own ATK. Type: VOIDtDCMmv3@@VOIDatmDCMmv3@@0.4accDCMmv3@@50hDCMmv3@@0atkDCMmv3@@30defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnynindENDMmv3@@_!nDCMmv4@@RetreatdDCMv4@@Anomal attacks with a short blow as he retreats backward. This move deals a very small amount of damage while giving Anomal some HP. However, it has a low chance to hit. Type: NONEtDCMmv4@@NONEatmDCMmv4@@1.5accDCMmv4@@30hDCMmv4@@75atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Throne of PredatorsdDCMv5@@If Anomal can manage to land this attack, it deals devastating damage, raises his DEF and ACC and heals him, but at the cost of a little ATK. Type: VOIDtDCMmv5@@VOIDatmDCMmv5@@4accDCMmv5@@-15hDCMmv5@@50atkDCMmv5@@-10defDCMmv5@@5acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string rigString = "nX!wj@am!ERigd@3MDMe#SCRig is a manifestation of the void itself. It is immune to bleeding and stunning due to its properties.t192y!@:PE22VOIDh!*##p2@<#1900at1!@!W0k100d%%23eFF100a1;c';c90dj1g><e30imnSTRT@@_!ynnnnynnnimnEND@@_!nDCMmv1@@Void RaydDCMv1@@Rig fires a small ray of void, dealing damage. Type: VOIDtDCMmv1@@VOIDatmDCMmv1@@1.5accDCMmv1@@40hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Void BeamdDCMv2@@Rig fires a thicker version of the Void Ray, dealing more damage but with less accuracy. Type: VOIDtDCMmv2@@VOIDatmDCMmv2@@2.5accDCMmv2@@10hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@ManifestationdDCMv3@@Rig manifests itself in a different form, increasing all of its stats. The opponent's 'dodge' value represents their ability to prevent this. Type: VOIDtDCMmv3@@VOIDatmDCMmv3@@0accDCMmv3@@80hDCMmv3@@0atkDCMmv3@@15defDCMmv3@@25acmDCMmv3@@5dgeDCMmv3@@5indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@OverbeardDCMv4@@Rig uses the powers of the void to overbear its opponent, inflicting a weakened state upon them and dealing some damage. Type: VOIDtDCMmv4@@VOIDatmDCMmv4@@1.5accDCMmv4@@40hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnynindENDMmv4@@_!nDCMmv5@@Void KamikazedDCMv5@@Rig flings itself at the opponent, dealing massive damage, raising its DEF, but harming itself. Type: VOIDtDCMmv5@@VOIDatmDCMmv5@@3.25accDCMmv5@@30hDCMmv5@@-50atkDCMmv5@@0defDCMmv5@@20acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Earthly
        string stoneGolemString = "nX!wj@am!EStone Golemd@3MDMe#SCThe Stone Golem is slow to move and light on the attack, but has a large stock of health, a high defense, and is immune to bleeding.t192y!@:PE22EARTHLYh!*##p2@<#4500at1!@!W0k60d%%23eFF315a1;c';c80dj1g><e10imnSTRT@@_!nnnnnynnnimnEND@@_!nDCMmv1@@Boulder TossdDCMv1@@The Stone Golem throws a large boulder at the target, inflicting damage and crippling them. Type: EARTHLYtDCMmv1@@EARTHLYatmDCMmv1@@1accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnynnnnnindENDMmv1@@_!nDCMmv2@@Rock PlantdDCMv2@@The Stone Golem plants itself in the ground, raising its own DEF substantially. The 'dodge' value for opponents represents their ability to prevent the plant. Type: NONEtDCMmv2@@NONEatmDCMmv2@@0accDCMmv2@@100hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@25acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Stone SmashdDCMv3@@The Stone Golem smashes a large stone on the target. Type: EARTHLYtDCMmv3@@EARTHLYatmDCMmv3@@1.25accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Golem's RagedDCMv4@@The Stone Golem goes into a fit of rage, dealing significant damage, slightly raising ATK, but harming itself in the process. Type: EARTHLYtDCMmv4@@EARTHLYatmDCMmv4@@1.75accDCMmv4@@60hDCMmv4@@-25atkDCMmv4@@5defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@DiscombobulationdDCMv5@@The Stone Golem temporarily splits into multiple pieces, dealing a small amount of damage, slightly raising the DGE value, but lowering its own defense slightly. Type: EARTHLYtDCMmv5@@EARTHLYatmDCMmv5@@0.8accDCMmv5@@60hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@-5acmDCMmv5@@0dgeDCMmv5@@5indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string livernString = "nX!wj@am!ELivernd@3MDMe#SCLivern resembles a sentient plant with strong roots.t192y!@:PE22EARTHLYh!*##p2@<#2300at1!@!W0k135d%%23eFF120a1;c';c80dj1g><e20imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@LeechdDCMv1@@Livern extends its roots, leeching off of the opponent's health. Type: EARTHLYtDCMmv1@@EARTHLYatmDCMmv1@@1.1accDCMmv1@@80hDCMmv1@@50atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Disease TransplantdDCMv2@@Livern removes the diseases from itself, raising its own HP, dealing damage to and weakening the opponent. Type: EARTHLYtDCMmv2@@EARTHLYatmDCMmv2@@1.5accDCMmv2@@50hDCMmv2@@30atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnynindENDMmv2@@_!nDCMmv3@@SeedlingsdDCMv3@@Livern plants multiple versions of itself surrounding itself, raising its own DEF and dealing some damage. Type: NATURALtDCMmv3@@NATURALatmDCMmv3@@0.8accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@15acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Mineral RushdDCMv4@@Livern gathers a rush of earthly minerals and channels the power into a devastating attack. Type: EARTHLYtDCMmv4@@EARTHLYatmDCMmv4@@2.5accDCMmv4@@50hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@UprootdDCMv5@@Livern uproots the ground around it, reducing its own DEF slightly but dealing massive damage. Type: GROUNDtDCMmv5@@GROUNDatmDCMmv5@@3.5accDCMmv5@@70hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@-10acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Air
        string albatrossString = "nX!wj@am!EAlbatrossd@3MDMe#SCThe Albatross's large body and endurance give it a high, well-rounded durability.t192y!@:PE22AIRh!*##p2@<#2900at1!@!W0k120d%%23eFF115a1;c';c90dj1g><e30imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Plankton SwoopdDCMv1@@The Albatross swoops down to attack the enemy, as if it was catching food. Type: AIRtDCMmv1@@AIRatmDCMmv1@@0.9accDCMmv1@@30hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Wing BlastdDCMv2@@The Albatross flaps its wings in a broad radius, blasting the target with a large gust of air. Type: AIRtDCMmv2@@AIRatmDCMmv2@@1.75accDCMmv2@@40hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@SustenancedDCMv3@@The Albatross delivers a quick blow, then soars to the skies, healing itself and raising all of its stats slightly. Type: AIRtDCMmv3@@AIRatmDCMmv3@@0.45accDCMmv3@@40hDCMmv3@@30atkDCMmv3@@5defDCMmv3@@5acmDCMmv3@@5dgeDCMmv3@@5indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@RaindDCMv4@@The Albatross calls upon the rains and swoops down in a combo attack.tDCMmv4@@AIRatmDCMmv4@@2accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Great LegenddDCMv5@@The Albatross attacks with a legendary finisher, dealing heavy damage but inflicting a small amount of damage on itself. Type: AIRtDCMmv5@@AIRatmDCMmv5@@4.5accDCMmv5@@50hDCMmv5@@-30atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string tweedleString = "nX!wj@am!ETweedled@3MDMe#SCTweedle is a tiny bird that has low health and is not capable of inflicting lots of damage, but has a great chance to dodge attacks.t192y!@:PE22AIRh!*##p2@<#1400at1!@!W0k60d%%23eFF90a1;c';c80dj1g><e100imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@PeckdDCMv1@@Tweedle pecks at the opponent. Type: AIRtDCMmv1@@AIRatmDCMmv1@@0.9accDCMmv1@@40hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@FlutterdDCMv2@@Tweedle flutters at the opponent, dealing a small amount of damage but confusing them, raising its DGE. Type: AIRtDCMmv2@@AIRatmDCMmv2@@0.75accDCMmv2@@40hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@BirdsongdDCMv3@@Tweedle sings a birdsong, raising its stats and dealing a small amount of damage. Type: NONEtDCMmv3@@NONEatmDCMmv3@@0.25accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@5defDCMmv3@@5acmDCMmv3@@5dgeDCMmv3@@5indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@CouragedDCMv4@@Tweedle gathers some courage, attacking the target with strength and raising ATK. Type: NONEtDCMmv4@@NONEatmDCMmv4@@0.9accDCMmv4@@40hDCMmv4@@0atkDCMmv4@@10defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Speed PeckdDCMv5@@Tweedle attacks quickly with its beak, dealing damage and inflicting bleeding.tDCMmv5@@AIRatmDCMmv5@@1accDCMmv5@@40hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnynnnindENDMmv5@@_!";
                //Ground
        string quakeString = "nX!wj@am!EQuaked@3MDMe#SCQuake is a ground-dwelling sentient rock structure that manipulated the terrain. As Quake is a rock, it is immune to bleeding and weakening.t192y!@:PE22GROUNDh!*##p2@<#2250at1!@!W0k115d%%23eFF200a1;c';c75dj1g><e30imnSTRT@@_!nnnynnnynimnEND@@_!nDCMmv1@@ShakedDCMv1@@Quake shakes the terrain, loosing rocks and other debris. Type: GROUNDtDCMmv1@@GROUNDatmDCMmv1@@1.25accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@RebuilddDCMv2@@Quake picks up its broken pieces, making itself stronger than before. HP and DEF are raised. Type: NONEtDCMmv2@@NONEatmDCMmv2@@0accDCMmv2@@100hDCMmv2@@50atkDCMmv2@@0defDCMmv2@@15acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Boulder RushdDCMv3@@Quake throws a volley of boulders, which accelerate and deal massive damage to the target, crippling them as well. Type: GROUNDtDCMmv3@@GROUNDatmDCMmv3@@2.5accDCMmv3@@40hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnynnnnnindENDMmv3@@_!nDCMmv4@@Terrain SwitchdDCMv4@@Quake switches around the terrain, raising its attack and dealing slight damage. Type: EARTHLYtDCMmv4@@EARTHLYatmDCMmv4@@1.25accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@15defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Mag 9dDCMv5@@Quake attacks with a devastating earthquake, inflicting massive damage. Recoil is significant. Type: GROUNDtDCMmv5@@GROUNDatmDCMmv5@@7accDCMmv5@@50hDCMmv5@@-75atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string therockString = "nX!wj@am!EThe Rockd@3MDMe#SCNot Dwayne Johnson, but is still very strong. Doesn't dodge well, and accuracy is low.t192y!@:PE22GROUNDh!*##p2@<#2900at1!@!W0k190d%%23eFF190a1;c';c50dj1g><e10imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@StrongholddDCMv1@@The Rock creates a rocky stronghold around itself, raising DEF and knocking the opponent back. Type: GROUNDtDCMmv1@@GROUNDatmDCMmv1@@1.25accDCMmv1@@90hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@10acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Stone DropdDCMv2@@The Rock drops a stone from a tall height onto the target, crippling them, Type: EARTHLYtDCMmv2@@EARTHLYatmDCMmv2@@0.9accDCMmv2@@80hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnynnnnnindENDMmv2@@_!nDCMmv3@@Rock SmashdDCMv3@@The Rock smashes itself on the opponent, dealing a large amount of damage, but taking recoil. Type: GROUNDtDCMmv3@@GROUNDatmDCMmv3@@2accDCMmv3@@80hDCMmv3@@-10atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@HeadhuntdDCMv4@@The Rock flings itself at the opponent's head, dealing high damage. Type: FORCEtDCMmv4@@FORCEatmDCMmv4@@1.25accDCMmv4@@90hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@CrumbledDCMv5@@The Rock crumbles on the opponent, reducing its DEF stat slightly but dealing heavy damage and stupefying the opponent. Type: GROUNDtDCMmv5@@GROUNDatmDCMmv5@@2accDCMmv5@@70hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@-2acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnynnindENDMmv5@@_!";
                //Electric
        string zipString = "nX!wj@am!EZipd@3MDMe#SCZip is a fast-moving, small humanoid creature, and what he lacks in ATK and DEF he more than makes up for in ACC and DGE. He is also immune to stuns.t192y!@:PE22ELECTRICh!*##p2@<#1250at1!@!W0k50d%%23eFF50a1;c';c100dj1g><e50imnSTRT@@_!ynnnnnnnnimnEND@@_!nDCMmv1@@LightningSpeeddDCMv1@@Zip attacks faster than lightning, dealing a small amount of damage but with high accuracy. Type: ELECTRICtDCMmv1@@ELECTRICatmDCMmv1@@0.8accDCMmv1@@100hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Electric PunchdDCMv2@@Zip attacks quickly with a strong, electricity-filled punch. It also stuns the enemy. Type: ELECTRICtDCMmv2@@ELECTRICatmDCMmv2@@1.35accDCMmv2@@100hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!ynnnnnnnnindENDMmv2@@_!nDCMmv3@@Neuron ZapdDCMv3@@Zip attacks the enemy with a zap to their nervous system, dealing damage and dazing them. Type: ELECTRICtDCMmv3@@ELECTRICatmDCMmv3@@0.9accDCMmv3@@100hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnyindENDMmv3@@_!nDCMmv4@@Vanishing ZapdDCMv4@@Zip quickly zaps the enemy, and then whips out of sight, slightly raising DEF. Type: ELECTRICtDCMmv4@@ELECTRICatmDCMmv4@@0.8accDCMmv4@@100hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@5acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@ShortdDCMv5@@Zip shorts his own circuits, releasing a deadly shockwave that deals recoil damage but also a devastating amount of damage, stunning and dazing the enemy. Type: ELECTRICtDCMmv5@@ELECTRICatmDCMmv5@@1.8accDCMmv5@@90hDCMmv5@@-15atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!ynnnnnnnyindENDMmv5@@_!";
        string magnaurString = "nX!wj@am!EMagnaurd@3MDMe#SCMagnaur is a magnetic field resembling an ancient dinosaur, and is capable of utilizing both Electric-type and Metal-type moves.t192y!@:PE22ELECTRICh!*##p2@<#1850at1!@!W0k115d%%23eFF140a1;c';c70dj1g><e40imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@AttractdDCMv1@@Magnaur attracts the target to another magnetic object, then zaps the target with an electric current, dealing heavy damage. Type: ELECTRICtDCMmv1@@ELECTRICatmDCMmv1@@2accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@ChanneldDCMv2@@Magnaur channels electric currents through its body, then expels them, dealing damage and raising ATK and DEF. Type: ELECTRICtDCMmv2@@ELECTRICatmDCMmv2@@1accDCMmv2@@50hDCMmv2@@0atkDCMmv2@@10defDCMmv2@@10acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Magnet TossdDCMv3@@Magnaur tosses a heavy magnet at the target, dealing heavy damage and pinning them to the nearest metal obkect, weakening them. Type: METALtDCMmv3@@METALatmDCMmv3@@1.5accDCMmv3@@50hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnynindENDMmv3@@_!nDCMmv4@@Dual ShockdDCMv4@@Magnaur sends shockwaves from two opposing magnets that collide with the target. Type: ELECTRICtDCMmv4@@ELECTRICatmDCMmv4@@1.75accDCMmv4@@40hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Magnet LeechdDCMv5@@Magnaur uses magnetic force to pull away energy from the opponent and give it to itself, dealing low damage but healing itself. Type: ELECTRICtDCMmv5@@ELECTRICatmDCMmv5@@0.75accDCMmv5@@50hDCMmv5@@25atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Metal
        string irodeString = "nX!wj@am!EIroded@3MDMe#SCIrode is humanoid made of tons of iron balls. It has a high defense.t192y!@:PE22METALh!*##p2@<#2750at1!@!W0k80d%%23eFF325a1;c';c60dj1g><e20imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Steel DropdDCMv1@@Irode detaches one of the metal balls from its body and drops it on the opponent's head, dealing a small amount of damage and crippling them. Type: METALtDCMmv1@@METALatmDCMmv1@@1accDCMmv1@@50hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnynnnnnindENDMmv1@@_!nDCMmv2@@CompressdDCMv2@@Irode uses its metal arms to compress the target, dealing damage. Type: METALtDCMmv2@@METALatmDCMmv2@@1.5accDCMmv2@@40hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Magnetic DefensedDCMv3@@Irode uses magnetic force to attract other metal balls to itself, greatly raising its DEF and dealing damage along the way. Type: METALtDCMmv3@@METALatmDCMmv3@@0.8accDCMmv3@@50hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@20acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@IrosiondDCMv4@@Irode erodes all metal stuck to the opponent, dealing damage to them and poisoning them. Type: METALtDCMmv4@@METALatmDCMmv4@@1.1accDCMmv4@@50hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nynnnnnnnindENDMmv4@@_!nDCMmv5@@Newton's CradledDCMv5@@Newton's Cradle deals massive damage and greatly raises Irode's defense. It also raises Irode's accuracy. Type: METALtDCMmv5@@METALatmDCMmv5@@2.5accDCMmv5@@60hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@20acmDCMmv5@@10dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string splargString = "nX!wj@am!ESplargd@3MDMe#SCSplarg resembles a large, humanoid spark plug. He is capable of dealing deadly damage and inducing many effects.t192y!@:PE22METALh!*##p2@<#1750at1!@!W0k190d%%23eFF100a1;c';c80dj1g><e30imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@IgnitiondDCMv1@@Splarg attacks, dealing a low amount of damage and raising his attack. Type: METALtDCMmv1@@METALatmDCMmv1@@1.2accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@5defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@SwitchdDCMv2@@Splarg attacks with a small amount of power, but both cripples and weakens the opponent. Type: METALtDCMmv2@@METALatmDCMmv2@@0.4accDCMmv2@@50hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnynnnynindENDMmv2@@_!nDCMmv3@@CatalyzedDCMv3@@Splarg catalyzes its own metal parts, dealing deadly damage, raising attack, and stunning the opponent. This attack has a low chance to hit. Type: METALtDCMmv3@@METALatmDCMmv3@@1.75accDCMmv3@@30hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!ynnnnnnnnindENDMmv3@@_!nDCMmv4@@Iron ShatterdDCMv4@@Splarg attacks with the power to shatter metal, but lowers its own attack slightly and takes recoil damage in the process. Type: METALtDCMmv4@@METALatmDCMmv4@@4.5accDCMmv4@@30hDCMmv4@@-10atkDCMmv4@@-5defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Turbo ShiftdDCMv5@@Splarg shits into turbo mode, attacking rapidly, dazing the opponent and slightly raising attack. Type: METALtDCMmv5@@METALatmDCMmv5@@1.25accDCMmv5@@40hDCMmv5@@0atkDCMmv5@@-5defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnyindENDMmv5@@_!";
                //Intelligent
        string docString = "nX!wj@am!EDocd@3MDMe#SCDoc is a human that happens to be very well versed in the topic of combat, and combines that with his knowledge of chemical reactions. He is a well-rounded unit, and is immune to poisons.t192y!@:PE22INTELLIGENTh!*##p2@<#2500at1!@!W0k140d%%23eFF140a1;c';c80dj1g><e50imnSTRT@@_!nynnnnnnnimnEND@@_!nDCMmv1@@ConcoctiondDCMv1@@Doc mixes a chemical reaction of deadly proportions, dealing heavy damage and poisoning the opponent. Type: INTELLIGENTtDCMmv1@@INTELLIGENTatmDCMmv1@@2.25accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nynnnnnnnindENDMmv1@@_!nDCMmv2@@Combat TacticsdDCMv2@@Doc thrusts at the opponent with sharp tools while dodging their return blows, raising his DEF and DGE. Type: INTELLIGENTtDCMmv2@@INTELLIGENTatmDCMmv2@@1.25accDCMmv2@@50hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@10acmDCMmv2@@0dgeDCMmv2@@2indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Scientific BreakthroughdDCMv3@@Doc makes a breakthrough in science. The reaction deals a small amount of damage to the enemy, but Doc raises all of his stats. Type: INTELLIGENTtDCMmv3@@INTELLIGENTatmDCMmv3@@0.75accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@5defDCMmv3@@5acmDCMmv3@@5dgeDCMmv3@@2indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Healing BlowdDCMv4@@Doc creates a chemical capable of dealing damage to the opponent while healing himself. Type: INTELLIGENTtDCMmv4@@INTELLIGENTatmDCMmv4@@1.2accDCMmv4@@60hDCMmv4@@15atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@DoctoratedDCMv5@@Doc's signature move. It deals heavy damage and further raises all of Doc's stats, but only slightly, and deals some slight recoil. Type: INTELLIGENTtDCMmv5@@INTELLIGENTatmDCMmv5@@3.5accDCMmv5@@60hDCMmv5@@-5atkDCMmv5@@5defDCMmv5@@5acmDCMmv5@@2dgeDCMmv5@@1indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string studentString = "nX!wj@am!EStudentd@3MDMe#SCThe Student is an enigma to all; an unknown studier of philosophy, whose learned abilities surpass understanding. He is able to take advantage of his opponents' weaknesses without the use of psychic abilities. The Student is also immune to being stupefied.t192y!@:PE22INTELLIGENTh!*##p2@<#1950at1!@!W0k130d%%23eFF160a1;c';c80dj1g><e40imnSTRT@@_!nnnnnnynnimnEND@@_!nDCMmv1@@PsychoanalysisdDCMv1@@Student analyzes the target's mental state, roots out their weakness, and deals devastating damage, weakening them as well. Type: INTELLIGENTtDCMmv1@@INTELLIGENTatmDCMmv1@@2.25accDCMmv1@@70hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnynindENDMmv1@@_!nDCMmv2@@Complete UnderstandingdDCMv2@@Student makes a philosophical breakthrough, dealing damage to the opponent and slightly raising all of his stats. Type: INTELLIGENTtDCMmv2@@INTELLIGENTatmDCMmv2@@1accDCMmv2@@60hDCMmv2@@0atkDCMmv2@@4defDCMmv2@@8acmDCMmv2@@3dgeDCMmv2@@1indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Mental BreakerdDCMv3@@Student attacks the opponent, inflicting a mental break. The target is stupefied and takes damage. Type: INTELLIGENTtDCMmv3@@INTELLIGENTatmDCMmv3@@1.25accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnynnindENDMmv3@@_!nDCMmv4@@EnigmatusdDCMv4@@Student vanishes out of sight, then reappears dealing a devastating mental blow. Type: INTELLIGENTtDCMmv4@@INTELLIGENTatmDCMmv4@@1.75accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@StudiousdDCMv5@@Student takes time to learn. This attack does damage and greatly raises Student's DEF. Type: INTELLIGENTtDCMmv5@@INTELLIGENTatmDCMmv5@@1.25accDCMmv5@@50hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@18acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Force
        string martisString = "nX!wj@am!EMartisd@3MDMe#SCMartis is one of Earth's most renowned martial arts fighters, and is well rounded in all stats, reflecting her expertise. She is also immune to being weakened.t192y!@:PE22FORCEh!*##p2@<#2100at1!@!W0k165d%%23eFF170a1;c';c90dj1g><e50imnSTRT@@_!nnnnnnnnyimnEND@@_!nDCMmv1@@ParrydDCMv1@@Martis parries an opponents blow, hitting back with crushing force and raising DEF. This attack also cripples the opponent. Type: FORCEtDCMmv1@@FORCEatmDCMmv1@@1.85accDCMmv1@@70hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@13acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Creative CombodDCMv2@@Martis employs her own fighting style, delivering a series of consecutive blows in a never-before-seen combo attack. Type: FORCEtDCMmv2@@FORCEatmDCMmv2@@2.5accDCMmv2@@60hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Brick BreakerdDCMv3@@Martis attacks with the force to break bricks, stunning the opponent. Type: FORCEtDCMmv3@@FORCEatmDCMmv3@@1.25accDCMmv3@@50hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!ynnnnnynnindENDMmv3@@_!nDCMmv4@@ZendDCMv4@@Martis enters her zen, dealing a slight amount of damage and raising all stats, healing herself in the process. Type: PSYCHICtDCMmv4@@PSYCHICatmDCMmv4@@1.85accDCMmv4@@70hDCMmv4@@20atkDCMmv4@@6defDCMmv4@@4acmDCMmv4@@2dgeDCMmv4@@1indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Advanced TacticsdDCMv5@@Martis uses advanced tactics to deal damage to the enemy and raise ATK, with the calculated cost of recoil damage. Type: FORCEtDCMmv5@@FORCEatmDCMmv5@@2.75accDCMmv5@@40hDCMmv5@@-20atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string discriniusString = "nX!wj@am!EDiscriniusd@3MDMe#SCDiscrinius has long studied the essence of defensive strategies and endurance. While he lacks experience in the attacking field, he is able to minimize the damage he takes, and his attacks increase his ability to do so. With his experience comes immunity to stuns, cripples, stupefications, weakening and dizzying.t192y!@:PE22FORCEh!*##p2@<#3275at1!@!W0k65d%%23eFF450a1;c';c60dj1g><e25imnSTRT@@_!ynnynnnyyimnEND@@_!nDCMmv1@@EnduredDCMv1@@Discrinius lashes out, then prepares for the return attack, raising DEF. Type: FORCEtDCMmv1@@FORCEatmDCMmv1@@1.15accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@12acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@HardeningdDCMv2@@Discrinius hardens his body, dealing physical damage and better preparing for receiving blows, raising ATK and DEF. Type: FORCEtDCMmv2@@FORCEatmDCMmv2@@1accDCMmv2@@50hDCMmv2@@0atkDCMmv2@@5defDCMmv2@@8acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Disciple's DecisiondDCMv3@@Discrinius deals damage, harms himself in the process, but in doing so better prepares for the future, raising DEF. Type: FORCEtDCMmv3@@FORCEatmDCMmv3@@0.95accDCMmv3@@50hDCMmv3@@-10atkDCMmv3@@0defDCMmv3@@13acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Calculated RiskdDCMv4@@Discrinius calculates the damage he will take, inflicts damage in response, and raises DEF slightly. Type: INTELLIGENTtDCMmv4@@INTELLIGENTatmDCMmv4@@1.15accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@6acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Stance ResetdDCMv5@@Discrinius resets his stance, looking at the target head on, and raising his DEF. Type: FORCEtDCMmv5@@FORCEatmDCMmv5@@1accDCMmv5@@50hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@9acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Ice
        string cicleString = "nX!wj@am!ECicled@3MDMe#SCJust a cold icicle. Can't be frozen, because it already is.t192y!@:PE22ICEh!*##p2@<#1200at1!@!W0k230d%%23eFF95a1;c';c90dj1g><e50imnSTRT@@_!nnnnynnnnimnEND@@_!nDCMmv1@@Sharp DropdDCMv1@@Cicle drops on someone's head, causing bleeding. Type: ICEtDCMmv1@@ICEatmDCMmv1@@1.5accDCMmv1@@50hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnynnnindENDMmv1@@_!nDCMmv2@@Freezing TouchdDCMv2@@Cicle is cold to the touch, and damages the target just by brushing up against it. Type: ICEtDCMmv2@@ICEatmDCMmv2@@1.4accDCMmv2@@65hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@HailstormdDCMv3@@Somehow the icicle brings about a hailstorm. Intriguing. It freezes the target. Type: ICEtDCMmv3@@ICEatmDCMmv3@@2accDCMmv3@@55hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnynnnnindENDMmv3@@_!nDCMmv4@@Ice ChaindDCMv4@@The falling Cicle triggers a chain reaction of other icicles falling on the opponent, dealing higher damage and inflicting bleeding, but also recoil. Type: ICEtDCMmv4@@ICEatmDCMmv4@@2.25accDCMmv4@@50hDCMmv4@@-15atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnynnnindENDMmv4@@_!nDCMmv5@@Ice SplitdDCMv5@@Cicle splits into thousands of pieces, crystallizing around and freezing the opponent. Type: ICEtDCMmv5@@ICEatmDCMmv5@@1accDCMmv5@@60hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnynnnnindENDMmv5@@_!";
        string blizerdString = "nX!wj@am!EBlizerdd@3MDMe#SCA cross between a lizard and a block of ice, Blizerd is immune to both poison and freezing.t192y!@:PE22ICEh!*##p2@<#1825at1!@!W0k160d%%23eFF155a1;c';c70dj1g><e30imnSTRT@@_!nynnynnnnimnEND@@_!nDCMmv1@@Icy BitedDCMv1@@Blizerd bites the opponent with freezing teeth, freezing the enemy. Type: ICEtDCMmv1@@ICEatmDCMmv1@@1.75accDCMmv1@@50hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnynnnnindENDMmv1@@_!nDCMmv2@@Venom DrenchdDCMv2@@Blizerd drenches the opponent in its cold venom. This posions the target. Type: MORTALtDCMmv2@@MORTALatmDCMmv2@@2accDCMmv2@@40hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nynnnnnnnindENDMmv2@@_!nDCMmv3@@ScurrydDCMv3@@Blizerd quickly attacks, then drops back, slightly raising his DGE. Type: NONEtDCMmv3@@NONEatmDCMmv3@@0.75accDCMmv3@@70hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@2indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Ice ThrashdDCMv4@@Blizerd attacks the opponent with deadly ice shards. Type: ICEtDCMmv4@@ICEatmDCMmv4@@2.1accDCMmv4@@50hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Ice AdaptationdDCMv5@@Blizerd adapts to its environment. This move deals damage and raises ATK and DEF. Type: ICEtDCMmv5@@ICEatmDCMmv5@@2accDCMmv5@@50hDCMmv5@@0atkDCMmv5@@15defDCMmv5@@15acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Fire
        string solcoreString = "nX!wj@am!ESolcored@3MDMe#SCThe core of the sun, but still a glass cannon.t192y!@:PE22FIREh!*##p2@<#3000at1!@!W0k280d%%23eFF50a1;c';c70dj1g><e20imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Light EmanationdDCMv1@@Solcore emanates a vast amount of light, dazing the enemy and raising ATK. Type: FIREtDCMmv1@@FIREatmDCMmv1@@0.95accDCMmv1@@50hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnyindENDMmv1@@_!nDCMmv2@@Solar FlaredDCMv2@@A concentrated, pinpoint attack that deals devastating damage and burns the enemy, but is difficult to hit. Type: FIREtDCMmv2@@FIREatmDCMmv2@@2.1accDCMmv2@@35hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnynnnnnnindENDMmv2@@_!nDCMmv3@@Solar StormdDCMv3@@Similar to Light Emanation, this attack surrounds the opponent and dazes them. It deals more damage than Light Emanation but has less accuracy than it. Type: FIREtDCMmv3@@FIREatmDCMmv3@@1.25accDCMmv3@@40hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnyindENDMmv3@@_!nDCMmv4@@Fiery EngulfdDCMv4@@Solcore engulfs the enemy in a fiery blaze. This attack causes recoil damage, but has a high accuracy. Type: FIREtDCMmv4@@FIREatmDCMmv4@@0.95accDCMmv4@@50hDCMmv4@@-25atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@SupernovadDCMv5@@The ultimate sun attack. It also inflicts burns. Type: FIREtDCMmv5@@FIREatmDCMmv5@@2.75accDCMmv5@@25hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnynnnnnnindENDMmv5@@_!";
        string pyrocitusString = "nX!wj@am!EPyrocitusd@3MDMe#SCPyrocitus deals out the fire damage in small amounts, but has a high DEF and is immune to burns due to his armor.t192y!@:PE22FIREh!*##p2@<#3250at1!@!W0k105d%%23eFF275a1;c';c70dj1g><e40imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@FlamethrowerdDCMv1@@Pyrocitus uses his flamethrower to set fire to all surroundings, inflicting burns. This attack has very high accuracy. Type: FIREtDCMmv1@@FIREatmDCMmv1@@1.25accDCMmv1@@100hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnynnnnnnindENDMmv1@@_!nDCMmv2@@Armor MeltdDCMv2@@Pyrocitus devastates the opponent's armor, effectively raising his ATK. Type: FIREtDCMmv2@@FIREatmDCMmv2@@1accDCMmv2@@60hDCMmv2@@0atkDCMmv2@@15defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Armor FusiondDCMv3@@Pyrocitus welds on more armor, dealing slight damage and raising DEF. Type: FIREtDCMmv3@@FIREatmDCMmv3@@0.85accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@15acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@PyromaniadDCMv4@@A deadly fire attack that also burns. Type: FIREtDCMmv4@@FIREatmDCMmv4@@2accDCMmv4@@50hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnynnnnnnindENDMmv4@@_!nDCMmv5@@Fire AuradDCMv5@@Pyrocitus spreads fire around him, dealing small damage and greatly raising DEF. Type: FIREtDCMmv5@@FIREatmDCMmv5@@0.5accDCMmv5@@60hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@30acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Natural
        string lyfebudString = "nX!wj@am!ELyfebudd@3MDMe#SCLyfebud always sticks to its opponent, and constantly leeches its life. It is also very small and has a very high chance to dodge.t192y!@:PE22NATURALh!*##p2@<#1650at1!@!W0k150d%%23eFF150a1;c';c60dj1g><e70imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@BarnclitedDCMv1@@Lyfebud attaches to the target like a barnacle, dealing small damage but stealing life. Type: NATURALtDCMmv1@@NATURALatmDCMmv1@@0.95accDCMmv1@@60hDCMmv1@@50atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@SporedDCMv2@@Lyfebud attackes spores to the target, and grows on them, raising DEF and healing. Type: NATURALtDCMmv2@@NATURALatmDCMmv2@@1.25accDCMmv2@@50hDCMmv2@@65atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Nutrition StealdDCMv3@@Lyfebud steals the opponent's nutrients, healing itself and weakening the opponent. Type: NATURALtDCMmv3@@NATURALatmDCMmv3@@0.8accDCMmv3@@60hDCMmv3@@85atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnynindENDMmv3@@_!nDCMmv4@@Rapid PlantdDCMv4@@Lyfebud rapidly multiplies, raising HP. Type: NATURALtDCMmv4@@NATURALatmDCMmv4@@0.95accDCMmv4@@60hDCMmv4@@40atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@RejuvenationdDCMv5@@Lyfebud deals a small amount of damage, but heals a great amount. Type: NATURALtDCMmv5@@NATURALatmDCMmv5@@0.5accDCMmv5@@55hDCMmv5@@95atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string elementusString = "nX!wj@am!EElementusd@3MDMe#SCThe combination of every natural element, Elementus has great versatility, is able to inflict many different status effects, and has moves that raise all stats. Elementus is also immune to bleeding.t192y!@:PE22NATURALh!*##p2@<#3125at1!@!W0k180d%%23eFF180a1;c';c65dj1g><e40imnSTRT@@_!nnnnnnynnimnEND@@_!nDCMmv1@@Metal AttackdDCMv1@@Elementus harnesses the power of the elemental metals, dealing damage, raising DEF, and crippling the opponent. Type: METALtDCMmv1@@METALatmDCMmv1@@1.5accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@21acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnynnnnnindENDMmv1@@_!nDCMmv2@@Halogen AttackdDCMv2@@Elementus attacks with the power of the highly reactive halogens, raising ATK, healing itself, and stupefying the opponent. Type: NATURALtDCMmv2@@NATURALatmDCMmv2@@1.9accDCMmv2@@50hDCMmv2@@44atkDCMmv2@@21defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnynnindENDMmv2@@_!nDCMmv3@@Noble Gas AttackdDCMv3@@Elementus attacks with the power of the stable noble gases, dealing damage and raising ACC. Type: NATURALtDCMmv3@@NATURALatmDCMmv3@@1.25accDCMmv3@@65hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@9dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Actinide AttackdDCMv4@@Elementus attacks with the power of the radioactive actinides, dealing small damage, raising ATK and DGE, and poisoning the opponent. Type: MORTALtDCMmv4@@MORTALatmDCMmv4@@1.5accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@21defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@3indSTRTMmv4@@_!nynnnnnnnindENDMmv4@@_!nDCMmv5@@Lanthanide AttackdDCMv5@@Elementus attacks with the power of the rare earth Lanthanides, dealing massive damage and dazing the opponent. Type: EARTHLYtDCMmv5@@EARTHLYatmDCMmv5@@2.5accDCMmv5@@50hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnyindENDMmv5@@_!";
                //Psychic
        string forseerString = "nX!wj@am!EForseerd@3MDMe#SCThe Forseer has low HP and low DEF, but is capable of seeing into the future and dodging attacks. The dodge takes some time to stack, however.t192y!@:PE22PSYCHICh!*##p2@<#1250at1!@!W0k95d%%23eFF95a1;c';c75dj1g><e40imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Foresight SupportdDCMv1@@Forseer adds slightly to his DGE value with foresight support, and deals damage. Type: PSYCHICtDCMmv1@@PSYCHICatmDCMmv1@@1accDCMmv1@@55hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@3indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Full ForesightdDCMv2@@Forseer deals a small amount of damage but greatly raises DGE. Type: PSYCHICtDCMmv2@@PSYCHICatmDCMmv2@@0.75accDCMmv2@@55hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@8indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Psychic BreakerdDCMv3@@Forseer attacks with a psychic break, dealing damage and weakening the opponent. Type: PSYCHICtDCMmv3@@PSYCHICatmDCMmv3@@1.55accDCMmv3@@55hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnynindENDMmv3@@_!nDCMmv4@@Mind ReaddDCMv4@@Forseer reads the opponent's mind, does damage, and slightly raises DGE. Type: PSYCHICtDCMmv4@@PSYCHICatmDCMmv4@@1.15accDCMmv4@@55hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@6indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Crystal BalldDCMv5@@Forseer looks into the future with a crystal ball, dealing barely any damage but greatly raising DGE. Type: PSYCHICtDCMmv5@@PSYCHICatmDCMmv5@@0.5accDCMmv5@@55hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@12indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string zodiumString = "nX!wj@am!EZodiumd@3MDMe#SCZodium is perhaps the defensive king, and each of his attacks incorporates a psychic aspect that either strengthens is physical or mental defenses.t192y!@:PE22PSYCHICh!*##p2@<#3750at1!@!W0k95d%%23eFF585a1;c';c65dj1g><e35imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Special DefensedDCMv1@@Zodium deals a small amount of damage, but greatly raises mental and physical DEF. Type: PSYCHICtDCMmv1@@PSYCHICatmDCMmv1@@0.95accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@20acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Psychic MeditationdDCMv2@@Zodium meditates, dealing mental damage and raising DEF. Type: PSYCHICtDCMmv2@@PSYCHICatmDCMmv2@@1.1accDCMmv2@@75hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@23acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@MindwalldDCMv3@@Zodium employs a mind wall, dealing damage to enemies that attack the wall and raising DEF. Type: PSYCHICtDCMmv3@@PSYCHICatmDCMmv3@@1accDCMmv3@@70hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@22acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Physical WalldDCMv4@@Zodium creates a physical wall, dealing damage to enemies that attack it and raising DEF. Type: PSYCHICtDCMmv4@@PSYCHICatmDCMmv4@@0.95accDCMmv4@@60hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@22acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Mind SupremedDCMv5@@The supreme psychic mind. Greatly raises DEF, deals massive damage, but has low ACC. Type: PSYCHICtDCMmv5@@PSYCHICatmDCMmv5@@2accDCMmv5@@50hDCMmv5@@0atkDCMmv5@@0defDCMmv5@@33acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
                //Mortal - may be changed to mortus/dark/death/etc. in future
        string humanusString = "nX!wj@am!EHumanusd@3MDMe#SCHumanus is a humanoid whose only job is to end the homo sapiens race.t192y!@:PE22MORTALh!*##p2@<#1780at1!@!W0k185d%%23eFF110a1;c';c70dj1g><e35imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@MortalitydDCMv1@@Humanus causes the target to face their own mortality, dealing massive damage. Type: MORTALtDCMmv1@@MORTALatmDCMmv1@@2accDCMmv1@@60hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@The GatedDCMv2@@Humanus gates off the opponent with deadly barbed wires, raising his own defense as well. Type: MORTALtDCMmv2@@MORTALatmDCMmv2@@1accDCMmv2@@65hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@20acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@SufferingdDCMv3@@Humanus induces a state of suffering in his targets, weakening them. Type: MORTALtDCMmv3@@MORTALatmDCMmv3@@1.15accDCMmv3@@60hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnynindENDMmv3@@_!nDCMmv4@@EternitydDCMv4@@Humanus torments the target for eternity, dealing deadly damage but causing minor recoil. Type: MORTALtDCMmv4@@MORTALatmDCMmv4@@2accDCMmv4@@60hDCMmv4@@-5atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@PermadeathdDCMv5@@Humanus puts the opponent in a state of permadeath, dealing massive damage, crippling them, but causing slight recoil Type: MORTALtDCMmv5@@MORTALatmDCMmv5@@3accDCMmv5@@55hDCMmv5@@-5atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnynnnnnindENDMmv5@@_!";
        string thedemonString = "nX!wj@am!EThe Demond@3MDMe#SCThe fiery demon from the darkest, fiery pits, versatile in its use of mortal and fire type attacks. It is also immune to burns.t192y!@:PE22MORTALh!*##p2@<#2350at1!@!W0k175d%%23eFF160a1;c';c75dj1g><e35imnSTRT@@_!nnynnnnnnimnEND@@_!nDCMmv1@@SindDCMv1@@The embodiment of mortal sin. Type: MORTALtDCMmv1@@MORTALatmDCMmv1@@1.5accDCMmv1@@45hDCMmv1@@0atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Fiery RagedDCMv2@@The Demon goes into a fit of fiery rage, burning the opponent. Type: FIREtDCMmv2@@FIREatmDCMmv2@@0.9accDCMmv2@@45hDCMmv2@@0atkDCMmv2@@0defDCMmv2@@0acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnynnnnnnindENDMmv2@@_!nDCMmv3@@Eternal FlamedDCMv3@@The flames of eternity deal high damage to the target. Type: FIREtDCMmv3@@FIREatmDCMmv3@@2.5accDCMmv3@@35hDCMmv3@@0atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@0dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Pit of DeathdDCMv4@@The target falls into the endless pit of death, taking damage and becoming weakened. Type: MORTALtDCMmv4@@MORTALatmDCMmv4@@1.5accDCMmv4@@45hDCMmv4@@0atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@0indSTRTMmv4@@_!nnnnnnnynindENDMmv4@@_!nDCMmv5@@The 9th RingdDCMv5@@The ultimate devastating attack. Burns and weakens the opponent along with doing devastating damage, but has very low accuracy and causes some recoil. Type: MORTALtDCMmv5@@MORTALatmDCMmv5@@5.5accDCMmv5@@5hDCMmv5@@-35atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnynnnnynindENDMmv5@@_!";
                //Ghost
        string spirtuString = "nX!wj@am!ESpirtud@3MDMe#SCThe good spirit, with high rejuvenating capabilities.t192y!@:PE22GHOSTh!*##p2@<#2450at1!@!W0k150d%%23eFF140a1;c';c65dj1g><e35imnSTRT@@_!nnnnnnnnnimnEND@@_!nDCMmv1@@Souls of DamagedDCMv1@@Spirtu causes upon the souls of damage, raising ATK and dealing damage. Spirtu also heals himself a little. Type: GHOSTtDCMmv1@@GHOSTatmDCMmv1@@1accDCMmv1@@65hDCMmv1@@15atkDCMmv1@@20defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnnnnnnnindENDMmv1@@_!nDCMmv2@@Souls of DefensedDCMv2@@Spirtu calls upon the Souls of Defense, dealing damage, raising DEF, and healing himself a little. Type: GHOSTtDCMmv2@@GHOSTatmDCMmv2@@1accDCMmv2@@65hDCMmv2@@15atkDCMmv2@@0defDCMmv2@@20acmDCMmv2@@0dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnnnindENDMmv2@@_!nDCMmv3@@Souls of AccuracydDCMv3@@Spitru calls upon the Souls of Accuracy, raising ACC, dealing damage, and healing himself a little. Type: GHOSTtDCMmv3@@GHOSTatmDCMmv3@@1accDCMmv3@@65hDCMmv3@@15atkDCMmv3@@0defDCMmv3@@0acmDCMmv3@@5dgeDCMmv3@@0indSTRTMmv3@@_!nnnnnnnnnindENDMmv3@@_!nDCMmv4@@Souls of DexteritydDCMv4@@Spirtu calls upon the Souls of Dexterity, dealing damage, raising DGE, and healing himself a little. Type: GHOSTtDCMmv4@@GHOSTatmDCMmv4@@1accDCMmv4@@65hDCMmv4@@15atkDCMmv4@@0defDCMmv4@@0acmDCMmv4@@0dgeDCMmv4@@2indSTRTMmv4@@_!nnnnnnnnnindENDMmv4@@_!nDCMmv5@@Souls of HealingdDCMv5@@Spirtu calls upon the Souls of Healing, dealing damage and greatly healing himself. Type: GHOSTtDCMmv5@@GHOSTatmDCMmv5@@1accDCMmv5@@65hDCMmv5@@150atkDCMmv5@@0defDCMmv5@@0acmDCMmv5@@0dgeDCMmv5@@0indSTRTMmv5@@_!nnnnnnnnnindENDMmv5@@_!";
        string duskanString = "nX!wj@am!EDuskand@3MDMe#SCThe ghostly spirit Duskan materializes itself in strange, amalgamous ways. Its properties are unknown.t192y!@:PE22GHOSTh!*##p2@<#1900at1!@!W0k200d%%23eFF200a1;c';c100dj1g><e50imnSTRT@@_!yyyyyyyyyimnEND@@_!nDCMmv1@@??????dDCMv1@@??????tDCMmv1@@GHOSTatmDCMmv1@@1accDCMmv1@@50hDCMmv1@@55atkDCMmv1@@0defDCMmv1@@0acmDCMmv1@@0dgeDCMmv1@@0indSTRTMmv1@@_!nnnynnnnnindENDMmv1@@_!nDCMmv2@@??????dDCMv2@@??????tDCMmv2@@GHOSTatmDCMmv2@@0.5accDCMmv2@@50hDCMmv2@@25atkDCMmv2@@5defDCMmv2@@5acmDCMmv2@@2dgeDCMmv2@@0indSTRTMmv2@@_!nnnnnnnynindENDMmv2@@_!nDCMmv3@@??????dDCMv3@@??????tDCMmv3@@GHOSTatmDCMmv3@@1.3accDCMmv3@@50hDCMmv3@@10atkDCMmv3@@5defDCMmv3@@5acmDCMmv3@@5dgeDCMmv3@@1indSTRTMmv3@@_!nnnnnnnnyindENDMmv3@@_!nDCMmv4@@??????dDCMv4@@??????tDCMmv4@@GHOSTatmDCMmv4@@1accDCMmv4@@50hDCMmv4@@5atkDCMmv4@@12defDCMmv4@@2acmDCMmv4@@2dgeDCMmv4@@2indSTRTMmv4@@_!nnnnnnynnindENDMmv4@@_!nDCMmv5@@??????dDCMv5@@??????tDCMmv5@@GHOSTatmDCMmv5@@4.5accDCMmv5@@20hDCMmv5@@-15atkDCMmv5@@5defDCMmv5@@5acmDCMmv5@@5dgeDCMmv5@@2indSTRTMmv5@@_!ynnnnnnnnindENDMmv5@@_!";

        //For use in-EvE-simulation:
        private Character player1;
        private Character player2;
        private int player1EvEMaxHP;
        private int player2EvEMaxHP;
        private int player1OrigHPEve;
        private int player2OrigHPEve;
        private float atkStatModValPsn = 1f;
        private float atkStatModValWk = 1f;
        private float effectivenessModVal = 1f;
        //Possibly deprecated
        int lastP1Move = 0;
        int lastP2Move = 0;

        public DCTBFightingSimulator()
        {
            InitializeComponent();
            disableAllElementalUI();
            startingPanel.Enabled = true;
            startingPanel.BringToFront();
            startingPanel.Show();
            //Fill in Changelog and Roadmap
            fillChangelog();
            fillRoadmap();
            //Initialize Tooltips
            initTooltips();
        }
        
        //Changelog and Roadmap
        public void fillChangelog()
        {
            //Current version: 0.2.0 (this), 0.1.1 (old)
            changelogText.Text = "";
            changelogText.AppendText("VERSON: 0.2.0");
            changelogText.AppendText(Environment.NewLine + "Version 0.2.0 Release (#3) of DCTBFightingSimulator!" + Environment.NewLine);
            changelogText.AppendText(Environment.NewLine + Environment.NewLine + "v0.2.0 Changelog:");
            changelogText.AppendText(Environment.NewLine + "Important update is here! New tooltips for clarity when creating a character, along with two new NONE-type characters and source code formatting changes.");
            changelogText.AppendText(Environment.NewLine + "ADDITIONS:");
            changelogText.AppendText(Environment.NewLine + "- Added tooltips for the main menu buttons");
            changelogText.AppendText(Environment.NewLine + "- Added tooltips to the character creation screen with more information on various components. Note: 'Meta Values' refers to a common range of values present in most vanilla characters. Not all vanilla characters follow this meta, and user-created builds do not have to either; this is just for balancing reference if desired.");
            changelogText.AppendText(Environment.NewLine + "- Two new NONE-type characters, Duncan and Firia");
            changelogText.AppendText(Environment.NewLine + "CHANGES:");
            changelogText.AppendText(Environment.NewLine + "- Fixed a typo on export instructions");
            changelogText.AppendText(Environment.NewLine + "- Formatting edits to the source code for clarity and conciseness");
            changelogText.AppendText(Environment.NewLine + "BALANCING:");
            changelogText.AppendText(Environment.NewLine + "- No balance changes this update.");
            //Post-Changes
            changelogText.AppendText(Environment.NewLine + Environment.NewLine + "This is only an initial release with baseline simulations working; expect PvE and local PvP features to come soon (see the roadmap for details) Please bring up any issues, questions, user-submitted builds, etc. on the github page.");
            changelogText.AppendText(Environment.NewLine + "Additionally, every time there is an update involving additional characters, new AI, or new gameplay features, an official tournament will be run. The link to view tournament results of the simulation between all characters will be found here. Custom-created, user-submitted builds will also be a part of the competition.");
            changelogText.AppendText(Environment.NewLine + Environment.NewLine + "View the most recent tournament (which may eventually be moved onto this program itself): https://challonge.com/ozrjzhgm");
            changelogText.AppendText(Environment.NewLine + "Tournament Archives:");
            changelogText.AppendText(Environment.NewLine + "Before version 0.2.0: https://challonge.com/bz19xyip");
        }
        public void fillRoadmap()
        {
            roadmapText.Text = "";
            roadmapText.AppendText("Roadmap:");
            roadmapText.AppendText(Environment.NewLine + Environment.NewLine + "Overarching Additions:");
            roadmapText.AppendText(Environment.NewLine + "- An installer (no more bypassing all system security)");
            roadmapText.AppendText(Environment.NewLine + "- PvE functionality");
            roadmapText.AppendText(Environment.NewLine + "- PvP functionality");
            roadmapText.AppendText(Environment.NewLine + "- New Computer AIs");
            roadmapText.AppendText(Environment.NewLine + "- Move strings and move databases; import pre-existing moves, export your moves to strings, etc.");
            roadmapText.AppendText(Environment.NewLine + "- New characters and other features");
            roadmapText.AppendText(Environment.NewLine + Environment.NewLine + "Additions (in no particular order):");
            roadmapText.AppendText(Environment.NewLine + "- Increased character creation user-friendliness");
            roadmapText.AppendText(Environment.NewLine + "- Simplistic taskbar icon");
            roadmapText.AppendText(Environment.NewLine + "- Healthbars");
            roadmapText.AppendText(Environment.NewLine + "- Update EvE UI to show more stats/info at once");
            roadmapText.AppendText(Environment.NewLine + "- Update EvE to allow multiple game speeds/exiting/resets during play");
            roadmapText.AppendText(Environment.NewLine + "- Update information displayed when attacking (i.e. mentioning the specific attack, more specific details on effects, etc.");
            roadmapText.AppendText(Environment.NewLine + "- Incorporating any user-submitted builds (recurring)");
            roadmapText.AppendText(Environment.NewLine + "- Balancing changes (recurring)");
            roadmapText.AppendText(Environment.NewLine + Environment.NewLine + "Other/Random Additions:");
            roadmapText.AppendText(Environment.NewLine + "- Streamlining load times");
            roadmapText.AppendText(Environment.NewLine + "- Consolidating code / simplifying other events");
            roadmapText.AppendText(Environment.NewLine + Environment.NewLine + "User-submitted builds will be implemented in the very next release after submission, and will show up in the tournament.");
        }
        //Tooltips
        public void initTooltips()
        {
            //Overarching Button tooltips
            ToolTip TT_mainButtons = new ToolTip();
            TT_mainButtons.AutoPopDelay = 5000;
            TT_mainButtons.InitialDelay = 1000;
            TT_mainButtons.ReshowDelay = 500;
            TT_mainButtons.SetToolTip(this.simulateEveButton, "AI vs. AI battle simulator.");
            TT_mainButtons.SetToolTip(this.pveButton, "Player vs. AI battle simulator.");
            TT_mainButtons.SetToolTip(this.pvpButton, "Local (same computer) Player vs. Player battle simulator.");
            TT_mainButtons.SetToolTip(this.createCharButton, "Character editor.");
            TT_mainButtons.SetToolTip(this.charDatabaseButton, "Database of current characters.");

            //Character Creation tooltips
            ToolTip TT_CC = new ToolTip();
            TT_CC.AutoPopDelay = 5000;
            TT_CC.InitialDelay = 1000;
            TT_CC.ReshowDelay = 500;
                //Column 1
            TT_CC.SetToolTip(this.CCT1, "Name of the character.");
            TT_CC.SetToolTip(this.CCT2, "Brief description of the character. Usually, the type and any immunities are described here as well.");
            TT_CC.SetToolTip(this.CCc1, "The character's type. This list is in order of effectiveness; the previous is effective on the next, and weak to the one before it.");
            TT_CC.SetToolTip(this.CCN40, "The character's HP. Meta values: 1000 - 5000.");
            TT_CC.SetToolTip(this.CCN1, "The character's ATK. Meta values: 50 - 250.");
            TT_CC.SetToolTip(this.CCN2, "The character's DEF. Meta values: 50 - 400.");
            TT_CC.SetToolTip(this.CCN3, "The character's ACC. Meta values: 50 - 120.");
            TT_CC.SetToolTip(this.CCN4, "The character's DGE. Meta values: 0 - 60.");
            TT_CC.SetToolTip(this.exportCharStringButton, "Export the string relating to the current values in the character creation board.");
            TT_CC.SetToolTip(this.loadBuildButton, "Load a build from the string in the text box.");
                //Moves (Universal tooltips across all moves)
            TT_CC.SetToolTip(this.CCT3, "Name of this move.");
            TT_CC.SetToolTip(this.CCT5, "Name of this move.");
            TT_CC.SetToolTip(this.CCT7, "Name of this move.");
            TT_CC.SetToolTip(this.CCT9, "Name of this move.");
            TT_CC.SetToolTip(this.CCT11, "Name of this move.");
            TT_CC.SetToolTip(this.CCT4, "Brief description of the move. Usually, effects of the move are also described.");
            TT_CC.SetToolTip(this.CCT6, "Brief description of the move. Usually, effects of the move are also described.");
            TT_CC.SetToolTip(this.CCT8, "Brief description of the move. Usually, effects of the move are also described.");
            TT_CC.SetToolTip(this.CCT10, "Brief description of the move. Usually, effects of the move are also described.");
            TT_CC.SetToolTip(this.CCT12, "Brief description of the move. Usually, effects of the move are also described.");
            TT_CC.SetToolTip(this.CCc11, "This move's type. Can be different from the character's type.");
            TT_CC.SetToolTip(this.CCc21, "This move's type. Can be different from the character's type.");
            TT_CC.SetToolTip(this.CCc31, "This move's type. Can be different from the character's type.");
            TT_CC.SetToolTip(this.CCc41, "This move's type. Can be different from the character's type.");
            TT_CC.SetToolTip(this.CCc51, "This move's type. Can be different from the character's type.");
            TT_CC.SetToolTip(this.CCN5, "The attack multiplier for this move (what ATK is multiplied by). Meta values: 0.5 - 5.");
            TT_CC.SetToolTip(this.CCN12, "The attack multiplier for this move (what ATK is multiplied by). Meta values: 0.5 - 5.");
            TT_CC.SetToolTip(this.CCN19, "The attack multiplier for this move (what ATK is multiplied by). Meta values: 0.5 - 5.");
            TT_CC.SetToolTip(this.CCN26, "The attack multiplier for this move (what ATK is multiplied by). Meta values: 0.5 - 5.");
            TT_CC.SetToolTip(this.CCN33, "The attack multiplier for this move (what ATK is multiplied by). Meta values: 0.5 - 5.");
            TT_CC.SetToolTip(this.CCN6, "The accuracy of this move. Meta values: 20 - 80.");
            TT_CC.SetToolTip(this.CCN13, "The accuracy of this move. Meta values: 20 - 80.");
            TT_CC.SetToolTip(this.CCN20, "The accuracy of this move. Meta values: 20 - 80.");
            TT_CC.SetToolTip(this.CCN27, "The accuracy of this move. Meta values: 20 - 80.");
            TT_CC.SetToolTip(this.CCN34, "The accuracy of this move. Meta values: 20 - 80.");
            TT_CC.SetToolTip(this.CCN7, "How much this move heals the character. Negative for self-damage. Meta values: -50 - 50.");
            TT_CC.SetToolTip(this.CCN14, "How much this move heals the character. Negative for self-damage. Meta values: -50 - 50.");
            TT_CC.SetToolTip(this.CCN21, "How much this move heals the character. Negative for self-damage. Meta values: -50 - 50.");
            TT_CC.SetToolTip(this.CCN28, "How much this move heals the character. Negative for self-damage. Meta values: -50 - 50.");
            TT_CC.SetToolTip(this.CCN35, "How much this move heals the character. Negative for self-damage. Meta values: -50 - 50.");
            TT_CC.SetToolTip(this.CCN8, "How much this changes the character's base ATK value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN15, "How much this changes the character's base ATK value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN22, "How much this changes the character's base ATK value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN29, "How much this changes the character's base ATK value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN36, "How much this changes the character's base ATK value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN9, "How much this changes the character's base DEF value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN16, "How much this changes the character's base DEF value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN23, "How much this changes the character's base DEF value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN30, "How much this changes the character's base DEF value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN37, "How much this changes the character's base DEF value by. Meta values: -5 - 20.");
            TT_CC.SetToolTip(this.CCN10, "How much this changes the character's base ACC value by. Meta values: -2 - 5.");
            TT_CC.SetToolTip(this.CCN17, "How much this changes the character's base ACC value by. Meta values: -2 - 5.");
            TT_CC.SetToolTip(this.CCN24, "How much this changes the character's base ACC value by. Meta values: -2 - 5.");
            TT_CC.SetToolTip(this.CCN31, "How much this changes the character's base ACC value by. Meta values: -2 - 5.");
            TT_CC.SetToolTip(this.CCN38, "How much this changes the character's base ACC value by. Meta values: -2 - 5.");
            TT_CC.SetToolTip(this.CCN11, "How much this changes the character's base DGE value by. Meta values: -2 - 3.");
            TT_CC.SetToolTip(this.CCN18, "How much this changes the character's base DGE value by. Meta values: -2 - 3.");
            TT_CC.SetToolTip(this.CCN25, "How much this changes the character's base DGE value by. Meta values: -2 - 3.");
            TT_CC.SetToolTip(this.CCN32, "How much this changes the character's base DGE value by. Meta values: -2 - 3.");
            TT_CC.SetToolTip(this.CCN39, "How much this changes the character's base DGE value by. Meta values: -2 - 3.");
        }

        //Button methods
        private void button1_Click(object sender, EventArgs e)
        {
            disableAllElementalUI();
            startingPanel.Enabled = true;
            startingPanel.BringToFront();
            startingPanel.Show();
            fillChangelog();
            fillRoadmap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/CJ5-Z/DCTBFightingSimulator");
        }

        //Elemental UI methods
        public void disableAllElementalUI()
        {
            //Welcome
            startingPanel.SendToBack();
            startingPanel.Hide();
            startingPanel.Enabled = false;
            //EvE
            hideEvEUI();
            //Character Creation
            hideAllCharacterCreation();
            //Character Database
            hideCharDatabaseUI();
        }
        public void disableAllButtons()
        {
            EvEStartButton.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            simulateEveButton.Enabled = false;
            pveButton.Enabled = false;
            pvpButton.Enabled = false;
            createCharButton.Enabled = false;
            charDatabaseButton.Enabled = false;
        }
        public void enableAllButtons()
        {
            EvEStartButton.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            simulateEveButton.Enabled = true;
            pveButton.Enabled = true;
            pvpButton.Enabled = true;
            createCharButton.Enabled = true;
            charDatabaseButton.Enabled = true;
        }
        public void hideAllCharacterCreation()
        {
            panel1.SendToBack();
            panel1.Hide();
            panel1.Enabled = false;
        }
        public void enableCharButtonElementalUI()
        {
            disableAllElementalUI();
            panel1.Enabled = true;
            panel1.BringToFront();
            panel1.Show();
        }
        public void enableCharDatabaseUI()
        {
            disableAllElementalUI();
            characterDatabasePanel.Enabled = true;
            characterDatabasePanel.BringToFront();
            characterDatabasePanel.Show();
        }
        public void hideCharDatabaseUI()
        {
            characterDatabasePanel.SendToBack();
            characterDatabasePanel.Hide();
            characterDatabasePanel.Enabled = false;
        }
        public void enableEvEUI()
        {
            disableAllElementalUI();
            EvEPanel.Enabled = true;
            EvEPanel.BringToFront();
            EvEPanel.Show();
        }
        public void hideEvEUI()
        {
            EvEPanel.SendToBack();
            EvEPanel.Hide();
            EvEPanel.Enabled = false;
        }

        //EvE Methods
        private void simulateEveButton_Click(object sender, EventArgs e)
        {
            enableEvEUI();
        }
        private void EvEStartButton_Click(object sender, EventArgs e)
        {
            //Perform checks - player 1
            if(player1SelectionEvE.Text == "" && player1ImportEvE.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Invalid: Character not selected for either player 1, player 2, or both.");
                return;
            }
            if (player2SelectionEvE.Text == "" && player2ImportEvE.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Invalid: Character not selected for either player 1, player 2, or both.");
                return;
            }
            if (player1SelectionEvE.Text == "")
            {
                if(checkImportString(player1ImportEvE.Text) != false)
                {
                    //Perform player 1 Imports based on the import string
                    player1ImportStringImports(player1ImportEvE.Text);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //Perform player 1 Imports based on the selected dropdown
                player1DropdownImports();
            }
            //Perform checks - player 2
            if (player2SelectionEvE.Text == "")
            {
                if (checkImportString(player2ImportEvE.Text) != false)
                {
                    //Perform player 2 Imports based on the import string
                    player2ImportStringImports(player2ImportEvE.Text);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //Perform player 2 Imports based on the selected dropdown
                player2DropdownImports();
            }
            player1OrigHPEve = player1.getHP();
            player2OrigHPEve = player2.getHP();
            loadPlayer1VisualStats();
            loadPlayer2VisualStats();
            EvESimulation();
        }
            //Player Imports
                //Player 1
        private void player1ImportStringImports(string importString)
        {
            player1 = new Character(importString);
            //Load in to all values visually
            loadPlayer1VisualStats();
        }
        private void player1DropdownImports()
        {
            //Vanilla
                //None
            if(player1SelectionEvE.Text == "Joseph (NONE) (Vanilla)")
            {
                player1 = new Character(josephString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "David (NONE) (Vanilla)")
            {
                player1 = new Character(davidString);
                loadPlayer1VisualStats();
            }
                //Void
            if (player1SelectionEvE.Text == "Anomal (VOID) (Vanilla)")
            {
                player1 = new Character(anomalString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Rig (VOID) (Vanilla)")
            {
                player1 = new Character(rigString);
                loadPlayer1VisualStats();
            }
                //Earthly
            if (player1SelectionEvE.Text == "Stone Golem (EARTHLY) (Vanilla)")
            {
                player1 = new Character(stoneGolemString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Livern (EARTHLY) (Vanilla)")
            {
                player1 = new Character(livernString);
                loadPlayer1VisualStats();
            }
                //Air
            if (player1SelectionEvE.Text == "Albatross (AIR) (Vanilla)")
            {
                player1 = new Character(albatrossString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Tweedle (AIR) (Vanilla)")
            {
                player1 = new Character(tweedleString);
                loadPlayer1VisualStats();
            }
                //Ground
            if (player1SelectionEvE.Text == "Quake (GROUND) (Vanilla)")
            {
                player1 = new Character(quakeString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "The Rock (GROUND) (Vanilla)")
            {
                player1 = new Character(therockString);
                loadPlayer1VisualStats();
            }
                //Electric
            if (player1SelectionEvE.Text == "Zip (ELECTRIC) (Vanilla)")
            {
                player1 = new Character(zipString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Magnaur (ELECTRIC) (Vanilla)")
            {
                player1 = new Character(magnaurString);
                loadPlayer1VisualStats();
            }
                //Metal
            if (player1SelectionEvE.Text == "Irode (METAL) (Vanilla)")
            {
                player1 = new Character(irodeString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Splarg (METAL) (Vanilla)")
            {
                player1 = new Character(splargString);
                loadPlayer1VisualStats();
            }
                //Intelligent
            if (player1SelectionEvE.Text == "Doc (INTELLIGENT) (Vanilla)")
            {
                player1 = new Character(docString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Student (INTELLIGENT) (Vanilla)")
            {
                player1 = new Character(studentString);
                loadPlayer1VisualStats();
            }
                //Force
            if (player1SelectionEvE.Text == "Martis (FORCE) (Vanilla)")
            {
                player1 = new Character(martisString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Discrinius (FORCE) (Vanilla)")
            {
                player1 = new Character(discriniusString);
                loadPlayer1VisualStats();
            }
                //Ice
            if (player1SelectionEvE.Text == "Cicle (ICE) (Vanilla)")
            {
                player1 = new Character(cicleString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Blizerd (ICE) (Vanilla)")
            {
                player1 = new Character(blizerdString);
                loadPlayer1VisualStats();
            }
                //Fire
            if (player1SelectionEvE.Text == "Solcore (FIRE) (Vanilla)")
            {
                player1 = new Character(solcoreString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Pyrocitus (FIRE) (Vanilla)")
            {
                player1 = new Character(pyrocitusString);
                loadPlayer1VisualStats();
            }
                //Natural
            if (player1SelectionEvE.Text == "Lyfebud (NATURAL) (Vanilla)")
            {
                player1 = new Character(lyfebudString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Elementus (NATURAL) (Vanilla)")
            {
                player1 = new Character(elementusString);
                loadPlayer1VisualStats();
            }
                //Psychic
            if (player1SelectionEvE.Text == "Forseer (PSYCHIC) (Vanilla)")
            {
                player1 = new Character(forseerString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Zodium (PSYCHIC) (Vanilla)")
            {
                player1 = new Character(zodiumString);
                loadPlayer1VisualStats();
            }
                //Mortal
            if (player1SelectionEvE.Text == "Humanus (MORTAL) (Vanilla)")
            {
                player1 = new Character(humanusString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "The Demon (MORTAL) (Vanilla)")
            {
                player1 = new Character(thedemonString);
                loadPlayer1VisualStats();
            }
                //Ghost
            if (player1SelectionEvE.Text == "Spirtu (GHOST) (Vanilla)")
            {
                player1 = new Character(spirtuString);
                loadPlayer1VisualStats();
            }
            if (player1SelectionEvE.Text == "Duskan (GHOST) (Vanilla)")
            {
                player1 = new Character(duskanString);
                loadPlayer1VisualStats();
            }
        }
                //Player 2
        private void player2ImportStringImports(string importString)
        {
            player2 = new Character(importString);
            //Load in to all values visually
            loadPlayer2VisualStats();
        }
        private void player2DropdownImports()
        {
            //Vanilla
            //None
            if (player2SelectionEvE.Text == "Joseph (NONE) (Vanilla)")
            {
                player2 = new Character(josephString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "David (NONE) (Vanilla)")
            {
                player2 = new Character(davidString);
                loadPlayer2VisualStats();
            }
            //Void
            if (player2SelectionEvE.Text == "Anomal (VOID) (Vanilla)")
            {
                player2 = new Character(anomalString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Rig (VOID) (Vanilla)")
            {
                player2 = new Character(rigString);
                loadPlayer2VisualStats();
            }
            //Earthly
            if (player2SelectionEvE.Text == "Stone Golem (EARTHLY) (Vanilla)")
            {
                player2 = new Character(stoneGolemString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Livern (EARTHLY) (Vanilla)")
            {
                player2 = new Character(livernString);
                loadPlayer2VisualStats();
            }
            //Air
            if (player2SelectionEvE.Text == "Albatross (AIR) (Vanilla)")
            {
                player2 = new Character(albatrossString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Tweedle (AIR) (Vanilla)")
            {
                player2 = new Character(tweedleString);
                loadPlayer2VisualStats();
            }
            //Ground
            if (player2SelectionEvE.Text == "Quake (GROUND) (Vanilla)")
            {
                player2 = new Character(quakeString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "The Rock (GROUND) (Vanilla)")
            {
                player2 = new Character(therockString);
                loadPlayer2VisualStats();
            }
            //Electric
            if (player2SelectionEvE.Text == "Zip (ELECTRIC) (Vanilla)")
            {
                player2 = new Character(zipString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Magnaur (ELECTRIC) (Vanilla)")
            {
                player2 = new Character(magnaurString);
                loadPlayer2VisualStats();
            }
            //Metal
            if (player2SelectionEvE.Text == "Irode (METAL) (Vanilla)")
            {
                player2 = new Character(irodeString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Splarg (METAL) (Vanilla)")
            {
                player2 = new Character(splargString);
                loadPlayer2VisualStats();
            }
            //Intelligent
            if (player2SelectionEvE.Text == "Doc (INTELLIGENT) (Vanilla)")
            {
                player2 = new Character(docString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Student (INTELLIGENT) (Vanilla)")
            {
                player2 = new Character(studentString);
                loadPlayer2VisualStats();
            }
            //Force
            if (player2SelectionEvE.Text == "Martis (FORCE) (Vanilla)")
            {
                player2 = new Character(martisString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Discrinius (FORCE) (Vanilla)")
            {
                player2 = new Character(discriniusString);
                loadPlayer2VisualStats();
            }
            //Ice
            if (player2SelectionEvE.Text == "Cicle (ICE) (Vanilla)")
            {
                player2 = new Character(cicleString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Blizerd (ICE) (Vanilla)")
            {
                player2 = new Character(blizerdString);
                loadPlayer2VisualStats();
            }
            //Fire
            if (player2SelectionEvE.Text == "Solcore (FIRE) (Vanilla)")
            {
                player2 = new Character(solcoreString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Pyrocitus (FIRE) (Vanilla)")
            {
                player2 = new Character(pyrocitusString);
                loadPlayer2VisualStats();
            }
            //Natural
            if (player2SelectionEvE.Text == "Lyfebud (NATURAL) (Vanilla)")
            {
                player2 = new Character(lyfebudString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Elementus (NATURAL) (Vanilla)")
            {
                player2 = new Character(elementusString);
                loadPlayer2VisualStats();
            }
            //Psychic
            if (player2SelectionEvE.Text == "Forseer (PSYCHIC) (Vanilla)")
            {
                player2 = new Character(forseerString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Zodium (PSYCHIC) (Vanilla)")
            {
                player2 = new Character(zodiumString);
                loadPlayer2VisualStats();
            }
            //Mortal
            if (player2SelectionEvE.Text == "Humanus (MORTAL) (Vanilla)")
            {
                player2 = new Character(humanusString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "The Demon (MORTAL) (Vanilla)")
            {
                player2 = new Character(thedemonString);
                loadPlayer2VisualStats();
            }
            //Ghost
            if (player2SelectionEvE.Text == "Spirtu (GHOST) (Vanilla)")
            {
                player2 = new Character(spirtuString);
                loadPlayer2VisualStats();
            }
            if (player2SelectionEvE.Text == "Duskan (GHOST) (Vanilla)")
            {
                player2 = new Character(duskanString);
                loadPlayer2VisualStats();
            }
        }
            //EvE Simulation
        private void EvESimulation()
        {
            disableAllButtons();
            player1EvEMaxHP = player1.getHP();
            player2EvEMaxHP = player2.getHP();
            eveSimText.Text = "";
            lastP1Move = 0;
            lastP2Move = 0;
            eveSimText.Text = "";
            loadPlayer1VisualStats();
            loadPlayer2VisualStats();
            while (player1.getHP() > 0 && player2.getHP() > 0)
            {
                loadPlayer1VisualStats();
                loadPlayer2VisualStats();
                EvERandomAI1(player1);
                loadPlayer1VisualStats();
                loadPlayer2VisualStats();
                if(player1.getHP() <= 0 || player2.getHP() <= 0)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
                eveSimText.AppendText(Environment.NewLine);
                EvERandomAI2(player2);
                loadPlayer1VisualStats();
                loadPlayer2VisualStats();
                if (player1.getHP() <= 0 || player2.getHP() <= 0)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
                eveSimText.AppendText(Environment.NewLine);
            }
            enableAllButtons();
        }
                //EvE AIs
        private void EvERandomAI1(Character player1)
        {
                //PLAYER 1
                //First, check if the player 1 is stunned or frozen
                bool p1Skipped = stunFrozenChecksP1(player1);
                if (p1Skipped == true)
                {
                    //If they are, see if they take damage from statuses, and then see if they are dead
                    if (damageStatusChecksP1(player1) == true)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                        enableAllButtons();
                        loadPlayer1VisualStats();
                        loadPlayer2VisualStats();
                        return;
                    }
                    else
                    {
                        //If they don't die, modify their status turns if applicable
                        player1.modifyStatusTurns();
                        loadPlayer1VisualStats();
                        loadPlayer2VisualStats();
                        return;
                    }
                }
                //If they are not stunned or frozen
                else
                {
                    //Check to see if they are stupefied (chance to not attack)
                    if (player1.getIsStupefied() == true)
                    {
                        //If they are, chance to not attack
                        Random rand1 = new Random();
                        int notHit = rand1.Next(0, 2);
                        //If 50% chance is 0, don't hit
                        if(notHit == 0)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 is stupefied and was not able to attack!");
                            //Finish the turn with status checks and modifications
                            if (damageStatusChecksP1(player1) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else
                            {
                                //If they don't die, modify their status turns if applicable
                                player1.modifyStatusTurns();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                        }
                        else
                        {
                            //Perform a random move
                            Random rand = new Random();
                            int randMove = rand.Next(1, 6);
                            while (randMove == lastP1Move)
                            {
                                randMove = rand.Next(1, 6);
                            }
                            //Peform the move based on the rand
                            p1Moves(randMove);
                            if(player2DeathChecks(player2) == true)
                            {
                                loadPlayer2VisualStats();
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else if(player1DeathChecks(player1) == true)
                            {
                                loadPlayer2VisualStats();
                                loadPlayer1VisualStats();
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else
                            {
                                //Finish the turn with status checks and modifications
                                if (damageStatusChecksP1(player1) == true)
                                {
                                    eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                    enableAllButtons();
                                    loadPlayer1VisualStats();
                                    loadPlayer2VisualStats();
                                    return;
                                }
                                else
                                {
                                    //If they don't die, modify their status turns if applicable
                                    player1.modifyStatusTurns();
                                    loadPlayer1VisualStats();
                                    loadPlayer2VisualStats();
                                    return;
                                }
                            }
                        }
                    }
                    //Perform a random move
                    else
                    {
                        Random rand = new Random();
                        int randMove = rand.Next(1, 6);
                        while (randMove == lastP1Move)
                        {
                            randMove = rand.Next(1, 6);
                        }
                        //Peform the move based on the rand
                        p1Moves(randMove);
                        if (player2DeathChecks(player2) == true)
                        {
                            loadPlayer2VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                            enableAllButtons();
                            loadPlayer1VisualStats();
                            loadPlayer2VisualStats();
                            return;
                        }
                        else if (player1DeathChecks(player1) == true)
                        {
                            loadPlayer2VisualStats();
                            loadPlayer1VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                            enableAllButtons();
                            loadPlayer1VisualStats();
                            loadPlayer2VisualStats();
                            return;
                        }
                        else
                        {
                            //Finish the turn with status checks and modifications
                            if (damageStatusChecksP1(player1) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else
                            {
                                //If they don't die, modify their status turns if applicable
                                player1.modifyStatusTurns();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                        }
                    }
                }
        }
        private void EvERandomAI2(Character player2)
        {
                //PLAYER 2
                //First, check if the player 2 is stunned or frozen
                bool p2Skipped = stunFrozenChecksP2(player2);
                if (p2Skipped == true)
                {
                    //If they are, see if they take damage from statuses, and then see if they are dead
                    if (damageStatusChecksP2(player2) == true)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                        enableAllButtons();
                        loadPlayer1VisualStats();
                        loadPlayer2VisualStats();
                        return;
                    }
                    else
                    {
                        //If they don't die, modify their status turns if applicable
                        player2.modifyStatusTurns();
                        loadPlayer1VisualStats();
                        loadPlayer2VisualStats();
                        return;
                    }
                }
                //If they are not stunned or frozen
                else
                {
                    //Check to see if they are stupefied (chance to not attack)
                    if (player2.getIsStupefied() == true)
                    {
                        //If they are, chance to not attack
                        Random rand1 = new Random();
                        int notHit = rand1.Next(0, 2);
                        //If 50% chance is 0, don't hit
                        if (notHit == 0)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 is stupefied and was not able to attack!");
                            //Finish the turn with status checks and modifications
                            if (damageStatusChecksP2(player2) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else
                            {
                                //If they don't die, modify their status turns if applicable
                                player2.modifyStatusTurns();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                        }
                        else
                        {
                            //Perform a random move
                            Random rand = new Random();
                            int randMove = rand.Next(1, 6);
                            while (randMove == lastP1Move)
                            {
                                randMove = rand.Next(1, 6);
                            }
                            //Peform the move based on the rand
                            p2Moves(randMove);
                            if (player1DeathChecks(player1) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else if (player2DeathChecks(player2) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else
                            {
                                //Finish the turn with status checks and modifications
                                if (damageStatusChecksP2(player2) == true)
                                {
                                    eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                    enableAllButtons();
                                    loadPlayer1VisualStats();
                                    loadPlayer2VisualStats();
                                    return;
                                }
                                else
                                {
                                    //If they don't die, modify their status turns if applicable
                                    player2.modifyStatusTurns();
                                    loadPlayer1VisualStats();
                                    loadPlayer2VisualStats();
                                    return;
                                }
                            }
                        }
                    }
                    //Perform a random move
                    else
                    {
                        Random rand = new Random();
                        int randMove = rand.Next(1, 6);
                        while (randMove == lastP1Move)
                        {
                            randMove = rand.Next(1, 6);
                        }
                        //Peform the move based on the rand
                        p2Moves(randMove);
                        if (player1DeathChecks(player1) == true)
                        {
                            loadPlayer1VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                            enableAllButtons();
                            loadPlayer1VisualStats();
                            loadPlayer2VisualStats();
                            return;
                        }
                        else if (player2DeathChecks(player2) == true)
                        {
                            loadPlayer1VisualStats();
                            loadPlayer2VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                            enableAllButtons();
                            loadPlayer1VisualStats();
                            loadPlayer2VisualStats();
                            return;
                        }
                        else
                        {
                            //Finish the turn with status checks and modifications
                            if (damageStatusChecksP2(player2) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                enableAllButtons();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                            else
                            {
                                //If they don't die, modify their status turns if applicable
                                player2.modifyStatusTurns();
                                loadPlayer1VisualStats();
                                loadPlayer2VisualStats();
                                return;
                            }
                        }
                    }
                }
        }

        //PvE Methods
        private void pveButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Coming Soon!");
        }

        //PvP Methods
        private void pvpButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Coming Soon!");
        }

            //Player 1 Checks and Methods (USEABLE FOR ALL SIMS)
        private bool stunFrozenChecksP1(Character player1)
        {
            //Bool returns if cannot move, true is yes, false is no
            if(player1.getIsStunned() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 is stunned and cannot move!");
                return true;
            }else if(player1.getIsFrozen() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 is frozen and cannot move!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool damageStatusChecksP1(Character player1)
        {
            //Bool returns if is dead (true is yes, false is no)
            //Poison
            if(player1.getIsPoisoned() == true)
            {
                if(player1.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes 1 damage from poison.");
                    player1.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes " + (player1.getHP() * 0.03).ToString() + " damage from poison.");
                    player1.modifyHP(-(int)(player1.getHP() * 0.03));
                }
                if(player1DeathChecks(player1) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer1VisualStats();
                }
            }
            //Burn
            if (player1.getIsBurned() == true)
            {
                if (player1.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes 1 damage from burn.");
                    player1.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes " + (player1.getHP() * 0.03).ToString() + " damage from burn.");
                    player1.modifyHP(-(int)(player1.getHP() * 0.03));
                }
                if (player1DeathChecks(player1) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer1VisualStats();
                }
            }
            //Bleed
            if (player1.getIsBleeding() == true)
            {
                if (player1.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes 1 damage from bleeding.");
                    player1.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes " + (player1.getHP() * 0.03).ToString() + " damage from bleeding.");
                    player1.modifyHP(-(int)(player1.getHP() * 0.03));
                }
                if (player1DeathChecks(player1) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer1VisualStats();
                }
            }
            return false;
        }
        private bool player1DeathChecks(Character player1)
        {
            if(player1.getHP() <= 0)
            {
                player1.setHp(0);
                loadPlayer1VisualStats();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void p1Moves(int move)
        {
            int totalAcc1;
            //Modifiers
            atkStatModValPsn = 1f;
            atkStatModValWk = 1f;
            effectivenessModVal = 1f;
            if(player1.getIsPoisoned() == true)
            {
                atkStatModValPsn = 0.9f;
            }
            if(player1.getIsWeak() == true)
            {
                atkStatModValWk = 0.75f;
            }
            //Move 1
            if(move == 1)
            {
                totalAcc1 = player1.getAcc() + player1.getMv1Acc() - player2.getDge();
                //Check effectiveness
                    //Effective
                if(player1.getMv1Type() == "NONE" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "VOID" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "EARTHLY" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "AIR" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "GROUND" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "ELECTRIC" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "METAL" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "INTELLIGENT" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "FORCE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "ICE" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "FIRE" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "NATURAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "PSYCHIC" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "MORTAL" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv1Type() == "GHOST" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                    //Not effective
                if (player1.getMv1Type() == "NONE" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "VOID" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "EARTHLY" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "AIR" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "GROUND" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "ELECTRIC" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "METAL" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "INTELLIGENT" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "FORCE" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "ICE" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "FIRE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "NATURAL" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "PSYCHIC" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "MORTAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv1Type() == "GHOST" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP1MV1Hits();
                }
                else if(totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if(chance <= totalAcc1)
                    {
                        //The move lands
                        eveP1MV1Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 2
            if (move == 2)
            {
                totalAcc1 = player1.getAcc() + player1.getMv2Acc() - player2.getDge();
                //Check effectiveness
                //Effective
                if (player1.getMv2Type() == "NONE" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "VOID" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "EARTHLY" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "AIR" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "GROUND" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "ELECTRIC" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "METAL" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "INTELLIGENT" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "FORCE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "ICE" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "FIRE" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "NATURAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "PSYCHIC" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "MORTAL" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv2Type() == "GHOST" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not effective
                if (player1.getMv2Type() == "NONE" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "VOID" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "EARTHLY" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "AIR" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "GROUND" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "ELECTRIC" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "METAL" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "INTELLIGENT" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "FORCE" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "ICE" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "FIRE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "NATURAL" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "PSYCHIC" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "MORTAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv2Type() == "GHOST" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP1MV2Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP1MV2Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 3
            if (move == 3)
            {
                totalAcc1 = player1.getAcc() + player1.getMv3Acc() - player2.getDge();
                //Check effectiveness
                //Effective
                if (player1.getMv3Type() == "NONE" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "VOID" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "EARTHLY" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "AIR" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "GROUND" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "ELECTRIC" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "METAL" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "INTELLIGENT" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "FORCE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "ICE" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "FIRE" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "NATURAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "PSYCHIC" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "MORTAL" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv3Type() == "GHOST" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not effective
                if (player1.getMv3Type() == "NONE" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "VOID" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "EARTHLY" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "AIR" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "GROUND" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "ELECTRIC" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "METAL" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "INTELLIGENT" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "FORCE" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "ICE" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "FIRE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "NATURAL" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "PSYCHIC" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "MORTAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv3Type() == "GHOST" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP1MV3Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP1MV3Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 4
            if (move == 4)
            {
                totalAcc1 = player1.getAcc() + player1.getMv4Acc() - player2.getDge();
                //Check effectiveness
                //Effective
                if (player1.getMv4Type() == "NONE" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "VOID" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "EARTHLY" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "AIR" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "GROUND" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "ELECTRIC" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "METAL" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "INTELLIGENT" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "FORCE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "ICE" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "FIRE" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "NATURAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "PSYCHIC" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "MORTAL" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv4Type() == "GHOST" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not effective
                if (player1.getMv4Type() == "NONE" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "VOID" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "EARTHLY" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "AIR" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "GROUND" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "ELECTRIC" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "METAL" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "INTELLIGENT" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "FORCE" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "ICE" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "FIRE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "NATURAL" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "PSYCHIC" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "MORTAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv4Type() == "GHOST" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP1MV4Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP1MV4Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 5
            if (move == 5)
            {
                totalAcc1 = player1.getAcc() + player1.getMv5Acc() - player2.getDge();
                //Check effectiveness
                //Effective
                if (player1.getMv5Type() == "NONE" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "VOID" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "EARTHLY" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "AIR" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "GROUND" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "ELECTRIC" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "METAL" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "INTELLIGENT" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "FORCE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "ICE" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "FIRE" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "NATURAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "PSYCHIC" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "MORTAL" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player1.getMv5Type() == "GHOST" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not effective
                if (player1.getMv5Type() == "NONE" && player2.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "VOID" && player2.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "EARTHLY" && player2.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "AIR" && player2.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "GROUND" && player2.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "ELECTRIC" && player2.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "METAL" && player2.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "INTELLIGENT" && player2.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "FORCE" && player2.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "ICE" && player2.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "FIRE" && player2.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "NATURAL" && player2.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "PSYCHIC" && player2.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "MORTAL" && player2.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player1.getMv5Type() == "GHOST" && player2.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP1MV5Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP1MV5Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Healthbar updates
            player1HealthBarEvE.Width = (player1.getHP() / player1EvEMaxHP);
            player2HealthBarEvE.Width = (player2.getHP() / player2EvEMaxHP);
            Application.DoEvents();
        }
            //Player 1 Move subactions (recurring methods in p1Moves)
        private void eveP1MV1Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 1!");
            int totalAtk = (int)(player1.getAtk() * player1.getMv1M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player2.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
            player2.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv1Heal().ToString());
            player1.modifyHP(player1.getMv1Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv1AtkMod().ToString());
            player1.modifyATK(player1.getMv1AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv1DefMod().ToString());
            player1.modifyDEF(player1.getMv1DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv1AccMod().ToString());
            player1.modifyACC(player1.getMv1AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv1DgeMod().ToString());
            player1.modifyDGE(player1.getMv1DgeMod());
            //Induces effects?
            if (player1.getMv1indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                player2.induceStun();
            }
            if (player1.getMv1indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                player2.inducePoison();
            }
            if (player1.getMv1indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                player2.induceBurn();
            }
            if (player1.getMv1indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                player2.induceCripple();
            }
            if (player1.getMv1indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                player2.induceFrozen();
            }
            if (player1.getMv1indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                player2.induceBleeding();
            }
            if (player1.getMv1indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                player2.induceStupefy();
            }
            if (player1.getMv1indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                player2.induceWeak();
            }
            if (player1.getMv1indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                player2.induceDizzy();
            }
        }
        private void eveP1MV2Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 2!");
            int totalAtk = (int)(player1.getAtk() * player1.getMv2M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player2.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
            player2.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv2Heal().ToString());
            player1.modifyHP(player1.getMv2Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv2AtkMod().ToString());
            player1.modifyATK(player1.getMv2AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv2DefMod().ToString());
            player1.modifyDEF(player1.getMv2DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv2AccMod().ToString());
            player1.modifyACC(player1.getMv2AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv2DgeMod().ToString());
            player1.modifyDGE(player1.getMv2DgeMod());
            //Induces effects?
            if (player1.getMv2indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                player2.induceStun();
            }
            if (player1.getMv2indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                player2.inducePoison();
            }
            if (player1.getMv2indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                player2.induceBurn();
            }
            if (player1.getMv2indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                player2.induceCripple();
            }
            if (player1.getMv2indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                player2.induceFrozen();
            }
            if (player1.getMv2indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                player2.induceBleeding();
            }
            if (player1.getMv2indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                player2.induceStupefy();
            }
            if (player1.getMv2indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                player2.induceWeak();
            }
            if (player1.getMv2indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                player2.induceDizzy();
            }
        }
        private void eveP1MV3Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 3!");
            int totalAtk = (int)(player1.getAtk() * player1.getMv3M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player2.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
            player2.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv3Heal().ToString());
            player1.modifyHP(player1.getMv3Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv3AtkMod().ToString());
            player1.modifyATK(player1.getMv3AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv3DefMod().ToString());
            player1.modifyDEF(player1.getMv3DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv3AccMod().ToString());
            player1.modifyACC(player1.getMv3AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv3DgeMod().ToString());
            player1.modifyDGE(player1.getMv3DgeMod());
            //Induces effects?
            if (player1.getMv3indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                player2.induceStun();
            }
            if (player1.getMv3indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                player2.inducePoison();
            }
            if (player1.getMv3indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                player2.induceBurn();
            }
            if (player1.getMv3indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                player2.induceCripple();
            }
            if (player1.getMv3indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                player2.induceFrozen();
            }
            if (player1.getMv3indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                player2.induceBleeding();
            }
            if (player1.getMv3indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                player2.induceStupefy();
            }
            if (player1.getMv3indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                player2.induceWeak();
            }
            if (player1.getMv3indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                player2.induceDizzy();
            }
        }
        private void eveP1MV4Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 4!");
            int totalAtk = (int)(player1.getAtk() * player1.getMv4M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player2.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
            player2.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv4Heal().ToString());
            player1.modifyHP(player1.getMv4Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv4AtkMod().ToString());
            player1.modifyATK(player1.getMv4AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv4DefMod().ToString());
            player1.modifyDEF(player1.getMv4DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv4AccMod().ToString());
            player1.modifyACC(player1.getMv4AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv4DgeMod().ToString());
            player1.modifyDGE(player1.getMv4DgeMod());
            //Induces effects?
            if (player1.getMv4indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                player2.induceStun();
            }
            if (player1.getMv4indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                player2.inducePoison();
            }
            if (player1.getMv4indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                player2.induceBurn();
            }
            if (player1.getMv4indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                player2.induceCripple();
            }
            if (player1.getMv4indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                player2.induceFrozen();
            }
            if (player1.getMv4indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                player2.induceBleeding();
            }
            if (player1.getMv4indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                player2.induceStupefy();
            }
            if (player1.getMv4indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                player2.induceWeak();
            }
            if (player1.getMv4indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                player2.induceDizzy();
            }
        }
        private void eveP1MV5Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 5!");
            int totalAtk = (int)(player1.getAtk() * player1.getMv4M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player2.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
            player2.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv5Heal().ToString());
            player1.modifyHP(player1.getMv5Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv5AtkMod().ToString());
            player1.modifyATK(player1.getMv5AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv5DefMod().ToString());
            player1.modifyDEF(player1.getMv5DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv5AccMod().ToString());
            player1.modifyACC(player1.getMv5AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv5DgeMod().ToString());
            player1.modifyDGE(player1.getMv5DgeMod());
            //Induces effects?
            if (player1.getMv5indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                player2.induceStun();
            }
            if (player1.getMv5indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                player2.inducePoison();
            }
            if (player1.getMv5indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                player2.induceBurn();
            }
            if (player1.getMv5indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                player2.induceCripple();
            }
            if (player1.getMv5indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                player2.induceFrozen();
            }
            if (player1.getMv5indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                player2.induceBleeding();
            }
            if (player1.getMv5indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                player2.induceStupefy();
            }
            if (player1.getMv5indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                player2.induceWeak();
            }
            if (player1.getMv5indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                player2.induceDizzy();
            }
        }

            //Player 2 Checks and Methods (USEABLE FOR ALL SIMS)
        private bool stunFrozenChecksP2(Character player2)
        {
            //Bool returns if cannot move, true is yes, false is no
            if (player2.getIsStunned() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 is stunned and cannot move!");
                return true;
            }
            else if (player2.getIsFrozen() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 is frozen and cannot move!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool damageStatusChecksP2(Character player2)
        {
            //Bool returns if is dead (true is yes, false is no)
            //Poison
            if (player2.getIsPoisoned() == true)
            {
                if (player2.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes 1 damage from poison.");
                    player2.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes " + (player2.getHP() * 0.03).ToString() + " damage from poison.");
                    player2.modifyHP(-(int)(player2.getHP() * 0.03));
                }
                if (player2DeathChecks(player2) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer2VisualStats();
                }
            }
            //Burn
            if (player2.getIsBurned() == true)
            {
                if (player2.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes 1 damage from burn.");
                    player2.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes " + (player2.getHP() * 0.03).ToString() + " damage from burn.");
                    player2.modifyHP(-(int)(player2.getHP() * 0.03));
                }
                if (player2DeathChecks(player2) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer2VisualStats();
                }
            }
            //Bleed
            if (player2.getIsBleeding() == true)
            {
                if (player2.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes 1 damage from bleeding.");
                    player2.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes " + (player2.getHP() * 0.03).ToString() + " damage from bleeding.");
                    player2.modifyHP(-(int)(player2.getHP() * 0.03));
                }
                if (player2DeathChecks(player2) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer2VisualStats();
                }
            }
            return false;
        }
        private bool player2DeathChecks(Character player2)
        {
            if (player2.getHP() <= 0)
            {
                player2.setHp(0);
                loadPlayer2VisualStats();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void p2Moves(int move)
        {
            int totalAcc1;
            //Modifiers
            atkStatModValPsn = 1f;
            atkStatModValWk = 1f;
            effectivenessModVal = 1f;
            if (player2.getIsPoisoned() == true)
            {
                atkStatModValPsn = 0.9f;
            }
            if (player2.getIsWeak() == true)
            {
                atkStatModValWk = 0.75f;
            }
            //Move 1
            if (move == 1)
            {
                totalAcc1 = player2.getAcc() + player2.getMv1Acc() - player1.getDge();
                //Check effectiveness
                //Effective
                if (player2.getMv1Type() == "NONE" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "VOID" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "EARTHLY" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "AIR" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "GROUND" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "ELECTRIC" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "METAL" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "INTELLIGENT" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "FORCE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "ICE" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "FIRE" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "NATURAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "PSYCHIC" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "MORTAL" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv1Type() == "GHOST" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not Effective
                if (player2.getMv1Type() == "NONE" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "VOID" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "EARTHLY" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "AIR" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "GROUND" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "ELECTRIC" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "METAL" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "INTELLIGENT" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "FORCE" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "ICE" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "FIRE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "NATURAL" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "PSYCHIC" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "MORTAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv1Type() == "GHOST" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP2MV1Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP2MV1Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 2
            if (move == 2)
            {
                totalAcc1 = player2.getAcc() + player2.getMv2Acc() - player1.getDge();
                //Check effectiveness
                //Effective
                if (player2.getMv2Type() == "NONE" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "VOID" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "EARTHLY" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "AIR" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "GROUND" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "ELECTRIC" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "METAL" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "INTELLIGENT" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "FORCE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "ICE" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "FIRE" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "NATURAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "PSYCHIC" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "MORTAL" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv2Type() == "GHOST" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not Effective
                if (player2.getMv2Type() == "NONE" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "VOID" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "EARTHLY" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "AIR" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "GROUND" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "ELECTRIC" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "METAL" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "INTELLIGENT" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "FORCE" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "ICE" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "FIRE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "NATURAL" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "PSYCHIC" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "MORTAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv2Type() == "GHOST" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP2MV2Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP2MV2Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 3
            if (move == 3)
            {
                totalAcc1 = player2.getAcc() + player2.getMv3Acc() - player1.getDge();
                //Check effectiveness
                //Effective
                if (player2.getMv3Type() == "NONE" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "VOID" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "EARTHLY" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "AIR" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "GROUND" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "ELECTRIC" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "METAL" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "INTELLIGENT" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "FORCE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "ICE" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "FIRE" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "NATURAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "PSYCHIC" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "MORTAL" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv3Type() == "GHOST" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not Effective
                if (player2.getMv3Type() == "NONE" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "VOID" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "EARTHLY" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "AIR" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "GROUND" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "ELECTRIC" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "METAL" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "INTELLIGENT" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "FORCE" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "ICE" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "FIRE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "NATURAL" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "PSYCHIC" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "MORTAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv3Type() == "GHOST" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP2MV3Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP2MV3Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 4
            if (move == 4)
            {
                totalAcc1 = player2.getAcc() + player2.getMv4Acc() - player1.getDge();
                //Check effectiveness
                //Effective
                if (player2.getMv4Type() == "NONE" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "VOID" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "EARTHLY" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "AIR" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "GROUND" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "ELECTRIC" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "METAL" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "INTELLIGENT" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "FORCE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "ICE" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "FIRE" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "NATURAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "PSYCHIC" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "MORTAL" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv4Type() == "GHOST" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not Effective
                if (player2.getMv4Type() == "NONE" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "VOID" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "EARTHLY" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "AIR" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "GROUND" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "ELECTRIC" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "METAL" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "INTELLIGENT" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "FORCE" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "ICE" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "FIRE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "NATURAL" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "PSYCHIC" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "MORTAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv4Type() == "GHOST" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP2MV4Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP2MV4Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 5
            if (move == 5)
            {
                totalAcc1 = player2.getAcc() + player2.getMv5Acc() - player1.getDge();
                //Check effectiveness
                //Effective
                if (player2.getMv5Type() == "NONE" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "VOID" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "EARTHLY" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "AIR" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "GROUND" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "ELECTRIC" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "METAL" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "INTELLIGENT" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "FORCE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "ICE" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "FIRE" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "NATURAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "PSYCHIC" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "MORTAL" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 1.25f;
                }
                if (player2.getMv5Type() == "GHOST" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 1.25f;
                }
                //Not Effective
                if (player2.getMv5Type() == "NONE" && player1.getType() == "GHOST")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "VOID" && player1.getType() == "NONE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "EARTHLY" && player1.getType() == "VOID")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "AIR" && player1.getType() == "EARTHLY")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "GROUND" && player1.getType() == "AIR")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "ELECTRIC" && player1.getType() == "GROUND")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "METAL" && player1.getType() == "ELECTRIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "INTELLIGENT" && player1.getType() == "METAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "FORCE" && player1.getType() == "INTELLIGENT")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "ICE" && player1.getType() == "FORCE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "FIRE" && player1.getType() == "ICE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "NATURAL" && player1.getType() == "FIRE")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "PSYCHIC" && player1.getType() == "NATURAL")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "MORTAL" && player1.getType() == "PSYCHIC")
                {
                    effectivenessModVal = 0.75f;
                }
                if (player2.getMv5Type() == "GHOST" && player1.getType() == "MORTAL")
                {
                    effectivenessModVal = 0.75f;
                }
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveP2MV5Hits();
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveP2MV5Hits();
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Healthbar updates
            player1HealthBarEvE.Width = (player1.getHP() / player1EvEMaxHP);
            player2HealthBarEvE.Width = (player2.getHP() / player2EvEMaxHP);
            Application.DoEvents();
        }
            //Player 2 Move subactions (recurring methods in p2Moves)
        private void eveP2MV1Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 1!");
            int totalAtk = (int)(player2.getAtk() * player2.getMv1M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player1.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
            player1.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv1Heal().ToString());
            player2.modifyHP(player2.getMv1Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv1AtkMod().ToString());
            player2.modifyATK(player2.getMv1AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv1DefMod().ToString());
            player2.modifyDEF(player2.getMv1DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv1AccMod().ToString());
            player2.modifyACC(player2.getMv1AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv1DgeMod().ToString());
            player2.modifyDGE(player2.getMv1DgeMod());
            //Induces effects?
            if (player2.getMv1indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                player1.induceStun();
            }
            if (player2.getMv1indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                player1.inducePoison();
            }
            if (player2.getMv1indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                player1.induceBurn();
            }
            if (player2.getMv1indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                player1.induceCripple();
            }
            if (player2.getMv1indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                player1.induceFrozen();
            }
            if (player2.getMv1indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                player1.induceBleeding();
            }
            if (player2.getMv1indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                player1.induceStupefy();
            }
            if (player2.getMv1indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                player1.induceWeak();
            }
            if (player2.getMv1indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                player1.induceDizzy();
            }
        }
        private void eveP2MV2Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 2!");
            int totalAtk = (int)(player2.getAtk() * player2.getMv2M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player1.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
            player1.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv2Heal().ToString());
            player2.modifyHP(player2.getMv2Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv2AtkMod().ToString());
            player2.modifyATK(player2.getMv2AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv2DefMod().ToString());
            player2.modifyDEF(player2.getMv2DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv2AccMod().ToString());
            player2.modifyACC(player2.getMv2AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv2DgeMod().ToString());
            player2.modifyDGE(player2.getMv2DgeMod());
            //Induces effects?
            if (player2.getMv2indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                player1.induceStun();
            }
            if (player2.getMv2indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                player1.inducePoison();
            }
            if (player2.getMv2indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                player1.induceBurn();
            }
            if (player2.getMv2indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                player1.induceCripple();
            }
            if (player2.getMv2indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                player1.induceFrozen();
            }
            if (player2.getMv2indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                player1.induceBleeding();
            }
            if (player2.getMv2indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                player1.induceStupefy();
            }
            if (player2.getMv2indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                player1.induceWeak();
            }
            if (player2.getMv2indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                player1.induceDizzy();
            }
        }
        private void eveP2MV3Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 3!");
            int totalAtk = (int)(player2.getAtk() * player2.getMv3M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player1.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
            player1.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv3Heal().ToString());
            player2.modifyHP(player2.getMv3Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv3AtkMod().ToString());
            player2.modifyATK(player2.getMv3AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv3DefMod().ToString());
            player2.modifyDEF(player2.getMv3DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv3AccMod().ToString());
            player2.modifyACC(player2.getMv3AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv3DgeMod().ToString());
            player2.modifyDGE(player2.getMv3DgeMod());
            //Induces effects?
            if (player2.getMv3indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                player1.induceStun();
            }
            if (player2.getMv3indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                player1.inducePoison();
            }
            if (player2.getMv3indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                player1.induceBurn();
            }
            if (player2.getMv3indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                player1.induceCripple();
            }
            if (player2.getMv3indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                player1.induceFrozen();
            }
            if (player2.getMv3indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                player1.induceBleeding();
            }
            if (player2.getMv3indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                player1.induceStupefy();
            }
            if (player2.getMv3indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                player1.induceWeak();
            }
            if (player2.getMv3indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                player1.induceDizzy();
            }
        }
        private void eveP2MV4Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 4!");
            int totalAtk = (int)(player2.getAtk() * player2.getMv4M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player1.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
            player1.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv4Heal().ToString());
            player2.modifyHP(player2.getMv4Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv4AtkMod().ToString());
            player2.modifyATK(player2.getMv4AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv4DefMod().ToString());
            player2.modifyDEF(player2.getMv4DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv4AccMod().ToString());
            player2.modifyACC(player2.getMv4AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv4DgeMod().ToString());
            player2.modifyDGE(player2.getMv4DgeMod());
            //Induces effects?
            if (player2.getMv4indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                player1.induceStun();
            }
            if (player2.getMv4indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                player1.inducePoison();
            }
            if (player2.getMv4indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                player1.induceBurn();
            }
            if (player2.getMv4indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                player1.induceCripple();
            }
            if (player2.getMv4indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                player1.induceFrozen();
            }
            if (player2.getMv4indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                player1.induceBleeding();
            }
            if (player2.getMv4indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                player1.induceStupefy();
            }
            if (player2.getMv4indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                player1.induceWeak();
            }
            if (player2.getMv4indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                player1.induceDizzy();
            }
        }
        private void eveP2MV5Hits()
        {
            eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 5!");
            int totalAtk = (int)(player2.getAtk() * player2.getMv4M() * atkStatModValPsn * atkStatModValWk * effectivenessModVal);
            int damageDealt = totalAtk ^ 2 / player1.getDef();
            eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
            player1.modifyHP(-damageDealt);
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv5Heal().ToString());
            player2.modifyHP(player2.getMv5Heal());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv5AtkMod().ToString());
            player2.modifyATK(player2.getMv5AtkMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv5DefMod().ToString());
            player2.modifyDEF(player2.getMv5DefMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv5AccMod().ToString());
            player2.modifyACC(player2.getMv5AccMod());
            eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv5DgeMod().ToString());
            player2.modifyDGE(player2.getMv5DgeMod());
            //Induces effects?
            if (player2.getMv5indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                player1.induceStun();
            }
            if (player2.getMv5indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                player1.inducePoison();
            }
            if (player2.getMv5indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                player1.induceBurn();
            }
            if (player2.getMv5indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                player1.induceCripple();
            }
            if (player2.getMv5indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                player1.induceFrozen();
            }
            if (player2.getMv5indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                player1.induceBleeding();
            }
            if (player2.getMv5indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                player1.induceStupefy();
            }
            if (player2.getMv5indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                player1.induceWeak();
            }
            if (player2.getMv5indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                player1.induceDizzy();
            }
        }
            //Visual Stats
        private void loadPlayer1VisualStats()
        {
            p1Name.Text = player1.getName();
            p1Desc.Text = player1.getDesc();
            p1Hp.Value = player1.getHP();
            p1Atk.Value = player1.getAtk();
            p1Def.Value = player1.getDef();
            p1Acc.Value = player1.getAcc();
            p1Dge.Value = player1.getDge();
            p1Mv1.Text = player1.getMv1Name();
            p1Mv1Desc.Text = player1.getMv1Desc();
            p1Mv1AtkM.Value = (decimal)player1.getMv1M();
            p1Mv1Acc.Value = player1.getMv1Acc();
            p1Mv2.Text = player1.getMv2Name();
            p1Mv2Desc.Text = player1.getMv2Desc();
            p1Mv2AtkM.Value = (decimal)player1.getMv2M();
            p1Mv2Acc.Value = player1.getMv2Acc();
            p1Mv3.Text = player1.getMv3Name();
            p1Mv3Desc.Text = player1.getMv3Desc();
            p1Mv3AtkM.Value = (decimal)player1.getMv3M();
            p1Mv3Acc.Value = player1.getMv3Acc();
            p1Mv4.Text = player1.getMv4Name();
            p1Mv4Desc.Text = player1.getMv4Desc();
            p1Mv4AtkM.Value = (decimal)player1.getMv4M();
            p1Mv4Acc.Value = player1.getMv4Acc();
            p1Mv5.Text = player1.getMv5Name();
            p1Mv5Desc.Text = player1.getMv5Desc();
            p1Mv5AtkM.Value = (decimal)player1.getMv5M();
            p1Mv5Acc.Value = player1.getMv5Acc();
            if (player1.getIsStunned() == true)
            {
                p1Stunned.Text = "YES";
            }
            else
            {
                p1Stunned.Text = "NO";
            }
            if (player1.getIsPoisoned() == true)
            {
                p1Poisoned.Text = "YES";
            }
            else
            {
                p1Poisoned.Text = "NO";
            }
            if (player1.getIsBurned() == true)
            {
                p1Burned.Text = "YES";
            }
            else
            {
                p1Burned.Text = "NO";
            }
            if (player1.getIsCrippled() == true)
            {
                p1Crippled.Text = "YES";
            }
            else
            {
                p1Crippled.Text = "NO";
            }
            if (player1.getIsFrozen() == true)
            {
                p1Frozen.Text = "YES";
            }
            else
            {
                p1Frozen.Text = "NO";
            }
            if (player1.getIsBleeding() == true)
            {
                p1Bleeding.Text = "YES";
            }
            else
            {
                p1Bleeding.Text = "NO";
            }
            if (player1.getIsStupefied() == true)
            {
                p1Stupefied.Text = "YES";
            }
            else
            {
                p1Stupefied.Text = "NO";
            }
            if (player1.getIsWeak() == true)
            {
                p1Weak.Text = "YES";
            }
            else
            {
                p1Weak.Text = "NO";
            }
            if (player1.getIsDizzy() == true)
            {
                p1Dizzy.Text = "YES";
            }
            else
            {
                p1Dizzy.Text = "NO";
            }
            Application.DoEvents();
        }
        private void loadPlayer2VisualStats()
        {
            p2Name.Text = player2.getName();
            p2Desc.Text = player2.getDesc();
            p2Hp.Value = player2.getHP();
            p2Atk.Value = player2.getAtk();
            p2Def.Value = player2.getDef();
            p2Acc.Value = player2.getAcc();
            p2Dge.Value = player2.getDge();
            p2Mv1.Text = player2.getMv1Name();
            p2Mv1Desc.Text = player2.getMv1Desc();
            p2Mv1AtkM.Value = (decimal)player2.getMv1M();
            p2Mv1Acc.Value = player2.getMv1Acc();
            p2Mv2.Text = player2.getMv2Name();
            p2Mv2Desc.Text = player2.getMv2Desc();
            p2Mv2AtkM.Value = (decimal)player2.getMv2M();
            p2Mv2Acc.Value = player2.getMv2Acc();
            p2Mv3.Text = player2.getMv3Name();
            p2Mv3Desc.Text = player2.getMv3Desc();
            p2Mv3AtkM.Value = (decimal)player2.getMv3M();
            p2Mv3Acc.Value = player2.getMv3Acc();
            p2Mv4.Text = player2.getMv4Name();
            p2Mv4Desc.Text = player2.getMv4Desc();
            p2Mv4AtkM.Value = (decimal)player2.getMv4M();
            p2Mv4Acc.Value = player2.getMv4Acc();
            p2Mv5.Text = player2.getMv5Name();
            p2Mv5Desc.Text = player2.getMv5Desc();
            p2Mv5AtkM.Value = (decimal)player2.getMv5M();
            p2Mv5Acc.Value = player2.getMv5Acc();
            if (player2.getIsStunned() == true)
            {
                p2Stunned.Text = "YES";
            }
            else
            {
                p2Stunned.Text = "NO";
            }
            if (player2.getIsPoisoned() == true)
            {
                p2Poisoned.Text = "YES";
            }
            else
            {
                p2Poisoned.Text = "NO";
            }
            if (player2.getIsBurned() == true)
            {
                p2Burned.Text = "YES";
            }
            else
            {
                p2Burned.Text = "NO";
            }
            if (player2.getIsCrippled() == true)
            {
                p2Crippled.Text = "YES";
            }
            else
            {
                p2Crippled.Text = "NO";
            }
            if (player2.getIsFrozen() == true)
            {
                p2Frozen.Text = "YES";
            }
            else
            {
                p2Frozen.Text = "NO";
            }
            if (player2.getIsBleeding() == true)
            {
                p2Bleeding.Text = "YES";
            }
            else
            {
                p2Bleeding.Text = "NO";
            }
            if (player2.getIsStupefied() == true)
            {
                p2Stupefied.Text = "YES";
            }
            else
            {
                p2Stupefied.Text = "NO";
            }
            if (player2.getIsWeak() == true)
            {
                p2Weak.Text = "YES";
            }
            else
            {
                p2Weak.Text = "NO";
            }
            if (player2.getIsDizzy() == true)
            {
                p2Dizzy.Text = "YES";
            }
            else
            {
                p2Dizzy.Text = "NO";
            }
            Application.DoEvents();

        }

        //Character Creation Methods
        private void createCharButton_Click(object sender, EventArgs e)
        {
            disableAllElementalUI();
            enableCharButtonElementalUI();
        }
        private void characterCreationResetButton_Click(object sender, EventArgs e)
        {
            //Character Attr
            CCT1.Text = "";
            CCT2.Text = "";
            CCc1.Text = "";
            CCN40.Value = 0;
            CCN1.Value = 0;
            CCN2.Value = 0;
            CCN3.Value = 0;
            CCN4.Value = 0;
            //Immunities
            CCc2.Text = "";
            CCc3.Text = "";
            CCc4.Text = "";
            CCc5.Text = "";
            CCc6.Text = "";
            CCc7.Text = "";
            CCc8.Text = "";
            CCc9.Text = "";
            CCc10.Text = "";
            CCc11.Text = "";
            //Move 1 Attr
            CCT3.Text = "";
            CCT4.Text = "";
            CCc11.Text = "";
            CCN5.Value = 0;
            CCN6.Value = 0;
            CCN7.Value = 0;
            CCN8.Value = 0;
            CCN9.Value = 0;
            CCN10.Value = 0;
            CCN11.Value = 0;
            //Move 1 Induces
            CCc12.Text = "";
            CCc13.Text = "";
            CCc14.Text = "";
            CCc15.Text = "";
            CCc16.Text = "";
            CCc17.Text = "";
            CCc18.Text = "";
            CCc19.Text = "";
            CCc20.Text = "";
            //Move 2 Attr
            CCT5.Text = "";
            CCT6.Text = "";
            CCc21.Text = "";
            CCN12.Value = 0;
            CCN13.Value = 0;
            CCN14.Value = 0;
            CCN15.Value = 0;
            CCN16.Value = 0;
            CCN17.Value = 0;
            CCN18.Value = 0;
            //Move 2 Induces
            CCc22.Text = "";
            CCc23.Text = "";
            CCc24.Text = "";
            CCc30.Text = "";
            CCc25.Text = "";
            CCc26.Text = "";
            CCc27.Text = "";
            CCc28.Text = "";
            CCc29.Text = "";
            //Move 3 Attr
            CCT7.Text = "";
            CCT8.Text = "";
            CCc31.Text = "";
            CCN19.Value = 0;
            CCN20.Value = 0;
            CCN21.Value = 0;
            CCN22.Value = 0;
            CCN23.Value = 0;
            CCN24.Value = 0;
            CCN25.Value = 0;
            //Move 3 Induces
            CCc32.Text = "";
            CCc33.Text = "";
            CCc34.Text = "";
            CCc35.Text = "";
            CCc36.Text = "";
            CCc37.Text = "";
            CCc38.Text = "";
            CCc39.Text = "";
            CCc40.Text = "";
            //Move 4 Attr
            CCT9.Text = "";
            CCT10.Text = "";
            CCc41.Text = "";
            CCN26.Value = 0;
            CCN27.Value = 0;
            CCN28.Value = 0;
            CCN29.Value = 0;
            CCN30.Value = 0;
            CCN31.Value = 0;
            CCN32.Value = 0;
            //Move 4 Induces
            CCc42.Text = "";
            CCc43.Text = "";
            CCc44.Text = "";
            CCc45.Text = "";
            CCc46.Text = "";
            CCc47.Text = "";
            CCc48.Text = "";
            CCc49.Text = "";
            CCc50.Text = "";
            //Move 5 Attr
            CCT11.Text = "";
            CCT12.Text = "";
            CCc51.Text = "";
            CCN33.Value = 0;
            CCN34.Value = 0;
            CCN35.Value = 0;
            CCN36.Value = 0;
            CCN37.Value = 0;
            CCN38.Value = 0;
            CCN39.Value = 0;
            //Move 5 Induces
            CCc52.Text = "";
            CCc53.Text = "";
            CCc54.Text = "";
            CCc55.Text = "";
            CCc56.Text = "";
            CCc57.Text = "";
            CCc58.Text = "";
            CCc59.Text = "";
            CCc60.Text = "";
        }
        //Export a Build
        private void exportCharStringButton_Click(object sender, EventArgs e)
        {
            //Generate the string
            ImportExportString importExportString = new ImportExportString();
            //General Attr
            string n = CCT1.Text;
            string d = CCT2.Text;
            string t = CCc1.Text;
            string[] ndt = new string[3];
            ndt[0] = n;
            ndt[1] = d;
            ndt[2] = t;
            for(int i = 0; i < ndt.Length; i++)
            {
                bool able = checkStringRestrictions(ndt[i]);
                if(able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type.");
                    return;
                }
            }
            int hp = (int)CCN40.Value;
            int atk = (int)CCN1.Value;
            int def = (int)CCN2.Value;
            int acc = (int)CCN3.Value;
            int dge = (int)CCN4.Value;
            importExportString.generateAttributesStringPart(n, d, t, hp, atk, def, acc, dge);
            //Immunities Attr
            bool[] immunities = new bool[9];
            string[] imnSel = new string[9];
            imnSel[0] = CCc2.Text;
            imnSel[1] = CCc3.Text;
            imnSel[2] = CCc4.Text;
            imnSel[3] = CCc5.Text;
            imnSel[4] = CCc6.Text;
            imnSel[5] = CCc7.Text;
            imnSel[6] = CCc8.Text;
            imnSel[7] = CCc9.Text;
            imnSel[8] = CCc10.Text;
            for(int i = 0; i < imnSel.Length; i++)
            {
                if(imnSel[i] == "YES")
                {
                    immunities[i] = true;
                }
                else if(imnSel[i] == "NO")
                {
                    immunities[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's immunity. Please check immunities and try again.");
                    return;
                }
            }
            importExportString.generateImmunitiesStringPart(immunities);
            //Move 1 Attr
            string m1n = CCT3.Text;
            string m1d = CCT4.Text;
            string m1t = CCc11.Text;
            string[] m1s = new string[3];
            m1s[0] = m1n;
            m1s[1] = m1d;
            m1s[2] = m1t;
            for (int i = 0; i < m1s.Length; i++)
            {
                bool able = checkStringRestrictions(m1s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 1.");
                    return;
                }
            }
            float m1atkmm = (float)CCN5.Value;
            int m1acc = (int)CCN6.Value;
            int m1h = (int)CCN7.Value;
            int m1atkM = (int)CCN8.Value;
            int m1defM = (int)CCN9.Value;
            int m1accM = (int)CCN10.Value;
            int m1dgeM = (int)CCN11.Value;
            bool[] move1InducesBools = new bool[9];
            string[] move1InducesSelections = new string[9];
            move1InducesSelections[0] = CCc12.Text;
            move1InducesSelections[1] = CCc13.Text;
            move1InducesSelections[2] = CCc14.Text;
            move1InducesSelections[3] = CCc15.Text;
            move1InducesSelections[4] = CCc16.Text;
            move1InducesSelections[5] = CCc17.Text;
            move1InducesSelections[6] = CCc18.Text;
            move1InducesSelections[7] = CCc19.Text;
            move1InducesSelections[8] = CCc20.Text;
            for(int i = 0; i < move1InducesSelections.Length; i++)
            {
                if(move1InducesSelections[i] == "YES")
                {
                    move1InducesBools[i] = true;
                }else if(move1InducesSelections[i] == "NO")
                {
                    move1InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 1 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveOneStringPart(m1n, m1d, m1t, m1atkmm, m1acc, m1h, m1atkM, m1defM, m1accM, m1dgeM, move1InducesBools);
            //Move 2
            string m2n = CCT5.Text;
            string m2d = CCT6.Text;
            string m2t = CCc21.Text;
            string[] m2s = new string[3];
            m2s[0] = m2n;
            m2s[1] = m2d;
            m2s[2] = m2t;
            for (int i = 0; i < m2s.Length; i++)
            {
                bool able = checkStringRestrictions(m2s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 2.");
                    return;
                }
            }
            float m2atkmm = (float)CCN12.Value;
            int m2acc = (int)CCN13.Value;
            int m2h = (int)CCN14.Value;
            int m2atkM = (int)CCN15.Value;
            int m2defM = (int)CCN16.Value;
            int m2accM = (int)CCN17.Value;
            int m2dgeM = (int)CCN18.Value;
            bool[] move2InducesBools = new bool[9];
            string[] move2InducesSelections = new string[9];
            move2InducesSelections[0] = CCc22.Text;
            move2InducesSelections[1] = CCc23.Text;
            move2InducesSelections[2] = CCc24.Text;
            move2InducesSelections[3] = CCc30.Text;
            move2InducesSelections[4] = CCc25.Text;
            move2InducesSelections[5] = CCc26.Text;
            move2InducesSelections[6] = CCc27.Text;
            move2InducesSelections[7] = CCc28.Text;
            move2InducesSelections[8] = CCc29.Text;
            for (int i = 0; i < move2InducesSelections.Length; i++)
            {
                if (move2InducesSelections[i] == "YES")
                {
                    move2InducesBools[i] = true;
                }
                else if (move2InducesSelections[i] == "NO")
                {
                    move2InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 2 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveTwoStringPart(m2n, m2d, m2t, m2atkmm, m2acc, m2h, m2atkM, m2defM, m2accM, m2dgeM, move2InducesBools);
            //Move 3
            string m3n = CCT7.Text;
            string m3d = CCT8.Text;
            string m3t = CCc31.Text;
            string[] m3s = new string[3];
            m3s[0] = m3n;
            m3s[1] = m3d;
            m3s[2] = m3t;
            for (int i = 0; i < m3s.Length; i++)
            {
                bool able = checkStringRestrictions(m3s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 3.");
                    return;
                }
            }
            float m3atkmm = (float)CCN19.Value;
            int m3acc = (int)CCN20.Value;
            int m3h = (int)CCN21.Value;
            int m3atkM = (int)CCN22.Value;
            int m3defM = (int)CCN23.Value;
            int m3accM = (int)CCN24.Value;
            int m3dgeM = (int)CCN25.Value;
            bool[] move3InducesBools = new bool[9];
            string[] move3InducesSelections = new string[9];
            move3InducesSelections[0] = CCc32.Text;
            move3InducesSelections[1] = CCc33.Text;
            move3InducesSelections[2] = CCc34.Text;
            move3InducesSelections[3] = CCc35.Text;
            move3InducesSelections[4] = CCc36.Text;
            move3InducesSelections[5] = CCc37.Text;
            move3InducesSelections[6] = CCc38.Text;
            move3InducesSelections[7] = CCc39.Text;
            move3InducesSelections[8] = CCc40.Text;
            for (int i = 0; i < move3InducesSelections.Length; i++)
            {
                if (move3InducesSelections[i] == "YES")
                {
                    move3InducesBools[i] = true;
                }
                else if (move3InducesSelections[i] == "NO")
                {
                    move3InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 3 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveThreeStringPart(m3n, m3d, m3t, m3atkmm, m3acc, m3h, m3atkM, m3defM, m3accM, m3dgeM, move3InducesBools);
            //Move 4
            string m4n = CCT9.Text;
            string m4d = CCT10.Text;
            string m4t = CCc41.Text;
            string[] m4s = new string[3];
            m4s[0] = m4n;
            m4s[1] = m4d;
            m4s[2] = m4t;
            for (int i = 0; i < m4s.Length; i++)
            {
                bool able = checkStringRestrictions(m4s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 4.");
                    return;
                }
            }
            float m4atkmm = (float)CCN26.Value;
            int m4acc = (int)CCN27.Value;
            int m4h = (int)CCN28.Value;
            int m4atkM = (int)CCN29.Value;
            int m4defM = (int)CCN30.Value;
            int m4accM = (int)CCN31.Value;
            int m4dgeM = (int)CCN32.Value;
            bool[] move4InducesBools = new bool[9];
            string[] move4InducesSelections = new string[9];
            move4InducesSelections[0] = CCc42.Text;
            move4InducesSelections[1] = CCc43.Text;
            move4InducesSelections[2] = CCc44.Text;
            move4InducesSelections[3] = CCc45.Text;
            move4InducesSelections[4] = CCc46.Text;
            move4InducesSelections[5] = CCc47.Text;
            move4InducesSelections[6] = CCc48.Text;
            move4InducesSelections[7] = CCc49.Text;
            move4InducesSelections[8] = CCc50.Text;
            for (int i = 0; i < move4InducesSelections.Length; i++)
            {
                if (move4InducesSelections[i] == "YES")
                {
                    move4InducesBools[i] = true;
                }
                else if (move4InducesSelections[i] == "NO")
                {
                    move4InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 4 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveFourStringPart(m4n, m4d, m4t, m4atkmm, m4acc, m4h, m4atkM, m4defM, m4accM, m4dgeM, move4InducesBools);
            //Move 5
            string m5n = CCT11.Text;
            string m5d = CCT12.Text;
            string m5t = CCc51.Text;
            string[] m5s = new string[3];
            m5s[0] = m5n;
            m5s[1] = m5d;
            m5s[2] = m5t;
            for (int i = 0; i < m5s.Length; i++)
            {
                bool able = checkStringRestrictions(m5s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 5.");
                    return;
                }
            }
            float m5atkmm = (float)CCN33.Value;
            int m5acc = (int)CCN34.Value;
            int m5h = (int)CCN35.Value;
            int m5atkM = (int)CCN36.Value;
            int m5defM = (int)CCN37.Value;
            int m5accM = (int)CCN38.Value;
            int m5dgeM = (int)CCN39.Value;
            bool[] move5InducesBools = new bool[9];
            string[] move5InducesSelections = new string[9];
            move5InducesSelections[0] = CCc52.Text;
            move5InducesSelections[1] = CCc53.Text;
            move5InducesSelections[2] = CCc54.Text;
            move5InducesSelections[3] = CCc55.Text;
            move5InducesSelections[4] = CCc56.Text;
            move5InducesSelections[5] = CCc57.Text;
            move5InducesSelections[6] = CCc58.Text;
            move5InducesSelections[7] = CCc59.Text;
            move5InducesSelections[8] = CCc60.Text;
            for (int i = 0; i < move5InducesSelections.Length; i++)
            {
                if (move5InducesSelections[i] == "YES")
                {
                    move5InducesBools[i] = true;
                }
                else if (move5InducesSelections[i] == "NO")
                {
                    move5InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 5 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveFiveStringPart(m5n, m5d, m5t, m5atkmm, m5acc, m5h, m5atkM, m5defM, m5accM, m5dgeM, move5InducesBools);
            //Get
            exportStringTextBox.Text = importExportString.getImportExportString();
        }
        private bool checkStringRestrictions(string s)
        {
            //General parameter checks
            if(s == null || s == "" || s == "nX!wj@am!E" || s == "d@3MDMe#SC" || s == "t192y!@:PE22" || s == "at1!@!W0k" || s == "d%%23eFF" || s == "a1;c';c" || s == "dj1g><e" || s == "imnSTRT@@_!" || s == "imnEND@@_!")
            {
                return false;
            }
            //Move 1 checks
            else if(s == "nDCMmv1@@" || s == "dDCMv1@@" || s == "tDCMmv1@@" || s == "atmDCMmv1@@" || s == "accDCMmv1@@" || s == "hDCMmv1@@" || s == "atkDCMmv1@@" || s == "defDCMmv1@@" || s == "acmDCMmv1@@" || s == "dgeDCMmv1@@" || s == "indSTRTMmv1@@_!" || s == "indENDMmv1@@_!")
            {
                return false;
            }
            //Move 2 checks
            else if (s == "nDCMmv2@@" || s == "dDCMv2@@" || s == "tDCMmv2@@" || s == "atmDCMmv2@@" || s == "accDCMmv2@@" || s == "hDCMmv2@@" || s == "atkDCMmv2@@" || s == "defDCMmv2@@" || s == "acmDCMmv2@@" || s == "dgeDCMmv2@@" || s == "indSTRTMmv2@@_!" || s == "indENDMmv2@@_!")
            {
                return false;
            }
            //Move 3 checks
            else if (s == "nDCMmv3@@" || s == "dDCMv3@@" || s == "tDCMmv3@@" || s == "atmDCMmv3@@" || s == "accDCMmv3@@" || s == "hDCMmv3@@" || s == "atkDCMmv3@@" || s == "defDCMmv3@@" || s == "acmDCMmv3@@" || s == "dgeDCMmv3@@" || s == "indSTRTMmv3@@_!" || s == "indENDMmv3@@_!")
            {
                return false;
            }
            //Move 4 checks
            else if (s == "nDCMmv4@@" || s == "dDCMv4@@" || s == "tDCMmv4@@" || s == "atmDCMmv4@@" || s == "accDCMmv4@@" || s == "hDCMmv4@@" || s == "atkDCMmv4@@" || s == "defDCMmv4@@" || s == "acmDCMmv4@@" || s == "dgeDCMmv4@@" || s == "indSTRTMmv4@@_!" || s == "indENDMmv4@@_!")
            {
                return false;
            }
            //Move 5 checks
            else if (s == "nDCMmv5@@" || s == "dDCMv5@@" || s == "tDCMmv5@@" || s == "atmDCMmv5@@" || s == "accDCMmv5@@" || s == "hDCMmv5@@" || s == "atkDCMmv5@@" || s == "defDCMmv5@@" || s == "acmDCMmv5@@" || s == "dgeDCMmv5@@" || s == "indSTRTMmv5@@_!" || s == "indENDMmv5@@_!")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
            //Import a Build
        private void loadBuildButton_Click(object sender, EventArgs e)
        {
            string importString = loadBuildTextBox.Text;
            //Perform Checks first
            if(checkImportString(importString) == true)
            {
                Character loadedBuild = new Character(importString);
                loadBuildVisually(loadedBuild);
                System.Windows.Forms.MessageBox.Show("Build successfully loaded!");
            }
        }
        private void loadBuildVisually(Character character)
        {
            //Character Attr
            CCT1.Text = character.getName();
            CCT2.Text = character.getDesc();
            CCc1.Text = character.getType();
            CCN40.Value = character.getHP();
            CCN1.Value = character.getAtk();
            CCN2.Value = character.getDef();
            CCN3.Value = character.getAcc();
            CCN4.Value = character.getDge();
            //Immunities
            if(character.getimnStun() == true)
            {
                CCc2.Text = "YES";
            }
            else
            {
                CCc2.Text = "NO";
            }
            if (character.getimnPsn() == true)
            {
                CCc3.Text = "YES";
            }
            else
            {
                CCc3.Text = "NO";
            }
            if (character.getimnBrn() == true)
            {
                CCc4.Text = "YES";
            }
            else
            {
                CCc4.Text = "NO";
            }
            if (character.getimnCrpl() == true)
            {
                CCc5.Text = "YES";
            }
            else
            {
                CCc5.Text = "NO";
            }
            if (character.getimnFrzn() == true)
            {
                CCc6.Text = "YES";
            }
            else
            {
                CCc6.Text = "NO";
            }
            if (character.getimnFrzn() == true)
            {
                CCc7.Text = "YES";
            }
            else
            {
                CCc7.Text = "NO";
            }
            if (character.getimnBld() == true)
            {
                CCc8.Text = "YES";
            }
            else
            {
                CCc8.Text = "NO";
            }
            if (character.getimnStpf() == true)
            {
                CCc9.Text = "YES";
            }
            else
            {
                CCc9.Text = "NO";
            }
            if (character.getimnWk() == true)
            {
                CCc10.Text = "YES";
            }
            else
            {
                CCc10.Text = "NO";
            }
            if (character.getimnDzz() == true)
            {
                CCc11.Text = "YES";
            }
            else
            {
                CCc11.Text = "NO";
            }
            //Move 1 Attr
            CCT3.Text = character.getMv1Name();
            CCT4.Text = character.getMv1Desc();
            CCc11.Text = character.getMv1Type();
            CCN5.Value = (decimal)character.getMv1M();
            CCN6.Value = character.getMv1Acc();
            CCN7.Value = character.getMv1Heal();
            CCN8.Value = character.getMv1AtkMod();
            CCN9.Value = character.getMv1DefMod();
            CCN10.Value = character.getMv1AccMod();
            CCN11.Value = character.getMv1DgeMod();
            //Move 1 Induces
            if(character.getMv1indStun() == true)
            {
                CCc12.Text = "YES";
            }
            else
            {
                CCc12.Text = "NO";
            }
            if (character.getMv1indPsn() == true)
            {
                CCc13.Text = "YES";
            }
            else
            {
                CCc13.Text = "NO";
            }
            if (character.getMv1indBrn() == true)
            {
                CCc14.Text = "YES";
            }
            else
            {
                CCc14.Text = "NO";
            }
            if (character.getMv1indCrpl() == true)
            {
                CCc15.Text = "YES";
            }
            else
            {
                CCc15.Text = "NO";
            }
            if (character.getMv1indFrzn() == true)
            {
                CCc16.Text = "YES";
            }
            else
            {
                CCc16.Text = "NO";
            }
            if (character.getMv1indBld() == true)
            {
                CCc17.Text = "YES";
            }
            else
            {
                CCc17.Text = "NO";
            }
            if (character.getMv1indStpf() == true)
            {
                CCc18.Text = "YES";
            }
            else
            {
                CCc18.Text = "NO";
            }
            if (character.getMv1indWk() == true)
            {
                CCc19.Text = "YES";
            }
            else
            {
                CCc19.Text = "NO";
            }
            if (character.getMv1indDzz() == true)
            {
                CCc20.Text = "YES";
            }
            else
            {
                CCc20.Text = "NO";
            }
            //Move 2 Attr
            CCT5.Text = character.getMv2Name();
            CCT6.Text = character.getMv2Desc();
            CCc21.Text = character.getMv2Type();
            CCN12.Value = (decimal)character.getMv2M();
            CCN13.Value = character.getMv2Acc();
            CCN14.Value = character.getMv2Heal();
            CCN15.Value = character.getMv2AtkMod();
            CCN16.Value = character.getMv2DefMod();
            CCN17.Value = character.getMv2AccMod();
            CCN18.Value = character.getMv2DgeMod();
            //Move 2 Induces
            if (character.getMv2indStun() == true)
            {
                CCc22.Text = "YES";
            }
            else
            {
                CCc22.Text = "NO";
            }
            if (character.getMv2indPsn() == true)
            {
                CCc23.Text = "YES";
            }
            else
            {
                CCc23.Text = "NO";
            }
            if (character.getMv2indBrn() == true)
            {
                CCc24.Text = "YES";
            }
            else
            {
                CCc24.Text = "NO";
            }
            if (character.getMv2indCrpl() == true)
            {
                CCc30.Text = "YES";
            }
            else
            {
                CCc30.Text = "NO";
            }
            if (character.getMv2indFrzn() == true)
            {
                CCc25.Text = "YES";
            }
            else
            {
                CCc25.Text = "NO";
            }
            if (character.getMv2indBld() == true)
            {
                CCc26.Text = "YES";
            }
            else
            {
                CCc26.Text = "NO";
            }
            if (character.getMv2indStpf() == true)
            {
                CCc27.Text = "YES";
            }
            else
            {
                CCc27.Text = "NO";
            }
            if (character.getMv2indWk() == true)
            {
                CCc28.Text = "YES";
            }
            else
            {
                CCc28.Text = "NO";
            }
            if (character.getMv2indDzz() == true)
            {
                CCc29.Text = "YES";
            }
            else
            {
                CCc29.Text = "NO";
            }
            //Move 3 Attr
            CCT7.Text = character.getMv3Name();
            CCT8.Text = character.getMv3Desc();
            CCc31.Text = character.getMv3Type();
            CCN19.Value = (decimal)character.getMv3M();
            CCN20.Value = character.getMv3Acc();
            CCN21.Value = character.getMv3Heal();
            CCN22.Value = character.getMv3AtkMod();
            CCN23.Value = character.getMv3DefMod();
            CCN24.Value = character.getMv3AccMod();
            CCN25.Value = character.getMv3DgeMod();
            //Move 3 Induces
            if (character.getMv3indStun() == true)
            {
                CCc32.Text = "YES";
            }
            else
            {
                CCc32.Text = "NO";
            }
            if (character.getMv3indPsn() == true)
            {
                CCc33.Text = "YES";
            }
            else
            {
                CCc33.Text = "NO";
            }
            if (character.getMv3indBrn() == true)
            {
                CCc34.Text = "YES";
            }
            else
            {
                CCc34.Text = "NO";
            }
            if (character.getMv3indCrpl() == true)
            {
                CCc35.Text = "YES";
            }
            else
            {
                CCc35.Text = "NO";
            }
            if (character.getMv3indFrzn() == true)
            {
                CCc36.Text = "YES";
            }
            else
            {
                CCc36.Text = "NO";
            }
            if (character.getMv3indBld() == true)
            {
                CCc37.Text = "YES";
            }
            else
            {
                CCc37.Text = "NO";
            }
            if (character.getMv3indStpf() == true)
            {
                CCc38.Text = "YES";
            }
            else
            {
                CCc38.Text = "NO";
            }
            if (character.getMv3indWk() == true)
            {
                CCc39.Text = "YES";
            }
            else
            {
                CCc39.Text = "NO";
            }
            if (character.getMv3indDzz() == true)
            {
                CCc40.Text = "YES";
            }
            else
            {
                CCc40.Text = "NO";
            }
            //Move 4 Attr
            CCT9.Text = character.getMv4Name();
            CCT10.Text = character.getMv4Desc();
            CCc41.Text = character.getMv4Type();
            CCN26.Value = (decimal)character.getMv4M();
            CCN27.Value = character.getMv4Acc();
            CCN28.Value = character.getMv4Heal();
            CCN29.Value = character.getMv4AtkMod();
            CCN30.Value = character.getMv4DefMod();
            CCN31.Value = character.getMv4AccMod();
            CCN32.Value = character.getMv4DgeMod();
            //Move 4 Induces
            if (character.getMv4indStun() == true)
            {
                CCc42.Text = "YES";
            }
            else
            {
                CCc42.Text = "NO";
            }
            if (character.getMv4indPsn() == true)
            {
                CCc43.Text = "YES";
            }
            else
            {
                CCc43.Text = "NO";
            }
            if (character.getMv4indBrn() == true)
            {
                CCc44.Text = "YES";
            }
            else
            {
                CCc44.Text = "NO";
            }
            if (character.getMv4indCrpl() == true)
            {
                CCc45.Text = "YES";
            }
            else
            {
                CCc45.Text = "NO";
            }
            if (character.getMv4indFrzn() == true)
            {
                CCc46.Text = "YES";
            }
            else
            {
                CCc46.Text = "NO";
            }
            if (character.getMv4indBld() == true)
            {
                CCc47.Text = "YES";
            }
            else
            {
                CCc47.Text = "NO";
            }
            if (character.getMv4indStpf() == true)
            {
                CCc48.Text = "YES";
            }
            else
            {
                CCc48.Text = "NO";
            }
            if (character.getMv4indWk() == true)
            {
                CCc49.Text = "YES";
            }
            else
            {
                CCc49.Text = "NO";
            }
            if (character.getMv4indDzz() == true)
            {
                CCc50.Text = "YES";
            }
            else
            {
                CCc50.Text = "NO";
            }
            //Move 5 Attr
            CCT11.Text = character.getMv5Name();
            CCT12.Text = character.getMv5Desc();
            CCc51.Text = character.getMv5Type();
            CCN33.Value = (decimal)character.getMv5M();
            CCN34.Value = character.getMv5Acc();
            CCN35.Value = character.getMv5Heal();
            CCN36.Value = character.getMv5AtkMod();
            CCN37.Value = character.getMv5DefMod();
            CCN38.Value = character.getMv5AccMod();
            CCN39.Value = character.getMv5DgeMod();
            //Move 5 Induces
            if (character.getMv5indStun() == true)
            {
                CCc52.Text = "YES";
            }
            else
            {
                CCc52.Text = "NO";
            }
            if (character.getMv5indPsn() == true)
            {
                CCc53.Text = "YES";
            }
            else
            {
                CCc53.Text = "NO";
            }
            if (character.getMv5indBrn() == true)
            {
                CCc54.Text = "YES";
            }
            else
            {
                CCc54.Text = "NO";
            }
            if (character.getMv5indCrpl() == true)
            {
                CCc55.Text = "YES";
            }
            else
            {
                CCc55.Text = "NO";
            }
            if (character.getMv5indFrzn() == true)
            {
                CCc56.Text = "YES";
            }
            else
            {
                CCc56.Text = "NO";
            }
            if (character.getMv5indBld() == true)
            {
                CCc57.Text = "YES";
            }
            else
            {
                CCc57.Text = "NO";
            }
            if (character.getMv5indStpf() == true)
            {
                CCc58.Text = "YES";
            }
            else
            {
                CCc58.Text = "NO";
            }
            if (character.getMv5indWk() == true)
            {
                CCc59.Text = "YES";
            }
            else
            {
                CCc59.Text = "NO";
            }
            if (character.getMv5indDzz() == true)
            {
                CCc60.Text = "YES";
            }
            else
            {
                CCc60.Text = "NO";
            }
        }
        private bool checkImportString(string importString)
        {
            //Main attributes
                //Name
            int descriptionLocatorStartIndex = importString.IndexOf("d@3MDMe#SC");
            if(descriptionLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'description' indicator.");
                return false;
            }
            int nameLocatorEndIndex = importString.IndexOf("nX!wj@am!E");
            if (nameLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'character name' indicator.");
                return false;
            }
            nameLocatorEndIndex = 9;
            if(descriptionLocatorStartIndex - 9 <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character name.");
                return false;
            }
            else if(checkStringRestrictions(importString.Substring(10, descriptionLocatorStartIndex - 9)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character name.");
                return false;
            }
                //Description
            int typeLocatorStartIndex = importString.IndexOf("t192y!@:PE22");
            if (typeLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'type' indicator.");
                return false;
            }
            int descriptionLocatorEndIndex = importString.IndexOf("d@3MDMe#SC");
            if (descriptionLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'description' indicator.");
                return false;
            }
            descriptionLocatorEndIndex = importString.IndexOf("d@3MDMe#SC") + "d@3MDMe#SC".Length - 1;
            if (typeLocatorStartIndex - descriptionLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character description.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(descriptionLocatorEndIndex + 1, typeLocatorStartIndex - descriptionLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character description.");
                return false;
            }
                //TYPE
            int hpLocatorStartIndex = importString.IndexOf("h!*##p2@<#");
            if (hpLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'HP' indicator 1.");
                return false;
            }
            int typeLocatorEndIndex = importString.IndexOf("t192y!@:PE22");
            if (typeLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Type' indicator.");
                return false;
            }
            typeLocatorEndIndex = importString.IndexOf("t192y!@:PE22") + "t192y!@:PE22".Length - 1;
            if (hpLocatorStartIndex - typeLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character type.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(typeLocatorEndIndex + 1, hpLocatorStartIndex - typeLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character type.");
                return false;
            }
                //HP
            int atkLocatorStartIndex = importString.IndexOf("at1!@!W0k");
            if (atkLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Attack' indicator.");
                return false;
            }
            int hpLocatorEndIndex = importString.IndexOf("h!*##p2@<#");
            if (hpLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'HP' indicator. 2");
                return false;
            }
            hpLocatorEndIndex = importString.IndexOf("h!*##p2@<#") + "h!*##p2@<#".Length - 1;
            if (atkLocatorStartIndex - hpLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character HP.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(hpLocatorEndIndex + 1, atkLocatorStartIndex - hpLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character HP.");
                return false;
            }
            //ATK
            int defLocatorStartIndex = importString.IndexOf("d%%23eFF");
            if (defLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Defense' indicator.");
                return false;
            }
            int atkLocatorEndIndex = importString.IndexOf("at1!@!W0k");
            if (atkLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Attack' indicator.");
                return false;
            }
            atkLocatorEndIndex = importString.IndexOf("at1!@!W0k") + "at1!@!W0k".Length - 1;
            if (defLocatorStartIndex - atkLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(atkLocatorEndIndex + 1, defLocatorStartIndex - atkLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character attack value.");
                return false;
            }
                //DEF
            int accLocatorStartIndex = importString.IndexOf("a1;c';c");
            if (accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Accuracy' indicator.");
                return false;
            }
            int defLocatorEndIndex = importString.IndexOf("d%%23eFF");
            if (defLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Defense' indicator.");
                return false;
            }
            defLocatorEndIndex = importString.IndexOf("d%%23eFF") + "d%%23eFF".Length - 1;
            if (accLocatorStartIndex - defLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character defense value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(defLocatorEndIndex + 1, accLocatorStartIndex - defLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character defense value.");
                return false;
            }
                //ACC
            int dgeLocatorStartIndex = importString.IndexOf("dj1g><e");
            if (dgeLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Dodge' indicator.");
                return false;
            }
            int accLocatorEndIndex = importString.IndexOf("a1;c';c");
            if (accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Accuracy' indicator.");
                return false;
            }
            accLocatorEndIndex = importString.IndexOf("a1;c';c") + "a1;c';c".Length - 1;
            if (dgeLocatorStartIndex - accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(accLocatorEndIndex + 1, dgeLocatorStartIndex - accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character accuracy value.");
                return false;
            }
                //DGE
            int imnLocatorStartIndex = importString.IndexOf("imnSTRT@@_!");
            if (imnLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Immunities Start' indicator.");
                return false;
            }
            int dgeLocatorEndIndex = importString.IndexOf("dj1g><e");
            if (dgeLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Dodge' indicator.");
                return false;
            }
            dgeLocatorEndIndex = importString.IndexOf("dj1g><e") + "dj1g><e".Length - 1;
            if (imnLocatorStartIndex - dgeLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Dodge value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(dgeLocatorEndIndex + 1, imnLocatorStartIndex - dgeLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Dodge value.");
                return false;
            }
                //IMMUNITIES
            int imn2LocatorStartIndex = importString.IndexOf("imnEND@@_!");
            if (imn2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Immunities End' indicator.");
                return false;
            }
            int imnLocatorEndIndex = importString.IndexOf("imnSTRT@@_!");
            if (imnLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Immunities Start' indicator.");
                return false;
            }
            imnLocatorEndIndex = importString.IndexOf("imnSTRT@@_!") + "imnSTRT@@_!".Length - 1;
            if (imn2LocatorStartIndex - imnLocatorEndIndex !=10)
            {
                System.Windows.Forms.MessageBox.Show("Error with character immunities data 1.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(imnLocatorEndIndex + 1, imn2LocatorStartIndex - imnLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character immunities data 2.");
                return false;
            }
            else
            {
                string check = importString.Substring(imnLocatorEndIndex + 1, 9);
                for(int i = 0; i < check.Length; i++)
                {
                    if(check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with character immunities data 3.");
                        return false;
                    }
                }
            }
                //Move 1 Name
            int mv1dLocatorStartIndex = importString.IndexOf("dDCMv1@@");
            if (mv1dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Description' indicator.");
                return false;
            }
            int mv1nLocatorEndIndex = importString.IndexOf("nDCMmv1@@");
            if (mv1nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Name' indicator.");
                return false;
            }
            mv1nLocatorEndIndex = importString.IndexOf("nDCMmv1@@") + "nDCMmv1@@".Length - 1;
            if (mv1dLocatorStartIndex - mv1nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1nLocatorEndIndex + 1, mv1dLocatorStartIndex - mv1nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Name value.");
                return false;
            }
                //Move 1 Desc
            int mv1tLocatorStartIndex = importString.IndexOf("tDCMmv1@@");
            if (mv1tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Type' indicator.");
                return false;
            }
            int mv1dLocatorEndIndex = importString.IndexOf("dDCMv1@@");
            if (mv1dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Description' indicator.");
                return false;
            }
            mv1dLocatorEndIndex = importString.IndexOf("dDCMv1@@") + "dDCMv1@@".Length - 1;
            if (mv1tLocatorStartIndex - mv1dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1dLocatorEndIndex + 1, mv1tLocatorStartIndex - mv1dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Description value.");
                return false;
            }
                //Move 1 Type
            int mv1atmLocatorStartIndex = importString.IndexOf("atmDCMmv1@@");
            if (mv1atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack' indicator.");
                return false;
            }
            int mv1tLocatorEndIndex = importString.IndexOf("tDCMmv1@@");
            if (mv1tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Type' indicator.");
                return false;
            }
            mv1tLocatorEndIndex = importString.IndexOf("tDCMmv1@@") + "tDCMmv1@@".Length - 1;
            if (mv1atmLocatorStartIndex - mv1tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1tLocatorEndIndex + 1, mv1atmLocatorStartIndex - mv1tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Type value.");
                return false;
            }
                //Move 1 Atk Multiplier
            int mv1accLocatorStartIndex = importString.IndexOf("accDCMmv1@@");
            if (mv1accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy' indicator.");
                return false;
            }
            int mv1atmLocatorEndIndex = importString.IndexOf("atmDCMmv1@@");
            if (mv1atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack' indicator.");
                return false;
            }
            mv1atmLocatorEndIndex = importString.IndexOf("atmDCMmv1@@") + "atmDCMmv1@@".Length - 1;
            if (mv1accLocatorStartIndex - mv1atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1atmLocatorEndIndex + 1, mv1accLocatorStartIndex - mv1atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack value.");
                return false;
            }
                //Move 1 Accuracy
            int mv1hLocatorStartIndex = importString.IndexOf("hDCMmv1@@");
            if (mv1hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Healing' indicator.");
                return false;
            }
            int mv1accLocatorEndIndex = importString.IndexOf("accDCMmv1@@");
            if (mv1accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy' indicator.");
                return false;
            }
            mv1accLocatorEndIndex = importString.IndexOf("accDCMmv1@@") + "accDCMmv1@@".Length - 1;
            if (mv1hLocatorStartIndex - mv1accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1accLocatorEndIndex + 1, mv1hLocatorStartIndex - mv1accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy value.");
                return false;
            }
                //Move 1 Healing
            int mv1atkMLocatorStartIndex = importString.IndexOf("atkDCMmv1@@");
            if (mv1atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack Modifier' indicator.");
                return false;
            }
            int mv1hLocatorEndIndex = importString.IndexOf("hDCMmv1@@");
            if (mv1hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Healing' indicator.");
                return false;
            }
            mv1hLocatorEndIndex = importString.IndexOf("hDCMmv1@@") + "hDCMmv1@@".Length - 1;
            if (mv1atkMLocatorStartIndex - mv1hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1hLocatorEndIndex + 1, mv1atkMLocatorStartIndex - mv1hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Healing value.");
                return false;
            }
                //Move 1 Attack Modifier
            int mv1defMLocatorStartIndex = importString.IndexOf("defDCMmv1@@");
            if (mv1defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Defense Modifier' indicator.");
                return false;
            }
            int mv1atkMLocatorEndIndex = importString.IndexOf("atkDCMmv1@@");
            if (mv1atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack Modifier' indicator.");
                return false;
            }
            mv1atkMLocatorEndIndex = importString.IndexOf("atkDCMmv1@@") + "atkDCMmv1@@".Length - 1;
            if (mv1defMLocatorStartIndex - mv1atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1atkMLocatorEndIndex + 1, mv1defMLocatorStartIndex - mv1atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack Modifier value.");
                return false;
            }
                //Move 1 Defense Modifier
            int mv1accMLocatorStartIndex = importString.IndexOf("acmDCMmv1@@");
            if (mv1accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy Modifier' indicator.");
                return false;
            }
            int mv1defMLocatorEndIndex = importString.IndexOf("defDCMmv1@@");
            if (mv1defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Defense Modifier' indicator.");
                return false;
            }
            mv1defMLocatorEndIndex = importString.IndexOf("defDCMmv1@@") + "defDCMmv1@@".Length - 1;
            if (mv1accMLocatorStartIndex - mv1defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1defMLocatorEndIndex + 1, mv1accMLocatorStartIndex - mv1defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Defense Modifier value.");
                return false;
            }
                //Move 1 Accuracy Modifier
            int mv1dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv1@@");
            if (mv1dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Dodge Modifier' indicator.");
                return false;
            }
            int mv1accMLocatorEndIndex = importString.IndexOf("acmDCMmv1@@");
            if (mv1accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy Modifier' indicator.");
                return false;
            }
            mv1accMLocatorEndIndex = importString.IndexOf("acmDCMmv1@@") + "acmDCMmv1@@".Length - 1;
            if (mv1dgeMLocatorStartIndex - mv1accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1accMLocatorEndIndex + 1, mv1dgeMLocatorStartIndex - mv1accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy Modifier value.");
                return false;
            }
                //Move 1 Dodge Modifier
            int mv1indMLocatorStartIndex = importString.IndexOf("indSTRTMmv1@@_!");
            if (mv1indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Induces Start' indicator.");
                return false;
            }
            int mv1dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv1@@");
            if (mv1dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Dodge Modifier' indicator.");
                return false;
            }
            mv1dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv1@@") + "dgeDCMmv1@@".Length - 1;
            if (mv1indMLocatorStartIndex - mv1dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1dgeMLocatorEndIndex + 1, mv1indMLocatorStartIndex - mv1dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Dodge Modifier value.");
                return false;
            }
                //Move 1 Induces
            int mv1ind2LocatorStartIndex = importString.IndexOf("indENDMmv1@@_!");
            if (mv1ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv1indLocatorEndIndex = importString.IndexOf("indSTRTMmv1@@_!");
            if (mv1indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv1indLocatorEndIndex = importString.IndexOf("indSTRTMmv1@@_!") + "indSTRTMmv1@@_!".Length - 1;
            if (mv1ind2LocatorStartIndex - mv1indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 1 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1indLocatorEndIndex + 1, mv1ind2LocatorStartIndex - mv1indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 1 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv1indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 1 Induces data.");
                        return false;
                    }
                }
            }
                //Move 2 Name
            int mv2dLocatorStartIndex = importString.IndexOf("dDCMv2@@");
            if (mv2dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Description' indicator.");
                return false;
            }
            int mv2nLocatorEndIndex = importString.IndexOf("nDCMmv2@@");
            if (mv2nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Name' indicator.");
                return false;
            }
            mv2nLocatorEndIndex = importString.IndexOf("nDCMmv2@@") + "nDCMmv2@@".Length - 1;
            if (mv2dLocatorStartIndex - mv2nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2nLocatorEndIndex + 1, mv2dLocatorStartIndex - mv2nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Name value.");
                return false;
            }
                //Move 2 Desc
            int mv2tLocatorStartIndex = importString.IndexOf("tDCMmv2@@");
            if (mv2tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Type' indicator.");
                return false;
            }
            int mv2dLocatorEndIndex = importString.IndexOf("dDCMv2@@");
            if (mv2dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Description' indicator.");
                return false;
            }
            mv2dLocatorEndIndex = importString.IndexOf("dDCMv2@@") + "dDCMv2@@".Length - 1;
            if (mv2tLocatorStartIndex - mv2dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2dLocatorEndIndex + 1, mv2tLocatorStartIndex - mv2dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Description value.");
                return false;
            }
                //Move 2 Type
            int mv2atmLocatorStartIndex = importString.IndexOf("atmDCMmv2@@");
            if (mv2atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack' indicator.");
                return false;
            }
            int mv2tLocatorEndIndex = importString.IndexOf("tDCMmv2@@");
            if (mv2tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Type' indicator.");
                return false;
            }
            mv2tLocatorEndIndex = importString.IndexOf("tDCMmv2@@") + "tDCMmv2@@".Length - 1;
            if (mv2atmLocatorStartIndex - mv2tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2tLocatorEndIndex + 1, mv2atmLocatorStartIndex - mv2tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Type value.");
                return false;
            }
                //Move 2 Atk Multiplier
            int mv2accLocatorStartIndex = importString.IndexOf("accDCMmv2@@");
            if (mv2accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy' indicator.");
                return false;
            }
            int mv2atmLocatorEndIndex = importString.IndexOf("atmDCMmv2@@");
            if (mv2atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack' indicator.");
                return false;
            }
            mv2atmLocatorEndIndex = importString.IndexOf("atmDCMmv2@@") + "atmDCMmv2@@".Length - 1;
            if (mv2accLocatorStartIndex - mv2atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2atmLocatorEndIndex + 1, mv2accLocatorStartIndex - mv2atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack value.");
                return false;
            }
                //Move 2 Accuracy
            int mv2hLocatorStartIndex = importString.IndexOf("hDCMmv2@@");
            if (mv2hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Healing' indicator.");
                return false;
            }
            int mv2accLocatorEndIndex = importString.IndexOf("accDCMmv2@@");
            if (mv2accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy' indicator.");
                return false;
            }
            mv2accLocatorEndIndex = importString.IndexOf("accDCMmv2@@") + "accDCMmv2@@".Length - 1;
            if (mv2hLocatorStartIndex - mv2accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2accLocatorEndIndex + 1, mv2hLocatorStartIndex - mv2accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy value.");
                return false;
            }
                //Move 2 Healing
            int mv2atkMLocatorStartIndex = importString.IndexOf("atkDCMmv2@@");
            if (mv2atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack Modifier' indicator.");
                return false;
            }
            int mv2hLocatorEndIndex = importString.IndexOf("hDCMmv2@@");
            if (mv2hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Healing' indicator.");
                return false;
            }
            mv2hLocatorEndIndex = importString.IndexOf("hDCMmv2@@") + "hDCMmv2@@".Length - 1;
            if (mv2atkMLocatorStartIndex - mv2hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2hLocatorEndIndex + 1, mv2atkMLocatorStartIndex - mv2hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Healing value.");
                return false;
            }
                //Move 2 Attack Modifier
            int mv2defMLocatorStartIndex = importString.IndexOf("defDCMmv2@@");
            if (mv2defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Defense Modifier' indicator.");
                return false;
            }
            int mv2atkMLocatorEndIndex = importString.IndexOf("atkDCMmv2@@");
            if (mv2atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack Modifier' indicator.");
                return false;
            }
            mv2atkMLocatorEndIndex = importString.IndexOf("atkDCMmv2@@") + "atkDCMmv2@@".Length - 1;
            if (mv2defMLocatorStartIndex - mv2atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2atkMLocatorEndIndex + 1, mv2defMLocatorStartIndex - mv2atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack Modifier value.");
                return false;
            }
                //Move 2 Defense Modifier
            int mv2accMLocatorStartIndex = importString.IndexOf("acmDCMmv2@@");
            if (mv2accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy Modifier' indicator.");
                return false;
            }
            int mv2defMLocatorEndIndex = importString.IndexOf("defDCMmv2@@");
            if (mv2defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Defense Modifier' indicator.");
                return false;
            }
            mv2defMLocatorEndIndex = importString.IndexOf("defDCMmv2@@") + "defDCMmv2@@".Length - 1;
            if (mv2accMLocatorStartIndex - mv2defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2defMLocatorEndIndex + 1, mv2accMLocatorStartIndex - mv2defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Defense Modifier value.");
                return false;
            }
                //Move 2 Accuracy Modifier
            int mv2dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv2@@");
            if (mv2dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Dodge Modifier' indicator.");
                return false;
            }
            int mv2accMLocatorEndIndex = importString.IndexOf("acmDCMmv2@@");
            if (mv2accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy Modifier' indicator.");
                return false;
            }
            mv2accMLocatorEndIndex = importString.IndexOf("acmDCMmv2@@") + "acmDCMmv2@@".Length - 1;
            if (mv2dgeMLocatorStartIndex - mv2accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2accMLocatorEndIndex + 1, mv2dgeMLocatorStartIndex - mv2accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy Modifier value.");
                return false;
            }
                //Move 2 Dodge Modifier
            int mv2indMLocatorStartIndex = importString.IndexOf("indSTRTMmv2@@_!");
            if (mv2indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Induces Start' indicator.");
                return false;
            }
            int mv2dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv2@@");
            if (mv2dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Dodge Modifier' indicator.");
                return false;
            }
            mv2dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv2@@") + "dgeDCMmv2@@".Length - 1;
            if (mv2indMLocatorStartIndex - mv2dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2dgeMLocatorEndIndex + 1, mv2indMLocatorStartIndex - mv2dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Dodge Modifier value.");
                return false;
            }
                //Move 2 Induces
            int mv2ind2LocatorStartIndex = importString.IndexOf("indENDMmv2@@_!");
            if (mv2ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv2indLocatorEndIndex = importString.IndexOf("indSTRTMmv2@@_!");
            if (mv2indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv2indLocatorEndIndex = importString.IndexOf("indSTRTMmv2@@_!") + "indSTRTMmv2@@_!".Length - 1;
            if (mv2ind2LocatorStartIndex - mv2indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 2 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2indLocatorEndIndex + 1, mv2ind2LocatorStartIndex - mv2indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 2 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv2indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 2 Induces data.");
                        return false;
                    }
                }
            }
                //Move 3 Name
            int mv3dLocatorStartIndex = importString.IndexOf("dDCMv3@@");
            if (mv3dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Description' indicator.");
                return false;
            }
            int mv3nLocatorEndIndex = importString.IndexOf("nDCMmv3@@");
            if (mv3nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Name' indicator.");
                return false;
            }
            mv3nLocatorEndIndex = importString.IndexOf("nDCMmv3@@") + "nDCMmv3@@".Length - 1;
            if (mv3dLocatorStartIndex - mv3nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3nLocatorEndIndex + 1, mv3dLocatorStartIndex - mv3nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Name value.");
                return false;
            }
                //Move 3 Desc
            int mv3tLocatorStartIndex = importString.IndexOf("tDCMmv3@@");
            if (mv3tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Type' indicator.");
                return false;
            }
            int mv3dLocatorEndIndex = importString.IndexOf("dDCMv3@@");
            if (mv3dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Description' indicator.");
                return false;
            }
            mv3dLocatorEndIndex = importString.IndexOf("dDCMv3@@") + "dDCMv3@@".Length - 1;
            if (mv3tLocatorStartIndex - mv3dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3dLocatorEndIndex + 1, mv3tLocatorStartIndex - mv3dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Description value.");
                return false;
            }
                //Move 3 Type
            int mv3atmLocatorStartIndex = importString.IndexOf("atmDCMmv3@@");
            if (mv3atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack' indicator.");
                return false;
            }
            int mv3tLocatorEndIndex = importString.IndexOf("tDCMmv3@@");
            if (mv3tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Type' indicator.");
                return false;
            }
            mv3tLocatorEndIndex = importString.IndexOf("tDCMmv3@@") + "tDCMmv3@@".Length - 1;
            if (mv3atmLocatorStartIndex - mv3tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3tLocatorEndIndex + 1, mv3atmLocatorStartIndex - mv3tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Type value.");
                return false;
            }
                //Move 3 Atk Multiplier
            int mv3accLocatorStartIndex = importString.IndexOf("accDCMmv3@@");
            if (mv3accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy' indicator.");
                return false;
            }
            int mv3atmLocatorEndIndex = importString.IndexOf("atmDCMmv3@@");
            if (mv3atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack' indicator.");
                return false;
            }
            mv3atmLocatorEndIndex = importString.IndexOf("atmDCMmv3@@") + "atmDCMmv3@@".Length - 1;
            if (mv3accLocatorStartIndex - mv3atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3atmLocatorEndIndex + 1, mv3accLocatorStartIndex - mv3atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack value.");
                return false;
            }
                //Move 3 Accuracy
            int mv3hLocatorStartIndex = importString.IndexOf("hDCMmv3@@");
            if (mv3hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Healing' indicator.");
                return false;
            }
            int mv3accLocatorEndIndex = importString.IndexOf("accDCMmv3@@");
            if (mv3accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy' indicator.");
                return false;
            }
            mv3accLocatorEndIndex = importString.IndexOf("accDCMmv3@@") + "accDCMmv3@@".Length - 1;
            if (mv3hLocatorStartIndex - mv3accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3accLocatorEndIndex + 1, mv3hLocatorStartIndex - mv3accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy value.");
                return false;
            }
                //Move 3 Healing
            int mv3atkMLocatorStartIndex = importString.IndexOf("atkDCMmv3@@");
            if (mv3atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack Modifier' indicator.");
                return false;
            }
            int mv3hLocatorEndIndex = importString.IndexOf("hDCMmv3@@");
            if (mv3hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Healing' indicator.");
                return false;
            }
            mv3hLocatorEndIndex = importString.IndexOf("hDCMmv3@@") + "hDCMmv3@@".Length - 1;
            if (mv3atkMLocatorStartIndex - mv3hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3hLocatorEndIndex + 1, mv3atkMLocatorStartIndex - mv3hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Healing value.");
                return false;
            }
                //Move 3 Attack Modifier
            int mv3defMLocatorStartIndex = importString.IndexOf("defDCMmv3@@");
            if (mv3defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Defense Modifier' indicator.");
                return false;
            }
            int mv3atkMLocatorEndIndex = importString.IndexOf("atkDCMmv3@@");
            if (mv3atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack Modifier' indicator.");
                return false;
            }
            mv3atkMLocatorEndIndex = importString.IndexOf("atkDCMmv3@@") + "atkDCMmv3@@".Length - 1;
            if (mv3defMLocatorStartIndex - mv3atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3atkMLocatorEndIndex + 1, mv3defMLocatorStartIndex - mv3atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack Modifier value.");
                return false;
            }
                //Move 3 Defense Modifier
            int mv3accMLocatorStartIndex = importString.IndexOf("acmDCMmv3@@");
            if (mv3accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy Modifier' indicator.");
                return false;
            }
            int mv3defMLocatorEndIndex = importString.IndexOf("defDCMmv3@@");
            if (mv3defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Defense Modifier' indicator.");
                return false;
            }
            mv3defMLocatorEndIndex = importString.IndexOf("defDCMmv3@@") + "defDCMmv3@@".Length - 1;
            if (mv3accMLocatorStartIndex - mv3defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3defMLocatorEndIndex + 1, mv3accMLocatorStartIndex - mv3defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Defense Modifier value.");
                return false;
            }
                //Move 3 Accuracy Modifier
            int mv3dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv3@@");
            if (mv3dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Dodge Modifier' indicator.");
                return false;
            }
            int mv3accMLocatorEndIndex = importString.IndexOf("acmDCMmv3@@");
            if (mv3accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy Modifier' indicator.");
                return false;
            }
            mv3accMLocatorEndIndex = importString.IndexOf("acmDCMmv3@@") + "acmDCMmv3@@".Length - 1;
            if (mv3dgeMLocatorStartIndex - mv3accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3accMLocatorEndIndex + 1, mv3dgeMLocatorStartIndex - mv3accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy Modifier value.");
                return false;
            }
                //Move 3 Dodge Modifier
            int mv3indMLocatorStartIndex = importString.IndexOf("indSTRTMmv3@@_!");
            if (mv3indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Induces Start' indicator.");
                return false;
            }
            int mv3dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv3@@");
            if (mv3dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Dodge Modifier' indicator.");
                return false;
            }
            mv3dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv3@@") + "dgeDCMmv3@@".Length - 1;
            if (mv3indMLocatorStartIndex - mv3dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3dgeMLocatorEndIndex + 1, mv3indMLocatorStartIndex - mv3dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Dodge Modifier value.");
                return false;
            }
                //Move 3 Induces
            int mv3ind2LocatorStartIndex = importString.IndexOf("indENDMmv3@@_!");
            if (mv3ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv3indLocatorEndIndex = importString.IndexOf("indSTRTMmv3@@_!");
            if (mv3indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv3indLocatorEndIndex = importString.IndexOf("indSTRTMmv3@@_!") + "indSTRTMmv3@@_!".Length - 1;
            if (mv3ind2LocatorStartIndex - mv3indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 3 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3indLocatorEndIndex + 1, mv3ind2LocatorStartIndex - mv3indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 3 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv3indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 3 Induces data.");
                        return false;
                    }
                }
            }
                //Move 4 Name
            int mv4dLocatorStartIndex = importString.IndexOf("dDCMv4@@");
            if (mv4dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Description' indicator.");
                return false;
            }
            int mv4nLocatorEndIndex = importString.IndexOf("nDCMmv4@@");
            if (mv4nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Name' indicator.");
                return false;
            }
            mv4nLocatorEndIndex = importString.IndexOf("nDCMmv4@@") + "nDCMmv4@@".Length - 1;
            if (mv4dLocatorStartIndex - mv4nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4nLocatorEndIndex + 1, mv4dLocatorStartIndex - mv4nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Name value.");
                return false;
            }
                //Move 4 Desc
            int mv4tLocatorStartIndex = importString.IndexOf("tDCMmv4@@");
            if (mv4tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Type' indicator.");
                return false;
            }
            int mv4dLocatorEndIndex = importString.IndexOf("dDCMv4@@");
            if (mv4dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Description' indicator.");
                return false;
            }
            mv4dLocatorEndIndex = importString.IndexOf("dDCMv4@@") + "dDCMv4@@".Length - 1;
            if (mv4tLocatorStartIndex - mv4dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4dLocatorEndIndex + 1, mv4tLocatorStartIndex - mv4dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Description value.");
                return false;
            }
                //Move 4 Type
            int mv4atmLocatorStartIndex = importString.IndexOf("atmDCMmv4@@");
            if (mv4atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack' indicator.");
                return false;
            }
            int mv4tLocatorEndIndex = importString.IndexOf("tDCMmv4@@");
            if (mv4tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Type' indicator.");
                return false;
            }
            mv4tLocatorEndIndex = importString.IndexOf("tDCMmv4@@") + "tDCMmv4@@".Length - 1;
            if (mv4atmLocatorStartIndex - mv4tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4tLocatorEndIndex + 1, mv4atmLocatorStartIndex - mv4tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Type value.");
                return false;
            }
                //Move 4 Atk Multiplier
            int mv4accLocatorStartIndex = importString.IndexOf("accDCMmv4@@");
            if (mv4accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy' indicator.");
                return false;
            }
            int mv4atmLocatorEndIndex = importString.IndexOf("atmDCMmv4@@");
            if (mv4atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack' indicator.");
                return false;
            }
            mv4atmLocatorEndIndex = importString.IndexOf("atmDCMmv4@@") + "atmDCMmv4@@".Length - 1;
            if (mv4accLocatorStartIndex - mv4atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4atmLocatorEndIndex + 1, mv4accLocatorStartIndex - mv4atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack value.");
                return false;
            }
                //Move 4 Accuracy
            int mv4hLocatorStartIndex = importString.IndexOf("hDCMmv4@@");
            if (mv4hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Healing' indicator.");
                return false;
            }
            int mv4accLocatorEndIndex = importString.IndexOf("accDCMmv4@@");
            if (mv4accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy' indicator.");
                return false;
            }
            mv4accLocatorEndIndex = importString.IndexOf("accDCMmv4@@") + "accDCMmv4@@".Length - 1;
            if (mv4hLocatorStartIndex - mv4accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4accLocatorEndIndex + 1, mv4hLocatorStartIndex - mv4accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy value.");
                return false;
            }
                //Move 4 Healing
            int mv4atkMLocatorStartIndex = importString.IndexOf("atkDCMmv4@@");
            if (mv4atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack Modifier' indicator.");
                return false;
            }
            int mv4hLocatorEndIndex = importString.IndexOf("hDCMmv4@@");
            if (mv4hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Healing' indicator.");
                return false;
            }
            mv4hLocatorEndIndex = importString.IndexOf("hDCMmv4@@") + "hDCMmv4@@".Length - 1;
            if (mv4atkMLocatorStartIndex - mv4hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4hLocatorEndIndex + 1, mv4atkMLocatorStartIndex - mv4hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Healing value.");
                return false;
            }
                //Move 4 Attack Modifier
            int mv4defMLocatorStartIndex = importString.IndexOf("defDCMmv4@@");
            if (mv4defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Defense Modifier' indicator.");
                return false;
            }
            int mv4atkMLocatorEndIndex = importString.IndexOf("atkDCMmv4@@");
            if (mv4atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack Modifier' indicator.");
                return false;
            }
            mv4atkMLocatorEndIndex = importString.IndexOf("atkDCMmv4@@") + "atkDCMmv4@@".Length - 1;
            if (mv4defMLocatorStartIndex - mv4atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4atkMLocatorEndIndex + 1, mv4defMLocatorStartIndex - mv4atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack Modifier value.");
                return false;
            }
                //Move 4 Defense Modifier
            int mv4accMLocatorStartIndex = importString.IndexOf("acmDCMmv4@@");
            if (mv4accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy Modifier' indicator.");
                return false;
            }
            int mv4defMLocatorEndIndex = importString.IndexOf("defDCMmv4@@");
            if (mv4defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Defense Modifier' indicator.");
                return false;
            }
            mv4defMLocatorEndIndex = importString.IndexOf("defDCMmv4@@") + "defDCMmv4@@".Length - 1;
            if (mv4accMLocatorStartIndex - mv4defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4defMLocatorEndIndex + 1, mv4accMLocatorStartIndex - mv4defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Defense Modifier value.");
                return false;
            }
                //Move 4 Accuracy Modifier
            int mv4dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv4@@");
            if (mv4dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Dodge Modifier' indicator.");
                return false;
            }
            int mv4accMLocatorEndIndex = importString.IndexOf("acmDCMmv4@@");
            if (mv4accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy Modifier' indicator.");
                return false;
            }
            mv4accMLocatorEndIndex = importString.IndexOf("acmDCMmv4@@") + "acmDCMmv4@@".Length - 1;
            if (mv4dgeMLocatorStartIndex - mv4accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4accMLocatorEndIndex + 1, mv4dgeMLocatorStartIndex - mv4accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy Modifier value.");
                return false;
            }
                //Move 4 Dodge Modifier
            int mv4indMLocatorStartIndex = importString.IndexOf("indSTRTMmv4@@_!");
            if (mv4indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Induces Start' indicator.");
                return false;
            }
            int mv4dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv4@@");
            if (mv4dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Dodge Modifier' indicator.");
                return false;
            }
            mv4dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv4@@") + "dgeDCMmv4@@".Length - 1;
            if (mv4indMLocatorStartIndex - mv4dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4dgeMLocatorEndIndex + 1, mv4indMLocatorStartIndex - mv4dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Dodge Modifier value.");
                return false;
            }
                //Move 4 Induces
            int mv4ind2LocatorStartIndex = importString.IndexOf("indENDMmv4@@_!");
            if (mv4ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv4indLocatorEndIndex = importString.IndexOf("indSTRTMmv4@@_!");
            if (mv4indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv4indLocatorEndIndex = importString.IndexOf("indSTRTMmv4@@_!") + "indSTRTMmv4@@_!".Length - 1;
            if (mv4ind2LocatorStartIndex - mv4indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 4 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4indLocatorEndIndex + 1, mv4ind2LocatorStartIndex - mv4indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 4 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv4indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 4 Induces data.");
                        return false;
                    }
                }
            }
                //Move 5 Name
            int mv5dLocatorStartIndex = importString.IndexOf("dDCMv5@@");
            if (mv5dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Description' indicator.");
                return false;
            }
            int mv5nLocatorEndIndex = importString.IndexOf("nDCMmv5@@");
            if (mv5nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Name' indicator.");
                return false;
            }
            mv5nLocatorEndIndex = importString.IndexOf("nDCMmv5@@") + "nDCMmv5@@".Length - 1;
            if (mv5dLocatorStartIndex - mv5nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5nLocatorEndIndex + 1, mv5dLocatorStartIndex - mv5nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Name value.");
                return false;
            }
                //Move 5 Desc
            int mv5tLocatorStartIndex = importString.IndexOf("tDCMmv5@@");
            if (mv5tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Type' indicator.");
                return false;
            }
            int mv5dLocatorEndIndex = importString.IndexOf("dDCMv5@@");
            if (mv5dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Description' indicator.");
                return false;
            }
            mv5dLocatorEndIndex = importString.IndexOf("dDCMv5@@") + "dDCMv5@@".Length - 1;
            if (mv5tLocatorStartIndex - mv5dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5dLocatorEndIndex + 1, mv5tLocatorStartIndex - mv5dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Description value.");
                return false;
            }
                //Move 5 Type
            int mv5atmLocatorStartIndex = importString.IndexOf("atmDCMmv5@@");
            if (mv5atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack' indicator.");
                return false;
            }
            int mv5tLocatorEndIndex = importString.IndexOf("tDCMmv5@@");
            if (mv5tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Type' indicator.");
                return false;
            }
            mv5tLocatorEndIndex = importString.IndexOf("tDCMmv5@@") + "tDCMmv5@@".Length - 1;
            if (mv5atmLocatorStartIndex - mv5tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5tLocatorEndIndex + 1, mv5atmLocatorStartIndex - mv5tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Type value.");
                return false;
            }
                //Move 5 Atk Multiplier
            int mv5accLocatorStartIndex = importString.IndexOf("accDCMmv5@@");
            if (mv5accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy' indicator.");
                return false;
            }
            int mv5atmLocatorEndIndex = importString.IndexOf("atmDCMmv5@@");
            if (mv5atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack' indicator.");
                return false;
            }
            mv5atmLocatorEndIndex = importString.IndexOf("atmDCMmv5@@") + "atmDCMmv5@@".Length - 1;
            if (mv5accLocatorStartIndex - mv5atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5atmLocatorEndIndex + 1, mv5accLocatorStartIndex - mv5atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack value.");
                return false;
            }
                //Move 5 Accuracy
            int mv5hLocatorStartIndex = importString.IndexOf("hDCMmv5@@");
            if (mv5hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Healing' indicator.");
                return false;
            }
            int mv5accLocatorEndIndex = importString.IndexOf("accDCMmv5@@");
            if (mv5accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy' indicator.");
                return false;
            }
            mv5accLocatorEndIndex = importString.IndexOf("accDCMmv5@@") + "accDCMmv5@@".Length - 1;
            if (mv5hLocatorStartIndex - mv5accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5accLocatorEndIndex + 1, mv5hLocatorStartIndex - mv5accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy value.");
                return false;
            }
                //Move 5 Healing
            int mv5atkMLocatorStartIndex = importString.IndexOf("atkDCMmv5@@");
            if (mv5atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack Modifier' indicator.");
                return false;
            }
            int mv5hLocatorEndIndex = importString.IndexOf("hDCMmv5@@");
            if (mv5hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Healing' indicator.");
                return false;
            }
            mv5hLocatorEndIndex = importString.IndexOf("hDCMmv5@@") + "hDCMmv5@@".Length - 1;
            if (mv5atkMLocatorStartIndex - mv5hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5hLocatorEndIndex + 1, mv5atkMLocatorStartIndex - mv5hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Healing value.");
                return false;
            }
                //Move 5 Attack Modifier
            int mv5defMLocatorStartIndex = importString.IndexOf("defDCMmv5@@");
            if (mv5defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Defense Modifier' indicator.");
                return false;
            }
            int mv5atkMLocatorEndIndex = importString.IndexOf("atkDCMmv5@@");
            if (mv5atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack Modifier' indicator.");
                return false;
            }
            mv5atkMLocatorEndIndex = importString.IndexOf("atkDCMmv5@@") + "atkDCMmv5@@".Length - 1;
            if (mv5defMLocatorStartIndex - mv5atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5atkMLocatorEndIndex + 1, mv5defMLocatorStartIndex - mv5atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack Modifier value.");
                return false;
            }
                //Move 5 Defense Modifier
            int mv5accMLocatorStartIndex = importString.IndexOf("acmDCMmv5@@");
            if (mv5accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy Modifier' indicator.");
                return false;
            }
            int mv5defMLocatorEndIndex = importString.IndexOf("defDCMmv5@@");
            if (mv5defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Defense Modifier' indicator.");
                return false;
            }
            mv5defMLocatorEndIndex = importString.IndexOf("defDCMmv5@@") + "defDCMmv5@@".Length - 1;
            if (mv5accMLocatorStartIndex - mv5defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5defMLocatorEndIndex + 1, mv5accMLocatorStartIndex - mv5defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Defense Modifier value.");
                return false;
            }
                //Move 5 Accuracy Modifier
            int mv5dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv5@@");
            if (mv5dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Dodge Modifier' indicator.");
                return false;
            }
            int mv5accMLocatorEndIndex = importString.IndexOf("acmDCMmv5@@");
            if (mv5accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy Modifier' indicator.");
                return false;
            }
            mv5accMLocatorEndIndex = importString.IndexOf("acmDCMmv5@@") + "acmDCMmv5@@".Length - 1;
            if (mv5dgeMLocatorStartIndex - mv5accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5accMLocatorEndIndex + 1, mv5dgeMLocatorStartIndex - mv5accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy Modifier value.");
                return false;
            }
                //Move 5 Dodge Modifier
            int mv5indMLocatorStartIndex = importString.IndexOf("indSTRTMmv5@@_!");
            if (mv5indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Induces Start' indicator.");
                return false;
            }
            int mv5dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv5@@");
            if (mv5dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Dodge Modifier' indicator.");
                return false;
            }
            mv5dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv5@@") + "dgeDCMmv5@@".Length - 1;
            if (mv5indMLocatorStartIndex - mv5dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5dgeMLocatorEndIndex + 1, mv5indMLocatorStartIndex - mv5dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Dodge Modifier value.");
                return false;
            }
                //Move 5 Induces
            int mv5ind2LocatorStartIndex = importString.IndexOf("indENDMmv5@@_!");
            if (mv5ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv5indLocatorEndIndex = importString.IndexOf("indSTRTMmv5@@_!");
            if (mv5indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv5indLocatorEndIndex = importString.IndexOf("indSTRTMmv5@@_!") + "indSTRTMmv5@@_!".Length - 1;
            if (mv5ind2LocatorStartIndex - mv5indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 5 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5indLocatorEndIndex + 1, mv5ind2LocatorStartIndex - mv5indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 5 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv5indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 5 Induces data.");
                        return false;
                    }
                }
            }
            //Valid!
            return true;
        }

        //Character Database Methods
        private void charDatabaseButton_Click(object sender, EventArgs e)
        {
            enableCharDatabaseUI();
        }
            //Vanilla
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //VANILLA
                //None
            if(comboBox1.Text == "Joseph (NONE)")
            {
                vanillaExports.Text = josephString;
            }
            if(comboBox1.Text == "David (NONE)")
            {
                vanillaExports.Text = davidString;
            }
                //Void
            if(comboBox1.Text == "Anomal (VOID)")
            {
                vanillaExports.Text = anomalString;
            }
            if (comboBox1.Text == "Rig (VOID)")
            {
                vanillaExports.Text = rigString;
            }
                //Earthly
            if (comboBox1.Text == "Stone Golem (EARTHLY)")
            {
                vanillaExports.Text = stoneGolemString;
            }
            if (comboBox1.Text == "Livern (EARTHLY)")
            {
                vanillaExports.Text = livernString;
            }
                //Air
            if (comboBox1.Text == "Albatross (AIR)")
            {
                vanillaExports.Text = albatrossString;
            }
            if(comboBox1.Text == "Tweedle (AIR)")
            {
                vanillaExports.Text = tweedleString;
            }
                //Ground
            if (comboBox1.Text == "Quake (GROUND)")
            {
                vanillaExports.Text = quakeString;
            }
            if (comboBox1.Text == "The Rock (GROUND)")
            {
                vanillaExports.Text = therockString;
            }
                //Electric
            if (comboBox1.Text == "Zip (ELECTRIC)")
            {
                vanillaExports.Text = zipString;
            }
            if (comboBox1.Text == "Magnaur (ELECTRIC)")
            {
                vanillaExports.Text = magnaurString;
            }
                //Metal
            if (comboBox1.Text == "Irode (METAL)")
            {
                vanillaExports.Text = irodeString;
            }
            if (comboBox1.Text == "Splarg (METAL)")
            {
                vanillaExports.Text = splargString;
            }
                //Intelligent
            if (comboBox1.Text == "Doc (INTELLIGENT)")
            {
                vanillaExports.Text = docString;
            }
            if (comboBox1.Text == "Student (INTELLIGENT)")
            {
                vanillaExports.Text = studentString;
            }
                //Force
            if (comboBox1.Text == "Martis (FORCE)")
            {
                vanillaExports.Text = martisString;
            }
            if (comboBox1.Text == "Discrinius (FORCE)")
            {
                vanillaExports.Text = discriniusString;
            }
                //Ice
            if (comboBox1.Text == "Cicle (ICE)")
            {
                vanillaExports.Text = cicleString;
            }
            if (comboBox1.Text == "Blizerd (ICE)")
            {
                vanillaExports.Text = blizerdString;
            }
                //Fire
            if (comboBox1.Text == "Solcore (FIRE)")
            {
                vanillaExports.Text = solcoreString;
            }
            if (comboBox1.Text == "Pyrocitus (FIRE)")
            {
                vanillaExports.Text = pyrocitusString;
            }
                //Natural
            if (comboBox1.Text == "Lyfebud (NATURAL)")
            {
                vanillaExports.Text = lyfebudString;
            }
            if (comboBox1.Text == "Elementus (NATURAL)")
            {
                vanillaExports.Text = elementusString;
            }
                //Psychic
            if (comboBox1.Text == "Forseer (PSYCHIC)")
            {
                vanillaExports.Text = forseerString;
            }
            if (comboBox1.Text == "Zodium (PSYCHIC)")
            {
                vanillaExports.Text = zodiumString;
            }
                //Mortal
            if (comboBox1.Text == "Humanus (MORTAL)")
            {
                vanillaExports.Text = humanusString;
            }
            if (comboBox1.Text == "The Demon (MORTAL)")
            {
                vanillaExports.Text = thedemonString;
            }
                //Ghost
            if (comboBox1.Text == "Spirtu (GHOST)")
            {
                vanillaExports.Text = spirtuString;
            }
            if (comboBox1.Text == "Duskan (GHOST)")
            {
                vanillaExports.Text = duskanString;
            }
        }
            //NONE Type
        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            //NONE
                //Vanilla
            if (comboBox5.Text == "Joseph (Vanilla)")
            {
                typeNoneExports.Text = josephString;
            }
            if (comboBox5.Text == "David (Vanilla)")
            {
                typeNoneExports.Text = davidString;
            }
        }
            //VOID Type
        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            //VOID
                //Vanilla
            if (comboBox6.Text == "Anomal (Vanilla)")
            {
                typeVoidExports.Text = anomalString;
            }
            if (comboBox6.Text == "Rig (Vanilla)")
            {
                typeVoidExports.Text = rigString;
            }
        }
            //EARTHLY Type
        private void comboBox7_TextChanged(object sender, EventArgs e)
        {
            //EARTHLY
                //Vanilla
            if (comboBox7.Text == "Stone Golem (Vanilla)")
            {
                typeEarthlyExports.Text = stoneGolemString;
            }
            if (comboBox7.Text == "Livern (Vanilla)")
            {
                typeEarthlyExports.Text = livernString;
            }
        }
            //AIR Type
        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            //AIR
                //Vanilla
            if (comboBox8.Text == "Albatross (Vanilla)")
            {
                typeAirExports.Text = albatrossString;
            }
            if (comboBox8.Text == "Tweedle (Vanilla)")
            {
                typeAirExports.Text = tweedleString;
            }
        }
            //GROUND Type
        private void comboBox9_TextChanged(object sender, EventArgs e)
        {
            //GROUND
                //Vanilla
            if (comboBox9.Text == "Quake (Vanilla)")
            {
                typeGroundExports.Text = quakeString;
            }
            if (comboBox9.Text == "The Rock (Vanilla)")
            {
                typeGroundExports.Text = therockString;
            }
        }
            //ELECTRIC Type
        private void comboBox10_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox10.Text == "Zip (Vanilla)")
            {
                typeElectricExports.Text = zipString;
            }
            if (comboBox10.Text == "Magnaur (Vanilla)")
            {
                typeElectricExports.Text = magnaurString;
            }
        }
            //METAL Type
        private void comboBox11_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox11.Text == "Irode (Vanilla)")
            {
                typeMetalExports.Text = irodeString;
            }
            if (comboBox11.Text == "Splarg (Vanilla)")
            {
                typeMetalExports.Text = splargString;
            }
        }
            //INTELLIGENT Type
        private void comboBox12_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox12.Text == "Doc (Vanilla)")
            {
                typeIntelligentExports.Text = docString;
            }
            if (comboBox12.Text == "Student (Vanilla)")
            {
                typeIntelligentExports.Text = studentString;
            }
        }
            //FORCE Type
        private void comboBox13_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox13.Text == "Martis (Vanilla)")
            {
                typeForceExports.Text = martisString;
            }
            if (comboBox13.Text == "Discrinius (Vanilla)")
            {
                typeForceExports.Text = discriniusString;
            }
        }
            //ICE Type
        private void comboBox14_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox14.Text == "Cicle (Vanilla)")
            {
                typeIceExports.Text = cicleString;
            }
            if (comboBox14.Text == "Blizerd (Vanilla)")
            {
                typeIceExports.Text = blizerdString;
            }
        }
            //FIRE Type
        private void comboBox15_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox15.Text == "Solcore (Vanilla)")
            {
                typeFireExports.Text = solcoreString;
            }
            if (comboBox15.Text == "Pyrocitus (Vanilla)")
            {
                typeFireExports.Text = pyrocitusString;
            }
        }
            //NATURAL Type
        private void comboBox16_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox16.Text == "Lyfebud (Vanilla)")
            {
                typeNaturalExports.Text = lyfebudString;
            }
            if (comboBox16.Text == "Elementus (Vanilla)")
            {
                typeNaturalExports.Text = elementusString;
            }
        }
            //PSYCHIC Type
        private void comboBox17_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox17.Text == "Forseer (Vanilla)")
            {
                typePsychicExports.Text = forseerString;
            }
            if (comboBox17.Text == "Zodium (Vanilla)")
            {
                typePsychicExports.Text = zodiumString;
            }
        }
            //MORTAL Type
        private void comboBox18_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox18.Text == "Humanus (Vanilla)")
            {
                typeMortalExports.Text = humanusString;
            }
            if (comboBox18.Text == "The Demon (Vanilla)")
            {
                typeMortalExports.Text = thedemonString;
            }
        }
            //GHOST Type
        private void comboBox19_TextChanged(object sender, EventArgs e)
        {
            //Vanilla
            if (comboBox19.Text == "Spirtu (Vanilla)")
            {
                typeGhostExports.Text = spirtuString;
            }
            if (comboBox19.Text == "Duskan (Vanilla)")
            {
                typeGhostExports.Text = duskanString;
            }
        }

        //UNEDITABLE/NON-REMOVABLE METHODS
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CCL40_Click(object sender, EventArgs e)
        {

        }

        private void CCL58_Click(object sender, EventArgs e)
        {

        }

        private void CCL57_Click(object sender, EventArgs e)
        {

        }

        private void CCL56_Click(object sender, EventArgs e)
        {

        }

        private void CCL55_Click(object sender, EventArgs e)
        {

        }

        private void CCL54_Click(object sender, EventArgs e)
        {

        }

        private void CCL53_Click(object sender, EventArgs e)
        {

        }

        private void CCL52_Click(object sender, EventArgs e)
        {

        }

        private void CCL51_Click(object sender, EventArgs e)
        {

        }

        private void CCc29_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc28_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc27_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc26_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc25_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc30_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc24_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc23_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc22_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCL50_Click(object sender, EventArgs e)
        {

        }

        private void CCL49_Click(object sender, EventArgs e)
        {

        }

        private void CCL48_Click(object sender, EventArgs e)
        {

        }

        private void CCL47_Click(object sender, EventArgs e)
        {

        }

        private void CCN18_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN17_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN16_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN15_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN14_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCL46_Click(object sender, EventArgs e)
        {

        }

        private void CCN13_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCL45_Click(object sender, EventArgs e)
        {

        }

        private void CCL44_Click(object sender, EventArgs e)
        {

        }

        private void CCN12_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCc21_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCL43_Click(object sender, EventArgs e)
        {

        }

        private void CCT6_TextChanged(object sender, EventArgs e)
        {

        }

        private void CCL42_Click(object sender, EventArgs e)
        {

        }

        private void CCT5_TextChanged(object sender, EventArgs e)
        {

        }

        private void CCL41_Click(object sender, EventArgs e)
        {

        }

        private void CCL59_Click(object sender, EventArgs e)
        {

        }

        private void CCP2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }
    }
}
