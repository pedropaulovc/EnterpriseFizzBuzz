namespace FizzBuzzCommon
{
    public interface IBuzzTableClient
    {
        BuzzTableEntity Get(int number);

        void Upsert(int number, bool isFizz);
    }
}