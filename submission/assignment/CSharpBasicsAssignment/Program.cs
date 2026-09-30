
// .csproj:
// Contains project configuration such as the target framework,
// nullable settings, implicit usings, and output type.

// Program.cs:
// Contains the main application code and program entry point.

// obj/:
// Contains intermediate files generated during the build process.

// bin/:
// Contains the final compiled output of the application.

// File-scoped namespace:
// A file-scoped namespace is written once at the top of the file.
// It removes the need to wrap the entire file inside { },
// which avoids one level of indentation.

// This project uses the classic .sln format.
// One advantage of the newer .slnx format is that it is a simpler,
// more lightweight solution format.

using CSharpBasicsAssignment;
int globalValue = 50;


RunTypesDemo();
RunValueVsReferenceDemo();
RunScopeDemo();

void RunTypesDemo()
{
    // --------------------------------------------------------
    // 1. Variables and their runtime types
    // --------------------------------------------------------
    Console.WriteLine("=== Part B — Variables, Types & Casting  ===");
    int integer = 7;
    long l = 1000000000L;
    double duo = 445.2;
    decimal dec = 23.23M;
    bool flag = true;
    char c = 'O';
    string s = "Omar";
    var vars = 22;

    Console.WriteLine("=== Variables and their runtime types ===");
    Console.WriteLine($"int: {integer}, Type: {integer.GetType()}");
    Console.WriteLine($"long: {l}, Type: {l.GetType()}");
    Console.WriteLine($"double: {duo}, Type: {duo.GetType()}");
    Console.WriteLine($"decimal: {dec}, Type: {dec.GetType()}");
    Console.WriteLine($"bool: {flag}, Type: {flag.GetType()}");
    Console.WriteLine($"char: {c}, Type: {c.GetType()}");
    Console.WriteLine($"string: {s}, Type: {s.GetType()}");
    Console.WriteLine($"var: {vars}, Type: {vars.GetType()}");
    Console.WriteLine();

    // --------------------------------------------------------
    // 2. Implicit conversion
    // --------------------------------------------------------

    int number = 50;
    long longNumber = number;

    char letter = 'A';
    int asciiValue = letter;

    Console.WriteLine("=== Implicit Conversion ===");
    Console.WriteLine($"int -> long: {longNumber}");
    Console.WriteLine($"char -> int: {asciiValue}");

    // No cast is required because these conversions are safe:
    // long can store every possible int value,
    // and char can be implicitly converted to its integer value.
    Console.WriteLine();

    // --------------------------------------------------------
    // 3. Explicit conversion
    // --------------------------------------------------------

    double originalDouble = 9.7;

    int castResult = (int)originalDouble;
    int convertResult = Convert.ToInt32(originalDouble);

    Console.WriteLine("=== Explicit Conversion ===");
    Console.WriteLine($"(int)9.7: {castResult}");
    Console.WriteLine($"Convert.ToInt32(9.7): {convertResult}");

    // (int) removes the decimal part so 9.7 becomes 9.
    // Convert.ToInt32 rounds to the nearest integer, so 9.7 becomes 10.

    Console.WriteLine();

    // --------------------------------------------------------
    // 4. Integer division trap
    // --------------------------------------------------------

    int integerDivision = 5 / 2;
    double doubleDivision = 5.0 / 2;

    Console.WriteLine("=== Integer Division ===");
    Console.WriteLine($"5 / 2 = {integerDivision}");
    Console.WriteLine($"5.0 / 2 = {doubleDivision}");

    // int / int performs integer division and removes the decimal part,
    // while using a double operand produces a floating-point result.

    Console.WriteLine();

    // --------------------------------------------------------
    // 5. Boxing and unboxing
    // --------------------------------------------------------

    int originalNumber = 100;

    object boxedNumber = originalNumber;

    Console.WriteLine("=== Boxing / Unboxing ===");
    Console.WriteLine($"After boxing: {boxedNumber}");

    int unboxedNumber = (int)boxedNumber;

    Console.WriteLine($"After unboxing: {unboxedNumber}");

    // Boxing copies the value type into an object on the heap.
    // Unboxing extracts the value back into the value type.

    Console.WriteLine();

    // --------------------------------------------------------
    // 6. Parsing
    // --------------------------------------------------------

    string validInput = "42";
    int parsedNumber = int.Parse(validInput);

    Console.WriteLine("=== Parsing ===");
    Console.WriteLine($"int.Parse(\"42\"): {parsedNumber}");

    string invalidInput = "abc";

    bool success = int.TryParse(invalidInput, out int result);

    Console.WriteLine($"int.TryParse(\"abc\") result: {success}");

    if (!success)
    {
        Console.WriteLine("Parsing failed, but no exception was thrown.");
    }

    Console.WriteLine();

    // --------------------------------------------------------
    // 7. float -> decimal
    // --------------------------------------------------------

    float floatValue = 12.5f;

    // This does NOT compile because float -> decimal
    // is not an implicit conversion:
    //
    // decimal wrongValue = floatValue;

    decimal correctValue = (decimal)floatValue;

    Console.WriteLine("=== float -> decimal ===");
    Console.WriteLine($"float value: {floatValue}");
    Console.WriteLine($"After explicit cast: {correctValue}");

    // The compiler requires an explicit cast because converting
    // from float to decimal can involve a possible loss/change
    // in representation, so C# does not allow it implicitly.
    Console.WriteLine();

}

void RunValueVsReferenceDemo()
{
    // --------------------------------------------------------
    // Experiment 1 — Struct copy semantics
    // --------------------------------------------------------
    Console.WriteLine("=== Part C — Value vs. Reference Types  ===");
    Console.WriteLine("=== Experiment 1: Struct Copy ===");

    Point p1 = new Point
    {
        X = 1,
        Y = 2
    };

    Point p2 = p1;

    p2.X = 99;

    Console.WriteLine($"p1.X = {p1.X}");
    Console.WriteLine($"p2.X = {p2.X}");

    // Point is a value type.
    // Assigning p1 to p2 copies the entire value,
    // so p1 and p2 are independent copies.

    Console.WriteLine();

    // --------------------------------------------------------
    // Experiment 2 — Class reference semantics
    // --------------------------------------------------------

    Console.WriteLine("=== Experiment 2: Class Reference ===");

    Order o1 = new Order
    {
        OrderId = 1,
        CustomerName = "Ali",
        Quantity = 3,
        UnitPrice = 100m,
        TotalPrice = 0m,
        IsPaid = false,
        DiscountPercent = 10,
        ShippingCity = "Cairo",
        Priority = 'H',
        ItemCode = 123456789L
    };

    o1.CalculateTotal();

    Order o2 = o1;

    o2.IsPaid = true;

    Console.WriteLine($"o1.IsPaid = {o1.IsPaid}");
    Console.WriteLine($"o2.IsPaid = {o2.IsPaid}");

    // Order is a reference type.
    // Assigning o1 to o2 copies the reference to the same
    // heap object, so changing the object through o2 also
    // changes what is seen through o1.

    Console.WriteLine();


    // --------------------------------------------------------
    // object reference
    // --------------------------------------------------------

    object boxedOrder = o1;

    // No boxing happens here because Order is a reference type.
    // boxedOrder simply stores the same reference to the Order object.

    Order o3 = (Order)boxedOrder;

    Console.WriteLine(
        $"ReferenceEquals(o1, o3): {object.ReferenceEquals(o1, o3)}"
    );

    Console.WriteLine();

    // o2 and o1 point to the same Order object,
    // so the summary reflects the change made through o2.

    Console.WriteLine("=== Order Summary ===");
    o2.PrintSummary();

    Console.WriteLine();

    // --------------------------------------------------------
    // Explanation
    // --------------------------------------------------------

    Console.WriteLine("=== Explanation ===");

    Console.WriteLine(
        "A struct is a value type, so assigning it copies its value."
    );

    Console.WriteLine(
        "A class is a reference type, so assigning it copies the reference to the same object."
    );

    Console.WriteLine(
        "The Order object is stored on the heap, while variables such as o1 and o2 hold references to it."
    );

    Console.WriteLine(
        "Storing a reference type in an object variable does not create a new object; it stores the same reference."
    );
    Console.WriteLine();
}

void RunScopeDemo()
{
    Console.WriteLine("=== PART D: Scope & Operators ===");
    Console.WriteLine();

    // --------------------------------------------------------
    // D1 — Scope
    // --------------------------------------------------------

    Console.WriteLine("=== D1: Scope ===");

    // Field scope:
    // globalValue is accessible from different methods
    // because it is declared at the top level of the file.
    Console.WriteLine($"Field value from RunScopeDemo: {globalValue}");

    ShowFieldValue();

    // Method scope:
    // localValue exists only inside this method.
    int localValue = 100;

    Console.WriteLine($"Method local variable: {localValue}");

    // localValue cannot be accessed from another method.

    // Block scope:
    for (int i = 0; i < 3; i++)
    {
        int insideLoop = i * 10;

        Console.WriteLine(
            $"Loop variable i = {i}, insideLoop = {insideLoop}"
        );
    }

    // The following would NOT compile because both i and
    // insideLoop only exist inside the for-loop block:
    //
    // Console.WriteLine(i);
    // Console.WriteLine(insideLoop);

    // This produces a compile error because the variables
    // are outside their scope after the loop ends.

    Console.WriteLine();

    // --------------------------------------------------------
    // D2 — Compound Assignment Operators
    // --------------------------------------------------------

    Console.WriteLine("=== D2: Compound Assignment ===");

    int total = 100;

    total += 5;
    Console.WriteLine($"After += 5: {total}");

    total -= 10;
    Console.WriteLine($"After -= 10: {total}");

    total *= 2;
    Console.WriteLine($"After *= 2: {total}");

    total /= 5;
    Console.WriteLine($"After /= 5: {total}");

    total %= 7;
    Console.WriteLine($"After %= 7: {total}");

    // Compound assignment:
    // total += 5;
    //
    // is equivalent to:
    //
    // total = total + 5;

    Console.WriteLine();

    // --------------------------------------------------------
    // D3 — Bitwise Operators
    // --------------------------------------------------------

    Console.WriteLine("=== D3: Bitwise Operators ===");

    int a = 12;
    int b = 10;

    int andResult = a & b;
    int orResult = a | b;
    int xorResult = a ^ b;

    Console.WriteLine($"a = {a}  (binary: 1100)");
    Console.WriteLine($"b = {b}  (binary: 1010)");

    Console.WriteLine($"a & b = {andResult}");
    Console.WriteLine($"a | b = {orResult}");
    Console.WriteLine($"a ^ b = {xorResult}");

    Console.WriteLine();
}

void ShowFieldValue()
{
    // The field can also be accessed from another method.
    Console.WriteLine($"Field value from ShowFieldValue: {globalValue}");
}


int FindSingleNumber(int[] nums)
{   
    int output = nums[0];

    for (int i = 1; i < nums.Length; i++)
    {
        // XOR cancels out numbers that appear twice because x ^ x = 0.
        // Since x ^ 0 = x, only the number that appears once remains.
        output = output ^ nums[i];
    }

    return output;
}

Console.WriteLine("=== PART F: LeetCode 136 - Single Number ===");

int[] nums1 = { 4, 1, 2, 1, 2 };
Console.WriteLine($"Result 1: {FindSingleNumber(nums1)}");

int[] nums2 = { 2, 2, 1 };
Console.WriteLine($"Result 2: {FindSingleNumber(nums2)}");