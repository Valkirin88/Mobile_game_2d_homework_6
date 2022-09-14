using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards
{
    internal class ContainerSlotRewardView : MonoBehaviour
    {
        [SerializeField] private Image _originalBackground;
        [SerializeField] private Image _selectBackground;
        [SerializeField] private Image _iconCurrency;
        [SerializeField] private TMP_Text _textDays;
        [SerializeField] private TMP_Text _countReward;
        private RewardView _rewardView;

        public void SetData(RewardConfig reward, int countPeriods, bool isSelected, RewardView rewardView)
        {
            _rewardView = rewardView;
            _iconCurrency.sprite = reward.IconCurrency;
            _textDays.text = $"{_rewardView.Period} {countPeriods}";
            _countReward.text = reward.CountCurrency.ToString();

            UpdateBackground(isSelected);
        }

        private void UpdateBackground(bool isSelect)
        {
            _originalBackground.gameObject.SetActive(!isSelect);
            _selectBackground.gameObject.SetActive(isSelect);
        }
    }
}
