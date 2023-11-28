using System;

namespace ET
{
    [FriendOf(typeof (CDComponent))]
    [EntitySystemOf(typeof(CDComponent))]
    public static partial class CDComponentSystem
    {
        //每30秒清理1次过时的CD信息
        const int clearCDInfoTimeMs = 30000;

        #region ================ CDComponent 事件 ================

        [Invoke(TimerInvokeType.CDTimer)]
        public class CDTimer: ATimer<CDComponent>
        {
            protected override void Run(CDComponent self)
            {
                try
                {
                    self.Clear();
                }
                catch (Exception e)
                {
                    Log.Error($"CDComponent error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this CDComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(clearCDInfoTimeMs, TimerInvokeType.CDTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this CDComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        private static void Clear(this CDComponent self)
        {
            long timeNow = TimeInfo.Instance.ServerNow();
            foreach (var cdInfo in self.dicCDTime)
            {
                if (cdInfo.Value < timeNow)
                {
                    self.listClearKeys.Add(cdInfo.Key);
                }
            }

            foreach (long id in self.listClearKeys)
            {
                self.dicCDTime.Remove(id);
            }

            self.listClearKeys.Clear();
        }

        #endregion

        #region ================ 供调用方法 ================

        /// <summary>
        /// 检测是否处于CD中
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cdMsDuration">CD时长</param>
        /// <param name="reset">是否设置/重置CD时间</param>
        /// <param name="cdEndCanReset">CD结束才能重置CD</param>
        /// <returns></returns>
        public static bool CheckCD(this CDComponent self, long id, int cdMsDuration, bool reset = true, bool cdEndCanReset = false)
        {
            if (cdMsDuration <= 0) return false;

            long timeNow = TimeInfo.Instance.ServerNow();
            self.dicCDTime.TryGetValue(id, out long endTime);

            bool inCDTime = timeNow < endTime;

            if (reset)
            {
                if (!cdEndCanReset || (cdEndCanReset && !inCDTime))
                {
                    self.dicCDTime[id] = timeNow + cdMsDuration;
                }
            }

            return inCDTime;
        }

        /// <summary>
        /// 无条件重置CD (使CD开始进入冷却)
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <param name="cdMsDuration"></param>
        public static void ResetCD(this CDComponent self, long id, int cdMsDuration)
        {
            self.dicCDTime[id] = TimeInfo.Instance.ServerNow() + cdMsDuration;
        }

        /// <summary>
        /// 清除CD (冷却立即完成)
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <param name="cdMsDuration"></param>
        public static void ClearCD(this CDComponent self, long id)
        {
            self.dicCDTime.Remove(id);
        }

        #endregion
    }
}