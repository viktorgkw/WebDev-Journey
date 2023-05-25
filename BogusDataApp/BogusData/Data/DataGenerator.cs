namespace BogusData.Data;

using System.Reflection.Metadata.Ecma335;
using Bogus;

public class DataGenerator
{
    private Faker<AccountModel> fakeAccountModel;

    public DataGenerator()
    {
        Randomizer.Seed = new Random(123);

        fakeAccountModel = new Faker<AccountModel>()
            .RuleFor(acc => acc.Id, f => f.Random.Guid().ToString())
            .RuleFor(acc => acc.UserName, f => f.Name.FullName())
            .RuleFor(acc => acc.Email, (f, u) => f.Internet.Email(u.UserName))
            .RuleFor(acc => acc.PhoneNumber, f => f.Phone.PhoneNumber("+359 {## ### ####}"))
            .RuleFor(acc => acc.Password, f => f.Internet.Password())
            .RuleFor(acc => acc.IsAdult, f => f.Random.Bool())
            .RuleFor(acc => acc.AccountQuality, f => f.PickRandom<AccountQuality>());
    }

    public AccountModel GenerateAccount()
    {
        return fakeAccountModel.Generate();
    }

    public IEnumerable<AccountModel> GenerateAccounts()
        => fakeAccountModel.GenerateForever();
}
