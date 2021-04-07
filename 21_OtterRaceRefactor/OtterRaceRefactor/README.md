# Otter Race Refactor

Otter Race is an otter racing application for 2 to 12 racers. It works okay, as far as we know. But it's not very well designed. It's one huge chunk of code: loops, decisions, and data-tracking, all inside the `Main` method.

Your job is to refactor Otter Race to use methods and classes.

## Approach

Don't refactor all at once. Work slowly and deliberately. Change one thing at a time and confirm that the change is good by running the app.

## Priorities

Start by identifying good candidate for methods. Look for repeated code or nested looping that could be extracted to a method. Think about method inputs and outputs.

Then look for `class` candidates. What are the application concepts or distinct nouns? (Hint: one starts with an 'o'.) List them.

When you think about classes, consider which data belongs in which class. Currently, Otter Race tracks the following data:

- The chance of an accident
- A list of accident categories
- The number of racers
- The race distance
- Each racer's name
- Each racer's current distance (progress in the race)
- Each racer's current stall state - how many rounds are they stalled?
- The current "round" (yeah, I know there aren't rounds in a race)
- The winner

When we transition to classes, where does that data belong?

Once we have the data in classes, consider class behavior. What methods belong in which classes? If you already refactored into methods, decide which existing methods go where.