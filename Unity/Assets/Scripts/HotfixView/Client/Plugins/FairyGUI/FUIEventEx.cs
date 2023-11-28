﻿using System;
using System.Collections.Generic;
using FairyGUI;

namespace ET.Client
{
    [FriendOf(typeof(FUIEventComponent))]
    public static partial class FUIEventEx
    {

        #region AddListnerAsync(this GObject self, Func<ETTask> action)

        public static void AddListnerAsync(this GObject self, Func<ETTask> action, int cd = 0)
        {
            async ETTask ClickActionAsync()
            {
                FUIEventComponent.Instance.isClicked = true;
                await action();
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }

        public static void AddListnerAsync<P1>(this GObject self, Func<P1, ETTask> action, P1 p1, int cd = 0)
        {
            async ETTask ClickActionAsync()
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(p1);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }

        public static void AddListnerAsync<P1, P2>(this GObject self, Func<P1, P2, ETTask> action, P1 p1, P2 p2, int cd = 0)
        {
            async ETTask ClickActionAsync()
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(p1, p2);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }

        public static void AddListnerAsync<P1, P2, P3>(this GObject self, Func<P1, P2, P3, ETTask> action, P1 p1, P2 p2, P3 p3, int cd = 0)
        {
            async ETTask ClickActionAsync()
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(p1, p2, p3);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }

        #endregion

        #region AddListner(this GObject self, Action action)

        public static void AddListner(this GObject self, Action action, int cd = 0)
        {
            self.onClick.Set(() =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke();
            });
        }

        public static void AddListner<P1>(this GObject self, Action<P1> action, P1 p1, int cd = 0)
        {
            self.onClick.Set(() =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(p1);
            });
        }

        public static void AddListner<P1, P2>(this GObject self, Action<P1, P2> action, P1 p1, P2 p2, int cd = 0)
        {
            self.onClick.Set(() =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(p1, p2);
            });
        }

        public static void AddListner<P1, P2, P3>(this GObject self, Action<P1, P2, P3> action, P1 p1, P2 p2, P3 p3, int cd = 0)
        {
            self.onClick.Set(() =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(p1, p2, p3);
            });
        }

        #endregion

        #region AddListnerAsync(this GObject self, Func<EventContext, ETTask> action)

        public static void AddListnerAsync(this GObject self, Func<EventContext, ETTask> action, int cd = 0)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(context);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }

        public static void AddListnerAsync<P1>(this GObject self, Func<EventContext, P1, ETTask> action, P1 p1, int cd = 0)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(context, p1);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }

        public static void AddListnerAsync<P1, P2>(this GObject self, Func<EventContext, P1, P2, ETTask> action, P1 p1, P2 p2, int cd = 0)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(context, p1, p2);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }

        public static void AddListnerAsync<P1, P2, P3>(this GObject self, Func<EventContext, P1, P2, P3, ETTask> action, P1 p1, P2 p2, P3 p3,
        int cd = 0)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEventComponent.Instance.isClicked = true;
                await action(context, p1, p2, p3);
                FUIEventComponent.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }

        #endregion

        #region AddListner(this GObject self, Action<EventContext> action)

        public static void AddListner(this GObject self, Action<EventContext> action, int cd = 0)
        {
            self.onClick.Set((contex) =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(contex);
            });
        }

        public static void AddListner<P1>(this GObject self, Action<EventContext, P1> action, P1 p1, int cd = 0)
        {
            self.onClick.Set((contex) =>
            {
                if (FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(contex, p1);
            });
        }

        public static void AddListner<P1, P2>(this GObject self, Action<EventContext, P1, P2> action, P1 p1, P2 p2, int cd = 0)
        {
            self.onClick.Set((contex) =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(contex, p1, p2);
            });
        }

        public static void AddListner<P1, P2, P3>(this GObject self, Action<EventContext, P1, P2, P3> action, P1 p1, P2 p2, P3 p3, int cd = 0)
        {
            self.onClick.Set((contex) =>
            {
                if (cd > 0 && FUIEventComponent.Instance.FUICD.CheckCD(self.displayObject.id, cd))
                {
                    return;
                }

                action?.Invoke(contex, p1, p2, p3);
            });
        }

        #endregion
    }
}