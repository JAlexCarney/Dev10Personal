// INTERLEAVE
const first = "B";
const second = "igStar";

// 1. Write a loop to interleave two strings to form a new string.
// To interleave, during each loop take one character from the first string and add it to the result
// and take one character from the second string and add it to the result.
// If there are no more characters available, don't add characters.
// 2. Print the result.

let result = "";
for(let i = 0; i < first.length || i < second.length; i++)
{
    if(i < first.length)
    {
        result += first[i];
    }
    if(i < second.length)
    {
        result += second[i];
    }
}
console.log(result);

// Examples
// "abc", "123" -> "a1b2c3"
// "cat", "dog" -> "cdaotg"
// "wonder", "o" -> "woonder"
// "B", "igstar" -> "Bigstar"
// "", "huh?" -> "huh?"
// "wha?", "" -> "wha?"