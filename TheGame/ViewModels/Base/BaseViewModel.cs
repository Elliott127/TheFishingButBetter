using CommunityToolkit.Mvvm.ComponentModel;

namespace Game.ViewModels.Base;

public abstract class ViewModelBase : ObservableObject
{
    protected ViewModelBase()
    {

    }

    public virtual Task InitialiseAsync(object navigationData)
    {
        return Task.FromResult(false);
    }
}