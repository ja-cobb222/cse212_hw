public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Define inputs: 'number' (starting number) and 'length' (number of multiples).
    
        // Step 2: Create an array to hold the multiples.
        double[] multiples = new double[length];
    
        // Step 3: Loop to populate the array with multiples of 'number'.
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple and store it in the array.
            multiples[i] = number * (i + 1); // Multiples start from number * 1
        }

        // Step 4: Return the populated array of multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Define inputs: 'data' (list to rotate) and 'amount' (number of positions to rotate).
        
        // Step 2: Handle rotation amount, ensuring it's within the bounds of the list size.
        int length = data.Count;
        amount = amount % length; // Handle cases where amount > length
        
        // Step 3: Identify the split point for the rotation.
        int splitPoint = length - amount;
        
        // Step 4: Slice the list into two parts.
        List<int> rightPart = data.GetRange(splitPoint, amount);
        List<int> leftPart = data.GetRange(0, splitPoint);
        
        // Step 5: Clear the original list and add the slices back in the new order.
        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
