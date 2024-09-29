using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Rule 1: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Scenario: Add multiple items to the queue and check the order in which they are added.
    // Expected Result: Items should be in the queue in the order they are added, regardless of priority.
    public void TestPriorityQueue_Enqueue_AddsToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1); // Low priority
        priorityQueue.Enqueue("Item2", 3); // Medium priority
        priorityQueue.Enqueue("Item3", 5); // High priority
        
        var queueRepresentation = priorityQueue.ToString();
        Assert.AreEqual("[Item1 (Pri:1), Item2 (Pri:3), Item3 (Pri:5)]", queueRepresentation);
    }

    [TestMethod]
    // Rule 2: The Dequeue function shall remove the item with the highest priority and return its value.
    // Scenario: Add multiple items with varying priorities and dequeue the highest priority item.
    // Expected Result: The highest priority item should be removed and returned.
    public void TestPriorityQueue_Dequeue_RemovesHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("MediumPriority", 3);
        priorityQueue.Enqueue("HighPriority", 5); // Highest priority

        var dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriority", dequeued); // Should dequeue the highest priority item
    }

    [TestMethod]
    // Rule 3: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Scenario: Add multiple items with the same highest priority and ensure FIFO ordering is respected.
    // Expected Result: The first added item with the highest priority should be dequeued first.
    public void TestPriorityQueue_Dequeue_RespectsFIFOForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 3); // Same priority
        priorityQueue.Enqueue("Item2", 3); // Same priority
        priorityQueue.Enqueue("Item3", 3); // Same priority
        
        var dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", dequeued); // Item1 (first added) should be dequeued first

        dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", dequeued); // Item2 (second added) should be dequeued next

        dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", dequeued); // Item3 (last added) should be dequeued last
    }

    [TestMethod]
    // Rule 4: If the queue is empty, then an error exception shall be thrown.
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    public void TestPriorityQueue_EmptyDequeue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), 
            "Expected an InvalidOperationException when dequeuing from an empty queue.");
    }
}