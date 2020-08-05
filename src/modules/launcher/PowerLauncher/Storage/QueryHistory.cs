﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerLauncher.Storage
{
    public class QueryHistory
    {
        public List<HistoryItem> Items { get; } = new List<HistoryItem>();

        private int _maxHistory = 300;

        public void Add(string query)
        {
            if (string.IsNullOrEmpty(query)) return;
            if (Items.Count > _maxHistory)
            {
                Items.RemoveAt(0);
            }

            if (Items.Count > 0 && Items.Last().Query == query)
            {
                Items.Last().ExecutedDateTime = DateTime.Now;
            }
            else
            {
                Items.Add(new HistoryItem
                {
                    Query = query,
                    ExecutedDateTime = DateTime.Now
                });
            }
        }
    }
}
