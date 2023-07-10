using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Scrappers.Managers
{
    public static class MyraAnimationManager
    {
        private const int AnimationDelayStep = 50;
        private static int _currentAnimationId;
        private static bool _notDisposed = true;
        private static Dictionary<int, Tuple<int, Command>> Animations;

        public static int AddAnimation(int miliseconds, Command animationCommand)
        {
            int numSteps = miliseconds / AnimationDelayStep;
            if (numSteps == 0)
                numSteps++;
            Animations.Add(_currentAnimationId, new Tuple<int, Command>(numSteps, animationCommand));
            return _currentAnimationId++;
        }

        public static void Dispose()
        {
            _notDisposed = false;
        }

        public static void Init()
        {
            _currentAnimationId = 0;
            Animations = new Dictionary<int, Tuple<int, Command>>();
            Task.Run(() =>
            {
                int x = 0;
                while (_notDisposed)
                {
                    if (x == int.MaxValue)
                        x = 0;
                    foreach (Tuple<int, Command> animation in Animations.Values)
                        if (x % animation.Item1 == 0 && animation.Item2.CanExecute)
                            animation.Item2.Execute(null);
                    Thread.Sleep(AnimationDelayStep);
                    x++;
                }
            });
        }

        public static void RemoveAnimation(int id)
        {
            if (Animations.ContainsKey(id))
            {
                Animations.Remove(id);
            }
        }
    }
}