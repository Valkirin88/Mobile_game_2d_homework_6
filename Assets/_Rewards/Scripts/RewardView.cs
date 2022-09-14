using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards
{
    internal class RewardView : MonoBehaviour
    {
        private string CurrentSlotInActiveKey;
        private string TimeGetRewardKey;

        [field: Header("Settings Time Get Reward")]

        [field: SerializeField] public Periods Period;
        public float TimeCooldown { get; private set; } 
        public float TimeDeadline { get; private set; } 

        [field: Header("Settings Rewards")]
        [field: SerializeField] public List<Reward> Rewards { get; private set; }

        [field: Header("Ui Elements")]
        [field: SerializeField] public TMP_Text TimerNewReward { get; private set; }
        [field: SerializeField] public Transform MountRootSlotsReward { get; private set; }
        [field: SerializeField] public ContainerSlotRewardView ContainerSlotRewardPrefab { get; private set; }
        [field: SerializeField] public Button GetRewardButton { get; private set; }
        [field: SerializeField] public Button ResetButton { get; private set; }


        private void Awake()
        {

            if (Period == Periods.Dayly)
            {
                TimeCooldown = 86400;
                TimeDeadline = 172800;
                CurrentSlotInActiveKey = "CurrentDailySlotInActiveKey)";
                TimeGetRewardKey = "TimeGetDailyRewardKey";
    }
            if (Period == Periods.Weekly)
            {
                TimeCooldown = 604800;
                TimeDeadline = 2419200;
                CurrentSlotInActiveKey = "CurrentWeeklySlotInActiveKey)";
                TimeGetRewardKey = "TimeGetWeeklyRewardKey";
            }



        }

        public int CurrentSlotInActive
        {
            get => PlayerPrefs.GetInt(CurrentSlotInActiveKey);
            set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
        }

        public DateTime? TimeGetReward
        {
            get
            {
                string data = PlayerPrefs.GetString(TimeGetRewardKey);
                if (!string.IsNullOrEmpty(data))
                    return DateTime.Parse(data);
                else
                     return null;

            }
            set
            {
                if (value != null)
                    PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(TimeGetRewardKey);
            }
        }
    }
}
