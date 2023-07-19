namespace FizzBuzzCommon
{
    public interface IFizzTableClient
    {
        FizzTableEntity Get(int number);

        void Upsert(int number, bool isFizz);
    }
}