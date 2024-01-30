namespace AsyncProgrammingNonBlockingCPUExample;

public class StockMarketTechnicalAnalysisData
{
    public StockMarketTechnicalAnalysisData(string stockSymbol, DateTime startDateTime, DateTime endDateTime)
    {
        // Call remote server to get analysis data
    }

    public decimal[] GetOpeningPrices()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(GetOpeningPrices)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] GetClosingPrices()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(GetClosingPrices)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] GetPriceHighs()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(GetPriceHighs)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] GetPriceLows()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(GetPriceLows)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] CalculteStochastics()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(CalculteStochastics)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(10000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] CalculateFastMovingAverage()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(CalculateFastMovingAverage)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(6000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] CalculateSlowMovingAverage()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(CalculateSlowMovingAverage)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(7000);
        data = new decimal[]{};
        return data;
    }
    public decimal[] CalculateUpperBoundBollingerBand()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(GetOpeningPrices)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(5000);
        data = new decimal[]{};
        return data;
    }
    
    public decimal[] CalculateLowerBoundBollingerBand()
    {
        decimal[] data;
        Console.WriteLine($"Method name: {nameof(CalculateLowerBoundBollingerBand)}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(5000);
        data = new decimal[]{};
        return data;
    }
}