﻿/* Hardware Warehouse Management System */

using API;

class Program
{
    private const int BatchSize = 5;
    public static void Main(string[] args)
    {
        CustomQueue<HardwareItem> hardwareItemQueue = new CustomQueue<HardwareItem>();
        hardwareItemQueue.CustomQueueEvent += CustomQueueOnCustomQueueEvent;
        Thread.Sleep(2000);

        hardwareItemQueue.AddItem(new Drill
            { Id = 1, Name = "Drill 1", Type = "Drill", UnitValue = 20.00m, Quantity = 10 });
        Thread.Sleep(1000);
        hardwareItemQueue.AddItem(new Drill
            { Id = 2, Name = "Drill 2", Type = "Drill", UnitValue = 30.00m, Quantity = 20 });
        Thread.Sleep(2000);
        hardwareItemQueue.AddItem(new Ladder
            { Id = 3, Name = "Ladder 1", Type = "Ladder", UnitValue = 100.00m, Quantity = 5 });
        Thread.Sleep(1000);
        hardwareItemQueue.AddItem(new Hammer
            { Id = 4, Name = "Hammer 1", Type = "Hammer", UnitValue = 10.00m, Quantity = 80 });
        Thread.Sleep(3000);
        hardwareItemQueue.AddItem(new PaintBrush
            { Id = 5, Name = "Paint Brush 1", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
        Thread.Sleep(3000);
        hardwareItemQueue.AddItem(new PaintBrush
            { Id = 6, Name = "Paint Brush 2", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
        Thread.Sleep(3000);
        hardwareItemQueue.AddItem(new PaintBrush
            { Id = 7, Name = "Paint Brush 3", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
        Thread.Sleep(3000);
        hardwareItemQueue.AddItem(new Hammer
            { Id = 8, Name = "Hammer 2", Type = "Hammer", UnitValue = 11.00m, Quantity = 80 });
        Thread.Sleep(3000);
        hardwareItemQueue.AddItem(new Hammer
            { Id = 9, Name = "Hammer 3", Type = "Hammer", UnitValue = 13.00m, Quantity = 80 });
        Thread.Sleep(3000);
        hardwareItemQueue.AddItem(new Hammer
            { Id = 10, Name = "Hammer 4", Type = "Hammer", UnitValue = 14.00m, Quantity = 80 });
        Thread.Sleep(3000);

        Console.ReadKey();
    }

    private static void ProcessItems(CustomQueue<HardwareItem> customQueue)
    {
        while (customQueue.QueueLength > 0)
        {
            Thread.Sleep(3000);
            HardwareItem hardwareItem = customQueue.GetItem();
        }
    }
    private static void CustomQueueOnCustomQueueEvent(CustomQueue<HardwareItem> sender, QueueEventArgs eventArgs)
    {
        Console.Clear();
        if (sender.QueueLength > 0)
        {
            Console.WriteLine(eventArgs);
            Console.WriteLine();
            WriteValuesInQueueToScreen(sender);
            if (sender.QueueLength == BatchSize)
            {
                ProcessItems(sender);
            }
        }
        else
        {
            Console.WriteLine($"All items have been processed ");
        }
    }

    private static void WriteValuesInQueueToScreen(CustomQueue<HardwareItem> hardwareItems)
    {
        foreach (var hardwareItem in hardwareItems)
        {
            Console.WriteLine(
                $"{hardwareItem.Id,-6}{hardwareItem.Name,-15}{hardwareItem.Type,-20}{hardwareItem.Quantity,10}{hardwareItem.UnitValue,10}");
        }
    }
}

public abstract class HardwareItem : IEntityPrimaryProperties, IEntityAdditionalProperties
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public decimal UnitValue { get; set; }
}

public interface IDrill
{
    // Custom drill property
    string DrillBrandName { get; set; }
}

public class Drill : HardwareItem, IDrill
{
    public string DrillBrandName { get; set; }
}

public interface ILadder
{
    // Custom ladder property
    string LadderBrandName { get; set; }
}

public class Ladder : HardwareItem, ILadder
{
    public string LadderBrandName { get; set; }
}

public interface IPaintBrush
{
    string PaintBrushBrandName { get; set; }
}

public class PaintBrush : HardwareItem, IPaintBrush
{
    public string PaintBrushBrandName { get; set; }
}

public interface IHammer
{
    string HammerBrandName { get; set; }
}

public class Hammer : HardwareItem, IHammer
{
    public string HammerBrandName { get; set; }
}