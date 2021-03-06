
// ======== Pattern Matching ========
// Match..with.. is a supercharged case/switch statement.
// syntax is "match Expr with" 

let simplePatternMatch x =
   match x with
    | "a" -> printfn "x is a"
    | "b" -> printfn "x is b"
    | _ -> printfn "x is something else"   // underscore matches anything

// try it
simplePatternMatch "a"

// You can do a shorthand for patter matching
// this is exactly the same as above. 
// Notice you lose the reference to the input param. So if you need that dont do this
let simpleShorthandPatternMatch = function
    | "a" -> printfn "x is a"
    | "b" -> printfn "x is b"
    | _ -> printfn "x is something else"   // underscore matches anything


// purely functional loop
let rec functionalLoop action list = 
    match list with
    | [x] -> action x
    | first::rest -> 
            action first
            functionalLoop action rest

// run it
[1..10] |> functionalLoop (printfn "%i")

// Some(..) and None are roughly analogous to Nullable wrappers
let invalidValue = None
let validValue = Some 6

// In this example, match..with matches the "Some" and the "None",
// and also unpacks the value in the "Some" at the same time.
let optionPatternMatch input =
   match input with
    | Some i when i % 2 = 0 -> printfn "input is an even int=%d" i
    | Some i -> printfn "input is an int=%d" i
    | None -> printfn "input is missing"

optionPatternMatch validValue
optionPatternMatch invalidValue


// Tuple types are pairs, triples, etc. Tuples use commas.
let twoTuple = 1, 2 

// often you put parentheses around them
let threeTuple = ("a", 2, true)

// deconstruct tuple again
let aString, anInt, aBool = threeTuple 

let whichIsBigger aTuple =
    match aTuple with
    | 1, 2 -> printfn "1 is less than 2"                     // matches where first tuple is 1 and second element is 2
    | x, y when x > y -> printfn "%d is greater than %d" x y // deconstruct tuple into variables x and y - but only matches when x > y
    | x, y when x < y -> printfn "%d is less than %d" x y
    | x, y -> printfn "%d equals %d" x y

let firstBiggerThanSecond (x, y) = x > y

let whichIsBigger2 aTuple =
    match firstBiggerThanSecond aTuple  with            // Use function in our match with. 
    | true -> printfn "First is greater than second"
    | false -> printfn "First is NOT greater than second"

whichIsBigger2 ("hello","bob")

let patternMatchMultiple number =
    match number * 2, number + 2 with
    | 4, 2 -> printfn "math is broken"
    | 2, 3 -> printfn "number was 1"
    | _ -> printfn "could be anything"

/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////// Fizz Buzz version 2 /////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////

// let fizzbuzz2 numbers = 
// implement me with patternmatching and tuples

// run this
// fizzbuzz2 [1..30]



// quicksort
let rec quicksort = function
   | [] -> []                         
   | first::rest -> 
        let smaller,larger = List.partition ((>=) first) rest 
        List.concat [quicksort smaller; [first]; quicksort larger]

quicksort [5;123;52;63;721;1;61;78;34;2;663]