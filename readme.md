# The Gilded Rose Refactoring Kata

## Initial Thoughts

* Incomplete unit test coverage
* UpdateQuality is hard to follow, difficult to extend
* Missing functionality for __"Conjured"__ items
* Item is closed for modification. It maintains the current state only and is updated on every UpdateQuality cycle. 

References: https://app.pluralsight.com/ilx/video-courses/8b818464-7d56-4f32-a307-04c7049540e1

## Next Steps
1. Complete missing unit tests
2. Refactor part 1 - Code organisation: introduce GildedRose.Common, move GildedRose.cs & Item.cs
3. Refactor part 2 - implement approrpiate design pattern. Options include:-
* __Factory__:  Define ItemFactory and concrete implementations of AgedBrie, Normal etc : Item, override UpdateQuality
* __Decorator__: Create AgedBrieDecorator etc, use decorator to define UpdateQuality
* __Template__:  Concrete implementations of each flavour of item. Override CalculateQuality
* __Strategy__: add a QualityUpdateStrategy when constructing items. Will mean a change to the Item class. 









