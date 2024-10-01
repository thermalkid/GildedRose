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
3. Refactor part 2 - implement appropriate design pattern. Options include:-
* __Factory__:  Define ItemFactory and concrete implementations of AgedBrie, Normal etc : Item, override UpdateQuality
* __Decorator__: Create AgedBrieDecorator etc, use decorator to define UpdateQuality
* __Template__:  Concrete implementations of each flavour of item. Override CalculateQuality
* __Strategy__: add a QualityUpdateStrategy when constructing items. Will mean a change to the Item class. 

## Update 10/1 - Actual Next Steps
Always read the instructions! 

We can't directly modify Item.cs (fair enough), but also can't modify the Items collection (darned Goblins). 
This rules any behavoiral patterns that construct objects at initialisation, and limits our options. 

UpdateQuality is the main area of change and is a free hit for us. Let's do a few things:-

1. Review the current if/else hell, and ensure we're covering each condition with a test.
1. Refactor the if/else hell into something more manageable.
2. Look for common themes (e.g Quality >= 0, "X" varieties of items).

At every point we need to ensure our unit tests are passing. 
Let's exclude the two failing tests (Sulfuras_Quality_Is_Always_80 & Quality_Increases_For_Brie) for now. 
The ApprovalTest acts as our catch-all at least for now.
 








