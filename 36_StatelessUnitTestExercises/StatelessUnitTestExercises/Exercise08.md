# Exercise08

1. Add a new class to the project named `StringMethods`.
2. Add a method
    ```
    Name: StartsWithDayOfWeek
    Inputs: string
    Output: bool
    Description: return true if the parameters starts with a day of week abbreviation:
    Mon, Tues, Weds, Thurs, Fri, Sat, Sun
    or false if it doesn't
    ```
3. Create tests for StartsWithDayOfWeek and confirm the method is correct.
4. Add a method
    ```
    Name: ContainsDayOfWeek
    Inputs: string
    Output: bool
    Description: return true if a day of week abbreviation occurs anywhere in the string
    or false if it doesn't
    ```
5. Create tests for ContainsDayOfWeek and confirm the method is correct.
6. Add a method (stretch goal)
    ```
    Name: RemoveVowelFromBetweenX
    Inputs: string
    Output: string
    Description: Look for the pattern "x[any single vowel]x" in a string. If you find it, remove the vowel.
    Return a new string with all the vowels between x removed.
    Examples:
    xox -> xx
    onexexx -> onexxx
    xerrex -> xerrex
    xuxxuxxux -> xxxxxx
    xaeioux -> xaeioux
    ```
 7. Create tests for RemoveVowelFromBetweenX and confirm the method is correct.