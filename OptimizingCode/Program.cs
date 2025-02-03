using OptimizingCode;

var originalImplementation = OriginalImplementation.IndexOfAnyButGsm7Char("A", 0, 1);
var binarySearchImplementation = BinarySearch.IndexOfAnyButGsm7Char("A", 0, 1);
var hashSetImplementation = HashSet.IndexOfAnyButGsm7Char("A", 0, 1);

Console.WriteLine("******** Results ********");
Console.WriteLine($"originalImplementation: {originalImplementation}");
Console.WriteLine($"binarySearchImplementation: {binarySearchImplementation}");
Console.WriteLine($"hashSetImplementation: {hashSetImplementation}");
Console.WriteLine("****************");
