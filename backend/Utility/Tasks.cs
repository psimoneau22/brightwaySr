using System.Threading.Tasks;

public class TaskHelper {
    public static async Task<(T1, T2)> WhenAll<T1, T2>(Task<T1> task1, Task<T2> task2) {
        await Task.WhenAll(task1, task2);
        return (task1.Result, task2.Result);
    }
}