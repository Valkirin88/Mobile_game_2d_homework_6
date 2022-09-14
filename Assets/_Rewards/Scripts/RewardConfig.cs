using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName =nameof(RewardConfig), menuName ="Configs/" + nameof(RewardConfig))]
    internal class RewardConfig : ScriptableObject
    {
        [field: SerializeField] public RewardType RewardType { get; private set; }
        [field: SerializeField] public Sprite IconCurrency { get; private set; }
        [field: SerializeField] public int CountCurrency { get; private set; }
    }
}
