# BetterLogisticsStations

This mod provides configurations to adjust the number of slots (also called the MaxItemKinds) and the capacity per item (also called the MaxItemCount) of the planetary and interstellar logistics stations.

![A screenshot of a planetary logistics station with 6 slots and 10000 capacity per item (this is not the default value, this is just for demonstration purposes)](/screenshot.png)

By default the capacities are the same as in Vanilla DSP, but the slot count is set to 6 for both the planetary and the interstellar logistics stations. Also, the slot count should *not* be set to more than 6, because the UI is not equipped to handle that many slots (I might try to patch this later, so slot counts up to 12 could be used).

When loading the mod, only newly placed stations will have the new slot counts, but all stations will have the new capacity. Reduce the capacity on existing save files at your own risk (you might lose items)!

## TODO / Ideas for the future

- Patch the UI so that more than 6 slots are possible
- Patch a whole lot of stuff to make the capacity scale with the stack size of the selected item. For example a logistics station  would then have 10 times the capacity for foundations compared to inserters. This might even be a good nerf to many items (to counteract the slot count buff) if a capacity of 5000 for planetary logistics stations and 10000 for interstellar logistics stations is selected for items with stack size 200. That would mean the planetary logistics station could effectively hold just 25 stacks of each item (and the interstellar logistics station could hold 50 stacks).
