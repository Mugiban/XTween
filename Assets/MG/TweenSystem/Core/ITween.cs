namespace MG.TweenSystem
{
    public interface ITween
    {
        void OnUpdate(float easedTime);

        void Cancel();
    }
}