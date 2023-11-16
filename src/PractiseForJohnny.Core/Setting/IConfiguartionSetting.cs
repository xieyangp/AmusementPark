namespace PractiseForJohnny.Core.Setting;

public interface IConfiguartionSetting
{
}

public interface IConfiguartionSetting<TValue> : IConfiguartionSetting
{
    TValue Value { get; set; }
}