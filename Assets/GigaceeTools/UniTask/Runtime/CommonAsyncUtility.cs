﻿using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace GigaceeTools
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class CommonAsyncUtility : ICommonWaitable
    {
        private readonly UniTaskCompletionSource _ucs = new UniTaskCompletionSource();

        public async UniTask<float> WaitForCompletionAsync(CancellationToken ct = default)
        {
            // 現在時刻を保持しておく
            float timeRequestedToPresent = Time.realtimeSinceStartup;

            // タスクが完了になるまで待機する
            while (_ucs.Task.Status == UniTaskStatus.Pending)
            {
                await UniTask.NextFrame(ct);
            }

            // このメソッドが呼ばれてからタスクの完了までに掛かった時間を計算して返す
            return Time.realtimeSinceStartup - timeRequestedToPresent;
        }

        public void Completed()
        {
            _ucs.TrySetResult();
        }
    }
}
