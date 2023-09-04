
/*
Please write a program that generates a list of 10,000 numbers in random order each timeit is run.
Each number in the list must be unique and be between 1 and 10,000 (inclusive).

Violent Solution:
    while length of randomNumbers < 10000:
        randomNumber = generateRandomNumber(1, 10000)
        if randomNumber is not in randomNumbers:
            add randomNumber to randomNumbers
A loop-based method can be used to generate unique random numbers until a specified number
is reached. In the worst case scenario, this may require multiple attempts to generate unique numbers.
Therefore, the time complexity of this algorithm can be approximated as O(n^2).

Optimized Solution:
    Fisher–Yates shuffle is an algorithm to generate random permutations:
    for i from n-1 down to 1 do
    j = random integer such that 0 <= j <= i
        exchange a[j] and a[i]
This implementation will be faster because it doesn't need to check each time if the list contains numbers.
Instead, it first creates arrays containing all possible numbers, and then randomly sorts the arrays using
the Fisher-Yates shuffling algorithm to ensure that the generated numbers are unique.
This will increase the speed of generation, especially with a large number of random numbers.

drawbacks：
the generated array is immutable, if you want it to be able to add, remote or change,
you have to create a new array.

improve method:
we can use List<int>, which is dynamically sized and can be adjusted as needed,
making it more suitable for situations where elements need to be added or removed dynamically at runtime.
however, List<int> is dynamically sized, it will take up more memory stored in memory.

*/


//Fisher–Yates shuffle algorithm Solution
class Program
{
    static void Main()
    {
        int[] randomNumbers = GenerateRandomNumbers(1, 10000);

        foreach (int num in randomNumbers)
        {
            Console.WriteLine(num);
        }
    }

    // Function to generate unique random numbers
    static int[] GenerateRandomNumbers(int min, int max)
    {
        // Create an array containing all possible numbers in the specified range
        int[] randomNumbers = new int[max - min + 1];
        for (int i = min; i <= max; i++)
        {
            randomNumbers[i - min] = i;
        }

        // Shuffle the array using Fisher-Yates shuffle algorithm
        Random rand = new Random();
        int n = randomNumbers.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            int temp = randomNumbers[i];
            randomNumbers[i] = randomNumbers[j];
            randomNumbers[j] = temp;
        }

        return randomNumbers;
    }
}



//improve method

//class Program
//{
//    static void Main()
//    {
//        //use List<int>
//        List<int> randomNumbers = GenerateRandomNumbers(1, 10000);

//        foreach (int num in randomNumbers)
//        {
//            Console.WriteLine(num);
//        }

//        // Adding more elements to the generated list
//        randomNumbers.Add(10001);


//        Console.WriteLine("Added two additional elements to the list:");
//        foreach (int num in randomNumbers)
//        {
//            Console.WriteLine(num);
//        }
//    }

//    static List<int> GenerateRandomNumbers(int min, int max)
//    {
//        List<int> randomNumbers = new List<int>();
//        Random rand = new Random();

//        for (int i = min; i <= max; i++)
//        {
//            randomNumbers.Add(i);
//        }

//        // Using the Fisher-Yates algorithm to shuffle the list randomly
//        int n = randomNumbers.Count;
//        for (int i = n - 1; i > 0; i--)
//        {
//            int j = rand.Next(0, i + 1);
//            int temp = randomNumbers[i];
//            randomNumbers[i] = randomNumbers[j];
//            randomNumbers[j] = temp;
//        }

//        return randomNumbers;
//    }
//}
